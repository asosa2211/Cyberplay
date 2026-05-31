using Cyberplay.Core;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmVentaEspecialProducto : Form
    {
        private Producto producto;

        public VentaProducto Venta { get; private set; }

        public frmVentaEspecialProducto()
        {
            InitializeComponent();
        }

        public frmVentaEspecialProducto(Producto producto)
        {
            this.producto =
                producto;

            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            ConfigurarFormulario();

            ActualizarCalculos();
        }

        private void ConfigurarFormulario()
        {
            Text =
                producto.Nombre;

            bool esContador =
                producto.TipoVenta == TipoVentaProducto.Contadores;

            ClientSize =
                esContador
                ? new Size(390, 310)
                : new Size(330, 150);

            lblContadorInicial.Visible =
                esContador;

            nudContadorInicial.Visible =
                esContador;

            lblContadorFinal.Visible =
                esContador;

            nudContadorFinal.Visible =
                esContador;

          //  lblTotalCopiasValor.Visible =
               // esContador;

         /*   lblPromedioValor.Visible =
                esContador;

            lblAproximadoValor.Visible =
                esContador;

            lblDiferenciaValor.Visible =
                esContador;*/

            int botonY =
                esContador
                ? 250
                : 80;

            btnGuardar.Location =
                new Point(85, botonY);

            btnCancelar.Location =
                new Point(185, botonY);

            nudContadorInicial.Enabled =
                true;

            nudContadorInicial.ReadOnly =
                false;

            if (esContador)
            {
                CargarContadorInicialAnterior();
            }
        }

        private void CargarContadorInicialAnterior()
        {
            if (SesionSistema.CajaActual == null)
            {
                return;
            }

            int cajaAnterior =
                SesionSistema.CajaActual.NumeroCaja - 1;

            if (cajaAnterior <= 0)
            {
                return;
            }

            PersistenciaVentasProductos persistenciaVentas =
                new PersistenciaVentasProductos();

            VentaProducto ventaAnterior =
                persistenciaVentas
                    .CargarVentas()
                    .Where(
                        v =>
                        v.TipoVenta == TipoVentaProducto.Contadores
                        && v.NumeroCaja == cajaAnterior
                        && v.ContadorFinal > 0)
                    .OrderByDescending(
                        v =>
                        v.Fecha)
                    .FirstOrDefault();

            if (ventaAnterior == null)
            {
                return;
            }

            nudContadorInicial.Value =
                Math.Min(
                    nudContadorInicial.Maximum,
                    ventaAnterior.ContadorFinal);

            nudContadorInicial.ReadOnly =
                true;

            nudContadorInicial.Enabled =
                false;
        }

        private void ActualizarCalculos()
        {
            if (producto == null
                || producto.TipoVenta != TipoVentaProducto.Contadores)
            {
                return;
            }

            int copias =
                Math.Max(
                    0,
                    (int)nudContadorFinal.Value
                    -
                    (int)nudContadorInicial.Value);

            decimal total =
                nudTotal.Value;

            decimal promedio =
                copias > 0
                ? total / copias
                : 0;

            decimal aproximado =
                copias * 0.3m;

            decimal diferencia =
                total - aproximado;

            /*lblTotalCopiasValor.Text =
                "Total copias: " + copias;

            lblPromedioValor.Text =
                "Promedio: " + promedio.ToString("0.00");

            lblAproximadoValor.Text =
                "Aprox: " + aproximado.ToString("0.00");

            lblDiferenciaValor.Text =
                "Diferencia: " + diferencia.ToString("0.00");*/
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
                    "Ingrese el total vendido.");

                return;
            }

            int copias =
                1;

            int inicial =
                0;

            int final =
                0;

            decimal promedio =
                0;

            decimal aproximado =
                0;

            decimal diferencia =
                0;

            if (producto.TipoVenta == TipoVentaProducto.Contadores)
            {
                inicial =
                    (int)nudContadorInicial.Value;

                final =
                    (int)nudContadorFinal.Value;

                copias =
                    final - inicial;

                if (copias <= 0)
                {
                    MessageBox.Show(
                        "El contador final debe ser mayor al inicial.");

                    return;
                }

                promedio =
                    nudTotal.Value / copias;

                aproximado =
                    copias * 0.3m;

                diferencia =
                    nudTotal.Value - aproximado;
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
                        producto.TipoVenta == TipoVentaProducto.Contadores
                        ? copias
                        : 1,

                    PrecioUnitario =
                        producto.TipoVenta == TipoVentaProducto.Contadores
                        ? promedio
                        : nudTotal.Value,

                    Total =
                        nudTotal.Value,

                    ContadorInicial =
                        inicial,

                    ContadorFinal =
                        final,

                    TotalCopias =
                        producto.TipoVenta == TipoVentaProducto.Contadores
                        ? copias
                        : 0,

                    Promedio =
                        promedio,

                    Aproximado =
                        aproximado,

                    Diferencia =
                        diferencia
                };

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudTotal_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void nudContadorInicial_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void nudContadorFinal_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCalculos();
        }

        private void nudTotal_Click(object sender, EventArgs e)
        {
            nudTotal.Select(0, nudTotal.Text.Length);
        }

        private void nudTotal_Enter(object sender, EventArgs e)
        {
            nudTotal.Select(0, nudTotal.Text.Length);
        }

        private void nudContadorInicial_Click(object sender, EventArgs e)
        {
            nudContadorInicial.Select(0, nudContadorInicial.Text.Length);
        }

        private void nudContadorInicial_Enter(object sender, EventArgs e)
        {
            nudContadorInicial.Select(0, nudContadorInicial.Text.Length);
        }

        private void nudContadorFinal_Enter(object sender, EventArgs e)
        {
            nudContadorFinal.Select(0, nudContadorFinal.Text.Length);
        }

        private void nudContadorFinal_Click(object sender, EventArgs e)
        {
            nudContadorFinal.Select(0, nudContadorFinal.Text.Length);
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
