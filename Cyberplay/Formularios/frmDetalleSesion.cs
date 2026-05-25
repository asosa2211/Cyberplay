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
    public partial class frmDetalleSesion : Form
    {
        private Sesion sesion;

        private ucPS4 consola;

        public frmDetalleSesion(Sesion sesion, ucPS4 consola)
        {
            InitializeComponent();

            this.sesion = sesion;

            this.consola = consola;

            CargarDetalle();
        }
        public frmDetalleSesion()
        {
            InitializeComponent();
        }


        private void CargarDetalle()
        {
            // =====================
            // VALIDAR
            // =====================

            if (sesion == null)
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
            // TIEMPO JUGADO
            // =====================

            TimeSpan tiempoJugado =
                sesion
                .Cronometro
                .TiempoTranscurrido;

            DateTime horaInicio =
                sesion
                .Cronometro
                .HoraInicioSesion;

            if (horaInicio == DateTime.MinValue)
            {
                horaInicio =
                    DateTime.Now
                    - tiempoJugado;
            }

            // =====================
            // TOTAL TIEMPO
            // =====================

            decimal totalTiempo =
                consola
                .ObtenerTotalTiempo();

            // =====================
            // HORA FIN
            // =====================

            string horaFin =
                horaInicio
                .Add(
                    tiempoJugado)
                .ToString("HH:mm:ss");

            // =====================
            // DETALLE TIEMPO
            // =====================

            dgvDetalleTiempo.Rows.Add(
                sesion
                    .UsuarioActual
                    .NombreCuenta,

                consola
                    .Estacion
                    .Nombre,

                horaInicio
                    .ToString("HH:mm:ss"),


                horaFin,

                tiempoJugado
                    .ToString(
                        @"hh\:mm\:ss"),

                totalTiempo
                    .ToString("0.00")
            );

            // =====================
            // TOTAL PRODUCTOS
            // =====================

            decimal totalProductos = 0;

            // =====================
            // PRODUCTOS
            // =====================

            foreach (VentaProducto producto
                in sesion
                .ProductosConsumidos)
            {
                dgvProductos.Rows.Add(
                    producto.Producto,
                    producto.PrecioUnitario.ToString("0.00"),
                    producto.Cantidad,

                    producto.Total
                        .ToString("0.00")
                );

                totalProductos +=
                    producto.Total;
            }

            // =====================
            // LABEL PRODUCTOS
            // =====================

            lblTotalProductos.Text =
                totalProductos
                .ToString("0.00")
                + " Bs";

            // =====================
            // HISTORIAL TARIFAS
            // =====================

            TipoTarifa tarifaAnterior =
                sesion
                .TarifaInicial;

            foreach (CambioTarifa cambio
                in sesion
                .HistorialTarifas)
            {
                // =====================
                // TOTAL HASTA MOMENTO
                // =====================

                decimal totalHastaMomento =
                    consola
                    .ObtenerTotalHasta(
                        cambio.TiempoCambio);

                // =====================
                // AGREGAR
                // =====================

                dgvHistorial.Rows.Add(
                    tarifaAnterior
                        .ToString(),

                    cambio
                        .TarifaNueva
                        .ToString(),

                    cambio
                        .TiempoCambio
                        .ToString(
                            @"hh\:mm\:ss"),

                    totalHastaMomento
                        .ToString("0.00")
                );

                // =====================
                // ACTUALIZAR
                // =====================

                tarifaAnterior =
                    cambio
                    .TarifaNueva;
            }

            // =====================
            // TOTAL GENERAL
            // =====================

            decimal totalGeneral =
                totalTiempo
                + totalProductos;

            lblTotalGeneral.Text =
                totalGeneral
                .ToString("0.00")
                + " Bs";
        }
    }
}
