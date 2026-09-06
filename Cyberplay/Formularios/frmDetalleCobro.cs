using Cyberplay.Modelos;
using Cyberplay.Core;
using Cyberplay.Helpers;
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

    cobro.EquipoDescripcion,

    cobro.HoraInicio
        .ToString("HH:mm:ss"),

    horaFin
        .ToString("HH:mm:ss"),

    cobro.TiempoJugado
        .ToString(
            @"hh\:mm\:ss"),

    cobro.TotalTiempoJugado
        .ToString("0.00")
);

            // =====================
            // PRODUCTOS
            // =====================

            decimal totalProductos = 0;

            foreach (VentaProducto producto
                in cobro.ProductosConsumidos
                ?? new List<VentaProducto>())
            {
                dgvProductos.Rows.Add(
                    producto.Detalle,

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
                totalProductos
                    .ToString("0.00")
                + " Bs";

            // =====================
            // HISTORIAL TARIFAS
            // =====================

            TipoTarifa tarifaAnterior =
     cobro.TarifaInicial;

            foreach (CambioTarifa cambio
                in cobro.HistorialTarifas
                ?? new List<CambioTarifa>())
            {
                decimal totalHastaCambio =
                    CalcularTotalHasta(
                        cambio.TiempoCambio);

                dgvHistorial.Rows.Add(
                    tarifaAnterior.ToString(),

                    cambio.TarifaNueva.ToString(),

                    cambio.TiempoCambio
                        .ToString(
                            @"hh\:mm\:ss"),

                    totalHastaCambio
                        .ToString("0.00")
                );

                tarifaAnterior =
                    cambio.TarifaNueva;
            }

            // =====================
            // TOTAL GENERAL
            // =====================

            lblNroTicket.Text =
    cobro.TicketId;

            lblTotalGeneral.Text = "TOTAL GENERAL: " +
                 cobro.TotalCobrado
                    .ToString("0.00")
                + " Bs";
        }

        private void frmDetalleCobro_Load(object sender, EventArgs e)
        {
            CargarDetalle();
            DataGridViewHelper.Configurar(dgvDetalleTiempo);
            DataGridViewHelper.Configurar(dgvProductos);
            DataGridViewHelper.Configurar(dgvHistorial);
            dgvDetalleTiempo.ClearSelection();
            dgvProductos.ClearSelection();
            dgvHistorial.ClearSelection();
            
        }

        private decimal CalcularTotalHasta(
            TimeSpan tiempo)
        {
            Estacion estacion =
                CrearEstacionCalculo();

            if (estacion != null)
            {
                CalculadoraCobro calculadora =
                    new CalculadoraCobro();

                return calculadora.CalcularCosto(
                    estacion,
                    cobro.TarifaInicial,
                    cobro.HistorialTarifas
                    ?? new List<CambioTarifa>(),
                    tiempo);
            }

            return CalcularTotalProporcional(
                tiempo);
        }

        private Estacion CrearEstacionCalculo()
        {
            if (cobro == null
                || SesionSistema.Configuracion == null
                || SesionSistema.Configuracion.TiposEquipo == null)
            {
                return null;
            }

            string tipoEquipo =
                cobro.TipoEquipo;

            if (string.IsNullOrWhiteSpace(
                tipoEquipo))
            {
                tipoEquipo =
                    EquipoIdentidad.ObtenerTipo(
                        cobro.Equipo);
            }

            TipoEquipoConfiguracion tipo =
                SesionSistema
                .Configuracion
                .TiposEquipo
                .FirstOrDefault(
                    t =>
                    t.Nombre == tipoEquipo);

            if (tipo == null)
            {
                return null;
            }

            return new Estacion()
            {
                NumeroEquipo =
                    cobro.NumeroEquipo,

                Nombre =
                    cobro.Equipo,

                TipoEquipo =
                    tipo.Nombre,

                SoportaMultijugador =
                    tipo.UsaTarifasMultijugador,

                TarifaCiclo =
                    tipo.TarifaLibre,

                Tarifa2M =
                    tipo.TarifaM2,

                Tarifa3M =
                    tipo.TarifaM3,

                Tarifa4M =
                    tipo.TarifaM4,

                CiclosPorHora =
                    tipo.CiclosPorHora > 0
                    ? tipo.CiclosPorHora
                    : tipo.UsaTarifasMultijugador
                        ? 4
                        : 3,

                MinutosCiclo =
                    tipo.CiclosPorHora > 0
                    ? 60 / tipo.CiclosPorHora
                    : tipo.UsaTarifasMultijugador
                        ? 15
                        : 20,

                ToleranciaMinutos =
                    SesionSistema
                    .Configuracion
                    .ToleranciaMinutos
            };
        }

        private decimal CalcularTotalProporcional(
            TimeSpan tiempo)
        {
            if (cobro == null
                || cobro.TiempoJugado.TotalSeconds <= 0)
            {
                return 0;
            }

            decimal totalTiempo =
                ObtenerTotalTiempoCobro();

            decimal proporcion =
                (decimal)(
                    tiempo.TotalSeconds
                    / cobro.TiempoJugado.TotalSeconds);

            return totalTiempo * proporcion;
        }

        private decimal ObtenerTotalTiempoCobro()
        {
            return CalculadoraImportesCobro
                .ObtenerTotalTiempoEfectivo(
                    cobro);
        }
    }
}
