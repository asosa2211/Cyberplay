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
        public frmEditarProducto()
        {
            InitializeComponent();
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

            // =====================
            // OK
            // =====================

            DialogResult =
                DialogResult.OK;

            Close();
        }
    }
}
