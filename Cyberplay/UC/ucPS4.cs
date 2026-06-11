using Cyberplay.Core;
using Cyberplay.Formularios;
using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay
{
    public partial class ucPS4 : UserControl
    {
        private bool restaurando = false;

        private bool pagado = false;

        private Estacion estacion;

        private Estacion estacionTarifasSesion;

        private bool equipoEncendido;

        public bool EquipoEncendido
        {
            get
            {
                return equipoEncendido;
            }

            set
            {
                equipoEncendido = value;
                //VerificarAdvertenciaEquipo();
            }
        }

        public Estacion Estacion
        {
            get
            {
                return estacion;
            }
        }

        public bool SesionActiva
        {
            get
            {
                return sesion != null;
            }
        }

        public Sesion Sesion
        {
            get
            {
                return sesion;
            }
        }
        private Sesion sesion;
        private CalculadoraCobro calc = new CalculadoraCobro();
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
        private PersistenciaCaja persistenciaCaja = new PersistenciaCaja();
        private GestorUsuarios gestorUsuarios;
        private Usuario usuarioInvitado = new Usuario("invitado", "Cliente invitado", "");
        frmPedirTiempo frm = new frmPedirTiempo();
        public event Action CobroRealizado;
        public event Action EstadoSesionCambiado;
        private string nombreConsola;

        public string NombreConsola
        {
            get
            {
                return nombreConsola;
            }

            set
            {
                nombreConsola = value;

                lblNombre.Text =
                    estacion != null
                    ? estacion.NumeroEquipo.ToString()
                    : value;
            }
        }

        public void VerificarAdvertenciaEquipo()
        {
            bool sesionPausadaMasDe3Min =
                sesion != null
                &&
                sesion.Cronometro != null
                &&
                sesion.Cronometro.Pausado
                &&
                DateTime.Now >=
                    sesion.Cronometro.HoraPausa
                        .AddMinutes(
    SesionSistema
        .Configuracion
        .MinutosMonitoreoEquipos);

            bool mostrarAdvertencia =
                EquipoEncendido
                &&
                (
                    sesion == null
                    ||
                    sesionPausadaMasDe3Min
                );

            if (!mostrarAdvertencia)
            {
                return;
            }

            int numeroEquipo =
                estacion != null
                ? estacion.NumeroEquipo
                : 0;

            string cajero =
                SesionSistema
                    .CajeroActual
                    ?.Usuario
                ?? "";

            PersistenciaAlertasEquipos
                persistencia =
                    new PersistenciaAlertasEquipos();

            persistencia.GuardarAlerta(
                new AlertaEquipo()
                {
                    FechaHora =
                        DateTime.Now,

                    NumeroEquipo =
                        numeroEquipo,

                    TipoEquipo =
                        estacion?.TipoEquipo,

                    Cajero =
                        cajero,

                    Motivo =
                        sesion == null
                        ? "Equipo encendido sin sesión activa"
                        : "Equipo encendido con sesión pausada"
                });
            Form principal =
    Application.OpenForms["frmPrincipal"];

            if (principal != null)
            {
                if (principal.WindowState ==
                    FormWindowState.Minimized)
                {
                    principal.WindowState =
                        FormWindowState.Normal;
                }

                principal.TopMost = true;

                principal.Activate();

                principal.BringToFront();

                principal.TopMost = false;
            }

            MessageBox.Show(
                sesion == null
                ? $"La consola {numeroEquipo} está encendida. Inicie el cronometro o apague la consola."
                : $"La consola {numeroEquipo} está encendida. Reanude el cronometro o apague la consola.",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private TipoEquipoConfiguracion ObtenerConfiguracionTipo()
        {
            return SesionSistema
                .Configuracion
                .TiposEquipo
                .FirstOrDefault(
                    t =>
                    t.Nombre
                    ==
                    estacion.TipoEquipo);
        }

        public void NotificarEstadoSesionCambiado()
        {
            if (restaurando)
            {
                return;
            }

            EstadoSesionCambiado?.Invoke();
        }

        private void CongelarTarifasSesion()
        {
            estacionTarifasSesion =
                ClonarEstacion(
                    Estacion);
        }

        private Estacion ObtenerEstacionCalculo()
        {
            return estacionTarifasSesion
                ?? Estacion;
        }

        private Estacion ClonarEstacion(
            Estacion origen)
        {
            if (origen == null)
            {
                return null;
            }

            return new Estacion()
            {
                IdEstacion = origen.IdEstacion,
                NumeroEquipo = origen.NumeroEquipo,
                Nombre = origen.Nombre,
                SoportaMultijugador = origen.SoportaMultijugador,
                Tipo = origen.Tipo,
                TipoEquipo = origen.TipoEquipo,
                Tarifa2M = origen.Tarifa2M,
                Tarifa3M = origen.Tarifa3M,
                Tarifa4M = origen.Tarifa4M,
                TarifaCiclo = origen.TarifaCiclo,
                MinutosCiclo = origen.MinutosCiclo,
                CiclosPorHora = origen.CiclosPorHora,
                ToleranciaMinutos = origen.ToleranciaMinutos
            };
        }

        private Estacion CrearEstacionSnapshot(
            EstadoSesion estado)
        {
            Estacion snapshot =
                ClonarEstacion(
                    Estacion);

            if (snapshot == null
                || estado == null)
            {
                return snapshot;
            }

            if (estado.Tarifa2M > 0)
            {
                snapshot.Tarifa2M =
                    estado.Tarifa2M;
            }

            if (estado.Tarifa3M > 0)
            {
                snapshot.Tarifa3M =
                    estado.Tarifa3M;
            }

            if (estado.Tarifa4M > 0)
            {
                snapshot.Tarifa4M =
                    estado.Tarifa4M;
            }

            if (estado.TarifaCiclo > 0)
            {
                snapshot.TarifaCiclo =
                    estado.TarifaCiclo;
            }

            if (estado.CiclosPorHora > 0)
            {
                snapshot.CiclosPorHora =
                    estado.CiclosPorHora;
            }

            if (estado.ToleranciaMinutos >= 0)
            {
                snapshot.ToleranciaMinutos =
                    estado.ToleranciaMinutos;
            }

            return snapshot;
        }

        private void SonidoIniciar()
        {
            Sonidos.Reproducir("inicio.wav");
        }

        private void SonidoPausar()
        {
            Sonidos.Reproducir("fin.wav");
        }

        private void SonidoReanudar()
        {
            Sonidos.Reproducir("inicio.wav");
        }

        private void SonidoTiempoTerminado()
        {
            Sonidos.Reproducir("fin.wav");
        }

        public void ActualizarTotal()
        {
            // =====================
            // VALIDAR
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // TOTAL TIEMPO
            // =====================

            decimal total =
                CalcularTotalSesion(
                    sesion.Cronometro
                        .TiempoTranscurrido);

            // =====================
            // LABEL
            // =====================

            lblTotal.Text =
                "Bs. "
                + total.ToString("0.0");

            CentrarControl(
                lblTotal);
        }

        private decimal CalcularTotalSesion(
            TimeSpan tiempo)
        {
            if (sesion == null)
            {
                return 0;
            }

           

            decimal totalTiempo =
                calc.CalcularCosto(
                    ObtenerEstacionCalculo(),
                    sesion.TarifaInicial,
                    sesion.HistorialTarifas,
                    tiempo);

            decimal totalProductos =
                sesion
                    .ProductosConsumidos
                    .Sum(
                        p => p.Total);

            return totalTiempo
                   + totalProductos;
        }
        private void MostrarLibre()
        {
            TipoEquipoConfiguracion tipo =
                ObtenerConfiguracionTipo();

            if (tipo == null)
            {
                return;
            }

            string color =
                tipo.ColorLibre;

            if (string.IsNullOrWhiteSpace(
                color))
            {
                color = "#E3E3E3";
            }

            pnlPrincipal.BackColor =
                ColorTranslator
                    .FromHtml(color);

            pnlTarifas.BackColor =
                ColorTranslator
                    .FromHtml(color);
        }

        private void MostrarActivo()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#11BDED");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#11BDED");
        }

        private void MostrarPausado()
        {
            TipoEquipoConfiguracion tipo =
        ObtenerConfiguracionTipo();

            if (tipo == null)
            {
                return;
            }

            string color =
                tipo.ColorPausado;

            if (string.IsNullOrWhiteSpace(
                color))
            {
                color = "#11BDED";
            }

            pnlPrincipal.BackColor =
                ColorTranslator
                    .FromHtml(color);

            pnlTarifas.BackColor =
                ColorTranslator
                    .FromHtml(color);
        }

        private void Mostrar2M()
        {
            TipoEquipoConfiguracion tipo =
                ObtenerConfiguracionTipo();

            if (tipo == null)
            {
                return;
            }

            string color =
                tipo.Color2M;

            if (string.IsNullOrWhiteSpace(
                color))
            {
                color = "#11BDED";
            }

            pnlPrincipal.BackColor =
                ColorTranslator
                    .FromHtml(color);

            pnlTarifas.BackColor =
                ColorTranslator
                    .FromHtml(color);
        }

        private void Mostrar3M()
        {
            TipoEquipoConfiguracion tipo =
         ObtenerConfiguracionTipo();

            if (tipo == null)
            {
                return;
            }

            string color =
                tipo.Color3M;

            if (string.IsNullOrWhiteSpace(
                color))
            {
                color = "#11BDED";
            }

            pnlPrincipal.BackColor =
                ColorTranslator
                    .FromHtml(color);

            pnlTarifas.BackColor =
                ColorTranslator
                    .FromHtml(color);
        }

        private void Mostrar4M()
        {
            TipoEquipoConfiguracion tipo =
        ObtenerConfiguracionTipo();

            if (tipo == null)
            {
                return;
            }

            string color =
                tipo.Color4M;

            if (string.IsNullOrWhiteSpace(
                color))
            {
                color = "#11BDED";
            }

            pnlPrincipal.BackColor =
                ColorTranslator
                    .FromHtml(color);

            pnlTarifas.BackColor =
                ColorTranslator
                    .FromHtml(color);
        }

        private void AplicarColorTarifaSeleccionada()
        {
            if (rb2M.Checked)
            {
                Mostrar2M();
                return;
            }

            if (rb3M.Checked)
            {
                Mostrar3M();
                return;
            }

            if (rb4M.Checked)
            {
                Mostrar4M();
            }
        }





        private void CentrarControl(Control control)
        {
            control.Left = (pnlPrincipal.Width - control.Width) / 2;
        }

        private void
ucPS4_DragDrop(
    object sender,
    DragEventArgs e)
        {
            // =====================
            // OBTENER ORIGEN
            // =====================

            ucPS4 origen =
                (ucPS4)e.Data
                .GetData(
                    typeof(ucPS4));

            // =====================
            // MISMO CONTROL
            // =====================

            if (origen == this)
            {
                return;
            }

            // =====================
            // ORIGEN SIN SESION
            // =====================

            if (origen.sesion
                == null)
            {
                return;
            }

            // =====================
            // DESTINO OCUPADO
            // =====================

            if (this.sesion
                != null)
            {
                MessageBox.Show(
                    "El equipo destino no está libre.");

                return;
            }

            // =====================
            // VALIDAR TIPO
            // =====================

            if (origen.Estacion.TipoEquipo
     != this.Estacion.TipoEquipo)
            {
                MessageBox.Show(
                    "No puede transferir entre tipos distintos.");

                return;
            }

            // =====================
            // TRANSFERIR
            // =====================

            this.sesion =
                origen.sesion;

            this.estacionTarifasSesion =
                origen.estacionTarifasSesion;


            origen.sesion =
                null;

            origen.estacionTarifasSesion =
                null;

            // =====================
            // ACTUALIZAR UI
            // =====================

            this.ActualizarUITransferida();

            origen.ReiniciarUI();

            this.NotificarEstadoSesionCambiado();
            origen.NotificarEstadoSesionCambiado();

           // MessageBox.Show(
                //"Sesión transferida correctamente.");
        }
        private void
ucPS4_DragEnter(
    object sender,
    DragEventArgs e)
        {
            if (e.Data
                .GetDataPresent(
                    typeof(ucPS4)))
            {
                e.Effect =
                    DragDropEffects.Move;
            }
        }

        private void
ActualizarUITransferida()
        {
            restaurando = true;
            switch (sesion.TarifaActual)
            {
                case TipoTarifa.M2:
                    rb2M.Checked = true;
                    break;

                case TipoTarifa.M3:
                    rb3M.Checked = true;
                    break;

                case TipoTarifa.M4:
                    rb4M.Checked = true;
                    break;
            }

            if (sesion.TiempoLimite
    == TimeSpan.Zero)
            {
                rbLibre.Checked = true;
                iniciar1HoraToolStripMenuItem.Enabled = false;
                iniciar30MinToolStripMenuItem.Enabled = false;
                aumentar1HoraToolStripMenuItem.Enabled = false;
                aumentar30MinToolStripMenuItem.Enabled = false;
                aumentar5MinToolStripMenuItem.Enabled = false;
            }
            else
            {
                rbLimitado.Checked =
                    true;

                lblTiempoLimite.Text =
                    sesion.TiempoLimite
                        .ToString(
                            @"hh\:mm\:ss");
                CentrarControl(lblTiempoLimite);
                //volveraqui
                iniciar1HoraToolStripMenuItem.Enabled = false;
                iniciar30MinToolStripMenuItem.Enabled = false;
                aumentar1HoraToolStripMenuItem.Enabled = true;
                aumentar30MinToolStripMenuItem.Enabled = true;
                aumentar5MinToolStripMenuItem.Enabled = true;
            }

            // =====================
            // USUARIO
            // =====================

            lblUsuario.Text =
                sesion
                .UsuarioActual
                .NombreCuenta;

            // =====================
            // BOTON
            // =====================

            btnIniciar.Text =
                "Pausar";

            // =====================
            // COLOR
            // =====================

            MostrarActivo();
            if (rb2M.Checked)
                Mostrar2M();
            if (rb3M.Checked)
                Mostrar3M();
            if (rb4M.Checked)
                Mostrar4M();

            // =====================
            // TIMER
            // =====================

            timer.Start();

            ActualizarTotal();

            restaurando = false;
        }
        //CONSTRUCTOR
        public ucPS4()
        {
            InitializeComponent();
        }

        public ucPS4(GestorUsuarios gestor, Estacion est)
        {
            InitializeComponent();
            pnlPrincipal.AllowDrop = true;
            pnlPrincipal.MouseDown += ucPS4_MouseDown;
            pnlPrincipal.DragEnter += ucPS4_DragEnter;
            pnlPrincipal.DragDrop +=  ucPS4_DragDrop;
            CentrarControl(lblUsuario);
            CentrarControl(lblCronometro);
            CentrarControl(lblTiempoJugado);
            CentrarControl(lblTiempoLimite);
            gestorUsuarios = gestor;
            estacion = est;
            MostrarLibre();
            if (!estacion
    .SoportaMultijugador)
            {
                rb2M.Visible = false;

                rb3M.Visible = false;

                rb4M.Visible = false;

                lblUsuario.Visible = false;
            }
            NombreConsola = estacion.Nombre;
            
            //this.Size = new Size(400, 300);
        }

        private decimal ObtenerTarifaHora()
        {
            switch (sesion.TarifaActual)
            {
                case TipoTarifa.M2:
                    return estacion.Tarifa2M;

                case TipoTarifa.M3:
                    return estacion.Tarifa3M;

                case TipoTarifa.M4:
                    return estacion.Tarifa4M;
            }

            return 0;
        }


        private void ReiniciarUI()
        {
            MostrarLibre();
            // =====================
            // LABELS
            // =====================

            lblCronometro.Text =
                "00:00:00";

            lblTiempoLimite.Text =
                "ILIMITADO";
            CentrarControl(lblTiempoLimite);

            lblTotal.Text =
                "Bs. 0.0";
            CentrarControl(lblTotal);

            lblUsuario.Text =
                "invitado";
            CentrarControl(lblUsuario);

            lblTiempoJugado.Text =
                 "00:00:00";


            // =====================
            // BOTON
            // =====================

            btnIniciar.Text =
                "Iniciar";

            // =====================
            // RADIOBUTTONS
            // =====================

            rbLibre.Checked =
                true;

            rb2M.Checked =
                true;
            iniciar1HoraToolStripMenuItem.Enabled = true;
            iniciar30MinToolStripMenuItem.Enabled = true;
            aumentar1HoraToolStripMenuItem.Enabled = false;
            aumentar30MinToolStripMenuItem.Enabled = false;
            aumentar5MinToolStripMenuItem.Enabled = false;
        }
        private void ucPS4_Load(object sender, EventArgs e)
        {
            
        }

        public TipoTarifa ObtenerTarifaSeleccionada()
        {
            if (rb2M.Checked)
            {
                return TipoTarifa.M2;
            }

            if (rb3M.Checked)
            {
                return TipoTarifa.M3;
            }

            return TipoTarifa.M4;
        }

        public TimeSpan?
    ObtenerTiempoRestante()
        {
            // =====================
            // SIN SESION
            // =====================

            if (sesion == null)
            {
                return null;
            }

            // =====================
            // LIBRE
            // =====================

            if (sesion.Modo
                == ModoSesion.Libre)
            {
                return null;
            }

            // =====================
            // LIMITADO
            // =====================

            TimeSpan restante =
                sesion.TiempoLimite
                -
                sesion.Cronometro
                    .TiempoTranscurrido;

            // =====================
            // EVITAR NEGATIVOS
            // =====================

            if (restante
                < TimeSpan.Zero)
            {
                restante =
                    TimeSpan.Zero;
            }

            return restante;
        }
        private void bntIniciar_Click(object sender, EventArgs e)
        {
            

            //SI NO EXISTE SESIÓN
            if (sesion == null)
            {
               
                //OBTENER TARIFA
                TipoTarifa tarifa = ObtenerTarifaSeleccionada();

               

                //TIEMPO LIBRE
                if (rbLibre.Checked)
                {
                    //CREAR SESION
                sesion = new Sesion(tarifa, usuarioInvitado);
                    
                    CongelarTarifasSesion();
                    ActualizarIndicadorNota();
                    sesion.IniciarLibre();
                    /*if (rb2M.Checked)
                        Mostrar2M();
                    if (rb3M.Checked)
                        Mostrar3M();
                    if (rb4M.Checked)
                        Mostrar4M();*/
                    //AplicarColorTarifaSeleccionada();
                    iniciar1HoraToolStripMenuItem.Enabled = false;
                    iniciar30MinToolStripMenuItem.Enabled = false;
                }

                //TIEMPO LIMITADO
                else if (rbLimitado.Checked)
                {
                    frm.Text = "Tiempo a jugar";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        TimeSpan tiempo =
                            new TimeSpan(
                                frm.Horas,
                                frm.Minutos,
                                0);
                        //CREAR SESION
                        sesion = new Sesion(tarifa, usuarioInvitado);
                        
                        CongelarTarifasSesion();
                        ActualizarIndicadorNota();
                        sesion.IniciarLimitado(
                            tiempo);

                        lblTiempoLimite.Text =
                            sesion.TiempoLimite
                            .ToString(@"hh\:mm\:ss");
                        CentrarControl(lblTiempoLimite);
                        

                        aumentar1HoraToolStripMenuItem.Enabled = true;
                        aumentar30MinToolStripMenuItem.Enabled = true;
                        aumentar5MinToolStripMenuItem.Enabled = true;

                        iniciar1HoraToolStripMenuItem.Enabled = false;
                        iniciar30MinToolStripMenuItem.Enabled = false;

                    }
                    else
                    {
                        // =================
                        // CANCELÓ
                        // =================

                        //sesion = null;
                       
                        return;
                    }
                }

                // =====================
                // INICIAR TIMER
                // =====================

                //MostrarActivo();
                Sonidos.Reproducir("inicio.wav");
                timer.Start();

                btnIniciar.Text = "Pausar";
                AplicarColorTarifaSeleccionada();
                NotificarEstadoSesionCambiado();

                return;
            }

            // =========================
            // PAUSAR
            // =========================

            if (sesion.Cronometro.EnEjecucion && !sesion.Cronometro.Pausado)
            {
                sesion.Cronometro.Pausar();
                

                timer.Stop();

                btnIniciar.Text = "Reanudar";
                MostrarPausado();
                Sonidos.Reproducir("fin.wav");
                NotificarEstadoSesionCambiado();
            }

            // =========================
            // REANUDAR
            // =========================

            else
            {
                sesion.Cronometro.Reanudar();
                

                timer.Start();

                btnIniciar.Text = "Pausar";
                if (rb2M.Checked)
                    Mostrar2M();
                if (rb3M.Checked)
                    Mostrar3M();
                if (rb4M.Checked)
                    Mostrar4M();
                Sonidos.Reproducir("inicio.wav");

                if (sesion.TiempoRestante <= TimeSpan.Zero)
                {
                    rbLibre.Checked = true;
                }

                NotificarEstadoSesionCambiado();
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SESION
            // =====================

            if (sesion == null)
            {
                return;
            }

            DialogResult resultado =
    MessageBox.Show(
        "¿Está seguro que desea cobrar?",
        "Confirmar cobro",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
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

            timer.Stop();
            sesion.Cronometro.Detener();

            // =====================
            // CALCULAR TOTAL
            // =====================

            decimal total =
                CalcularTotalSesion(
                    tiempoFinal);

            decimal totalTiempoJugado =
    calc.CalcularCosto(
        ObtenerEstacionCalculo(),
        sesion.TarifaInicial,
        sesion.HistorialTarifas,
        tiempoFinal);

            RegistroCobro cobro =
    new RegistroCobro(
        sesion.UsuarioActual.NombreCuenta,

        sesion.Cronometro.HoraInicioReal == DateTime.MinValue
        ? DateTime.Now - tiempoFinal
        : sesion.Cronometro.HoraInicioReal,

        DateTime.Now,

        tiempoFinal,

        total,

        sesion.TarifaActual,

        SesionSistema
            .CajeroActual
            .Usuario,

        Estacion.NumeroEquipo,

        Estacion.TipoEquipo,

        SesionSistema
    .CajaActual
    .NumeroCaja);

            cobro.TarifaInicial =
    sesion.TarifaInicial;

            cobro.TicketId =
    GeneradorTickets
        .Generar();

            cobro.ProductosConsumidos =
                sesion
                    .ProductosConsumidos
                    .ToList();

            cobro.HistorialTarifas =
                sesion
                    .HistorialTarifas
                    .ToList();

            cobro.TotalTiempoJugado =
    totalTiempoJugado;

            persistenciaCobros.GuardarCobro(cobro);
            
            SesionSistema.CajaActual.TotalCobrado += total;

            persistenciaCaja.GuardarCaja(SesionSistema.CajaActual);

            // =====================
            // INGRESO CAJA
            // =====================

            PersistenciaIngresosCaja
                persistenciaIngresos =
                    new PersistenciaIngresosCaja();

            List<IngresoCaja> ingresos =
                persistenciaIngresos
                    .CargarIngresos();

            IngresoCaja ingreso =
                new IngresoCaja()
                {
                    Concepto =
                        "Cobro sesión: "
                        + EquipoIdentidad.Formatear(
                            Estacion.NumeroEquipo,
                            Estacion.TipoEquipo),

                    Monto =
                        total,

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario,

                    NumeroCaja =
                        SesionSistema
                            .CajaActual
                            .NumeroCaja
                };

            ingresos.Add(
                ingreso);

            // =====================
            // GUARDAR
            // =====================

            persistenciaIngresos
                .GuardarIngresos(
                    ingresos);

            Application.DoEvents();
            CobroRealizado?.Invoke();


            // =====================
            // ACUMULAR USUARIO
            // =====================

            sesion.UsuarioActual
                .TiempoTotalJugado +=
                    tiempoFinal;

           

            // =====================
            // LIMPIAR SESION
            // =====================

            sesion = null;
            
            estacionTarifasSesion = null;
            ActualizarIndicadorNota();
            ActualizarIndicadorCarrito();

            // =====================
            // REINICIAR UI
            // =====================

            ReiniciarUI();
            iniciar1HoraToolStripMenuItem.Enabled = true;
            iniciar30MinToolStripMenuItem.Enabled = true;
            NotificarEstadoSesionCambiado();
        }

        public decimal ObtenerTotalHasta(
    TimeSpan tiempo)
        {
            return calc.CalcularCosto(
                ObtenerEstacionCalculo(),
                sesion.TarifaInicial,
                sesion.HistorialTarifas,
                tiempo);
        }

        private void ActualizarIndicadorNota()
        {
            // =====================
            // SIN SESION
            // =====================

            if (sesion == null)
            {
                pbNota.Visible = false;

                toolTip1.SetToolTip(
                    pbNota,
                    "");

                return;
            }

            // =====================
            // SIN NOTA
            // =====================

            if (string.IsNullOrWhiteSpace(
                sesion.Nota))
            {
                pbNota.Visible = false;

                toolTip1.SetToolTip(
                    pbNota,
                    "");

                return;
            }

            // =====================
            // CON NOTA
            // =====================

            pbNota.Visible = true;

            toolTip1.SetToolTip(
                pbNota,
                sesion.Nota);
        }

        public void ActualizarIndicadorCarrito()
        {
            if (sesion == null)
            {
                pbCarrito.Visible = false;
                return;
            }

            pbCarrito.Visible =
                sesion.ProductosConsumidos != null
                && sesion.ProductosConsumidos.Count > 0;
        }

        public void RestaurarEstado(
    EstadoSesion estado)
        {
            restaurando = true;

            try
            {
                if (estado == null
                    || !estado.SesionActiva)
                {
                    sesion = null;
                    MostrarLibre();
                    return;
                }

                Usuario usuario =
                    gestorUsuarios
                        .ObtenerUsuarios()
                        .FirstOrDefault(
                            u =>
                            u.NombreCuenta
                            == estado.Usuario)
                    ?? usuarioInvitado;

                TipoTarifa tarifaInicial =
                    estado.HistorialTarifas != null
                    && estado.HistorialTarifas.Count > 0
                    ? estado.TarifaInicial
                    : estado.Tarifa;

                sesion =
                    new Sesion(
                        tarifaInicial,
                        usuario);
                estacionTarifasSesion =
                    CrearEstacionSnapshot(
                        estado);

                sesion.ProductosConsumidos =
                    estado.ProductosConsumidos
                    ?? new List<VentaProducto>();

                sesion.Nota =
                    estado.Nota;

                if (estado.Modo == ModoSesion.Libre)
                {
                    sesion.IniciarLibre();
                }
                else
                {
                    TimeSpan limite =
                        estado.TiempoLimite < TimeSpan.Zero
                        ? TimeSpan.Zero
                        : estado.TiempoLimite;

                    sesion.IniciarLimitado(
                        limite);

                    lblTiempoLimite.Text =
                        limite
                            .ToString(@"hh\:mm\:ss");
                }

                TimeSpan tiempoGuardado =
                    estado.TiempoTranscurrido < TimeSpan.Zero
                    ? TimeSpan.Zero
                    : estado.TiempoTranscurrido;

                sesion.Cronometro
                    .TiempoAcumulado =
                        tiempoGuardado;

                sesion.Cronometro
                    .HoraInicioReal =
                        estado.HoraInicioReal == DateTime.MinValue
                        ? estado.HoraInicio
                        : estado.HoraInicioReal;

                sesion.RestaurarTarifas(
                    tarifaInicial,
                    estado.Tarifa,
                    estado.HistorialTarifas);

                bool estabaCorriendo =
                    estado.EstabaCorriendo
                    || (!estado.Pausado
                        && estado.FechaSnapshot == DateTime.MinValue);

                if (estabaCorriendo)
                {
                    DateTime fechaSnapshot =
                        estado.FechaSnapshot != DateTime.MinValue
                        ? estado.FechaSnapshot
                        : estado.HoraPausa;

                    TimeSpan tiempoApagado =
                        fechaSnapshot == DateTime.MinValue
                        ? TimeSpan.Zero
                        : DateTime.Now - fechaSnapshot;

                    if (tiempoApagado < TimeSpan.Zero)
                    {
                        tiempoApagado =
                            TimeSpan.Zero;
                    }

                    sesion.Cronometro
                        .TiempoAcumulado +=
                            tiempoApagado;

                    sesion.Cronometro
                        .HoraInicio =
                            DateTime.Now;
                }
                else
                {
                    sesion.Cronometro
                        .Pausar();
                }

                switch (estado.Tarifa)
                {
                    case TipoTarifa.M2:
                        rb2M.Checked = true;
                        break;

                    case TipoTarifa.M3:
                        rb3M.Checked = true;
                        break;

                    case TipoTarifa.M4:
                        rb4M.Checked = true;
                        break;
                }

                if (estado.Modo == ModoSesion.Libre)
                {
                    rbLibre.Checked = true;
                    lblTiempoLimite.Text =
                        "ILIMITADO";
                }
                else
                {
                    rbLimitado.Checked = true;
                }

                lblUsuario.Text =
                    usuario.NombreCuenta;

                ActualizarIndicadorNota();
                ActualizarIndicadorCarrito();

                bool vencida =
                    sesion.Modo == ModoSesion.Limitado
                    && sesion.TiempoRestante <= TimeSpan.Zero;

                if (estado.Pausado
                    || !estabaCorriendo
                    || vencida)
                {
                    sesion.Cronometro
                        .Pausar();

                    timer.Stop();

                    btnIniciar.Text =
                        vencida
                        ? "Continuar"
                        : "Reanudar";

                    MostrarPausado();
                }
                else
                {
                    timer.Start();

                    btnIniciar.Text =
                        "Pausar";

                    AplicarColorTarifaSeleccionada();
                }

                ActualizarTotal();
            }
            finally
            {
                restaurando = false;
                
            }
        }

        public EstadoSesion
    ObtenerEstado()
        {
            EstadoSesion estado =
                new EstadoSesion();

            estado.NombreConsola =
                NombreConsola;

            estado.NumeroEquipo =
                Estacion.NumeroEquipo;

            estado.IdEstacion =
                Estacion.IdEstacion;

            estado.TipoEquipo =
                Estacion.TipoEquipo;

            estado.SesionActiva =
                sesion != null;

            // =====================
            // SI NO HAY SESION
            // =====================

            if (sesion == null)
            {
                return estado;
            }

            // =====================
            // SESION
            // =====================

            estado.TiempoTranscurrido =
    sesion.Cronometro
        .TiempoTranscurrido;

            estado.Usuario =
                sesion.UsuarioActual
                    .NombreCuenta;

            estado.Tarifa =
                sesion.TarifaActual;

            estado.TarifaInicial =
                sesion.TarifaInicial;

            estado.Modo =
                sesion.Modo;

            estado.HoraInicio =
                sesion.Cronometro
                    .HoraInicio;

            estado.HoraInicioReal =
                sesion.Cronometro
                    .HoraInicioReal;

            estado.TiempoLimite =
                sesion.TiempoLimite;

            estado.Pausado =
                sesion.Cronometro
                    .Pausado;

            estado.EstabaCorriendo =
                sesion.Cronometro.EnEjecucion
                && !sesion.Cronometro.Pausado;

            estado.FechaSnapshot =
                DateTime.Now;

            estado.HoraPausa =
                sesion.Cronometro.Pausado
                ? sesion.Cronometro.HoraPausa
                : estado.FechaSnapshot;

            Estacion estacionSnapshot =
                ObtenerEstacionCalculo();

            if (estacionSnapshot != null)
            {
                estado.Tarifa2M =
                    estacionSnapshot.Tarifa2M;

                estado.Tarifa3M =
                    estacionSnapshot.Tarifa3M;

                estado.Tarifa4M =
                    estacionSnapshot.Tarifa4M;

                estado.TarifaCiclo =
                    estacionSnapshot.TarifaCiclo;

                estado.CiclosPorHora =
                    estacionSnapshot.CiclosPorHora;

                estado.ToleranciaMinutos =
                    estacionSnapshot.ToleranciaMinutos;
            }

            estado.ProductosConsumidos =
                sesion
                .ProductosConsumidos
                .ToList();

            estado.Nota =
                sesion.Nota;

            estado.HistorialTarifas =
                sesion
                .HistorialTarifas
                .ToList();

            return estado;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            CentrarControl(lblUsuario);
            CentrarControl(lblCronometro);
            CentrarControl(lblTiempoJugado);
            CentrarControl(lblTiempoLimite);
            if (sesion == null)
            {
                return;
            }

            lblUsuario.Text = sesion.UsuarioActual.NombreCuenta;

            if (sesion.Modo == ModoSesion.Libre)
            {
                lblCronometro.Text = sesion
                    .Cronometro
                    .TiempoTranscurrido
                    .ToString(@"hh\:mm\:ss");
                
            }

            // =====================
            // TIEMPO LIMITADO
            // =====================

            else
            {
                lblCronometro.Text = sesion
                    .TiempoRestante
                    .ToString(@"hh\:mm\:ss");
                

                lblTiempoJugado.Text = sesion.Cronometro
                    .TiempoTranscurrido
                    .ToString(@"hh\:mm\:ss");
                
            }
            if (sesion.Modo == ModoSesion.Limitado
                    && sesion.TiempoRestante <= TimeSpan.Zero)
            {
                // ======================
                // DETENER TIMER VISUAL
                // ======================

                timer.Stop();

                // ======================
                // PAUSAR CRONÓMETRO
                // ======================

                sesion.Cronometro.Pausar();
                

                // ======================
                // ACTUALIZAR BOTÓN
                // ======================

                btnIniciar.Text = "Continuar";
                Sonidos.Reproducir("fin.wav");
                MostrarPausado();

                // ======================
                // OPCIONAL
                // ======================

                //MessageBox.Show("Tiempo agotado");
            }

           ActualizarTotal();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
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
                CentrarControl(lblUsuario);
                NotificarEstadoSesionCambiado();
            }
        }

        private void rb2M_CheckedChanged(object sender, EventArgs e)
        {
            if (restaurando)
            {
                return;
            }

            if (rb2M.Checked && sesion != null)
            {
                sesion.CambiarTarifa(TipoTarifa.M2);
                Mostrar2M();
                ActualizarTotal();
                NotificarEstadoSesionCambiado();
            }
                
        }

        private void rb3M_CheckedChanged(object sender, EventArgs e)
        {
            if (restaurando)
            {
                return;
            }

            if (rb3M.Checked && sesion != null)
            {
                sesion.CambiarTarifa(TipoTarifa.M3);
                Mostrar3M();
                ActualizarTotal();
                NotificarEstadoSesionCambiado();
            }
               
        }

        private void rb4M_CheckedChanged(object sender, EventArgs e)
        {
            if (restaurando)
            {
                return;
            }

            if (rb4M.Checked && sesion != null)
            {
                sesion.CambiarTarifa(TipoTarifa.M4);
                Mostrar4M();
                ActualizarTotal();
                NotificarEstadoSesionCambiado();
            }
                
        }

        private void rbLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (restaurando)
            {
                return;
            }

            if (rbLibre.Checked)
            {
                aumentar1HoraToolStripMenuItem.Enabled = false;
                aumentar30MinToolStripMenuItem.Enabled = false;  
                aumentar5MinToolStripMenuItem.Enabled = false;

                if (sesion != null)
                {
                    sesion.CambiarALibre();
                    lblTiempoLimite.Text = "ILIMITADO";
                    lblTiempoJugado.Text = "00:00:00";
                    CentrarControl(lblTiempoLimite);
                    CentrarControl(lblTiempoJugado);
                    if (rb2M.Checked)
                        Mostrar2M();
                    if (rb3M.Checked)
                        Mostrar3M();
                    if (rb4M.Checked)
                        Mostrar4M();

                    if ((sesion.Cronometro.Pausado) ||
                            (sesion.Cronometro.TiempoTranscurrido == sesion.TiempoLimite))
                    {
                        sesion.Cronometro.Reanudar();
                       
                        timer.Start();
                        btnIniciar.Text = "Pausar";
                    }

                    NotificarEstadoSesionCambiado();
                }


            }
        }

        private void rbLimitado_CheckedChanged(object sender, EventArgs e)
        {
            if (restaurando)
                return;
            
            // =====================
            // SOLO SI EXISTE SESION
            // =====================


            if (!rbLimitado.Checked
                || sesion == null)
            {
                return;
            }



            // =====================
            // PEDIR TIEMPO
            // =====================
            frm.Text = "Tiempo a jugar";
            if (frm.ShowDialog()
                == DialogResult.OK)
            {
                TimeSpan tiempo =
                    new TimeSpan(
                        frm.Horas,
                        frm.Minutos,
                        0);

                sesion.CambiarALimitado(
                    tiempo);

                lblTiempoLimite.Text =
                    sesion.TiempoLimite
                    .ToString(@"hh\:mm\:ss");
                CentrarControl(lblTiempoLimite);

                aumentar1HoraToolStripMenuItem.Enabled = true;
                aumentar30MinToolStripMenuItem.Enabled = true;
                aumentar5MinToolStripMenuItem.Enabled = true;
                NotificarEstadoSesionCambiado();
            }
            else
            {
                rbLibre.Checked = true;
            }
        }

        private void lblTiempoLimite_Click(object sender, EventArgs e)
        {
            if (lblTiempoLimite.Text != "ILIMITADO")
            {
                frm.Text = "Agregar tiempo";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TimeSpan tiempo = new TimeSpan(frm.Horas, frm.Minutos, 0);
                    sesion.AgregarTiempo(tiempo);
                    timer.Start();
                    sesion.Cronometro.Reanudar();
                    
                    lblTiempoLimite.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
                    btnIniciar.Text = "Pausar";
                    if (rb2M.Checked)
                        Mostrar2M();
                    if (rb3M.Checked)
                        Mostrar3M();
                    if (rb4M.Checked)
                        Mostrar4M();

                    NotificarEstadoSesionCambiado();
                }

            }
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTiempoJugado_Click(object sender, EventArgs e)
        {

        }

        private void ucPS4_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pnlPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            // =====================
            // SOLO CLICK IZQUIERDO
            // =====================

            if (e.Button
                != MouseButtons.Left)
            {
                return;
            }

            // =====================
            // SIN SESION
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // INICIAR DRAG
            // =====================

            DoDragDrop(
                this,
                DragDropEffects.Move);
        }

        private void btn1H_Click(
    object sender,
    EventArgs e)
        {
           
        }
        private void rbLimitado_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // =====================
            // EVITAR DURANTE RESTAURACION
            // =====================

            if (restaurando)
            {
                return;
            }

            // =====================
            // SI YA EXISTE SESION
            // =====================

            if (sesion != null)
            {
                return;
            }

            // =====================
            // TIEMPO
            // =====================

            TimeSpan tiempo =
                TimeSpan.FromHours(1);

            // =====================
            // CREAR SESION
            // =====================

            sesion =
                new Sesion(
                    ObtenerTarifaSeleccionada(),
                    usuarioInvitado);
            CongelarTarifasSesion();

            // =====================
            // INICIAR LIMITADO
            // =====================

            sesion.IniciarLimitado(
                tiempo);

            // =====================
            // UI
            // =====================
            restaurando = true;
            rbLimitado.Checked =
                true;
            restaurando = false;

            lblTiempoLimite.Text =
                tiempo.ToString(
                    @"hh\:mm\:ss");

            btnIniciar.Text =
                "Pausar";

            timer.Start();

            AplicarColorTarifaSeleccionada();

            Sonidos.Reproducir("inicio.wav");

            CentrarControl(
                lblTiempoLimite);

            NotificarEstadoSesionCambiado();
        }

        private void lbl30M_Click(object sender, EventArgs e)
        {
            // =====================
            // EVITAR DURANTE RESTAURACION
            // =====================

            if (restaurando)
            {
                return;
            }

            // =====================
            // SI YA EXISTE SESION
            // =====================

            if (sesion != null)
            {
                return;
            }

            // =====================
            // TIEMPO
            // =====================

            TimeSpan tiempo =
                TimeSpan.FromMinutes(30);

            // =====================
            // CREAR SESION
            // =====================

            sesion =
                new Sesion(
                    ObtenerTarifaSeleccionada(),
                    usuarioInvitado);
            CongelarTarifasSesion();

            // =====================
            // INICIAR LIMITADO
            // =====================

            sesion.IniciarLimitado(
                tiempo);

            // =====================
            // UI
            // =====================
            restaurando = true;
            rbLimitado.Checked =
                true;
            restaurando = false;

            lblTiempoLimite.Text =
                tiempo.ToString(
                    @"hh\:mm\:ss");

            btnIniciar.Text =
                "Pausar";

            timer.Start();

            AplicarColorTarifaSeleccionada();

            Sonidos.Reproducir("inicio.wav");

            CentrarControl(
                lblTiempoLimite);

            NotificarEstadoSesionCambiado();
        }

        private void AgregarTiempoLimite(
            TimeSpan tiempoExtra)
        {
            if (sesion == null)
            {
                return;
            }

            if (sesion.Modo == ModoSesion.Libre)
            {
                sesion.CambiarALimitado(
                    sesion.Cronometro.TiempoTranscurrido
                    + tiempoExtra);

                restaurando = true;
                rbLimitado.Checked =
                    true;
                restaurando = false;
            }
            else
            {
                sesion.AgregarTiempo(
                    tiempoExtra);
            }

            lblTiempoLimite.Text =
                sesion.TiempoLimite
                .ToString(@"hh\:mm\:ss");

            if (sesion.Cronometro.Pausado)
            {
                sesion.Cronometro
                    .Reanudar();

                timer.Start();

                btnIniciar.Text =
                    "Pausar";

                AplicarColorTarifaSeleccionada();

                Sonidos.Reproducir("inicio.wav");
            }

            CentrarControl(
                lblTiempoLimite);

            NotificarEstadoSesionCambiado();
        }

        private void lbl30Mplus_Click(object sender, EventArgs e)
        {
            AgregarTiempoLimite(
                TimeSpan.FromMinutes(30));
        }

        private void lbl1Hplus_Click(object sender, EventArgs e)
        {
            AgregarTiempoLimite(
                TimeSpan.FromHours(1));
        }

        private void venderProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sesion == null)
            {
                MessageBox.Show(
                    "El equipo no tiene sesión activa.");

                return;
            }

         
            // =====================
            // FORM
            // =====================

            frmVentaProductos frm =
                new frmVentaProductos(
                    Estacion.NumeroEquipo.ToString());

            frm.ShowDialog();

            NotificarEstadoSesionCambiado();
        }

        public decimal ObtenerTotalTiempo()
        {
            // =====================
            // VALIDAR
            // =====================

            if (sesion == null)
            {
                return 0;
            }

            // =====================
            // CALCULAR
            // =====================

            return calc.CalcularCosto(
                ObtenerEstacionCalculo(),
                sesion.TarifaInicial,
                sesion.HistorialTarifas,
                sesion.Cronometro
                    .TiempoTranscurrido);
        }
        private void lblTotal_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // FORM
            // =====================

            frmDetalleSesion frm =
                new frmDetalleSesion(
                    sesion,
                    this);

            frm.ShowDialog();
        }

        private void iniciar30MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // =====================
            // EVITAR DURANTE RESTAURACION
            // =====================

            if (restaurando)
            {
                return;
            }

            iniciar1HoraToolStripMenuItem.Enabled = false;
            iniciar30MinToolStripMenuItem.Enabled = false;
            aumentar1HoraToolStripMenuItem.Enabled = true;
            aumentar30MinToolStripMenuItem.Enabled = true;
            aumentar5MinToolStripMenuItem.Enabled = true;

            // =====================
            // SI YA EXISTE SESION
            // =====================

            if (sesion != null)
            {
                return;
            }

            // =====================
            // TIEMPO
            // =====================

            TimeSpan tiempo =
                TimeSpan.FromMinutes(30);

            // =====================
            // CREAR SESION
            // =====================

            sesion =
                new Sesion(
                    ObtenerTarifaSeleccionada(),
                    usuarioInvitado);
            CongelarTarifasSesion();

            // =====================
            // INICIAR LIMITADO
            // =====================

            sesion.IniciarLimitado(
                tiempo);

            // =====================
            // UI
            // =====================
            restaurando = true;
            rbLimitado.Checked =
                true;
            restaurando = false;

            lblTiempoLimite.Text =
                tiempo.ToString(
                    @"hh\:mm\:ss");

            btnIniciar.Text =
                "Pausar";

            timer.Start();

            AplicarColorTarifaSeleccionada();

            Sonidos.Reproducir("inicio.wav");

            CentrarControl(
                lblTiempoLimite);
        }

        private void iniciar1HoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // =====================
            // EVITAR DURANTE RESTAURACION
            // =====================

            if (restaurando)
            {
                return;
            }

            iniciar1HoraToolStripMenuItem.Enabled = false;
            iniciar30MinToolStripMenuItem.Enabled = false;
            aumentar1HoraToolStripMenuItem.Enabled = true;
            aumentar30MinToolStripMenuItem.Enabled = true;
            aumentar5MinToolStripMenuItem.Enabled = true;

            // =====================
            // SI YA EXISTE SESION
            // =====================

            if (sesion != null)
            {
                return;
            }

            // =====================
            // TIEMPO
            // =====================

            TimeSpan tiempo =
                TimeSpan.FromHours(1);

            // =====================
            // CREAR SESION
            // =====================

            sesion =
                new Sesion(
                    ObtenerTarifaSeleccionada(),
                    usuarioInvitado);
            CongelarTarifasSesion();

            // =====================
            // INICIAR LIMITADO
            // =====================

            sesion.IniciarLimitado(
                tiempo);

            // =====================
            // UI
            // =====================
            restaurando = true;
            rbLimitado.Checked =
                true;
            restaurando = false;

            lblTiempoLimite.Text =
                tiempo.ToString(
                    @"hh\:mm\:ss");

            btnIniciar.Text =
                "Pausar";

            timer.Start();

            AplicarColorTarifaSeleccionada();

            Sonidos.Reproducir("inicio.wav");


            CentrarControl(
                lblTiempoLimite);

            NotificarEstadoSesionCambiado();
        }

        private void aumentar30MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarTiempoLimite(
                TimeSpan.FromMinutes(30));
        }

        private void aumentar1HoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarTiempoLimite(
               TimeSpan.FromHours(1));
        }

        private void GestionarNota()
        {
            // =====================
            // VALIDAR SESION
            // =====================

            if (sesion == null)
            {
                MessageBox.Show(
                    "No existe una sesión activa.");

                return;
            }

            // =====================
            // FORMULARIO
            // =====================

            frmNota frm =
                new frmNota(
                    sesion.Nota);

            if (frm.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            // =====================
            // ELIMINAR
            // =====================

            if (frm.EliminarNota)
            {
                sesion.Nota = "";
            }

            else
            {
                sesion.Nota =
                    frm.Nota;
            }

            // =====================
            // REFRESCAR
            // =====================

            ActualizarIndicadorNota();
            NotificarEstadoSesionCambiado();
        }

        private void mnuAgregarNota_Click(object sender, EventArgs e)
        {
            GestionarNota();
        }

        private void pbNota_Click(object sender, EventArgs e)
        {
            GestionarNota();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            
        }

        private void lblNombre_DoubleClick(object sender, EventArgs e)
        {
            if (pagado)
            {
                lblNombre.BackColor = Color.White;
                pagado = false;
            }
            else
            {
                lblNombre.BackColor = Color.Fuchsia;
                pagado = true;
            }
            
        }

        private void aumentar5MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarTiempoLimite(
                TimeSpan.FromMinutes(5));
        }

        private void pbCarrito_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // FORM
            // =====================

            frmDetalleSesion frm =
                new frmDetalleSesion(
                    sesion,
                    this);

            frm.ShowDialog();
        }
    }
    
}
