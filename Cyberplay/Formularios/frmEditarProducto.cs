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
        }

        public frmEditarProducto(Producto producto)
        {
            InitializeComponent();

            productoEditar = producto;

            //cargar datos
            cbCategoria.Text = producto.Categoria;
            nudPrecioCosto.Value = producto.PrecioCosto;
            nudPrecioVenta.Value = producto.PrecioVenta;
            nudStock.Value = producto.Stock;
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

            if (cbCategoria.Text.Trim()
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
                            cbCategoria.Text,

                        PrecioCosto =
                            nudPrecioCosto.Value,
                        PrecioVenta =
                             nudPrecioVenta.Value,

                        Stock =
                            (int)nudStock.Value
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
                    cbCategoria.Text;

                productoEditar.PrecioCosto =
                    nudPrecioCosto.Value;

                productoEditar.PrecioVenta =
                    nudPrecioVenta.Value;

                productoEditar.Stock =
                    (int)nudStock.Value;

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

        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            cbCategoria.Items.Add(
    "Bebidas");

            cbCategoria.Items.Add(
                "Snacks");

            cbCategoria.Items.Add(
                "Dulces");

            cbCategoria.Items.Add(
                "Impresiones");

            cbCategoria.Items.Add(
                "Otros");
        }
    }
}
