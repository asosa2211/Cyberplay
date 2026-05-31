using Cyberplay.Core;
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
    public partial class frmEditarProducto : Form
    {
        public Producto ProductoCreado { get; private set; }
        private Producto productoEditar;

        public frmEditarProducto()
        {
            InitializeComponent();
            InicializarTipoVenta();
            CargarCategorias();
        }

        public frmEditarProducto(Producto producto)
        {
            InitializeComponent();
            InicializarTipoVenta();
            CargarCategorias();
            productoEditar = producto;

            //cargar datos
            tbNombre.Text = producto.Nombre;
            cbCategorias.Text = producto.Categoria;
            nudPrecioCosto.Value = producto.PrecioCosto;
            nudPrecioVenta.Value = producto.PrecioVenta;
            nudStock.Value = producto.Stock;
            cbTipoVenta.SelectedItem = producto.TipoVenta;
            cbTipoVenta_SelectedIndexChanged(null, null);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR NOMBRE
            // =====================

            if (tbNombre.Text.Trim()
                == "")
            {
                MessageBox.Show(
                    "Ingrese nombre.");

                return;
            }

            // =====================
            // VALIDAR CATEGORIA
            // =====================

            if (cbCategorias.Text.Trim()
                == "")
            {
                MessageBox.Show(
                    "Ingrese categoría.");

                return;
            }

            // =====================
            // CREAR
            // =====================

            if (productoEditar == null)
            {
                // =====================
                // NUEVO
                // =====================

                ProductoCreado =
                    new Producto()
                    {
                        Nombre =
                            tbNombre.Text,

                        Categoria =
                            cbCategorias.Text,

                        PrecioCosto =
                            nudPrecioCosto.Value,
                        PrecioVenta =
                             nudPrecioVenta.Value,

                        Stock =
                            (int)nudStock.Value,

                        TipoVenta =
                            (TipoVentaProducto)
                            cbTipoVenta.SelectedItem
                    };
            }
            else
            {
                // =====================
                // EDITAR
                // =====================

                productoEditar.Nombre =
                    tbNombre.Text;

                productoEditar.Categoria =
                    cbCategorias.Text;

                productoEditar.PrecioCosto =
                    nudPrecioCosto.Value;

                productoEditar.PrecioVenta =
                    nudPrecioVenta.Value;

                productoEditar.Stock =
                    (int)nudStock.Value;

                productoEditar.TipoVenta =
                    (TipoVentaProducto)
                    cbTipoVenta.SelectedItem;

                ProductoCreado =
                    productoEditar;
            }

            // =====================
            // OK
            // =====================

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void InicializarTipoVenta()
        {
            cbTipoVenta.Items.Clear();

            cbTipoVenta.Items.Add(
                TipoVentaProducto.ConStock);

            cbTipoVenta.Items.Add(
                TipoVentaProducto.MontoDirecto);

            cbTipoVenta.Items.Add(
                TipoVentaProducto.Contadores);

            cbTipoVenta.SelectedItem =
                TipoVentaProducto.ConStock;
        }

        private void CargarCategorias()
        {
            // =====================
            // LIMPIAR
            // =====================

            cbCategorias.Items.Clear();

            // =====================
            // RECORRER
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

            if (cbCategorias.Items.Count > 0)
            {
                cbCategorias.SelectedIndex = 0;
            }
        }
        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            
        }

        private void nudPrecioCosto_Click(object sender, EventArgs e)
        {
            nudPrecioCosto.Select(0, nudPrecioCosto.Text.Length);
        }

        private void nudPrecioCosto_Enter(object sender, EventArgs e)
        {
            nudPrecioCosto.Select(0, nudPrecioCosto.Text.Length);
        }

        private void nudPrecioVenta_Click(object sender, EventArgs e)
        {
            nudPrecioVenta.Select(0, nudPrecioVenta.Text.Length);
        }

        private void nudPrecioVenta_Enter(object sender, EventArgs e)
        {
            nudPrecioVenta.Select(0, nudPrecioVenta.Text.Length);
        }

        private void nudPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudStock_Enter(object sender, EventArgs e)
        {
            nudStock.Select(0, nudStock.Text.Length);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool usaStock =
                cbTipoVenta.SelectedItem is TipoVentaProducto
                &&
                (TipoVentaProducto)cbTipoVenta.SelectedItem
                == TipoVentaProducto.ConStock;

            nudStock.Enabled =
                usaStock;

            lblStock.Text =
                usaStock
                ? "Stock"
                : "Stock (no aplica)";
        }

        private void nudStock_Click(object sender, EventArgs e)
        {
            nudStock.Select(0, nudStock.Text.Length);
        }
    }
}
