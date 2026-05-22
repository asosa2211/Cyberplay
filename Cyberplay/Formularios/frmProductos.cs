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
    public partial class frmProductos : Form
    {
        private PersistenciaProductos persistenciaProductos = new PersistenciaProductos();

        private List<Producto> productos = new List<Producto>();
       
        //CONSTRUCTOR
        public frmProductos()
        {
            InitializeComponent();
            productos = persistenciaProductos.CargarProductos();

            CargarCategorias();
            CargarProductos();
        }

        private void CargarProductos()
        {
            // =====================
            // CARGAR
            // =====================

            productos =
                persistenciaProductos
                    .CargarProductos();

            // =====================
            // VALIDAR
            // =====================

            if (cbCategorias.SelectedItem
                == null)
            {
                return;
            }

            // =====================
            // CATEGORIA
            // =====================

            string categoria =
                cbCategorias
                .SelectedItem
                .ToString();

            string busqueda = tbBuscar.Text.Trim().ToLower();

            // =====================
            // FILTRAR
            // =====================

            List<Producto> filtrados;

            if (categoria == "Todas")
            {
                filtrados =
                    productos
                    .Where(
                        p =>
                        p.Nombre
                        .ToLower()
                        .Contains(
                            busqueda))
                    .OrderBy(
                        p =>
                        p.Nombre)
                    .ToList();
            }

            else
            {
                filtrados =
                    productos
                    .Where(
                        p =>
                        p.Categoria
                        == categoria
                        &&
                        p.Nombre
                        .ToLower()
                        .Contains(
                            busqueda))
                    .OrderBy(
                        p =>
                        p.Nombre)
                    .ToList();
            }

            // =====================
            // LIMPIAR
            // =====================

            dgvProductos.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (Producto producto
                in filtrados)
            {
                int fila =
                    dgvProductos.Rows.Add(
                        producto.Nombre,
                        producto.Categoria,
                        producto.PrecioVenta,
                        producto.Stock);

                dgvProductos.Rows[fila].Tag =
                    producto;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // =====================
            // FORM
            // =====================

            frmEditarProducto frm =
                new frmEditarProducto();

            // =====================
            // RESULTADO
            // =====================

            if (frm.ShowDialog()
                == DialogResult.OK)
            {
                // =====================
                // AGREGAR
                // =====================

                productos.Add(
                    frm.ProductoCreado);

                // =====================
                // GUARDAR
                // =====================

                persistenciaProductos
                    .GuardarProductos(
                        productos);

                // =====================
                // RECARGAR
                // =====================

                CargarProductos();
            }
        }

        private void btnEditar_Click(
    object sender,
    EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvProductos
                .SelectedRows.Count
                == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto.");

                return;
            }

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                dgvProductos
                .SelectedRows[0]
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR
            // =====================

            Producto producto =
                productos
                .FirstOrDefault(
                    p =>
                    p.Nombre
                    == nombre);

            if (producto == null)
            {
                return;
            }

            // =====================
            // FORM
            // =====================

            frmEditarProducto frm =
                new frmEditarProducto(
                    producto);

            // =====================
            // RESULTADO
            // =====================

            if (frm.ShowDialog()
                == DialogResult.OK)
            {
                // =====================
                // GUARDAR
                // =====================

                persistenciaProductos
                    .GuardarProductos(
                        productos);

                // =====================
                // RECARGAR
                // =====================

                CargarProductos();
            }
        }

        private void CargarCategorias()
        {
            // =====================
            // LIMPIAR
            // =====================

            cbCategorias.Items.Clear();
            cbCategorias.Items.Add("Todas");

            // =====================
            // OBTENER
            // =====================

            List<string> categorias =
                productos
                .Select(
                    p => p.Categoria)
                .Distinct()
                .OrderBy(
                    c => c)
                .ToList();

            // =====================
            // AGREGAR
            // =====================

            foreach (string categoria
                in categorias)
            {
                cbCategorias.Items.Add(
                    categoria);
            }

            // =====================
            // SELECCIONAR
            // =====================

            if (cbCategorias.Items.Count
                > 0)
            {
                cbCategorias.SelectedIndex = 0;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvProductos
                .SelectedRows.Count
                == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto.");

                return;
            }

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                dgvProductos
                .SelectedRows[0]
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR
            // =====================

            Producto producto =
                productos
                .FirstOrDefault(
                    p =>
                    p.Nombre
                    == nombre);

            if (producto == null)
            {
                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Eliminar producto?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }

            // =====================
            // ELIMINAR
            // =====================

            productos.Remove(
                producto);

            // =====================
            // GUARDAR
            // =====================

            persistenciaProductos
                .GuardarProductos(
                    productos);

            // =====================
            // RECARGAR
            // =====================

            CargarProductos();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {

            if (dgvProductos
                .CurrentRow
                == null)
            {
                return;
            }

            Producto producto =
                (Producto)
                dgvProductos
                .CurrentRow
                .Tag;

            frmStockProducto frm =
                new frmStockProducto(
                    producto);

            frm.ShowDialog();

            CargarProductos();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void tbBuscar_Enter(object sender, EventArgs e)
        {
            cbCategorias.SelectedItem = "Todas";
        }
    }
}
