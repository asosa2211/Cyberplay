using Cyberplay.Core;
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
    public partial class frmEgresosCaja : Form
    {
        private PersistenciaEgresosCaja persistenciaEgresos = new PersistenciaEgresosCaja();

        private List<EgresoCaja> egresos = new List<EgresoCaja>();

        //CONSTRUCTOR
        public frmEgresosCaja()
        {
            InitializeComponent();
            CargarEgresos();
        }

        private void CargarEgresos()
        {
            // =====================
            // CARGAR
            // =====================

            egresos =
                persistenciaEgresos
                    .CargarEgresos();

            // =====================
            // LIMPIAR
            // =====================

            dgvEgresos.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (EgresoCaja egreso
                in egresos)
            {
                dgvEgresos.Rows.Add(
                    egreso.Fecha,
                    egreso.Concepto,
                    egreso.Monto,
                    egreso.Cajero);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (tbConcepto.Text.Trim()
                == "")
            {
                MessageBox.Show(
                    "Ingrese concepto.");

                return;
            }

            // =====================
            // VALIDAR MONTO
            // =====================

            if (nudMonto.Value <= 0)
            {
                MessageBox.Show(
                    "Ingrese monto válido.");

                return;
            }

            // =====================
            // CREAR
            // =====================

            EgresoCaja egreso =
                new EgresoCaja()
                {
                    Concepto =
                        tbConcepto.Text,

                    Monto =
                        nudMonto.Value,

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario
                };

            // =====================
            // AGREGAR
            // =====================

            egresos.Add(
                egreso);

            // =====================
            // GUARDAR
            // =====================

            persistenciaEgresos
                .GuardarEgresos(
                    egresos);

            // =====================
            // RECARGAR
            // =====================

            CargarEgresos();

            // =====================
            // LIMPIAR
            // =====================

            tbConcepto.Clear();

            nudMonto.Value = 0;

            // =====================
            // OK
            // =====================

            MessageBox.Show(
                "Egreso registrado.");
        }
    }
}
