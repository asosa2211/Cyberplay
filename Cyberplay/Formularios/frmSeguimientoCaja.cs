using Cyberplay.Core;
using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmSeguimientoCaja : Form
    {
        public frmSeguimientoCaja()
        {
            InitializeComponent();

            Load += frmSeguimientoCaja_Load;
            btnActualizar.Click += btnActualizar_Click;
        }

        private void frmSeguimientoCaja_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configurar(dgvSeguimiento);
            // Mostrar automáticamente la caja actual.
            if (SesionSistema.CajaActual == null)
            {
                MessageBox.Show(
                    "No existe una caja activa.",
                    "Seguimiento de caja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int numeroCaja = SesionSistema.CajaActual.NumeroCaja;

            tbNroCaja.Text = numeroCaja.ToString();

            CargarSeguimiento(numeroCaja);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar el número de caja ingresado.
            if (!int.TryParse(tbNroCaja.Text.Trim(), out int numeroCaja)
                || numeroCaja <= 0)
            {
                MessageBox.Show(
                    "Ingresa un número de caja válido.",
                    "Seguimiento de caja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tbNroCaja.Focus();
                return;
            }

            CargarSeguimiento(numeroCaja);
        }

        private void CargarSeguimiento(int numeroCaja)
        {
            dgvSeguimiento.Rows.Clear();

            List<MovimientoSeguimiento> movimientos =
                new List<MovimientoSeguimiento>();

            // =====================================================
            // 1. CARGAR COBROS DE SESIONES
            // =====================================================

            List<RegistroCobro> cobros = new PersistenciaCobros()
                .CargarCobros()
                .Where(x => x.NumeroCaja == numeroCaja)
                .ToList();

            // Identificar las ventas de productos asociadas a sesiones.
            HashSet<Guid> idsVentasCobradasEnSesion =
                ObtenerIdsVentasCobradasEnSesion(cobros);

            // Identificar ventas que todavía pertenecen a sesiones activas.
            HashSet<Guid> idsVentasEnSesionesActivas =
                ObtenerIdsVentasEnSesionesActivas();

            foreach (RegistroCobro cobro in cobros)
            {
                decimal ingreso =
                    CalculadoraImportesCobro.ObtenerTotalTiempoEfectivo(cobro);

                string concepto = "Sesión";

                if (!string.IsNullOrWhiteSpace(cobro.EquipoDescripcion))
                {
                    concepto += " - " + cobro.EquipoDescripcion;
                }

                if (!string.IsNullOrWhiteSpace(cobro.NombreCuenta))
                {
                    concepto += " - " + cobro.NombreCuenta;
                }

                movimientos.Add(new MovimientoSeguimiento
                {
                    Fecha = cobro.Fecha,
                    Concepto = concepto,
                    Ingreso = ingreso,
                    Egreso = 0
                });
            }

            // =====================================================
            // 2. CARGAR VENTAS DE PRODUCTOS
            // =====================================================

            List<VentaProducto> ventas = new PersistenciaVentasProductos()
                .CargarVentas()
                .Where(x =>
                    CalculadoraImportesCobro.EsVentaContabilizadaEnCaja(
                        x,
                        numeroCaja,
                        idsVentasCobradasEnSesion)
                    &&
                    !idsVentasEnSesionesActivas.Contains(x.Id))
                .ToList();

            foreach (VentaProducto venta in ventas)
            {
                movimientos.Add(new MovimientoSeguimiento
                {
                    Fecha = venta.Fecha,
                    Concepto = "Venta: " + venta.Detalle,
                    Ingreso = venta.Total,
                    Egreso = 0
                });
            }

            // =====================================================
            // 3. CARGAR INGRESOS MANUALES
            // =====================================================

            List<IngresoCaja> ingresos = new PersistenciaIngresosCaja()
                .CargarIngresos()
                .Where(x =>
                    x.NumeroCaja == numeroCaja
                    &&
                    !EsIngresoAutomaticoContabilizado(x))
                .ToList();

            foreach (IngresoCaja ingreso in ingresos)
            {
                movimientos.Add(new MovimientoSeguimiento
                {
                    Fecha = ingreso.Fecha,
                    Concepto = ingreso.Concepto,
                    Ingreso = ingreso.Monto,
                    Egreso = 0
                });
            }

            // =====================================================
            // 4. CARGAR EGRESOS
            // =====================================================

            List<EgresoCaja> egresos = new PersistenciaEgresosCaja()
                .CargarEgresos()
                .Where(x => x.NumeroCaja == numeroCaja)
                .ToList();

            foreach (EgresoCaja egreso in egresos)
            {
                movimientos.Add(new MovimientoSeguimiento
                {
                    Fecha = egreso.Fecha,
                    Concepto = egreso.Concepto,
                    Ingreso = 0,
                    Egreso = egreso.Monto
                });
            }

            // =====================================================
            // 5. ORDENAR Y MOSTRAR MOVIMIENTOS
            // =====================================================

            decimal saldoAcumulado = 0;

            List<MovimientoSeguimiento> movimientosOrdenados =
                movimientos
                    .OrderBy(x => x.Fecha)
                    .ToList();

            foreach (MovimientoSeguimiento movimiento in movimientosOrdenados)
            {
                saldoAcumulado += movimiento.Ingreso - movimiento.Egreso;

                dgvSeguimiento.Rows.Add(
                    movimiento.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                    movimiento.Concepto,
                    movimiento.Ingreso.ToString("0.00"),
                    movimiento.Egreso.ToString("0.00"),
                    saldoAcumulado.ToString("0.00"));
            }
        }

        // =========================================================
        // IDENTIFICAR VENTAS ASOCIADAS A COBROS DE SESIONES
        // =========================================================

        private HashSet<Guid> ObtenerIdsVentasCobradasEnSesion(
            List<RegistroCobro> cobros)
        {
            return cobros
                .Where(x => x.ProductosConsumidos != null) 
                .SelectMany(x => x.ProductosConsumidos)
                .Select(x => x.Id)
                .ToHashSet();
        }

        // =========================================================
        // IDENTIFICAR VENTAS DE SESIONES QUE SIGUEN ACTIVAS
        // =========================================================

        private HashSet<Guid> ObtenerIdsVentasEnSesionesActivas()
        {
            HashSet<Guid> ids = new HashSet<Guid>();

            foreach (var consola in frmPrincipal.Consolas)
            {
                if (consola.Sesion != null
                    && consola.Sesion.ProductosConsumidos != null)
                {
                    foreach (VentaProducto venta in
                        consola.Sesion.ProductosConsumidos)
                    {
                        ids.Add(venta.Id);
                    }
                }
            }

            return ids;
        }

        // =========================================================
        // EVITAR DUPLICAR INGRESOS AUTOMÁTICOS
        // =========================================================

        private bool EsIngresoAutomaticoContabilizado(IngresoCaja ingreso)
        {
            if (ingreso == null ||
                string.IsNullOrWhiteSpace(ingreso.Concepto))
            {
                return false;
            }

            string concepto = ingreso.Concepto.Trim();

            return concepto.Equals(
                       "Venta productos",
                       StringComparison.OrdinalIgnoreCase)
                   ||
                   concepto.StartsWith(
                       "Cobro sesión:",
                       StringComparison.OrdinalIgnoreCase);
        }

        // =========================================================
        // MODELO INTERNO PARA LOS MOVIMIENTOS DEL SEGUIMIENTO
        // =========================================================

        private class MovimientoSeguimiento
        {
            public DateTime Fecha { get; set; }

            public string Concepto { get; set; }

            public decimal Ingreso { get; set; }

            public decimal Egreso { get; set; }
        }
    }
}