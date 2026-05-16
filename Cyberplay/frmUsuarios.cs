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
    public partial class frmUsuarios : Form
    {
        private GestorUsuarios gestorUsuarios;
        public frmUsuarios(GestorUsuarios gestor)
        {
            InitializeComponent();
            gestorUsuarios = gestor;
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            lbUsuarios.Items.Clear();

            foreach (Usuario usuario
                in gestorUsuarios
                    .ObtenerUsuarios())
            {
                lbUsuarios.Items.Add(
                    usuario);
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
        {
            tbCuenta.Clear();

            tbNombre.Clear();

            tbTelefono.Clear();

            tbCuenta.Focus();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR CAMPOS
            // =====================

            if (tbCuenta.Text == ""
                || tbNombre.Text == "")
            {
                MessageBox.Show(
                    "Complete los datos");

                return;
            }

            // =====================
            // CREAR USUARIO
            // =====================

            Usuario usuario =
                new Usuario(
                    tbCuenta.Text,
                    tbNombre.Text,
                    tbTelefono.Text);

            // =====================
            // AGREGAR
            // =====================

            bool agregado =
                gestorUsuarios
                    .AgregarUsuario(
                        usuario);

            // =====================
            // RESULTADO
            // =====================

            if (agregado)
            {
                MessageBox.Show(
                    "Usuario creado");

                ActualizarLista();

                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    "La cuenta ya existe");
            }
        }
    }
}
