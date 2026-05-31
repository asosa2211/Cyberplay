using Cyberplay.Core;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public class frmVentaEspecialProducto : Form
    {
        private Producto producto;
        private NumericUpDown nudTotal;
        private NumericUpDown nudContadorInicial;
        private NumericUpDown nudContadorFinal;
        private Label lblTotalCopiasValor;
        private Label lblPromedioValor;
        private Label lblAproximadoValor;
        private Label lblDiferenciaValor;

        public VentaProducto Venta { get; private set; }

        public frmVentaEspecialProducto(Producto producto)
        {
            this.producto =
                producto;

            InicializarComponentes();

            ActualizarCalculos();
        }

        private void InicializarComponentes()
        {
            Text =
                producto.Nombre;

            ShowIcon =
                false;

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox =
                false;

            ClientSize =
                producto.TipoVenta == TipoVentaProducto.Contadores
                ? new Size(390, 310)
                : new Size(330, 150);

            Label lblTotal =
                new Label();

            lblTotal.Text =
                "Total Bs";

            lblTotal.Location =
                new Point(35, 28);

            lblTotal.AutoSize =
                true;

            nudTotal =
                new NumericUpDown();

            nudTotal.DecimalPlaces =
                2;

            nudTotal.Maximum =
                100000;

            nudTotal.Location =
                new Point(145, 24);

            nudTotal.Width =
                100;

            nudTotal.ValueChanged +=
                (s, e) => ActualizarCalculos();

            Controls.Add(lblTotal);
            Controls.Add(nudTotal);

            int botonY =
                80;

            if (producto.TipoVenta == TipoVentaProducto.Contadores)
            {
                Label lblInicial =
                    new Label();

                lblInicial.Text =
                    "Contador inicial";

                lblInicial.Location =
                    new Point(35, 65);

                lblInicial.AutoSize =
                    true;

                nudContadorInicial =
                    new NumericUpDown();

                nudContadorInicial.Maximum =
                    1000000;

                nudContadorInicial.Location =
                    new Point(145, 61);

                nudContadorInicial.Width =
                    100;

                nudContadorInicial.ValueChanged +=
                    (s, e) => ActualizarCalculos();

                Label lblFinal =
                    new Label();

                lblFinal.Text =
                    "Contador final";

                lblFinal.Location =
                    new Point(35, 100);

                lblFinal.AutoSize =
                    true;

                nudContadorFinal =
                    new NumericUpDown();

                nudContadorFinal.Maximum =
                    1000000;

                nudContadorFinal.Location =
                    new Point(145, 96);

                nudContadorFinal.Width =
                    100;

                nudContadorFinal.ValueChanged +=
                    (s, e) => ActualizarCalculos();

                lblTotalCopiasValor =
                    CrearValor("Total copias", 135);

                lblPromedioValor =
                    CrearValor("Promedio", 160);

                lblAproximadoValor =
                    CrearValor("Aprox", 185);

                lblDiferenciaValor =
                    CrearValor("Diferencia", 210);

                Controls.Add(lblInicial);
                Controls.Add(nudContadorInicial);
                Controls.Add(lblFinal);
                Controls.Add(nudContadorFinal);

                CargarContadorInicialAnterior();

                botonY =
                    250;
            }

            Button btnGuardar =
                new Button();

            btnGuardar.Text =
                "Guardar";

            btnGuardar.Location =
                new Point(85, botonY);

            btnGuardar.Click +=
                btnGuardar_Click;

            Button btnCancelar =
                new Button();

            btnCancelar.Text =
                "Cancelar";

            btnCancelar.Location =
                new Point(185, botonY);

            btnCancelar.Click +=
                (s, e) => Close();

            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
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

        private Label CrearValor(string texto, int y)
        {
            Label lbl =
                new Label();

            lbl.Text =
                texto + ": 0";

            lbl.Location =
                new Point(35, y);

            lbl.AutoSize =
                true;

            Controls.Add(lbl);

            return lbl;
        }

        private void ActualizarCalculos()
        {
            if (producto.TipoVenta != TipoVentaProducto.Contadores
                || nudContadorInicial == null
                || nudContadorFinal == null)
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

            lblTotalCopiasValor.Text =
                "Total copias: " + copias;

            lblPromedioValor.Text =
                "Promedio: " + promedio.ToString("0.00");

            lblAproximadoValor.Text =
                "Aprox: " + aproximado.ToString("0.00");

            lblDiferenciaValor.Text =
                "Diferencia: " + diferencia.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
    }
}
