using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmEspera : Form
    {
        public frmEspera()
        {
            InitializeComponent();
        }

        public static frmEspera Mostrar(
        string mensaje)
        {
            frmEspera frm =
                new frmEspera();

            frm.lblMensaje.Text =
                mensaje;

            frm.Show();

            Application.DoEvents();

            return frm;
        }
    }
}
