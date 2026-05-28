using Cyberplay.enums;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
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
            PersistenciaCajeros persistencia =
    new PersistenciaCajeros();

            List<Cajero> cajeros =
                persistencia
                    .CargarCajeros();

            bool existe =
                cajeros.Any(
                    c =>
                    c.Usuario.ToLower()
                    ==
                    tbUsuario.Text
                        .Trim()
                        .ToLower());

            if (cajeroEditar == null
                && existe)
            {
                MessageBox.Show(
                    "El usuario ya existe.");

                return;
            }

            //validar
            // =====================
            // USUARIO
            // =====================

            if (tbUsuario.Text.Trim()
                == "")
            {
                MessageBox.Show(
                    "Ingrese usuario.");

                return;
            }

            // =====================
            // NOMBRE
            // =====================

            if (tbNombre.Text.Trim()
                == "")
            {
                MessageBox.Show(
                    "Ingrese nombre.");

                return;
            }

            // =====================
            // PASSWORD
            // =====================

            if (tbPassword.Text.Trim()
                == "")
            {
                MessageBox.Show(
                    "Ingrese contraseña.");

                return;
            }

            // =====================
            // LONGITUD PASSWORD
            // =====================

            if (tbPassword.Text.Length
                < 3)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 3 caracteres.");

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
