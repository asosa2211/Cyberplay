using Cyberplay.Modelos;
using System;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmVentaMontoDirecto : Form
    {
        private Producto producto;

        public VentaProducto Venta { get; private set; }

        public frmVentaMontoDirecto()
        {
            InitializeComponent();
        }

        public frmVentaMontoDirecto(Producto producto)
        {
            InitializeComponent();

            this.producto =
                producto;

            if (producto != null)
            {
                Text =
                    producto.Nombre;

                nudTotal.Value =
                    Math.Min(
                        nudTotal.Maximum,
                        producto.PrecioVenta);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (producto == null)
            {
                Close();
                return;
            }

            if (nudTotal.Value <= 0)
            {
                MessageBox.Show(
                    "Ingrese el monto.");

                return;
            }

            Venta =
                new VentaProducto()
                {
                    Producto =
                        producto.Nombre,

                    Categoria =
                        producto.Categoria,

                    TipoVenta =
                        producto.TipoVenta,

                    Cantidad =
                        1,

                    PrecioUnitario =
                        nudTotal.Value,

                    Total =
                        nudTotal.Value
                };

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudTotal_Click(object sender, EventArgs e)
        {
            nudTotal.Select(0, nudTotal.Text.Length);
        }

        private void nudTotal_Enter(object sender, EventArgs e)
        {
            nudTotal.Select(0, nudTotal.Text.Length);
        }

        private void nudTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}
