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
        private PersistenciaCobros persistenciaCobros = new PersistenciaCobros();
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

            dgvCobros.Rows.Clear();

            // =====================
            // OBTENER COBROS
            // =====================

            List<RegistroCobro> cobros =
                persistenciaCobros
                    .CargarCobros();

            // =====================
            // RECORRER
            // =====================

            foreach (RegistroCobro cobro
                in cobros)
            {
                dgvCobros.Rows.Add(
                    cobro.NombreCuenta,

                    cobro.Fecha
                        .ToString(
                            "dd/MM/yyyy HH:mm"),

                    cobro.TiempoJugado
                        .ToString(
                            @"hh\:mm\:ss"),

                    cobro.TotalCobrado
                        .ToString(
                            "0.00"),

                    cobro.TarifaFinal);
            }
        }
        private void frmHistorialCobros_Load(object sender, EventArgs e)
        {

        }
    }
}
