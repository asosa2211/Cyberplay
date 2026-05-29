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
    public partial class frmNota : Form
    {
        public string Nota
        {
            get;
            private set;
        }

        public bool EliminarNota
        {
            get;
            private set;
        }
        public frmNota()
        {
            InitializeComponent();
        }

        public frmNota(
    string notaActual)
        {
            InitializeComponent();

            tbNota.Text =
                notaActual;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Nota =
        tbNota.Text.Trim();

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
       MessageBox.Show(
           "¿Desea eliminar la nota?",
           "Confirmar",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question)
       != DialogResult.Yes)
            {
                return;
            }

            EliminarNota = true;

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult =
        DialogResult.Cancel;

            Close();
        }
    }
}
