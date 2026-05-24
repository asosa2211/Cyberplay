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
                            .Usuario
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
    }
}
