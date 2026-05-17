using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay
{
    public partial class ucPS4 : UserControl
    {
        private Sesion sesion;
        private CalculadoraCobro calc = new CalculadoraCobro();
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
        private GestorUsuarios gestorUsuarios;
        private Usuario usuarioInvitado = new Usuario("Invitado", "Cliente invitado", "");
        frmPedirTiempo frm = new frmPedirTiempo();
        public event Action CobroRealizado;
        public string NombreConsola { get; set; }

        public ucPS4(GestorUsuarios gestor)
        {
            InitializeComponent();
            gestorUsuarios = gestor;
            this.Size = new Size(400, 300);
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

            bntIniciar.Text =
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

                bntIniciar.Text = "Pausar";

                return;
            }

            // =========================
            // PAUSAR
            // =========================

            if (sesion.Cronometro.EnEjecucion && !sesion.Cronometro.Pausado)
            {
                sesion.Cronometro.Pausar();

                timer.Stop();

                bntIniciar.Text = "Reanudar";
            }

            // =========================
            // REANUDAR
            // =========================

            else
            {
                sesion.Cronometro.Reanudar();

                timer.Start();

                bntIniciar.Text = "Pausar";

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

                bntIniciar.Text = "Continuar";

                // ======================
                // OPCIONAL
                // ======================

                MessageBox.Show("Tiempo agotado");
            }

            decimal total = calc.CalcularCosto(sesion.TarifaInicial, sesion.HistorialTarifas,
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
                        bntIniciar.Text = "Pausar";
                    }
                }


            }
        }

        private void rbLimitado_CheckedChanged(object sender, EventArgs e)
        {
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
    }
}
