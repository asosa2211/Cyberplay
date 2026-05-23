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
            CargarCategorias();
            CargarTiposEquipo();
            cbMultijugador_CheckedChanged(null, null);
            nudTolerancia.Value = SesionSistema.Configuracion.ToleranciaMinutos;
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
                    .Categorias)
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

                        tipo.Cantidad,

                        tipo.TarifaLibre,

                        tipo.UsaTarifasMultijugador
                            ? "Sí"
                            : "No",

                        tipo.TarifaM2,

                        tipo.TarifaM3,

                        tipo.TarifaM4);
            }
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
                (int)nudCantidad.Value;

            tipo.UsaTarifasMultijugador =
                cbMultijugador.Checked;

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

            nudCantidad.Value = 1;

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
                tipo.Cantidad;

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
                tbNombreEquipo.Text
                .Trim();

            tipo.Cantidad =
                (int)nudCantidad.Value;

            tipo.UsaTarifasMultijugador =
                cbMultijugador.Checked;

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

            if (tipo.Cantidad > 0)
            {
                MessageBox.Show(
                    "Para eliminar un tipo equipo primero debe establecer la cantidad en 0.");

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
    }
}
