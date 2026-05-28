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
    public partial class frmDetalleCobro : Form
    {

        private RegistroCobro cobro;
        public frmDetalleCobro()
        {
            InitializeComponent();
        }

        public frmDetalleCobro(
    RegistroCobro cobro)
        {
            InitializeComponent();

            this.cobro = cobro;
        }

        private void CargarDetalle()
        {
            // =====================
            // VALIDAR
            // =====================

            if (cobro == null)
            {
                return;
            }

            // =====================
            // LIMPIAR
            // =====================

            dgvDetalleTiempo.Rows.Clear();

            dgvProductos.Rows.Clear();

            dgvHistorial.Rows.Clear();

            // =====================
            // HORA FIN
            // =====================

            DateTime horaFin =
                cobro.HoraInicio
                .Add(cobro.TiempoJugado);

            // =====================
            // DETALLE TIEMPO
            // =====================

            dgvDetalleTiempo.Rows.Add(
                cobro.NombreCuenta,

                cobro.Equipo,

                cobro.HoraInicio
                    .ToString("HH:mm:ss"),

                horaFin
                    .ToString("HH:mm:ss"),

                cobro.TiempoJugado
                    .ToString(
                        @"hh\:mm\:ss"),

                cobro.TotalCobrado
                    .ToString("0.00")
            );

            // =====================
            // PRODUCTOS
            // =====================

            decimal totalProductos = 0;

            foreach (VentaProducto producto
                in cobro.ProductosConsumidos)
            {
                dgvProductos.Rows.Add(
                    producto.Producto,

                    producto.PrecioUnitario
                        .ToString("0.00"),

                    producto.Cantidad,

                    producto.Total
                        .ToString("0.00")
                );

                totalProductos +=
                    producto.Total;
            }

            // =====================
            // TOTAL PRODUCTOS
            // =====================

            lblTotalProductos.Text =
                "Total Productos: "
                + totalProductos
                    .ToString("0.00")
                + " Bs";

            // =====================
            // HISTORIAL TARIFAS
            // =====================

            foreach (CambioTarifa cambio
                in cobro.HistorialTarifas)
            {
                dgvHistorial.Rows.Add(
                    "",
                    cambio.TarifaNueva,
                    cambio.TiempoCambio
                        .ToString(
                            @"hh\:mm\:ss"),
                    ""
                );
            }

            // =====================
            // TOTAL GENERAL
            // =====================

            lblNroTicket.Text =
    "Ticket: "
    + cobro.TicketId;

            lblTotalGeneral.Text =
                "Total General: "
                + cobro.TotalCobrado
                    .ToString("0.00")
                + " Bs";
        }

        private void frmDetalleCobro_Load(object sender, EventArgs e)
        {
            CargarDetalle();
        }
    }
}
