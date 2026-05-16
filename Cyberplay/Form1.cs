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
        Sesion sesion;
        Cronometro ps5 = new Cronometro();     
        frmPedirTiempo frm = new frmPedirTiempo();
        CalculadoraCobro calc = new CalculadoraCobro();
        private Usuario usuarioInvitado = new Usuario("Invitado");      
        private List<Usuario> usuarios = new List<Usuario>()
        {
        new Usuario("pepito1"),
        new Usuario("pepito2"),
        new Usuario("pepito3")
        };

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // =========================
            // NO EXISTE SESION
            // =========================

            if (sesion == null)
            {
                // =====================
                // OBTENER TARIFA
                // =====================

                TipoTarifa tarifa =
                    ObtenerTarifaSeleccionada();

                // =====================
                // CREAR SESION
                // =====================

                sesion =
                    new Sesion(tarifa, usuarioInvitado);

                // =====================
                // TIEMPO LIBRE
                // =====================

                if (rbps5Libre.Checked)
                {
                    sesion.IniciarLibre();
                }

                // =====================
                // TIEMPO LIMITADO
                // =====================

                else if (rbps5Limitado.Checked)
                {
                    if (frm.ShowDialog()
            == DialogResult.OK)
                    {
                        TimeSpan tiempo =
                            new TimeSpan(
                                frm.Horas,
                                frm.Minutos,
                                0);

                        sesion.IniciarLimitado(
                            tiempo);

                        lblps5Tiempo.Text =
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

                btnps5Control.Text = "Pausar";

                return;
            }

            // =========================
            // PAUSAR
            // =========================

            if (sesion.Cronometro.EnEjecucion && !sesion.Cronometro.Pausado)
            {
                sesion.Cronometro.Pausar();

                timer.Stop();

                btnps5Control.Text = "Reanudar";
            }

            // =========================
            // REANUDAR
            // =========================

            else
            {
                sesion.Cronometro.Reanudar();

                timer.Start();

                btnps5Control.Text = "Pausar";
            
                if (sesion.TiempoRestante <= TimeSpan.Zero)
                {
                     rbps5Libre.Checked = true;
                }
            }
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

            lblUsuario.Text = sesion.UsuarioActual.Nombre;

            if (sesion.Modo == ModoSesion.Libre)
            {
                lblps5Crono.Text = sesion
                    .Cronometro
                    .TiempoTranscurrido
                    .ToString(@"hh\:mm\:ss");
            }

            // =====================
            // TIEMPO LIMITADO
            // =====================

            else
            {
                lblps5Crono.Text = sesion
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

                btnps5Control.Text = "Continuar";

                // ======================
                // OPCIONAL
                // ======================

                MessageBox.Show("Tiempo agotado");
            }

            decimal total = calc.CalcularCosto(sesion.TarifaInicial, sesion.HistorialTarifas,
                            sesion.Cronometro.TiempoTranscurrido);

            lblps5Total.Text = "Bs. " + total.ToString("0.0");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public TipoTarifa ObtenerTarifaSeleccionada()
        {
            if (rbps52M.Checked)
            {
                return TipoTarifa.M2;
            }

            if (rbps53M.Checked)
            {
                return TipoTarifa.M3;
            }

            return TipoTarifa.M4;
        }

        /*private void tbps5Minutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int valor = int.Parse(tbps5Minutos.Text);

                // sesion.AgregarTiempo(TimeSpan.FromMinutes(valor));
                sesion.CambiarALimitado(TimeSpan.FromMinutes(valor));
                lblps5Tiempo.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");

                if (btnps5Control.Text == "Iniciar")
                {
                    btnps5Control.PerformClick();
                }
            }
        }*/

        private void rbps5Libre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbps5Libre.Checked)
            {
                if (sesion != null)
                {
                    sesion.CambiarALibre();
                    lblps5Tiempo.Text = "ILIMITADO";

                    if ((sesion.Cronometro.Pausado) ||
                            (sesion.Cronometro.TiempoTranscurrido == sesion.TiempoLimite))
                    {
                        sesion.Cronometro.Reanudar();
                        timer.Start();
                        btnps5Control.Text = "Pausar";
                    }
                }
                

            }
        }

        private void lblps5Tiempo_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void lblps5Tiempo_Click(object sender, EventArgs e)
        {
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TimeSpan tiempo = new TimeSpan(frm.Horas, frm.Minutos, 0);
                sesion.AgregarTiempo(tiempo);
                timer.Start();
                sesion.Cronometro.Reanudar();
                lblps5Tiempo.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
                btnps5Control.Text = "Pausar";
            }
            
        }

        private void rbps5Limitado_CheckedChanged(object sender, EventArgs e)
        {
            // =====================
            // SOLO SI EXISTE SESION
            // =====================
            

            if (!rbps5Limitado.Checked
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

                lblps5Tiempo.Text =
                    sesion.TiempoLimite
                    .ToString(@"hh\:mm\:ss");
            }
            else
            {
                rbps5Libre.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sesion.CambiarTarifa(TipoTarifa.M3);
            MessageBox.Show("Nueva Tarifa M3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sesion.CambiarTarifa(TipoTarifa.M4);
            MessageBox.Show("Nueva Tarifa M4");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var cambio in sesion.HistorialTarifas)
            {
                MessageBox.Show(
                    cambio.TiempoCambio.ToString(@"hh\:mm\:ss"));
            }
        }

        private void rbps52M_CheckedChanged(object sender, EventArgs e)
        {
            if (rbps52M.Checked && sesion != null) 
                sesion.CambiarTarifa(TipoTarifa.M2);
        }

        private void rbps53M_CheckedChanged(object sender, EventArgs e)
        {
            if (rbps53M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M3);
        }

        private void rbps54M_CheckedChanged(object sender, EventArgs e)
        {
            if (rbps54M.Checked && sesion != null)
                sesion.CambiarTarifa(TipoTarifa.M4);  
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            if (sesion == null)
            {
                return;
            }

            // =====================
            // PRUEBA
            // =====================

            sesion.CambiarUsuario(usuarios[0]);
        }
    }
}
