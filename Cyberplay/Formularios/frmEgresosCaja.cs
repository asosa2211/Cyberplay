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

        public event Action EgresoRegistrado;

        //CONSTRUCTOR
        public frmEgresosCaja()
        {
            InitializeComponent();
            
        }

        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (string.IsNullOrWhiteSpace(
                tbConcepto.Text))
            {
                MessageBox.Show(
                    "Ingrese un detalle.");

                return;
            }

            if (nudMonto.Value <= 0)
            {
                MessageBox.Show(
                    "Ingrese un monto válido.");

                return;
            }

            // =====================
            // VALIDAR CAJA
            // =====================

            if (nudMonto.Value >
                SesionSistema
                    .CajaActual
                    .TotalCobrado)
            {
                MessageBox.Show(
                    "La caja no tiene suficiente saldo.");

                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Registrar egreso?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }
            // =====================
            // CREAR EGRESO
            // =====================

            EgresoCaja egreso =
                new EgresoCaja()
                {
                    Concepto =
                        tbConcepto.Text
                        .Trim(),

                    Monto =
                        nudMonto.Value,

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

            PersistenciaEgresosCaja
                persistencia =
                    new PersistenciaEgresosCaja();

            List<EgresoCaja> egresos =
                persistencia
                    .CargarEgresos();

            // =====================
            // AGREGAR
            // =====================

            egresos.Add(
                egreso);

            // =====================
            // GUARDAR
            // =====================

            persistencia
                .GuardarEgresos(
                    egresos);

            // =====================
            // ACTUALIZAR CAJA
            // =====================

            SesionSistema
                .CajaActual
                .TotalCobrado -=
                    egreso.Monto;

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
            // REFRESCAR PRINCIPAL
            // =====================

            EgresoRegistrado?.Invoke();

            // =====================
            // MENSAJE
            // =====================

            MessageBox.Show(
                "Egreso registrado correctamente.");

            // =====================
            // CERRAR
            // =====================

            Close();
        }

        private void nudMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudMonto_Enter(object sender, EventArgs e)
        {
            nudMonto.Select(0, nudMonto.Text.Length);
        }

        private void nudMonto_Click(object sender, EventArgs e)
        {
            nudMonto.Select(0, nudMonto.Text.Length);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
