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
    public partial class frmHistorialCajas : Form
    {
        public frmHistorialCajas()
        {
            InitializeComponent();
            CargarHistorial();
        }

        private void
     CargarHistorial()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvHistorialCajas
                .Rows
                .Clear();

            // =====================
            // PERSISTENCIA
            // =====================

            PersistenciaHistorialCajas
                persistencia =
                    new PersistenciaHistorialCajas();

            // =====================
            // CARGAR
            // =====================

            List<Caja> cajas =
                persistencia
                    .CargarHistorial()
                    .OrderByDescending(
                        x =>
                        x.NumeroCaja)
                    .Take(10)
                    .ToList();

            // =====================
            // RECORRER
            // =====================

            foreach (Caja caja
                in cajas)
            {
                dgvHistorialCajas
    .Rows
    .Add(
        caja.NumeroCaja,

        caja.FechaApertura
            .ToString(
                "dd/MM/yyyy HH:mm"),

        caja.FechaCierre
            ?.ToString(
                "dd/MM/yyyy HH:mm")
            ?? "-",

        caja.Cajero,

        caja.TotalCobrado
            .ToString("0.00"));
            }
        }

        private void dgvHistorialCajas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (e.RowIndex < 0)
            {
                return;
            }

            // =====================
            // NUMERO CAJA
            // =====================

            int numeroCaja =
                Convert.ToInt32(
                    dgvHistorialCajas
                    .Rows[e.RowIndex]
                    .Cells[0]
                    .Value);

            // =====================
            // ABRIR
            // =====================

            frmDetalleCaja frm =
                new frmDetalleCaja(
                    numeroCaja);

            frm.ShowDialog();
        }
    }
}
