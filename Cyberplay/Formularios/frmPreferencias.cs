using Cyberplay.Core;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmPreferencias : Form
    {
        private PersistenciaConfiguracion persistenciaConfiguracion =
        new PersistenciaConfiguracion();

        public frmPreferencias()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

            CargarCategorias();
            CargarTiposEquipo();

            CargarEstaciones();
            cbMultijugador_CheckedChanged(null, null);
            nudTolerancia.Value = SesionSistema.Configuracion.ToleranciaMinutos;
            lblCantidad.Text = "Asignados";
            nudCantidad.Enabled = false;
        }

        private void CargarCategorias()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvCategorias.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (string categoria
                in SesionSistema
                    .Configuracion
                    .Categorias
                    .OrderBy(
                        c =>
                        c))
            {
                dgvCategorias.Rows.Add(
                    categoria);
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            // =====================
            // NOMBRE
            // =====================

            string categoria =
                tbNombre.Text
                .Trim();

            // =====================
            // VALIDAR
            // =====================

            if (string.IsNullOrWhiteSpace(
                categoria))
            {
                MessageBox.Show(
                    "Ingrese una categoría.");

                return;
            }

            // =====================
            // EXISTE
            // =====================

            if (SesionSistema
                .Configuracion
                .Categorias
                .Contains(categoria))
            {
                MessageBox.Show(
                    "La categoría ya existe.");

                return;
            }

            // =====================
            // AGREGAR
            // =====================

            SesionSistema
                .Configuracion
                .Categorias
                .Add(categoria);

            SesionSistema
                .Configuracion
                .Categorias =
                    SesionSistema
                    .Configuracion
                    .Categorias
                    .OrderBy(
                        c =>
                        c)
                    .ToList();

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // LIMPIAR
            // =====================

            tbNombre.Clear();

            // =====================
            // RECARGAR
            // =====================

            CargarCategorias();
        }

        private void CargarTiposEquipo()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvTiposEquipo
                .Rows
                .Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (
                TipoEquipoConfiguracion tipo
                in SesionSistema
                    .Configuracion
                    .TiposEquipo)
            {
                dgvTiposEquipo
                    .Rows
                    .Add(
                        tipo.Nombre,

                        ObtenerCantidadAsignada(
                            tipo.Nombre),

                        tipo.TarifaLibre,

                        tipo.CiclosPorHora,

                        ObtenerCostoCiclo(
                            tipo),

                        tipo.UsaTarifasMultijugador
                            ? "Sí"
                            : "No",

                        tipo.TarifaM2,

                        tipo.TarifaM3,

                        tipo.TarifaM4);
            }
        }

        private int ObtenerCantidadAsignada(
            string tipoEquipo)
        {
            return SesionSistema
                .Configuracion
                .Estaciones
                .Count(
                    e =>
                    e.Activa
                    && e.TipoEquipo == tipoEquipo);
        }

        private string ObtenerCostoCiclo(
            TipoEquipoConfiguracion tipo)
        {
            int ciclos =
                tipo.CiclosPorHora > 0
                ? tipo.CiclosPorHora
                : ObtenerCiclosPorDefecto(
                    tipo);

            if (!tipo.UsaTarifasMultijugador)
            {
                return (tipo.TarifaLibre / ciclos)
                    .ToString("0.00");
            }

            return "M2 "
                   + (tipo.TarifaM2 / ciclos).ToString("0.00")
                   + " / M3 "
                   + (tipo.TarifaM3 / ciclos).ToString("0.00")
                   + " / M4 "
                   + (tipo.TarifaM4 / ciclos).ToString("0.00");
        }

        private int ObtenerCiclosPorDefecto(
            TipoEquipoConfiguracion tipo)
        {
            return tipo.UsaTarifasMultijugador
                   ? 4
                   : 3;
        }
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvCategorias.CurrentRow
                == null)
            {
                return;
            }

            // =====================
            // CATEGORIA
            // =====================

            string categoria =
                dgvCategorias
                .CurrentRow
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // ELIMINAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Eliminar la categoría "
                    + categoria
                    + "?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            SesionSistema
                .Configuracion
                .Categorias
                .Remove(categoria);

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // RECARGAR
            // =====================

            CargarCategorias();
        }

        private void cbMultijugador_CheckedChanged(object sender, EventArgs e)
        {
            bool multi =
        cbMultijugador.Checked;

            nudM2.Enabled = multi;

            nudM3.Enabled = multi;

            nudM4.Enabled = multi;

            nudLibre.Enabled = !multi;
        }

        private void btnAgregarTipoEquipo_Click(object sender, EventArgs e)
        {
            // =====================
            // NOMBRE
            // =====================

            string nombre =
                tbNombreEquipo.Text
                .Trim();

            // =====================
            // VALIDAR
            // =====================

            if (string.IsNullOrWhiteSpace(
                nombre))
            {
                MessageBox.Show(
                    "Ingrese un nombre.");

                return;
            }

            // =====================
            // EXISTE
            // =====================

            bool existe =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .Any(
                    t =>
                    t.Nombre
                    .Equals(
                        nombre,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (existe)
            {
                MessageBox.Show(
                    "El tipo equipo ya existe.");

                return;
            }

            // =====================
            // CREAR
            // =====================

            TipoEquipoConfiguracion
                tipo =
                    new TipoEquipoConfiguracion();

            tipo.Nombre =
                nombre;

            tipo.Cantidad =
                0;

            tipo.UsaTarifasMultijugador =
                cbMultijugador.Checked;

            tipo.CiclosPorHora =
                (int)nudCiclos.Value;

            AplicarColoresPorDefecto(
                tipo);

            // =====================
            // LIBRE
            // =====================

            if (!tipo
                .UsaTarifasMultijugador)
            {
                tipo.TarifaLibre =
                    nudLibre.Value;
            }

            // =====================
            // MULTIJUGADOR
            // =====================

            else
            {
                tipo.TarifaM2 =
                    nudM2.Value;

                tipo.TarifaM3 =
                    nudM3.Value;

                tipo.TarifaM4 =
                    nudM4.Value;
            }

            AplicarColoresPorDefecto(
                tipo);

            // =====================
            // AGREGAR
            // =====================

            SesionSistema
                .Configuracion
                .TiposEquipo
                .Add(tipo);

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // RECARGAR
            // =====================

            CargarTiposEquipo();

            // =====================
            // LIMPIAR
            // =====================

            tbNombreEquipo.Clear();

            nudCantidad.Value = 0;

            nudCiclos.Value = 4;

            nudLibre.Value = 0;

            nudM2.Value = 0;

            nudM3.Value = 0;

            nudM4.Value = 0;
        }

        private void dgvTiposEquipo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvTiposEquipo.CurrentRow
                == null)
            {
                return;
            }

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                dgvTiposEquipo
                .CurrentRow
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR
            // =====================

            TipoEquipoConfiguracion tipo =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .FirstOrDefault(
                    t =>
                    t.Nombre
                    == nombre);

            if (tipo == null)
            {
                return;
            }

            // =====================
            // CARGAR
            // =====================

            tbNombreEquipo.Text =
                tipo.Nombre;

            nudCantidad.Value =
                ObtenerCantidadAsignada(
                    tipo.Nombre);

            nudCiclos.Value =
                tipo.CiclosPorHora > 0
                ? tipo.CiclosPorHora
                : ObtenerCiclosPorDefecto(
                    tipo);

            cbMultijugador.Checked =
                tipo
                .UsaTarifasMultijugador;

            nudLibre.Value =
                tipo.TarifaLibre;

            nudM2.Value =
                tipo.TarifaM2;

            nudM3.Value =
                tipo.TarifaM3;

            nudM4.Value =
                tipo.TarifaM4;
        }

        private void btnEditarTipoEquipo_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvTiposEquipo.CurrentRow
                == null)
            {
                return;
            }

            // =====================
            // NOMBRE ORIGINAL
            // =====================

            string nombreOriginal =
                dgvTiposEquipo
                .CurrentRow
                .Cells[0]
                .Value
                .ToString();

            string nombreNuevo =
                tbNombreEquipo.Text
                .Trim();

            if (string.IsNullOrWhiteSpace(
                nombreNuevo))
            {
                MessageBox.Show(
                    "Ingrese un nombre.");

                return;
            }

            bool existe =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .Any(
                    t =>
                    t.Nombre != nombreOriginal
                    && t.Nombre.Equals(
                        nombreNuevo,
                        StringComparison.OrdinalIgnoreCase));

            if (existe)
            {
                MessageBox.Show(
                    "El tipo equipo ya existe.");

                return;
            }

            // =====================
            // BUSCAR
            // =====================

            TipoEquipoConfiguracion tipo =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .FirstOrDefault(
                    t =>
                    t.Nombre
                    == nombreOriginal);

            if (tipo == null)
            {
                return;
            }

            // =====================
            // ACTUALIZAR
            // =====================

            tipo.Nombre =
                nombreNuevo;

            tipo.Cantidad =
                ObtenerCantidadAsignada(
                    nombreOriginal);

            tipo.UsaTarifasMultijugador =
                cbMultijugador.Checked;

            tipo.CiclosPorHora =
                (int)nudCiclos.Value;

            // =====================
            // LIBRE
            // =====================

            if (!tipo
                .UsaTarifasMultijugador)
            {
                tipo.TarifaLibre =
                    nudLibre.Value;

                tipo.TarifaM2 = 0;

                tipo.TarifaM3 = 0;

                tipo.TarifaM4 = 0;
            }

            // =====================
            // MULTIJUGADOR
            // =====================

            else
            {
                tipo.TarifaLibre = 0;

                tipo.TarifaM2 =
                    nudM2.Value;

                tipo.TarifaM3 =
                    nudM3.Value;

                tipo.TarifaM4 =
                    nudM4.Value;
            }

            if (nombreNuevo != nombreOriginal)
            {
                foreach (EstacionConfiguracion estacion
                    in SesionSistema
                        .Configuracion
                        .Estaciones
                        .Where(
                            estacionConfig =>
                            estacionConfig.TipoEquipo == nombreOriginal))
                {
                    estacion.TipoEquipo =
                        nombreNuevo;
                }
            }

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // RECARGAR
            // =====================

            CargarTiposEquipo();

            CargarEstaciones();

            MessageBox.Show(
                "Tipo equipo actualizado.");
        }

        private void btnEliminarTipoEquipo_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvTiposEquipo.CurrentRow
                == null)
            {
                return;
            }

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                dgvTiposEquipo
                .CurrentRow
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR
            // =====================

            TipoEquipoConfiguracion tipo =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .FirstOrDefault(
                    t =>
                    t.Nombre
                    == nombre);

            if (tipo == null)
            {
                return;
            }

            // =====================
            // VALIDAR CANTIDAD
            // =====================

            if (SesionSistema
                .Configuracion
                .Estaciones
                .Any(
                    estacionConfig =>
                    estacionConfig.Activa
                    && estacionConfig.TipoEquipo == tipo.Nombre))
            {
                MessageBox.Show(
                    "Para eliminar un tipo equipo primero reasigne sus estaciones a otro tipo.");

                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Eliminar tipo equipo?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }

            // =====================
            // ELIMINAR
            // =====================

            SesionSistema
                .Configuracion
                .TiposEquipo
                .Remove(tipo);

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // RECARGAR
            // =====================

            CargarTiposEquipo();

            CargarEstaciones();

            MessageBox.Show(
                "Tipo equipo eliminado.");
        }

        private void bntGuardarTolerancia_Click(object sender, EventArgs e)
        {
            // =====================
            // GUARDAR
            // =====================

            SesionSistema
                .Configuracion
                .ToleranciaMinutos =
                    (int)nudTolerancia.Value;

            // =====================
            // PERSISTIR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // MENSAJE
            // =====================

            MessageBox.Show(
                "Tolerancia actualizada.");
        }

        private void CargarEstaciones()
        {
            if (dgvEstaciones == null)
            {
                return;
            }

            dgvEstaciones.Rows.Clear();

            cbTipoEstacion.Items.Clear();

            foreach (TipoEquipoConfiguracion tipo
                in SesionSistema
                    .Configuracion
                    .TiposEquipo
                    .OrderBy(
                        t =>
                        t.Nombre))
            {
                cbTipoEstacion.Items.Add(
                    tipo.Nombre);
            }

            foreach (EstacionConfiguracion estacion
                in SesionSistema
                    .Configuracion
                    .Estaciones
                    .Where(
                        e =>
                        e.Activa)
                    .OrderBy(
                        e =>
                        e.NumeroEquipo))
            {
                dgvEstaciones.Rows.Add(
                    estacion.NumeroEquipo,
                    estacion.TipoEquipo,
                    estacion.DireccionIP);
            }

            int total =
                SesionSistema
                .Configuracion
                .Estaciones
                .Count(
                    e =>
                    e.Activa);

            if (total > 0)
            {
                nudTotalEstaciones.Value =
                    total;

                nudInicioEstaciones.Value =
                    SesionSistema.Configuracion.InicioEstaciones > 0
                    ? Math.Min(
                        nudInicioEstaciones.Maximum,
                        SesionSistema.Configuracion.InicioEstaciones)
                    : SesionSistema
                        .Configuracion
                        .Estaciones
                        .Where(
                            e =>
                            e.Activa)
                        .Min(
                            e =>
                            e.NumeroEquipo);
            }

            if (cbTipoEstacion.Items.Count > 0
                && cbTipoEstacion.SelectedIndex < 0)
            {
                cbTipoEstacion.SelectedIndex =
                    0;
            }
        }

        private void btnAplicarTotalEstaciones_Click(
            object sender,
            EventArgs e)
        {
            int total =
                (int)nudTotalEstaciones.Value;

            int inicio =
                (int)nudInicioEstaciones.Value;

            AjustarTotalEstaciones(
                total,
                inicio);

            GuardarYRecargarConfiguracion();
        }

        private void btnAsignarTipoEstacion_Click(
            object sender,
            EventArgs e)
        {
            if (cbTipoEstacion.SelectedItem == null)
            {
                MessageBox.Show(
                    "Seleccione un tipo.");

                return;
            }

            int numero =
                (int)nudNumeroEstacion.Value;

            EstacionConfiguracion estacion =
                SesionSistema
                .Configuracion
                .Estaciones
                .FirstOrDefault(
                    estacionConfig =>
                    estacionConfig.NumeroEquipo == numero);

            if (estacion == null)
            {
                estacion =
                    new EstacionConfiguracion()
                    {
                        NumeroEquipo =
                            numero,

                        Activa =
                            true
                    };

                SesionSistema
                    .Configuracion
                    .Estaciones
                    .Add(estacion);
            }

            estacion.TipoEquipo =
                cbTipoEstacion
                .SelectedItem
                .ToString();

            estacion.DireccionIP =
    tbIP.Text.Trim();

            estacion.Activa =
                true;

            GuardarYRecargarConfiguracion();
        }

        private void dgvEstaciones_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (dgvEstaciones.CurrentRow == null)
            {
                return;
            }

            nudNumeroEstacion.Value =
                Convert.ToInt32(
                    dgvEstaciones
                    .CurrentRow
                    .Cells[0]
                    .Value);

            tbIP.Text =
    dgvEstaciones
        .CurrentRow
        .Cells[2]
        .Value
        ?.ToString()
        ?? "";

            string tipo =
                dgvEstaciones
                .CurrentRow
                .Cells[1]
                .Value
                .ToString();

            if (cbTipoEstacion.Items.Contains(
                tipo))
            {
                cbTipoEstacion.SelectedItem =
                    tipo;
            }
        }

        private void AjustarTotalEstaciones(
            int total,
            int inicio)
        {
            string tipoPorDefecto =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .OrderBy(
                    t =>
                    t.Nombre)
                .Select(
                    t =>
                    t.Nombre)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(
                tipoPorDefecto))
            {
                MessageBox.Show(
                    "Primero cree al menos un tipo de equipo.");

                return;
            }

            int fin =
                inicio + total - 1;

            SesionSistema
                .Configuracion
                .InicioEstaciones =
                    inicio;

            for (int numero = inicio;
                numero <= fin;
                numero++)
            {
                EstacionConfiguracion estacion =
                    SesionSistema
                    .Configuracion
                    .Estaciones
                    .FirstOrDefault(
                        e =>
                        e.NumeroEquipo == numero);

                if (estacion != null)
                {
                    estacion.Activa =
                        true;

                    if (string.IsNullOrWhiteSpace(
                        estacion.TipoEquipo))
                    {
                        estacion.TipoEquipo =
                            tipoPorDefecto;
                    }

                    continue;
                }

                SesionSistema
                    .Configuracion
                    .Estaciones
                    .Add(
                        new EstacionConfiguracion()
                        {
                            NumeroEquipo =
                                numero,

                            TipoEquipo =
                                tipoPorDefecto,

                            Activa =
                                true
                        });
            }

            foreach (EstacionConfiguracion estacion
                in SesionSistema
                    .Configuracion
                    .Estaciones)
            {
                if (estacion.NumeroEquipo < inicio
                    || estacion.NumeroEquipo > fin)
                {
                    estacion.Activa =
                        false;
                }
            }
        }

        private void GuardarYRecargarConfiguracion()
        {
            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            CargarTiposEquipo();

            CargarEstaciones();
        }

        private void AplicarColoresPorDefecto(
            TipoEquipoConfiguracion tipo)
        {
            if (tipo == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(
                tipo.ColorLibre))
            {
                tipo.ColorLibre =
                    "#E3E3E3";
            }

            if (string.IsNullOrWhiteSpace(
                tipo.Color2M))
            {
                tipo.Color2M =
                    "#11BDED";
            }

            if (string.IsNullOrWhiteSpace(
                tipo.Color3M))
            {
                tipo.Color3M =
                    "#E9ED1F";
            }

            if (string.IsNullOrWhiteSpace(
                tipo.Color4M))
            {
                tipo.Color4M =
                    "#2DED1F";
            }

            if (string.IsNullOrWhiteSpace(
                tipo.ColorPausado))
            {
                tipo.ColorPausado =
                    "#DFBFF2";
            }
        }
    }
}
