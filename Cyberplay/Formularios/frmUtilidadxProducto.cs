using Cyberplay.Core;
using Cyberplay.Helpers;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using Cyberplay.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cyberplay.Formularios
{
    public partial class frmUtilidadxProducto : Form
    {
        private List<ResumenProducto> _productos = new List<ResumenProducto>();
        public frmUtilidadxProducto()
        {
            InitializeComponent();
        }

        private void CargarCategorias()
        {
            cbCategorias.Items.Clear();

            cbCategorias.Items.Add("Todas");

            if (SesionSistema.Configuracion?.Categorias != null)
            {
                foreach (string categoria
                    in SesionSistema.Configuracion.Categorias
                        .OrderBy(c => c))
                {
                    cbCategorias.Items.Add(categoria);
                }
            }

            cbCategorias.SelectedIndex = 0;
        }

        private void ActualizarEstadoFiltros()
        {
            bool filtrarPorFecha =
                rbFechas.Checked;

            dtpDesde.Enabled =
                filtrarPorFecha;

            dtpHasta.Enabled =
                filtrarPorFecha;

            nudCajaDesde.Enabled =
                !filtrarPorFecha;

            nudCajaHasta.Enabled =
                !filtrarPorFecha;
        }

        private void Consultar()
        {
            List<VentaProducto> ventas =
                ObtenerVentasFiltradas();

            _productos =
                ObtenerResumenProductos(ventas);

            CargarProductos(_productos);
        }

        private void CargarProductos(
    List<ResumenProducto> productos)
        {
            dgvProductos.Rows.Clear();

            foreach (ResumenProducto producto in productos)
            {
                dgvProductos.Rows.Add(
                    producto.Producto,
                    producto.Categoria,
                    producto.Precio,
                    producto.Cantidad,
                    producto.Total,
                    producto.Utilidad);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void frmUtilidadxProducto_Load(object sender, EventArgs e)
        {
            rbFechas.Checked = true;
            ActualizarEstadoFiltros();
            CargarCategorias();
            DataGridViewHelper.Configurar(dgvProductos);
            colUtilidad.SortMode = DataGridViewColumnSortMode.Automatic;
            colUtilidad.DefaultCellStyle.Format = "0.00";
            dgvProductos.ClearSelection();
        }

        private void rbCajas_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoFiltros();
        }

        private void rbFechas_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoFiltros();
        }

        private void cbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated)
                return;

            Consultar();
        }

        private List<VentaProducto> ObtenerVentasFiltradas()
        {
            PersistenciaVentasProductos persistencia =
                new PersistenciaVentasProductos();

            List<VentaProducto> ventas =
                persistencia.CargarVentas();

            if (rbFechas.Checked)
            {
                DateTime desde =
                    dtpDesde.Value.Date;

                DateTime hasta =
                    dtpHasta.Value.Date
                        .AddDays(1)
                        .AddTicks(-1);

                ventas =
                    ventas
                    .Where(v =>
                        v.Fecha >= desde &&
                        v.Fecha <= hasta)
                    .ToList();
            }
            else
            {
                int cajaDesde =
                    (int)nudCajaDesde.Value;

                int cajaHasta =
                    (int)nudCajaHasta.Value;

                ventas =
                    ventas
                    .Where(v =>
                        v.NumeroCaja >= cajaDesde &&
                        v.NumeroCaja <= cajaHasta)
                    .ToList();
            }

            // =====================
            // FILTRO POR CATEGORIA
            // =====================

            if (cbCategorias.Text != "Todas")
            {
                ventas =
                    ventas
                    .Where(v =>
                        v.Categoria == cbCategorias.Text)
                    .ToList();
            }

            return ventas;
        }

        private List<ResumenProducto> ObtenerResumenProductos(
    List<VentaProducto> ventas)
        {
            return ventas
                .GroupBy(v => new
                {
                    v.Producto,
                    v.Categoria
                })
                .Select(g => new ResumenProducto
                {
                    Producto = g.Key.Producto,
                    Categoria = g.Key.Categoria,
                    Precio = g.First().PrecioUnitario,
                    Cantidad = g.Sum(x => x.Cantidad),
                    Total = g.Sum(x => x.Total),
                    Utilidad = g.Sum(x => x.Utilidad)
                })
                .OrderBy(x => x.Categoria)
                .ThenBy(x => x.Producto)
                .ToList();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (_productos == null || _productos.Count == 0)
            {
                MessageBox.Show(
                    "No existen datos para exportar.",
                    "Exportar PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documento PDF (*.pdf)|*.pdf";
            sfd.FileName = $"UtilidadProductos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            PdfReportInfo info = new PdfReportInfo
            {
                Titulo = "Reporte de Utilidad por Producto",
                Usuario = SesionSistema.CajeroActual.Usuario,
                FechaEmision = DateTime.Now
            };

            if (rbFechas.Checked)
            {
                info.Filtros.Add($"Desde: {dtpDesde.Value:dd/MM/yyyy}");
                info.Filtros.Add($"Hasta: {dtpHasta.Value:dd/MM/yyyy}");
            }
            else
            {
                info.Filtros.Add($"Caja desde: {nudCajaDesde.Value}");
                info.Filtros.Add($"Caja hasta: {nudCajaHasta.Value}");
            }

            info.Filtros.Add($"Categoría: {cbCategorias.Text}");

            PdfHelper.ExportarUtilidadProducto(
                sfd.FileName,
                info,
                _productos);

            Process.Start(new ProcessStartInfo
            {
                FileName = sfd.FileName,
                UseShellExecute = true
            });
        }
    }
}
