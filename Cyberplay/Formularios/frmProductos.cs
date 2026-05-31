using Cyberplay.Core;
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

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

            productos = persistenciaProductos.CargarProductos();

            CargarCategorias();
            CargarProductos();
        }

        private void MostrarAccesoDenegado()
        {
            MessageBox.Show(
                "Acceso denegado",
                "Permisos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private bool RequiereAdmin()
        {
            if (Permisos.EsAdmin())
            {
                return true;
            }

            MostrarAccesoDenegado();

            return false;
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
                        producto.TipoVenta == TipoVentaProducto.ConStock
                        ? producto.Stock.ToString()
                        : "No aplica");

                dgvProductos.Rows[fila].Tag =
                    producto;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!RequiereAdmin())
            {
                return;
            }

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
            if (!RequiereAdmin())
            {
                return;
            }

             
            // =====================
            // VALIDAR
            // =====================

            if (dgvProductos.CurrentRow
                == null)
            {
                MessageBox.Show(
                    "Seleccione un producto.");

                return;
            }

            // =====================
            // PRODUCTO
            // =====================

            Producto producto =
                (Producto)
                dgvProductos
                .CurrentRow
                .Tag;

            if (producto.TipoVenta != TipoVentaProducto.ConStock)
            {
                MessageBox.Show(
                    "Este producto no maneja stock.");

                return;
            }

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

            // =====================
            // TODAS
            // =====================

            cbCategorias.Items.Add(
                "Todas");

            // =====================
            // CONFIGURACION
            // =====================

            foreach (string categoria
                in SesionSistema
                    .Configuracion
                    .Categorias
                    .OrderBy(
                        c =>
                        c))
            {
                cbCategorias.Items.Add(
                    categoria);
            }

            // =====================
            // SELECCIONAR
            // =====================

            cbCategorias.SelectedItem =
                "Todas";
        }
        private void btnEliminar_Click(
    object sender,
    EventArgs e)
        {
            if (!RequiereAdmin())
            {
                return;
            }

            // =====================
            // VALIDAR
            // =====================

            if (dgvProductos.CurrentRow
                == null)
            {
                MessageBox.Show(
                    "Seleccione un producto.");

                return;
            }

            // =====================
            // PRODUCTO
            // =====================

            Producto producto =
                (Producto)
                dgvProductos
                .CurrentRow
                .Tag;

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
