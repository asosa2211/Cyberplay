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
    public partial class frmUtilidades : Form
    {
        public frmUtilidades()
        {
            InitializeComponent();
        }

        private void CargarUtilidadesEquipos()
        {
            // =====================
            // LIMPIAR GRID
            // =====================

            dgvEquipos.Rows.Clear();

            // =====================
            // CARGAR COBROS
            // =====================

            PersistenciaCobros persistencia =
                new PersistenciaCobros();

            List<RegistroCobro> cobros =
                persistencia
                    .CargarCobros();

            // =====================
            // FILTRAR POR FECHA
            // =====================

            if (rbFecha.Checked)
            {
                DateTime desde =
                    dtpDesde.Value.Date;

                DateTime hasta =
                    dtpHasta.Value.Date
                        .AddDays(1)
                        .AddTicks(-1);

                cobros =
                    cobros
                    .Where(
                        x =>
                        x.Fecha >= desde
                        &&
                        x.Fecha <= hasta)
                    .ToList();
            }

            // =====================
            // FILTRAR POR CAJA
            // =====================

            else if (rbCaja.Checked)
            {
                int cajaDesde =
                    (int)nudCajaDesde.Value;

                int cajaHasta =
                    (int)nudCajaHasta.Value;

                cobros =
                    cobros
                    .Where(
                        x =>
                        x.NumeroCaja >= cajaDesde
                        &&
                        x.NumeroCaja <= cajaHasta)
                    .ToList();
            }

            // =====================
            // AGRUPAR POR TIPO
            // =====================

            var utilidades =
                cobros
                .Where(
                    x =>
                    !string.IsNullOrWhiteSpace(
                        x.TipoEquipo))
                .GroupBy(
                    x =>
                    x.TipoEquipo)
                .Select(
                    g =>
                    new
                    {
                        TipoEquipo =
                            g.Key,

                        Utilidad =
                            g.Sum(
                                x =>
                                x.TotalTiempoJugado)
                    })
                .OrderBy(
                    x =>
                    x.TipoEquipo)
                .ToList();

            // =====================
            // CARGAR GRID
            // =====================

            foreach (var item
                in utilidades)
            {
                dgvEquipos.Rows.Add(
                    item.TipoEquipo,
                    item.Utilidad.ToString("0.00"));
            }

            // =====================
            // TOTAL EQUIPOS
            // =====================

            decimal totalEquipos =
                utilidades.Sum(
                    x =>
                    x.Utilidad);

            lblTotalEquipos.Text =
                "Equipos: Bs. "
                + totalEquipos.ToString("0.00");
        }

        private void CargarUtilidadesCategorias()
        {
            // =====================
            // LIMPIAR GRID
            // =====================

            dgvCategorias.Rows.Clear();

            // =====================
            // VENTAS
            // =====================

            PersistenciaVentasProductos
                persistencia =
                    new PersistenciaVentasProductos();

            List<VentaProducto> ventas =
                persistencia
                    .CargarVentas();

            // =====================
            // FILTRO FECHA
            // =====================

            if (rbFecha.Checked)
            {
                DateTime desde =
                    dtpDesde.Value.Date;

                DateTime hasta =
                    dtpHasta.Value.Date
                        .AddDays(1)
                        .AddTicks(-1);

                ventas =
                    ventas
                    .Where(
                        x =>
                        x.Fecha >= desde
                        &&
                        x.Fecha <= hasta)
                    .ToList();
            }

            // =====================
            // FILTRO CAJA
            // =====================

            else if (rbCaja.Checked)
            {
                int cajaDesde =
                    (int)nudCajaDesde.Value;

                int cajaHasta =
                    (int)nudCajaHasta.Value;

                ventas =
                    ventas
                    .Where(
                        x =>
                        x.NumeroCaja >= cajaDesde
                        &&
                        x.NumeroCaja <= cajaHasta)
                    .ToList();
            }

            // =====================
            // AGRUPAR
            // =====================

            var categorias =
                ventas
                .Where(
                    x =>
                    !string.IsNullOrWhiteSpace(
                        x.Categoria))
                .GroupBy(
                    x =>
                    x.Categoria)
                .Select(
                    g =>
                    new
                    {
                        Categoria =
                            g.Key,

                        Utilidad =
                            g.Sum(
                                x =>
                                x.Utilidad)
                    })
                .OrderBy(
                    x =>
                    x.Categoria)
                .ToList();

            // =====================
            // GRID
            // =====================

            foreach (var item
                in categorias)
            {
                dgvCategorias.Rows.Add(
                    item.Categoria,
                    item.Utilidad.ToString("0.00"));
            }

            // =====================
            // TOTAL PRODUCTOS
            // =====================

            decimal totalProductos =
                categorias.Sum(
                    x =>
                    x.Utilidad);

            lblTotalProductos.Text =
                "Productos: Bs. "
                + totalProductos.ToString("0.00");
        }

        private void ActualizarResumenGeneral()
        {
            decimal totalEquipos =
                ObtenerTotalEquipos();

            decimal totalProductos =
                ObtenerTotalProductos();

            decimal totalGeneral =
                totalEquipos
                + totalProductos;

            lblTotalGeneral.Text =
                "GENERAL: Bs. "
                + totalGeneral.ToString("0.00");
        }

        private decimal ObtenerTotalEquipos()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila
                in dgvEquipos.Rows)
            {
                if (fila.Cells[1].Value == null)
                {
                    continue;
                }

                total +=
                    Convert.ToDecimal(
                        fila.Cells[1].Value);
            }

            return total;
        }

        private decimal ObtenerTotalProductos()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila
                in dgvCategorias.Rows)
            {
                if (fila.Cells[1].Value == null)
                {
                    continue;
                }

                total +=
                    Convert.ToDecimal(
                        fila.Cells[1].Value);
            }

            return total;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarUtilidadesEquipos();

            CargarUtilidadesCategorias();

            ActualizarResumenGeneral();
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = rbFecha.Checked;
            dtpHasta.Enabled = rbFecha.Checked;

            nudCajaDesde.Enabled = !rbFecha.Checked;
            nudCajaHasta.Enabled = !rbFecha.Checked;
        }

        private void frmUtilidades_Load(object sender, EventArgs e)
        {
            rbFecha.Checked = true;

            dtpDesde.Value =
                DateTime.Today;

            dtpHasta.Value =
                DateTime.Today;
        }

        private void rbCaja_CheckedChanged(object sender, EventArgs e)
        {
            rbFecha_CheckedChanged(sender, e);
        }
    }
}
