using Cyberplay.Core;
using Cyberplay.enums;
using Cyberplay.Formularios;
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
using static System.Collections.Specialized.BitVector32;

namespace Cyberplay
{
    public partial class frmPrincipal : Form
    {
        private PersistenciaUsuarios persistenciaUsuarios = new PersistenciaUsuarios();
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
        private GestorUsuarios gestorUsuarios = new GestorUsuarios();
        private List<ucPS4> consolas = new List<ucPS4>();
        private PersistenciaSesiones persistenciaSesiones = new PersistenciaSesiones();
        private PersistenciaCaja persistenciaCaja = new PersistenciaCaja();
        private PersistenciaHistorialCajas persistenciaHistorialCajas =
                                            new PersistenciaHistorialCajas();

       
        

        public frmPrincipal()
        {
            InitializeComponent();
            tmrAutoSave.Start();
            lvProximasSalidas.Columns.Add("Consola", 100);
            lvProximasSalidas.Columns.Add("Tiempo restante", 120);
            lvProximasSalidas.Location = new Point(1100, 100);

            lvUltimosCobros.Location = new Point(1100, 500);

            lvUltimosCobros.Columns.Add(
    "Equipo",
    80);

            lvUltimosCobros.Columns.Add(
                "Inicio",
                80);

            lvUltimosCobros.Columns.Add(
                "Fin",
                80);

            lvUltimosCobros.Columns.Add(
                "Tiempo",
                80);

            lvUltimosCobros.Columns.Add(
                "Total",
                80);
            this.AutoScroll = true;
            SesionSistema.CajaActual = persistenciaCaja.CargarCaja();
            if (SesionSistema.CajaActual
    != null
    &&
    SesionSistema
        .CajaActual
        .NumeroCaja == 0)
            {
                SesionSistema
                    .CajaActual
                    .NumeroCaja =
                        persistenciaHistorialCajas
                            .ObtenerSiguienteNumeroCaja();

                persistenciaCaja
                    .GuardarCaja(
                        SesionSistema
                            .CajaActual);
            }
            if (SesionSistema
    .CajaActual
    == null)
            {
                SesionSistema.CajaActual =
    new Caja()
    {
        NumeroCaja =
            persistenciaHistorialCajas
                .ObtenerSiguienteNumeroCaja(),

        Nombre =
            "Caja Principal",

        Cajero =
            SesionSistema
                .CajeroActual
                .Usuario,

        FechaApertura =
            DateTime.Now,

        TotalCobrado =
            0,

        Abierta =
            true
    };
            }
            CrearConsolas();
            CargarUsuarios();
            RestaurarSesiones();
            ActualizarCaja();
            ActualizarInfoCaja();
            AplicarPermisos();

            // SesionSistema.CajeroActual = new Cajero("admin", "Administrador",
            //         "123", RolUsuario.Admin);


        }

        // APLICAR PERMISOS
        private void AplicarPermisos()
        {
            // =====================
            // CAJEROS
            // =====================

            cajerosToolStripMenuItem.Visible =
                Permisos.EsAdmin();

            // =====================
            // REPORTES
            // =====================

            // reportesToolStripMenuItem.Visible =
            //     Permisos.EsAdmin();

            // =====================
            // CONFIGURACION
            // =====================

            // configuracionToolStripMenuItem.Visible =
            //     Permisos.EsAdmin();
        }
        //ACTUALIZAR ULTIMOS COBROS
        private void
ActualizarUltimosCobros()
        {
            // =====================
            // LIMPIAR
            // =====================

            lvUltimosCobros
                .Items
                .Clear();

            // =====================
            // OBTENER COBROS
            // =====================

            List<RegistroCobro>
                cobros =
                    persistenciaCobros
                        .ObtenerCobros();

            // =====================
            // FILTRAR
            // =====================

            cobros =
                cobros
                .Where(c => c.NumeroCaja  == SesionSistema.CajaActual.NumeroCaja
                        && c.TotalCobrado > 0)
                .OrderByDescending(
                    c => c.Fecha)
                .Take(10)
                .ToList();

            // =====================
            // AGREGAR
            // =====================

            foreach (RegistroCobro
                cobro
                in cobros)
            {
                ListViewItem item =
                    new ListViewItem(
                        cobro.Equipo);

                item.SubItems.Add(
                    cobro.HoraInicio
                    .ToString("HH:mm"));

                item.SubItems.Add(
                    cobro.Fecha
                    .ToString("HH:mm"));

                item.SubItems.Add(
                    cobro.TiempoJugado
                    .ToString(@"hh\:mm\:ss"));

                item.SubItems.Add(
                    cobro.TotalCobrado
                    .ToString("0.00"));

                lvUltimosCobros
                    .Items
                    .Add(item);
            }
        }

        private void ActualizarProximasSalidas()
        {
            // =====================
            // LIMPIAR
            // =====================

            lvProximasSalidas.Items.Clear();

            // =====================
            // LISTA TEMPORAL
            // =====================

            List<(string consola,
                TimeSpan? restante)>
                lista =
                    new List<
                        (string,
                        TimeSpan?)>();

            // =====================
            // RECORRER CONSOLAS
            // =====================

            foreach (ucPS4 consola
                in consolas)
            {
                // =====================
                // SOLO CONSOLAS
                // =====================

                if (consola.Estacion.Tipo
                    == TipoEstacion.PC)
                {
                    continue;
                }

                // =====================
                // SIN SESION
                // =====================

                if (!consola.SesionActiva)
                {
                    continue;
                }

                // =====================
                // OBTENER RESTANTE
                // =====================

                TimeSpan? restante =
                    consola.ObtenerTiempoRestante();

                lista.Add(
                    (
                        consola.Estacion.Nombre,
                        restante
                    ));
            }

            // =====================
            // ORDENAR
            // =====================

            lista =
                lista
                .OrderBy(
                    x =>
                    x.restante
                    == null)
                .ThenBy(
                    x =>
                    x.restante)
                .ToList();

            // =====================
            // AGREGAR LISTVIEW
            // =====================

            foreach (var item
                in lista)
            {
                string textoTiempo;

                // =====================
                // ILIMITADO
                // =====================

                if (item.restante
                    == null)
                {
                    textoTiempo =
                        "ILIMITADO";
                }

                // =====================
                // LIMITADO
                // =====================

                else
                {
                    textoTiempo =
                        item.restante.Value
                        .ToString(
                            @"hh\:mm\:ss");
                }

                ListViewItem lv =
                    new ListViewItem(
                        item.consola);

                lv.SubItems.Add(
                    textoTiempo);

                lvProximasSalidas
                    .Items
                    .Add(lv);
            }
        }

        
        private void ActualizarInfoCaja()
        {
            lblCajero.Text =
                "Cajero: "
                +
                SesionSistema
                    .CajeroActual
                    .Usuario;

            lblNumeroCaja.Text =
                "Caja N°: "
                +
                SesionSistema
                    .CajaActual
                    .NumeroCaja;
        }


        private void GuardarSesiones()
        {
            List<EstadoSesion>
                estados =
                    new List<EstadoSesion>();

            foreach (ucPS4 consola
                in consolas)
            {
                estados.Add(
                    consola.ObtenerEstado());
            }

            persistenciaSesiones
                .Guardar(estados);
        }

        private TipoEstacion
    ConvertirTipoEstacion(
        string nombre)
        {
            switch (nombre)
            {
                case "PC":

                    return TipoEstacion.PC;

                case "PS4":

                    return TipoEstacion.PS4;

                case "PS5":

                    return TipoEstacion.PS5;
            }

            return TipoEstacion.PC;
        }
        private void CrearConsolas()
        {
            // =====================
            // POSICION
            // =====================

            int x = 20;

            int y = 70;

            // =====================
            // RECORRER TIPOS
            // =====================

            foreach (
                TipoEquipoConfiguracion tipo
                in SesionSistema
                    .Configuracion
                    .TiposEquipo)
            {
                // =====================
                // CREAR CANTIDAD
                // =====================

                for (int i = 1;
                    i <= tipo.Cantidad;
                    i++)
                {
                    // =====================
                    // ESTACION
                    // =====================

                    Estacion est =
                        new Estacion();

                    // =====================
                    // NOMBRE
                    // =====================

                    est.Nombre =
                        tipo.Nombre
                        + "-"
                        + i;

                    // =====================
                    // TIPO
                    // =====================

                    est.Tipo =
                        ConvertirTipoEstacion(
                            tipo.Nombre);

                    est.TipoEquipo =
                         tipo.Nombre;

                    // =====================
                    // MULTIJUGADOR
                    // =====================

                    est.SoportaMultijugador =
                        tipo
                        .UsaTarifasMultijugador;

                    // =====================
                    // TARIFA LIBRE
                    // =====================

                    est.TarifaCiclo =
                        tipo.TarifaLibre;

                    est.MinutosCiclo =
                        tipo.CiclosPorHora > 0
                        ? 60 / tipo.CiclosPorHora
                        : 20;

                    est.CiclosPorHora =
                        tipo.CiclosPorHora > 0
                        ? tipo.CiclosPorHora
                        : 3;

                    // =====================
                    // TOLERANCIA
                    // =====================

                    est.ToleranciaMinutos =
                        SesionSistema
                            .Configuracion
                            .ToleranciaMinutos;

                    // =====================
                    // TARIFAS MULTIJUGADOR
                    // =====================

                    est.Tarifa2M =
                        tipo.TarifaM2;

                    est.Tarifa3M =
                        tipo.TarifaM3;

                    est.Tarifa4M =
                        tipo.TarifaM4;

                    // =====================
                    // CREAR CONTROL
                    // =====================

                    ucPS4 consola =
                        new ucPS4(
                            gestorUsuarios,
                            est);

                    // =====================
                    // EVENTOS
                    // =====================

                    consola.CobroRealizado +=
                        ActualizarCaja;

                    // =====================
                    // POSICION
                    // =====================

                    consola.Location =
                        new Point(x, y);

                    // =====================
                    // AGREGAR
                    // =====================

                    Controls.Add(consola);

                    consolas.Add(consola);

                    // =====================
                    // SIGUIENTE POSICION
                    // =====================

                    x += consola.Width + 15;

                    // =====================
                    // SALTO FILA
                    // =====================

                    if (consolas.Count % 5 == 0)
                    {
                        x = 20;

                        y += consola.Height + 5;
                    }
                }
            }
        }
        private void GuardarUsuarios()
        {
            persistenciaUsuarios
                .GuardarUsuarios(
                    gestorUsuarios
                        .ObtenerUsuarios());
        }
        private void CargarUsuarios()
        {
            List<Usuario> usuarios =
                persistenciaUsuarios
                    .CargarUsuarios();

            foreach (Usuario usuario
                in usuarios)
            {
                gestorUsuarios
                    .AgregarUsuario(
                        usuario);
            }
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            
           // cajerosToolStripMenuItem.Visible = Permisos.EsAdmin();
        }

        public void ActualizarCaja()
        {
            decimal total =
    SesionSistema
        .CajaActual
        .TotalCobrado;

            lblCaja.Text =
                total.ToString("0.00")
                + " Bs";
            ActualizarUltimosCobros();
        }
        

        private void lblps5Tiempo_MouseUp(object sender, MouseEventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            frmHistorialCobros frm =
        new frmHistorialCobros();

            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  frmUsuarios frm = new frmUsuarios(gestorUsuarios);
            // frm.ShowDialog();
            List<RegistroCobro> cobros =
        persistenciaCobros
            .CargarCobros();

            MessageBox.Show(
                cobros.Count
                .ToString());
        }

       /* private void rbps52M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2M.Checked && sesion != null) 
                sesion.CambiarTarifa(TipoTarifa.M2);
        }

        private void rbps53M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M3);
        }

        private void rbps54M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb4M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M4);  
        }*/

        /*private void lblUsuario_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SESION
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // ABRIR FORM
            // =====================

            frmUsuarios frm =
                new frmUsuarios(
                    gestorUsuarios);

            // =====================
            // RESULTADO
            // =====================

            if (frm.ShowDialog()
                == DialogResult.OK)
            {
                sesion.CambiarUsuario(
                    frm.UsuarioSeleccionado);

                lblUsuario.Text =
                    sesion.UsuarioActual
                        .NombreCuenta;
            }
        }*/

       /* private void ReiniciarUI()
        {
            // =====================
            // LABELS
            // =====================

            lblCronometro.Text =
                "00:00:00";

            lblTiempoLimite.Text =
                "ILIMITADO";

            lblTotal.Text =
                "0.00";

            lblUsuario.Text =
                "invitado";


            // =====================
            // BOTON
            // =====================

            bntIniciar.Text =
                "Iniciar";

            // =====================
            // RADIOBUTTONS
            // =====================

            rbLibre.Checked =
                true;

            rb2M.Checked =
                true;
        }*/

       /* private void btnCobrar_Click(object sender, EventArgs e)
        {
           
        
            // =====================
            // VALIDAR SESION
            // =====================

            if (sesion == null)
            {
                return;
            }


            // =====================
            // TIEMPO FINAL
            // =====================

            TimeSpan tiempoFinal =
                sesion.Cronometro
                .TiempoTranscurrido;

            // =====================
            // DETENER
            // =====================

            sesion.Cronometro.Detener();

            // =====================
            // CALCULAR TOTAL
            // =====================

            decimal total =
                calc.CalcularCosto(
                    sesion.TarifaInicial,
                    sesion.HistorialTarifas,
                    tiempoFinal);

            RegistroCobro cobro =
    new RegistroCobro(
        sesion.UsuarioActual
            .NombreCuenta,

        DateTime.Now,

        tiempoFinal,

        total,

        sesion.TarifaActual);

            persistenciaCobros
    .GuardarCobro(
        cobro);

            ActualizarCaja();

            // =====================
            // ACUMULAR USUARIO
            // =====================

            sesion.UsuarioActual
                .TiempoTotalJugado +=
                    tiempoFinal;

            // =====================
            // MOSTRAR COBRO
            // =====================

            MessageBox.Show(
                $"Usuario: {sesion.UsuarioActual.NombreCuenta}\n\n" +
                $"Tiempo: {tiempoFinal:hh\\:mm\\:ss}\n" +
                $"Total: {total:0.00} Bs",
                "Cobro");

            // =====================
            // LIMPIAR SESION
            // =====================

            sesion = null;

            // =====================
            // REINICIAR UI
            // =====================

            ReiniciarUI();
        }*/

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            // =====================
            // SESIONES ACTIVAS
            // =====================

            if (HaySesionesActivas())
            {
                MessageBox.Show(
                    "No se puede cerrar el sistema porque existen sesiones activas.",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true;

                return;
            }

            // =====================
            // CONFIRMAR CIERRE
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Está seguro que desea cerrar el sistema?",
                    "Confirmar cierre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            // =====================
            // CANCELAR
            // =====================

            if (resultado
                == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            GuardarUsuarios();
            GuardarSesiones();
        }

        private bool HaySesionesActivas()
        {
            // =====================
            // RECORRER CONTROLES
            // =====================

            foreach (Control control
                in Controls)
            {
                // =================
                // SOLO UCPS4
                // =================

                if (control is ucPS4 uc)
                {
                    // =============
                    // SESION
                    // =============

                    if (uc.SesionActiva)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private void RestaurarSesiones()
        {
            List<EstadoSesion>
                estados =
                    persistenciaSesiones
                        .Cargar();

            foreach (EstadoSesion estado
                in estados)
            {
                ucPS4 consola =
                    consolas
                    .FirstOrDefault(
                        c =>
                        c.NombreConsola
                        == estado.NombreConsola);

                if (consola != null)
                {
                    consola.RestaurarEstado(
                        estado);
                }
            }
        }

        private void btnCerrarCaja_Click(
    object sender,
    EventArgs e)
        {
           

            // =====================
            // CERRAR CAJA
            // =====================

            SesionSistema
                .CajaActual
                .Abierta = false;

            SesionSistema
                .CajaActual
                .FechaCierre =
                    DateTime.Now;

            // =====================
            // GUARDAR HISTORIAL
            // =====================

            persistenciaHistorialCajas
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // CREAR NUEVA CAJA
            // =====================

            SesionSistema.CajaActual =
                new Caja()
                {
                    NumeroCaja =
                        persistenciaHistorialCajas
                            .ObtenerSiguienteNumeroCaja(),

                    Nombre =
                        "Caja Principal",

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario,

                    FechaApertura =
                        DateTime.Now,

                    TotalCobrado =
                        0,

                    Abierta =
                        true
                };

            // =====================
            // GUARDAR NUEVA CAJA
            // =====================

            persistenciaCaja
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // ACTUALIZAR UI
            // =====================

            ActualizarCaja();

            ActualizarInfoCaja();

            MessageBox.Show(
                "Caja cerrada correctamente.");

            frmLogin login =
    new frmLogin();

            this.Hide();

            if (login.ShowDialog()
                == DialogResult.OK)
            {
                ActualizarInfoCaja();
                AplicarPermisos();
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ActualizarProximasSalidas();
        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Permisos.EsAdmin())
            {
                MessageBox.Show(
                    "No tiene permisos para acceder a esta función.",
                    "Permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            frmGestionCajeros frm = new frmGestionCajeros();
            frm.ShowDialog();
        }

        private void gestionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // =====================
            // FORM
            // =====================

            frmVentaProductos frm =
                new frmVentaProductos();

            // =====================
            // MOSTRAR
            // =====================

            frm.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresosCaja frm = new frmIngresosCaja();
            frm.IngresoRegistrado += ActualizarCaja;
            frm.ShowDialog();
            
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEgresosCaja frm = new frmEgresosCaja();
            frm.ShowDialog();
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBalance frm =
        new frmBalance();

            frm.ShowDialog();
        }

        private void tsmiPreferencias_Click(object sender, EventArgs e)
        {
            frmPreferencias frm =
       new frmPreferencias();

            frm.ShowDialog();
        }

        private void tmrAutoSave_Tick(object sender, EventArgs e)
        {
            try
            {
                GuardarUsuarios();
                GuardarSesiones();
            }
            catch
            {

            }
        }
    }
    
}
