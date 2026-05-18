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
            lvProximasSalidas.Columns.Add("Consola", 100);
            lvProximasSalidas.Columns.Add("Tiempo restante", 120);
            lvProximasSalidas.Location = new Point(1100, 100);
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

            SesionSistema.CajeroActual = new Cajero("admin", "Administrador",
                                        "123", RolUsuario.Admin);

            
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
        private void CrearConsolas()
        {
            int x = 20;
            int y = 50;

            for (int i = 1; i <= 14; i++)
            {
                // =====================
                // CREAR ESTACION
                // =====================

                Estacion est =
                    new Estacion();

                // =====================
                // PCs
                // =====================

                if (i <= 4)
                {
                    est.Nombre =
                        "PC-" + i;

                    est.Tipo =
                        TipoEstacion.PC;
                    est.SoportaMultijugador = false;

                    // =====================
                    // TARIFA PC
                    // =====================

                    est.TarifaCiclo = 1;

                    est.MinutosCiclo = 20;

                    est.ToleranciaMinutos = 2;
                }

                // =====================
                // PS4
                // =====================

                else
                {
                    est.Nombre =
                        "PS4-" + i;

                    est.Tipo =
                        TipoEstacion.PS4;
                    est.SoportaMultijugador = true;

                    // =====================
                    // TARIFAS
                    // =====================

                    est.Tarifa2M = 10;

                    est.Tarifa3M = 12;

                    est.Tarifa4M = 14;
                }

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

                x += consola.Width + 20;

                // =====================
                // SALTO FILA
                // =====================

                if (i % 5 == 0)
                {
                    x = 20;

                    y += consola.Height + 15;
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
            
        }

        private void ActualizarCaja()
        {
            decimal total =
    SesionSistema
        .CajaActual
        .TotalCobrado;

            lblCaja.Text =
                total.ToString("0.00")
                + " Bs";
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
            GuardarUsuarios();
            GuardarSesiones();
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
    }
    
}
