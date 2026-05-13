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
        Cronometro ps6 = new Cronometro();
        Sesion sesion = new Sesion();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // =========================
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
                    lblps5Tiempo.Text = "Ilimitado";
                }

                // =====================
                // TIEMPO LIMITADO
                // =====================

                else if (rbps5Limitado.Checked)
                {
                    if (!int.TryParse(tbps5Minutos.Text, out int minutos))
                    {
                        MessageBox.Show("Ingrese minutos válidos");
                        return;
                    }

                    if (minutos <= 0)
                    {
                        MessageBox.Show("Los minutos deben ser mayores a 0");
                        return;
                    }

                    sesion.IniciarLimitado(
                        TimeSpan.FromMinutes(minutos));
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnps6Control_Click(object sender, EventArgs e)
        {
            if (!ps6.EnEjecucion)
            {
                ps6.Iniciar();
                timer.Start();
                btnps6Control.Text = "Pausar";
                return;
            }

            // PAUSAR

            if (!ps6.Pausado)
            {
                ps6.Pausar();
                btnps6Control.Text = "Reanudar";
                return;
            }

            // REANUDAR

            ps6.Reanudar();
            btnps6Control.Text = "Pausar";
        }

        private void btnps5Ok_Click(object sender, EventArgs e)
        {
            sesion.AgregarTiempo(TimeSpan.FromMinutes(int.Parse(tbps5Minutos.Text)));
            lblps5Tiempo.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
        }
    }
}
