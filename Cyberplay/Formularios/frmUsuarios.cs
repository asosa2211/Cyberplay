using Cyberplay.Formularios;
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
        public Usuario UsuarioSeleccionado{ get; private set; }
        public bool ModoSeleccion
        {
            get;
            set;
        }

        public frmUsuarios()
        {
            InitializeComponent();
            gestorUsuarios =
                new GestorUsuarios();
        }

        public frmUsuarios(GestorUsuarios gestor)
        {
            InitializeComponent();
            gestorUsuarios = gestor;
            ActualizarLista();
        }

        private void ActualizarListaFiltrada(string texto)
        {
            CargarUsuarios(gestorUsuarios.BuscarUsuarios(texto));
        }
        private void ActualizarLista()
        {
            CargarUsuarios(gestorUsuarios.ObtenerUsuarios());
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
           // btnSeleccionar.Visible =  ModoSeleccion;
        }

        private void LimpiarCampos()
        {
            tbCuenta.Clear();

            tbNombre.Clear();

            tbTelefono.Clear();

            tbCuenta.Focus();
        }

        private void CargarUsuarios(
    IEnumerable<Usuario> usuarios)
        {
            dgvUsuarios.Rows.Clear();

            foreach (Usuario usuario in usuarios)
            {
                int indice =
                    dgvUsuarios.Rows.Add(
                        usuario.NombreCuenta,
                        usuario.NombreCliente,
                        usuario.Telefono,
                        usuario.TiempoTotalJugado);

                dgvUsuarios.Rows[indice].Tag =
                    usuario;
            }
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

        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SELECCION
            // =====================

            if (UsuarioSeleccionado
                == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario");

                return;
            }

            // =====================
            // EDITAR
            // =====================

            bool editado =
                gestorUsuarios
                    .EditarUsuario(
                        UsuarioSeleccionado
                            .NombreCuenta,

                        tbCuenta.Text,

                        tbNombre.Text,

                        tbTelefono.Text);

            // =====================
            // RESULTADO
            // =====================

            if (editado)
            {
                MessageBox.Show(
                    "Usuario editado");

                ActualizarLista();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SELECCION
            // =====================

            if (UsuarioSeleccionado
                == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario");

                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    $"¿Eliminar usuario '{UsuarioSeleccionado.NombreCuenta}'?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            // =====================
            // CANCELÓ
            // =====================

            if (resultado
                != DialogResult.Yes)
            {
                return;
            }

            // =====================
            // ELIMINAR
            // =====================

            bool eliminado =
                gestorUsuarios
                    .EliminarUsuario(
                        UsuarioSeleccionado
                            .NombreCuenta);

            // =====================
            // RESULTADO
            // =====================

            if (eliminado)
            {
                MessageBox.Show(
                    "Usuario eliminado");

                ActualizarLista();

                LimpiarCampos();

                UsuarioSeleccionado =
                    null;
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar");
            }
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarListaFiltrada(
       tbBuscar.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (UsuarioSeleccionado
                == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario");

                return;
            }

            

            // =====================
            // CERRAR
            // =====================

            DialogResult =
                DialogResult.OK;

            Close();
        }

       /* private void btnBuscar_Click(object sender, EventArgs e)
        {

        }*/

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Usuario usuario =
                dgvUsuarios.Rows[e.RowIndex].Tag
                as Usuario;

            if (usuario == null)
            {
                return;
            }

            UsuarioSeleccionado = usuario;

            tbCuenta.Text =
                usuario.NombreCuenta;

            tbNombre.Text =
                usuario.NombreCliente;

            tbTelefono.Text =
                usuario.Telefono;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Usuario usuario =
                dgvUsuarios.Rows[e.RowIndex].Tag
                as Usuario;

            if (usuario == null)
            {
                return;
            }

            // =====================
            // MODO SELECCIÓN
            // =====================

            if (ModoSeleccion)
            {
                UsuarioSeleccionado =
                    usuario;

                DialogResult =
                    DialogResult.OK;

                Close();

                return;
            }

            // =====================
            // VER DETALLE
            // =====================

            frmDetalleCliente frm =
                new frmDetalleCliente(usuario);

            frm.ShowDialog();
        }
    }
}
