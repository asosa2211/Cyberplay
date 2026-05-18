using Cyberplay.Core;
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
using System.Media;

namespace Cyberplay
{
    public partial class ucPS4 : UserControl
    {
        private bool restaurando = false;
        private Estacion estacion;

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
        private Sesion sesion;
        private CalculadoraCobro calc = new CalculadoraCobro();
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
        private PersistenciaCaja persistenciaCaja = new PersistenciaCaja();
        private GestorUsuarios gestorUsuarios;
        private Usuario usuarioInvitado = new Usuario("invitado", "Cliente invitado", "");
        frmPedirTiempo frm = new frmPedirTiempo();
        public event Action CobroRealizado;
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

                string[] partes =
            value.Split('-');

                lblNombre.Text =
                    partes[
                        partes.Length - 1];
            }
        }

        private void SonidoIniciar()
        {
            SystemSounds.Asterisk.Play();
        }

        private void SonidoPausar()
        {
            SystemSounds.Beep.Play();
        }

        private void SonidoReanudar()
        {
            SystemSounds.Exclamation.Play();
        }

        private void SonidoTiempoTerminado()
        {
            SystemSounds.Hand.Play();
        }
        private void MostrarLibre()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#E3E3E3");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#E3E3E3");
        }

        private void MostrarActivo()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#11BDED");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#11BDED");
        }

        private void MostrarPausado()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#DFBFF2");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#DFBFF2");
        }

        private void Mostrar2M()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#11BDED");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#11BDED");
        }

        private void Mostrar3M()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#E9ED1F");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#E9ED1F");
        }

        private void Mostrar4M()
        {
            pnlPrincipal.BackColor = ColorTranslator.FromHtml("#2DED1F");
            pnlTarifas.BackColor = ColorTranslator.FromHtml("#2DED1F");
        }





        private void CentrarControl(Control control)
        {
            control.Left = (pnlPrincipal.Width - control.Width) / 2;
        }

        public ucPS4(GestorUsuarios gestor, Estacion est)
        {
            InitializeComponent();
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
            switch (estacion.Tipo)
            {
                case TipoEstacion.PS4:
                    BackColor =
                        Color.LightBlue;
                    break;

                case TipoEstacion.PS5:
                    BackColor =
                        Color.LightGreen;
                    break;

                case TipoEstacion.PC:
                    BackColor =
                        Color.LightYellow;
                    break;
            }
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
            CentrarControl(lblTotal);
            
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

            lblUsuario.Text =
                "invitado";

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
                MostrarActivo();
                SonidoIniciar();
                //OBTENER TARIFA
                TipoTarifa tarifa = ObtenerTarifaSeleccionada();

                //CREAR SESION
                sesion = new Sesion(tarifa, usuarioInvitado);

                //TIEMPO LIBRE
                if (rbLibre.Checked)
                {
                    sesion.IniciarLibre();
                    if (rb2M.Checked)
                        Mostrar2M();
                    if (rb3M.Checked)
                        Mostrar3M();
                    if (rb4M.Checked)
                        Mostrar4M();
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

                        sesion.IniciarLimitado(
                            tiempo);

                        lblTiempoLimite.Text =
                            sesion.TiempoLimite
                            .ToString(@"hh\:mm\:ss");
                        CentrarControl(lblTiempoLimite);
                        if (rb2M.Checked)
                            Mostrar2M();
                        if (rb3M.Checked)
                            Mostrar3M();
                        if (rb4M.Checked)
                            Mostrar4M();
                    }
                    else
                    {
                        // =================
                        // CANCELÓ
                        // =================

                        sesion = null;

                        return;
                    }
                }

                // =====================
                // INICIAR TIMER
                // =====================

                timer.Start();

                btnIniciar.Text = "Pausar";

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
                SonidoPausar();
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
                SonidoReanudar();

                if (sesion.TiempoRestante <= TimeSpan.Zero)
                {
                    rbLibre.Checked = true;
                }
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
                calc.CalcularCosto(Estacion,
    sesion.TarifaInicial,
    sesion.HistorialTarifas, tiempoFinal);

            RegistroCobro cobro =
    new RegistroCobro(
        sesion.UsuarioActual
            .NombreCuenta,

        DateTime.Now,

        tiempoFinal,

        total,

        sesion.TarifaActual, SesionSistema.CajeroActual.Usuario);

            persistenciaCobros.GuardarCobro(cobro);

            SesionSistema.CajaActual.TotalCobrado += total;

            persistenciaCaja.GuardarCaja(SesionSistema.CajaActual);

            Application.DoEvents();
            CobroRealizado?.Invoke();


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
        }

        public void RestaurarEstado(
    EstadoSesion estado)
        {
            restaurando = true;
            // =====================
            // VALIDAR
            // =====================

            if (!estado.SesionActiva)
            {
                restaurando = false;
                MostrarLibre();
                return;
            }

            // =====================
            // BUSCAR USUARIO
            // =====================

            Usuario usuario =
                gestorUsuarios
                    .ObtenerUsuarios()
                    .FirstOrDefault(
                        u =>
                        u.NombreCuenta ==
                        estado.Usuario);

            // =====================
            // SI NO EXISTE
            // =====================

            if (usuario == null)
            {
                usuario =
                    usuarioInvitado;
            }

            // =====================
            // CREAR SESION
            // =====================

            sesion =
                new Sesion(
                    estado.Tarifa,
                    usuario);

            // =====================
            // MODO
            // =====================

            if (estado.Modo
                == ModoSesion.Libre)
            {
                sesion.IniciarLibre();
            }
            else
            {
                sesion.IniciarLimitado(
                    estado.TiempoLimite);

                lblTiempoLimite.Text =
                    estado.TiempoLimite
                    .ToString(@"hh\:mm\:ss");
            }

            // =====================
            // RESTAURAR TIEMPO
            // =====================

            sesion.Cronometro
                .TiempoAcumulado =
                    estado.TiempoTranscurrido;

            // =====================
            // SESION PAUSADA
            // =====================

            if (estado.Pausado)
            {
                sesion.Cronometro
                    .Pausar();

                lblCronometro.Text =
                    estado.TiempoTranscurrido
                        .ToString(@"hh\:mm\:ss");

                btnIniciar.Text =
                    "Reanudar";
                MostrarPausado();
            }

            // =====================
            // SESION ACTIVA
            // =====================

            else
            {
                // =====================
                // CALCULAR TIEMPO APAGADO
                // =====================

                TimeSpan tiempoApagado =
                    DateTime.Now -
                    estado.HoraPausa;

                // =====================
                // SUMAR TIEMPO APAGADO
                // =====================

                sesion.Cronometro
                    .TiempoAcumulado +=
                        tiempoApagado;

                // =====================
                // REINICIAR BASE
                // =====================

                sesion.Cronometro
                    .HoraInicio =
                        DateTime.Now;

                timer.Start();

                btnIniciar.Text =
                    "Pausar";

                MostrarActivo();
            }

            // =====================
            // USUARIO
            // =====================

            lblUsuario.Text =
                usuario.NombreCuenta;

            // =====================
            // TARIFA UI
            // =====================

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

            // =====================
            // MODO UI
            // =====================

            if (estado.Modo
                == ModoSesion.Libre)
            {
                rbLibre.Checked = true;
            }
            else
            {
                rbLimitado.Checked = true;
            }
            restaurando = false;
        }

        public EstadoSesion
    ObtenerEstado()
        {
            EstadoSesion estado =
                new EstadoSesion();

            estado.NombreConsola =
                NombreConsola;

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

            estado.Modo =
                sesion.Modo;

            estado.HoraInicio =
                sesion.Cronometro
                    .HoraInicio;

            estado.TiempoLimite =
                sesion.TiempoLimite;

            estado.Pausado =
                sesion.Cronometro
                    .Pausado;

            estado.HoraPausa =
                 DateTime.Now;

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
                SonidoTiempoTerminado();
                MostrarPausado();

                // ======================
                // OPCIONAL
                // ======================

                MessageBox.Show("Tiempo agotado");
            }

            decimal total = calc.CalcularCosto(
    Estacion,
    sesion.TarifaInicial,
    sesion.HistorialTarifas,
    sesion.Cronometro.TiempoTranscurrido);

            lblTotal.Text = "Bs. " + total.ToString("0.0");
            CentrarControl(lblTotal);
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
            }
        }

        private void rb2M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2M.Checked && sesion != null)
            {
                sesion.CambiarTarifa(TipoTarifa.M2);
                Mostrar2M();
            }
                
        }

        private void rb3M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3M.Checked && sesion != null)
            {
                sesion.CambiarTarifa(TipoTarifa.M3);
                Mostrar3M();
            }
               
        }

        private void rb4M_CheckedChanged(object sender, EventArgs e)
        {

            if (rb4M.Checked && sesion != null)
            {
                sesion.CambiarTarifa(TipoTarifa.M4);
                Mostrar4M();    
            }
                
        }

        private void rbLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLibre.Checked)
            {
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
                }

            }
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTiempoJugado_Click(object sender, EventArgs e)
        {

        }
    }
}
