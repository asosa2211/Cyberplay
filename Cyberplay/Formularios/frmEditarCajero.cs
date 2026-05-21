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
        private Cajero cajeroEditar;


        public frmEditarCajero()
        {
            InitializeComponent();

            cbRol.DataSource = Enum.GetValues(typeof(RolUsuario));
        }

        public frmEditarCajero(Cajero cajero)
        {
            InitializeComponent();
            cbRol.DataSource = Enum.GetValues(typeof(RolUsuario));
            
            //guarda la referencia
            cajeroEditar = cajero;

            //cargar datos
            tbUsuario.Text = cajero.Usuario;
            tbNombre.Text = cajero.NombreCompleto;
            tbPassword.Text = cajero.Password;
            cbRol.SelectedItem = cajero.Rol;

            //bloquear usuario
            tbUsuario.Enabled = false;
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
            if (cajeroEditar == null)
            {
                // =====================
                // NUEVO
                // =====================

                CajeroCreado =
                    new Cajero(
                        tbUsuario.Text,
                        tbNombre.Text,
                        tbPassword.Text,
                        (RolUsuario)
                        cbRol.SelectedItem);
            }
            else
            {
                // =====================
                // EDITAR
                // =====================

                cajeroEditar
                    .NombreCompleto =
                        tbNombre.Text;

                cajeroEditar
                    .Password =
                        tbPassword.Text;

                cajeroEditar
                    .Rol =
                        (RolUsuario)
                        cbRol.SelectedItem;

                CajeroCreado =
                    cajeroEditar;
            }


            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
