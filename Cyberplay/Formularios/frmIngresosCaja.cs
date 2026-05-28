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
    public partial class frmIngresosCaja : Form
    {
        private PersistenciaIngresosCaja persistenciaIngresos = new PersistenciaIngresosCaja();

        private List<IngresoCaja> ingresos = new List<IngresoCaja>();

        public event Action IngresoRegistrado;

        //CONSTRUCTOR
        public frmIngresosCaja()
        {
            InitializeComponent();
            
        }

        private void btnIngresoCaja_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (string.IsNullOrWhiteSpace(
                tbConcepto.Text))
            {
                MessageBox.Show(
                    "Ingrese un concepto.");

                return;
            }

            if (nudTotal.Value <= 0)
            {
                MessageBox.Show(
                    "Ingrese un monto válido.");

                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Registrar ingreso?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }
            // =====================
            // CREAR INGRESO
            // =====================

            IngresoCaja ingreso =
                new IngresoCaja()
                {
                    Concepto =
                        tbConcepto.Text
                        .Trim(),

                    Monto =
                        nudTotal.Value,

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario,
                    NumeroCaja =
                         SesionSistema
                             .CajaActual
                             .NumeroCaja,
                };

            // =====================
            // CARGAR
            // =====================

            PersistenciaIngresosCaja
                persistencia =
                    new PersistenciaIngresosCaja();

            List<IngresoCaja> ingresos =
                persistencia
                    .CargarIngresos();

            // =====================
            // AGREGAR
            // =====================

            ingresos.Add(
                ingreso);

            // =====================
            // GUARDAR
            // =====================

            persistencia
                .GuardarIngresos(
                    ingresos);

            // =====================
            // ACTUALIZAR CAJA
            // =====================

            SesionSistema
                .CajaActual
                .TotalCobrado +=
                    ingreso.Monto;

            // =====================
            // GUARDAR CAJA
            // =====================

            PersistenciaCaja
                persistenciaCaja =
                    new PersistenciaCaja();

            persistenciaCaja
                .GuardarCaja(
                    SesionSistema
                        .CajaActual);

            // =====================
            // ACTUALIZAR UI
            // =====================

            MessageBox.Show(
                "Ingreso registrado correctamente.");

            IngresoRegistrado?.Invoke();
            Close();
        }

        private void nudTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudTotal_Enter(object sender, EventArgs e)
        {
            nudTotal.Select(0, nudTotal.Text.Length);
        }

        private void nudTotal_Click(object sender, EventArgs e)
        {
            nudTotal.Select(0, nudTotal.Text.Length);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
