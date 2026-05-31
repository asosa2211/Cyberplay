using Cyberplay.Core;
using Cyberplay.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberplay
{
    public partial class frmHistorialCobros : Form
    {
        private PersistenciaCobros persistencia = new PersistenciaCobros();

        
        public frmHistorialCobros()
        {
            InitializeComponent();
            
        }

        private void CargarCobros(
    int numeroCaja)
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvCobros.Rows.Clear();

            // =====================
            // MOSTRAR CAJA
            // =====================

            lblCajaActual.Text =
                "Caja actual: "
                + numeroCaja;

            // =====================
            // OBTENER COBROS
            // =====================

            List<RegistroCobro>
                cobros =
                    persistencia
                        .CargarCobros();

            // =====================
            // FILTRAR CAJA
            // =====================

            cobros =
                cobros
                .Where(
                    x =>
                    x.NumeroCaja
                    == numeroCaja)
                .OrderByDescending(
                    x =>
                    x.Fecha)
                .ToList();

            // =====================
            // CARGAR GRID
            // =====================

            foreach (RegistroCobro cobro
                in cobros)
            {
                dgvCobros.Rows.Add(
                    cobro.TicketId,
                    cobro.EquipoDescripcion,
                    cobro.Cajero,
                    cobro.TotalCobrado,
                    cobro.Fecha
                        .ToString(
                            "dd/MM/yyyy HH:mm"));
            }
        }


        private void frmHistorialCobros_Load(object sender, EventArgs e)
        {
            int cajaActual =
    SesionSistema
        .CajaActual
        .NumeroCaja;

            tbCaja.Text =
                cajaActual
                    .ToString();

            CargarCobros(
                cajaActual);
        }

        private void dgvCobros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (e.RowIndex < 0)
            {
                return;
            }

            // =====================
            // OBTENER TICKET
            // =====================

            string ticketId =
                dgvCobros
                .Rows[e.RowIndex]
                .Cells[0]
                .Value
                ?.ToString();

            if (string.IsNullOrEmpty(
                ticketId))
            {
                return;
            }

            // =====================
            // BUSCAR COBRO
            // =====================

            RegistroCobro cobro =
                persistencia
                .CargarCobros()
                .FirstOrDefault(
                    x =>
                    x.TicketId
                    == ticketId);

            if (cobro == null)
            {
                MessageBox.Show(
                    "No se encontró el ticket.");

                return;
            }

            // =====================
            // ABRIR DETALLE
            // =====================

            frmDetalleCobro frm =
                new frmDetalleCobro(
                    cobro);

            frm.ShowDialog();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int numeroCaja;

            if (!int.TryParse(
                tbCaja.Text,
                out numeroCaja))
            {
                MessageBox.Show(
                    "Ingrese un número de caja válido.");

                return;
            }

            CargarCobros(
                numeroCaja);
        }
    }
}
