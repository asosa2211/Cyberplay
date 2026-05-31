using Cyberplay.Core;
using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
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
    public partial class frmDetalleCaja : Form
    {
        private int numeroCaja;
       
        private decimal totalIngresos;

        private decimal totalEgresos;

        public frmDetalleCaja()
        {
            InitializeComponent();
        }

        public frmDetalleCaja(int numeroCaja)
        {
            InitializeComponent();
            // =====================
            // CAJA
            // =====================

            this.numeroCaja = numeroCaja;

            lblNroCaja.Text = "Caja Nº: " + numeroCaja.ToString();

            
            // =====================
            // CAJERO
            // =====================

            lblCajero.Text = "Cajero: " + SesionSistema.CajeroActual.Usuario;


            // =====================
            // HISTORIAL
            // =====================

            PersistenciaHistorialCajas
                persistenciaHistorial =
                    new PersistenciaHistorialCajas();

            Caja caja =
                persistenciaHistorial
                    .CargarHistorial()
                    .FirstOrDefault(
                        x =>
                        x.NumeroCaja
                        == numeroCaja);

            // =====================
            // CAJA ACTUAL
            // =====================

            if (caja == null)
            {
                caja =
                    SesionSistema
                        .CajaActual;
            }

            // =====================
            // APERTURA
            // =====================

            lblApertura.Text = "Apertura: " +
                caja.FechaApertura
                    .ToString(
                        "dd/MM/yyyy HH:mm");

            // =====================
            // CIERRE
            // =====================

            lblCierre.Text = "Cierre:  " +
                caja.FechaCierre
                    ?.ToString(
                        "dd/MM/yyyy HH:mm")
                    ?? "-";

            // =====================
            // CARGAR
            // =====================

            CargarIngresos();

            CargarEgresos();

            CargarDetalleVentasProductos();

            CargarDetalleMultijugador();

            CargarDetalleStock();

            // =====================
            // TOTAL
            // =====================

            if (caja != null || numeroCaja>0)
            {
                //lblTotalGeneral.Text = caja.TotalCobrado.ToString("0.00") + " Bs.";
                lblTotalGeneral.Text = "Total General: " + (totalIngresos - totalEgresos).ToString("0.00");
            }
        }

        private string ObtenerTipoEquipo(
            RegistroCobro cobro)
        {
            if (cobro == null)
            {
                return "";
            }

            if (!string.IsNullOrWhiteSpace(
                cobro.TipoEquipo))
            {
                return cobro.TipoEquipo;
            }

            return EquipoIdentidad
                .ObtenerTipo(
                    cobro.Equipo);
        }

        private void CargarDetalleMultijugador()
        {
            dgvDetalleMultijugador
                .Rows
                .Clear();

            PersistenciaCobros persistenciaCobros =
                new PersistenciaCobros();

            List<RegistroCobro> cobros =
                persistenciaCobros
                    .CargarCobros()
                    .Where(
                        x =>
                        x.NumeroCaja == numeroCaja
                        && ObtenerTipoEquipo(
                            x)
                            .ToUpper() != "PC"
                        && (x.TarifaFinal == TipoTarifa.M2
                            || x.TarifaFinal == TipoTarifa.M3
                            || x.TarifaFinal == TipoTarifa.M4))
                    .ToList();

            var resumen =
                cobros
                .GroupBy(
                    x =>
                    new
                    {
                        Tarifa =
                            x.TarifaFinal,

                        Tipo =
                            ObtenerTipoEquipo(
                                x)
                    })
                .Select(
                    g =>
                    new
                    {
                        g.Key.Tarifa,
                        g.Key.Tipo,
                        Total =
                            g.Sum(
                                x =>
                                x.TotalCobrado)
                    })
                .OrderBy(
                    x =>
                    x.Tipo)
                .ThenBy(
                    x =>
                    x.Tarifa)
                .ToList();

            foreach (var item
                in resumen)
            {
                dgvDetalleMultijugador
                    .Rows
                    .Add(
                        item.Tarifa.ToString(),
                        item.Tipo,
                        item.Total.ToString("0.00"));
            }
        }

        private void CargarDetalleVentasProductos()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvDetalleVentaProductos
                .Rows
                .Clear();

            // =====================
            // NUMERO CAJA
            // =====================

            int numeroCaja =
                this.numeroCaja;

            // =====================
            // PERSISTENCIA
            // =====================

            PersistenciaVentasProductos
                persistencia =
                    new PersistenciaVentasProductos();

            // =====================
            // CARGAR
            // =====================

            List<VentaProducto> ventas =
                persistencia
                    .CargarVentas()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .ToList();

            // =====================
            // AGRUPAR
            // =====================

            var resumen =
                ventas
                .GroupBy(
                    x =>
                    x.Producto)
                .Select(
                    g => new
                    {
                        Producto =
                            g.Key,

                        Categoria =
                            g.First()
                            .Categoria,

                        Precio =
                            g.First()
                            .PrecioUnitario,

                        Cantidad =
                            g.Sum(
                                x =>
                                x.Cantidad),

                        Total =
                            g.Sum(
                                x =>
                                x.Total)
                    })
                .OrderBy(
    x =>
    x.Categoria)
.ThenBy(
    x =>
    x.Producto)
                .ToList();

            // =====================
            // AGREGAR
            // =====================

            foreach (var item
                in resumen)
            {
                dgvDetalleVentaProductos
                    .Rows
                    .Add(
                        item.Producto,

                        item.Categoria,

                        item.Precio
                            .ToString("0.00"),

                        item.Cantidad,

                        item.Total
                            .ToString("0.00"));
            }
        }

        private void
    CargarDetalleStock()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvDetalleStock
                .Rows
                .Clear();

            // =====================
            // PRODUCTOS
            // =====================

            PersistenciaProductos
                persistenciaProductos =
                    new PersistenciaProductos();

            List<Producto> productos =
                persistenciaProductos
                    .CargarProductos()
                    .Where(
                        x =>
                        x.TipoVenta == TipoVentaProducto.ConStock)
                    .OrderBy(
                        x =>
                        x.Categoria)
                    .ThenBy(
                        x =>
                        x.Nombre)
                    .ToList();

            // =====================
            // MOVIMIENTOS
            // =====================

            PersistenciaMovimientoStock
                persistenciaMovimientos =
                    new PersistenciaMovimientoStock();

            List<MovimientoStock>
                movimientos =
                    persistenciaMovimientos
                        .CargarMovimientos()
                        .Where(
                            x =>
                            x.NumeroCaja
                            == numeroCaja)
                        .ToList();

            // =====================
            // RECORRER
            // =====================

            foreach (Producto producto
                in productos)
            {
                // =====================
                // MOVIMIENTOS PRODUCTO
                // =====================

                List<MovimientoStock>
                    movimientosProducto =
                        movimientos
                        .Where(
                            x =>
                            x.Producto
                            == producto.Nombre)
                        .ToList();

                // =====================
                // TOTALES
                // =====================

                int entrada =
                    movimientosProducto
                    .Sum(
                        x =>
                        x.Entrada);

                int recibido =
                    movimientosProducto
                    .Sum(
                        x =>
                        x.Recibido);

                int entregado =
                    movimientosProducto
                    .Sum(
                        x =>
                        x.Entregado);

                int retiro =
                    movimientosProducto
                    .Sum(
                        x =>
                        x.Retiro);

                // =====================
                // DIFERENCIA
                // =====================

                int diferencia =
                    (entrada + recibido)
                    -
                    (entregado + retiro);

                // =====================
                // AGREGAR
                // =====================

                dgvDetalleStock
                    .Rows
                    .Add(
                        producto.Nombre,

                        producto.Categoria,

                        entrada,

                        recibido,

                        entregado,

                        retiro,

                        diferencia);
            }
        }
        private void CargarEgresos()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvEgresos.Rows.Clear();
            totalEgresos = 0;

            // =====================
            // NUMERO CAJA
            // =====================

            int numeroCaja =
                this.numeroCaja;

            // =====================
            // PERSISTENCIA
            // =====================

            PersistenciaEgresosCaja
                persistencia =
                    new PersistenciaEgresosCaja();

            // =====================
            // CARGAR
            // =====================

            List<EgresoCaja> egresos =
                persistencia
                    .CargarEgresos()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .OrderBy(
                        x =>
                        x.Concepto)
                    .ToList();

            // =====================
            // AGREGAR
            // =====================

            foreach (EgresoCaja egreso
                in egresos)
            {
                dgvEgresos.Rows.Add(
                    egreso.Concepto,

                    egreso.Monto
                        .ToString("0.00"));

                totalEgresos += egreso.Monto;
            }
            lblTotalEgresos.Text = "Total Egresos: " +
    totalEgresos
        .ToString("0.00")
    + " Bs.";
        }
        private void  CargarIngresos()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvIngresos.Rows.Clear();
            totalIngresos = 0;

            // =====================
            // NUMERO CAJA
            // =====================

            int numeroCaja =
                this.numeroCaja;

            // =====================
            // COBROS EQUIPOS
            // =====================

            PersistenciaCobros
                persistenciaCobros =
                    new PersistenciaCobros();

            List<RegistroCobro> cobros =
                persistenciaCobros
                    .CargarCobros()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .ToList();

            // =====================
            // AGRUPAR EQUIPOS
            // =====================

            var resumenEquipos =
                cobros
                .GroupBy(
                    c =>
                    ObtenerTipoEquipo(
                        c))
                .Select(
                    g => new
                    {
                        Concepto =
                            g.Key,

                        Total =
                            g.Sum(
                                x =>
                                x.TotalCobrado)
                    })
                .OrderBy(
                    x =>
                    x.Concepto)
                .ToList();

            // =====================
            // AGREGAR EQUIPOS
            // =====================

            foreach (var item
                in resumenEquipos)
            {
                dgvIngresos.Rows.Add(
                    item.Concepto,

                    item.Total
                        .ToString("0.00"));

                totalIngresos += item.Total;
            }

            // =====================
            // VENTAS PRODUCTOS
            // =====================

            PersistenciaVentasProductos
                persistenciaVentas =
                    new PersistenciaVentasProductos();

            List<VentaProducto> ventas =
                persistenciaVentas
                    .CargarVentas()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .ToList();

            // =====================
            // AGRUPAR CATEGORIAS
            // =====================

            var resumenCategorias =
                ventas
                .GroupBy(
                    v =>
                    v.Categoria)
                .Select(
                    g => new
                    {
                        Concepto =
                            g.Key,

                        Total =
                            g.Sum(
                                x =>
                                x.Total)
                    })
                .OrderBy(
                    x =>
                    x.Concepto)
                .ToList();

            // =====================
            // AGREGAR CATEGORIAS
            // =====================

            foreach (var item
                in resumenCategorias)
            {
                dgvIngresos.Rows.Add(
                    item.Concepto,

                    item.Total
                        .ToString("0.00"));

                totalIngresos += item.Total;
            }

            // =====================
            // INGRESOS MANUALES
            // =====================

            PersistenciaIngresosCaja
                persistenciaIngresos =
                    new PersistenciaIngresosCaja();

            List<IngresoCaja> ingresos =
                persistenciaIngresos
                    .CargarIngresos()
                    .Where(
                        x =>
                        x.NumeroCaja
                        == numeroCaja)
                    .OrderBy(
                        x =>
                        x.Concepto)
                    .ToList();

            // =====================
            // AGREGAR INGRESOS
            // =====================

            foreach (IngresoCaja ingreso in ingresos)
            {
                dgvIngresos.Rows.Add(ingreso.Concepto, ingreso.Monto.ToString("0.00"));
                totalIngresos += ingreso.Monto;
            }

            lblTotalIngresos.Text = "Total Ingresos: " + totalIngresos.ToString("0.00") + " Bs.";
        }
    }
}
