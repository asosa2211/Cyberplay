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
            tbCategoria.Text = producto.Categoria;
            nudPrecio.Value = producto.Precio;
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

            if (tbCategoria.Text.Trim()
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
                            tbCategoria.Text,

                        Precio =
                            nudPrecio.Value,

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
                    tbCategoria.Text;

                productoEditar.Precio =
                    nudPrecio.Value;

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
    }
}
