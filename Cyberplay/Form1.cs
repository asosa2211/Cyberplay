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
        Cronometro ps5 = new Cronometro();
        Sesion sesion = new Sesion();
        frmPedirTiempo frm = new frmPedirTiempo();
        CalculadoraCobro calc = new CalculadoraCobro();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // =======================
            // INICIAR
            // =========================

            if (!sesion.Cronometro.EnEjecucion)
            {
                // =====================
                // TIEMPO LIBRE
                // =====================

                if (rbps5Libre.Checked)
                {
                    sesion.IniciarLibre();
                    lblps5Tiempo.Text = "ILIMITADO";
                }

                // =====================
                // TIEMPO LIMITADO
                // =====================

                else if (rbps5Limitado.Checked)
                {
                    /*if (!int.TryParse(tbps5Minutos.Text, out int minutos))
                    {
                        MessageBox.Show("Ingrese minutos válidos");
                        return;
                    }

                    if (minutos <= 0)
                    {
                        MessageBox.Show("Los minutos deben ser mayores a 0");
                        return;
                    }*/

                    sesion.IniciarLimitado(
                        TimeSpan.FromMinutes(60));
                    lblps5Tiempo.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
                }

                timer.Start();
                btnps5Control.Text = "Pausar";
                return;
            }

            // =========================
            // PAUSAR
            // =========================

            if (!sesion.Cronometro.Pausado)
            {
                sesion.Cronometro.Pausar();

                btnps5Control.Text = "Reanudar";

                return;
            }

            // =========================
            // REANUDAR
            // =========================

            sesion.Cronometro.Reanudar();
            btnps5Control.Text = "Pausar";
            timer.Start();
            if (sesion.TiempoRestante <= TimeSpan.Zero)
            {
                rbps5Libre.Checked = true;
            }
        }
           

        private void timer_Tick(object sender, EventArgs e)
        {
            // lblps5Crono.Text = ps5.TiempoTranscurrido.ToString(@"hh\:mm\:ss");
            //lblps6Crono.Text = ps6.TiempoTranscurrido.ToString(@"hh\:mm\:ss");
            // =====================
            // TIEMPO LIBRE
            // =====================

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

            decimal total = calc.CalcularCosto(TipoTarifa.M2, sesion.HistorialTarifas,
                            sesion.Cronometro.TiempoTranscurrido);

            lblps5Total.Text = "Bs. " + total.ToString("0.0");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (rbps5Limitado.Checked)
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TimeSpan tiempo = new TimeSpan(frm.Horas, frm.Minutos, 0);
                    if (sesion.Cronometro.TiempoTranscurrido > TimeSpan.Zero)
                        sesion.CambiarALimitado(tiempo);
                    else
                        sesion.IniciarLimitado(tiempo);
                    if (sesion.Cronometro.Pausado)
                        sesion.Cronometro.Reanudar();
                    timer.Start();
                    lblps5Tiempo.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
                    btnps5Control.Text = "Pausar";
                }
                else 
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
    }
}
