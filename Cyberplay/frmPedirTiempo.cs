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
    public partial class frmPedirTiempo : Form
    {
        public int Horas { get; private set; }
        public int Minutos { get; private set; }
        public frmPedirTiempo()
        {
            InitializeComponent();
        }

        private void frmPedirTiempo_Load(object sender, EventArgs e)
        {
            cbHora.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5 });
            cbMin.Items.AddRange(new object[] { 0, 1, 15, 30, 45 });
            cbHora.SelectedIndex = 0;
            cbMin.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Horas = Convert.ToInt32(cbHora.SelectedItem);
            Minutos = Convert.ToInt32(cbMin.SelectedItem);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
