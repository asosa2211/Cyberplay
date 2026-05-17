using Cyberplay.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Sesion sesion;
        private CalculadoraCobro calc = new CalculadoraCobro();
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
        private GestorUsuarios gestorUsuarios;
        private Usuario usuarioInvitado = new Usuario("Invitado", "Cliente invitado", "");
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

                lblNombre.Text =
                    value.Replace(
                        "PS4-",
                        "");
            }
        }

        public ucPS4(GestorUsuarios gestor, Estacion est)
        {
            InitializeComponent();
            gestorUsuarios = gestor;
            estacion = est;
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
        private void bntIniciar_Click(object sender, EventArgs e)
        {
            //SI NO EXISTE SESIÓN
            if (sesion == null)
            {
                //OBTENER TARIFA
                TipoTarifa tarifa = ObtenerTarifaSeleccionada();

                //CREAR SESION
                sesion = new Sesion(tarifa, usuarioInvitado);

                //TIEMPO LIBRE
                if (rbLibre.Checked)
                {
                    sesion.IniciarLibre();
                }

                //TIEMPO LIMITADO
                else if (rbLimitado.Checked)
                {
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
            }

            // =========================
            // REANUDAR
            // =========================

            else
            {
                sesion.Cronometro.Reanudar();

                timer.Start();

                btnIniciar.Text = "Pausar";

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

            persistenciaCobros
    .GuardarCobro(
        cobro);
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
            // lblps5Crono.Text = ps5.TiempoTranscurrido.ToString(@"hh\:mm\:ss");
            //lblps6Crono.Text = ps6.TiempoTranscurrido.ToString(@"hh\:mm\:ss");
            // =====================
            // TIEMPO LIBRE
            // =====================
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
            }
        }

        private void rb2M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M2);
        }

        private void rb3M_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M3);
        }

        private void rb4M_CheckedChanged(object sender, EventArgs e)
        {

            if (rb4M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M4);
        }

        private void rbLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLibre.Checked)
            {
                if (sesion != null)
                {
                    sesion.CambiarALibre();
                    lblTiempoLimite.Text = "ILIMITADO";

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
            }
            else
            {
                rbLibre.Checked = true;
            }
        }

        private void lblTiempoLimite_Click(object sender, EventArgs e)
        {
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TimeSpan tiempo = new TimeSpan(frm.Horas, frm.Minutos, 0);
                sesion.AgregarTiempo(tiempo);
                timer.Start();
                sesion.Cronometro.Reanudar();
                lblTiempoLimite.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
                btnIniciar.Text = "Pausar";
            }
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
