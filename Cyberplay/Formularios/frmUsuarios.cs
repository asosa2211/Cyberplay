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
        private Usuario usuarioSeleccionado;
        private GestorUsuarios gestorUsuarios;
        public Usuario UsuarioSeleccionado{ get; private set; }

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

        private void ActualizarListaFiltrada(
    string texto)
        {
            dgvUsuarios.Rows.Clear();

            List<Usuario> encontrados =
                gestorUsuarios
                    .BuscarUsuarios(texto);

            foreach (Usuario usuario
                in encontrados)
            {
                dgvUsuarios.Rows.Add(
                    usuario.NombreCuenta,
                    usuario.NombreCliente,
                    usuario.Telefono,
                    usuario.TiempoTotalJugado);
            }
        }
        private void ActualizarLista()
        {
            dgvUsuarios.Rows.Clear();

            foreach (Usuario usuario
                in gestorUsuarios
                    .ObtenerUsuarios())
            {
                dgvUsuarios.Rows.Add(
                    usuario.NombreCuenta,
                    usuario.NombreCliente,
                    usuario.Telefono,
                    usuario.TiempoTotalJugado);
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

        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SELECCION
            // =====================

            if (usuarioSeleccionado
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
                        usuarioSeleccionado
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

            if (usuarioSeleccionado
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
                    $"¿Eliminar usuario '{usuarioSeleccionado.NombreCuenta}'?",
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
                        usuarioSeleccionado
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

                usuarioSeleccionado =
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

            if (usuarioSeleccionado
                == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario");

                return;
            }

            // =====================
            // GUARDAR
            // =====================

            UsuarioSeleccionado =
                usuarioSeleccionado;

            // =====================
            // CERRAR
            // =====================

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string cuenta =
                dgvUsuarios.Rows[e.RowIndex]
                    .Cells["colCuenta"]
                    .Value
                    ?.ToString();

            if (string.IsNullOrWhiteSpace(cuenta))
            {
                return;
            }

            Usuario usuario =
                gestorUsuarios
                    .ObtenerUsuarios()
                    .FirstOrDefault(
                        u => u.NombreCuenta == cuenta);

            if (usuario == null)
            {
                return;
            }

            usuarioSeleccionado = usuario;

            tbCuenta.Text = usuario.NombreCuenta;
            tbNombre.Text = usuario.NombreCliente;
            tbTelefono.Text = usuario.Telefono;
        }
    }
}
