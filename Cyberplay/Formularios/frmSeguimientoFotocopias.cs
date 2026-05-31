using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cyberplay.Formularios
{
    public class frmSeguimientoFotocopias : Form
    {
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private ComboBox cbCajero;
        private Button btnFiltrar;
        private DataGridView dgvSeguimiento;
        private PersistenciaVentasProductos persistenciaVentas =
            new PersistenciaVentasProductos();

        public frmSeguimientoFotocopias()
        {
            InicializarComponentes();
            CargarCajeros();
            CargarSeguimiento();
        }

        private void InicializarComponentes()
        {
            Text = "Seguimiento de fotocopias";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(980, 520);
            MinimumSize = new Size(900, 420);

            Label lblDesde = new Label();
            lblDesde.Text = "Desde";
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(18, 18);

            dtpDesde = new DateTimePicker();
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(65, 14);
            dtpDesde.Width = 110;
            dtpDesde.Value = DateTime.Today;

            Label lblHasta = new Label();
            lblHasta.Text = "Hasta";
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(195, 18);

            dtpHasta = new DateTimePicker();
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(240, 14);
            dtpHasta.Width = 110;
            dtpHasta.Value = DateTime.Today;

            Label lblCajero = new Label();
            lblCajero.Text = "Cajero";
            lblCajero.AutoSize = true;
            lblCajero.Location = new Point(370, 18);

            cbCajero = new ComboBox();
            cbCajero.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCajero.Location = new Point(420, 14);
            cbCajero.Width = 155;

            btnFiltrar = new Button();
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Location = new Point(595, 12);
            btnFiltrar.Width = 85;
            btnFiltrar.Click += (s, e) => CargarSeguimiento();

            dgvSeguimiento = new DataGridView();
            dgvSeguimiento.AllowUserToAddRows = false;
            dgvSeguimiento.AllowUserToDeleteRows = false;
            dgvSeguimiento.Anchor =
                AnchorStyles.Top
                | AnchorStyles.Bottom
                | AnchorStyles.Left
                | AnchorStyles.Right;
            dgvSeguimiento.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeguimiento.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeguimiento.Location = new Point(18, 55);
            dgvSeguimiento.MultiSelect = false;
            dgvSeguimiento.Name = "dgvSeguimiento";
            dgvSeguimiento.ReadOnly = true;
            dgvSeguimiento.RowHeadersVisible = false;
            dgvSeguimiento.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvSeguimiento.Size = new Size(930, 390);

            dgvSeguimiento.Columns.Add("colFecha", "Fecha");
            dgvSeguimiento.Columns.Add("colCajero", "Cajero");
            dgvSeguimiento.Columns.Add("colEntrada", "Entrada");
            dgvSeguimiento.Columns.Add("colSalida", "Salida");
            dgvSeguimiento.Columns.Add("colTotalCopias", "Total Copias");
            dgvSeguimiento.Columns.Add("colTotalBs", "Total bs");
            dgvSeguimiento.Columns.Add("colPromedio", "Promedio");
            dgvSeguimiento.Columns.Add("colAprox", "Aprox");
            dgvSeguimiento.Columns.Add("colDiferencia", "Diferencia");

            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(lblCajero);
            Controls.Add(cbCajero);
            Controls.Add(btnFiltrar);
            Controls.Add(dgvSeguimiento);
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
    }
}
