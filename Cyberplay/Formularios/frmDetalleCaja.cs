using Cyberplay.Core;
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
        public frmDetalleCaja()
        {
            InitializeComponent();
            // =====================
            // CAJA
            // =====================

            lblNroCaja.Text =
                SesionSistema
                    .CajaActual
                    .NumeroCaja
                    .ToString();

            // =====================
            // FECHA
            // =====================

            lblFecha.Text =
                DateTime.Now
                    .ToShortDateString();

            // =====================
            // HORA
            // =====================

            lblHora.Text =
                DateTime.Now
                    .ToShortTimeString();

            // =====================
            // CAJERO
            // =====================

            lblCajero.Text =
                SesionSistema
                    .CajeroActual
                    .Usuario;

            // =====================
            // TOTAL
            // =====================

            lblTotalGeneral.Text =
                SesionSistema
                    .CajaActual
                    .TotalCobrado
                    .ToString("0.00")
                + " Bs.";

            CargarIngresos();
            CargarEgresos();
            CargarDetalleVentasProductos();
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
                SesionSistema
                    .CajaActual
                    .NumeroCaja;

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
        private void CargarEgresos()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvEgresos.Rows.Clear();

            // =====================
            // NUMERO CAJA
            // =====================

            int numeroCaja =
                SesionSistema
                    .CajaActual
                    .NumeroCaja;

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
            }
        }
        private void  CargarIngresos()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvIngresos.Rows.Clear();

            // =====================
            // NUMERO CAJA
            // =====================

            int numeroCaja =
                SesionSistema
                    .CajaActual
                    .NumeroCaja;

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
                    c.Equipo
                    .Split('-')[0])
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

            foreach (IngresoCaja ingreso
                in ingresos)
            {
                dgvIngresos.Rows.Add(
                    ingreso.Concepto,

                    ingreso.Monto
                        .ToString("0.00"));
            }
        }
    }
}
