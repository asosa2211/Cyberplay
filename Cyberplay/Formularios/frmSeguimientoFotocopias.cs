using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public partial class frmSeguimientoFotocopias : Form
    {
        private PersistenciaVentasProductos persistenciaVentas =
            new PersistenciaVentasProductos();

        public frmSeguimientoFotocopias()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            dtpDesde.Value =
                DateTime.Today;

            dtpHasta.Value =
                DateTime.Today;

            CargarCajeros();
            CargarSeguimiento();
        }

        private void CargarCajeros()
        {
            List<string> cajeros =
                persistenciaVentas
                    .CargarVentas()
                    .Where(
                        v =>
                        v.TipoVenta == TipoVentaProducto.Contadores)
                    .Select(
                        v =>
                        v.Cajero)
                    .Where(
                        c =>
                        !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .OrderBy(
                        c =>
                        c)
                    .ToList();

            cbCajero.Items.Clear();
            cbCajero.Items.Add("Todos");

            foreach (string cajero in cajeros)
            {
                cbCajero.Items.Add(cajero);
            }

            cbCajero.SelectedIndex = 0;
        }

        private void CargarSeguimiento()
        {
            dgvSeguimiento.Rows.Clear();

            DateTime desde =
                dtpDesde.Value.Date;

            DateTime hasta =
                dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            string cajero =
                cbCajero.SelectedItem == null
                ? "Todos"
                : cbCajero.SelectedItem.ToString();

            List<VentaProducto> ventas =
                persistenciaVentas
                    .CargarVentas()
                    .Where(
                        v =>
                        v.TipoVenta == TipoVentaProducto.Contadores
                        && v.Fecha >= desde
                        && v.Fecha <= hasta
                        && (cajero == "Todos"
                            || v.Cajero == cajero))
                    .OrderBy(
                        v =>
                        v.Fecha)
                    .ToList();

            foreach (VentaProducto venta in ventas)
            {
                int fila =
                    dgvSeguimiento.Rows.Add(
                        venta.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        venta.Cajero,
                        venta.ContadorInicial,
                        venta.ContadorFinal,
                        venta.TotalCopias,
                        venta.Total.ToString("0.00"),
                        venta.Promedio.ToString("0.00"),
                        venta.Aproximado.ToString("0.00"),
                        venta.Diferencia.ToString("0.00"));

                DataGridViewCell celdaDiferencia =
                    dgvSeguimiento
                        .Rows[fila]
                        .Cells["colDiferencia"];

                celdaDiferencia.Style.BackColor =
                    venta.Diferencia >= 0
                    ? Color.LightGreen
                    : Color.LightCoral;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarSeguimiento();
        }
    }
}
