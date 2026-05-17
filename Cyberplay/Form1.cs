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

        public frmPrincipal()
        {
            InitializeComponent();
            CrearConsolas();
            CargarUsuarios();
            RestaurarSesiones();
            ActualizarCaja();
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

            for (int i = 1; i <= 9; i++)
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

                x += consola.Width + 5;

                // =====================
                // SALTO FILA
                // =====================

                if (i % 3 == 0)
                {
                    x = 20;

                    y += consola.Height + 5;
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
                persistenciaCobros
                    .ObtenerTotalCobrado();

            lblCaja.Text =
                total.ToString("0.00")
                + " Bs";
        }
        /*public TipoTarifa ObtenerTarifaSeleccionada()
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
        }*/

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

        /*private void rbps5Libre_CheckedChanged(object sender, EventArgs e)
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
        }*/

        private void lblps5Tiempo_MouseUp(object sender, MouseEventArgs e)
        {

        }

        /*private void lblps5Tiempo_Click(object sender, EventArgs e)
        {
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TimeSpan tiempo = new TimeSpan(frm.Horas, frm.Minutos, 0);
                sesion.AgregarTiempo(tiempo);
                timer.Start();
                sesion.Cronometro.Reanudar();
                lblTiempoLimite.Text = sesion.TiempoLimite.ToString(@"hh\:mm\:ss");
                bntIniciar.Text = "Pausar";
            }
            
        }*/

       /* private void rbps5Limitado_CheckedChanged(object sender, EventArgs e)
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
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            frmHistorialCobros frm =
        new frmHistorialCobros();

            frm.ShowDialog();
        }

       /* private void button2_Click(object sender, EventArgs e)
        {
            sesion.CambiarTarifa(TipoTarifa.M4);
            MessageBox.Show("Nueva Tarifa M4");
        }*/

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

    }
    
}
