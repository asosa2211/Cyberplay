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
    public partial class frmUtilidadxProducto : Form
    {
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
            List<VentaProducto> ventas = ObtenerVentasFiltradas();
            CargarProductos(ventas);
        }

        private void CargarProductos(List<VentaProducto> ventas)
        {
            dgvProductos.Rows.Clear();
            var productos =
    ventas
    .GroupBy(v => new
    {
        v.Producto,
        v.Categoria
    })
    .Select(g => new
    {
        Producto =
            g.Key.Producto,

        Categoria =
            g.Key.Categoria,

        Precio =
            g.First().PrecioUnitario,

        Cantidad =
            g.Sum(x => x.Cantidad),

        Total =
            g.Sum(x => x.Total),

        Utilidad =
            g.Sum(x => x.Utilidad)
    })
    .OrderBy(x => x.Categoria)
    .ThenBy(x => x.Producto)
    .ToList();

            foreach (var producto in productos)
            {
                dgvProductos.Rows.Add(
                    producto.Producto,
                    producto.Categoria,
                    producto.Precio.ToString("0.00"),
                    producto.Cantidad,
                    producto.Total.ToString("0.00"),
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
    }
}
