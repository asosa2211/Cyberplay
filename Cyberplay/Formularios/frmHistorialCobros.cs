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
            CargarCobros();
        }

        private void CargarCobros()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvCobros
                .Rows
                .Clear();

            // =====================
            // OBTENER COBROS
            // =====================

            List<RegistroCobro>
                cobros =
                    persistencia
                        .CargarCobros();

            // =====================
            // ORDENAR
            // =====================

            cobros =
                cobros
                .OrderByDescending(
                    x =>
                    x.Fecha)
                .ToList();

            // =====================
            // RECORRER
            // =====================

            foreach (RegistroCobro cobro
                in cobros)
            {
                dgvCobros
                    .Rows
                    .Add(
                        cobro.TicketId,
                        cobro.Equipo,
                        cobro.NombreCuenta,
                        cobro.TotalCobrado,
                        cobro.Fecha
                            .ToString(
                                "dd/MM/yyyy HH:mm"));
            }
        }
        private void frmHistorialCobros_Load(object sender, EventArgs e)
        {

        }
    }
}
