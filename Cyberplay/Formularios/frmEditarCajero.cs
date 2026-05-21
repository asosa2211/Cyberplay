using Cyberplay.enums;
using Cyberplay.Modelos;
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
    public partial class frmEditarCajero : Form
    {
        public Cajero CajeroCreado{ get; private set; }

      
        public frmEditarCajero()
        {
            InitializeComponent();
            cbRol.DataSource = Enum.GetValues(typeof(RolUsuario));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar
            if (tbUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese usuario.");
                return;
            }

            //crear
            CajeroCreado = new Cajero(tbUsuario.Text, tbNombre.Text, tbPassword.Text,
                                     (RolUsuario)cbRol.SelectedItem);

            
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
