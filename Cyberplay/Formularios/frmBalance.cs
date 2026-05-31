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
    public partial class frmBalance : Form
    {
        private PersistenciaIngresosCaja persistenciaIngresos = 
                                         new PersistenciaIngresosCaja();

        private PersistenciaEgresosCaja persistenciaEgresos =
                                        new PersistenciaEgresosCaja();

        private PersistenciaVentasProductos persistenciaVentas =
                                        new PersistenciaVentasProductos();


        //CONSTRUCTOR
        public frmBalance()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

            CargarBalance();
        }

        private void CargarBalance()
        {
            // =====================
            // CARGAR
            // =====================

            List<IngresoCaja> ingresos =
                persistenciaIngresos
                    .CargarIngresos();

            List<EgresoCaja> egresos =
                persistenciaEgresos
                    .CargarEgresos();

            List<VentaProducto> ventas =
    persistenciaVentas
        .CargarVentas();

            // =====================
            // TOTALES
            // =====================

            decimal totalIngresos =
                ingresos.Sum(
                    i => i.Monto);

            decimal totalEgresos =
                egresos.Sum(
                    e => e.Monto);
            decimal totalUtilidad =
    ventas.Sum(v => v.Utilidad);

            decimal balance =
                totalIngresos
                - totalEgresos;

            // =====================
            // LABELS
            // =====================

            lblIngresos.Text =
                totalIngresos
                .ToString("0.00")
                + " Bs";

            lblEgresos.Text =
                totalEgresos
                .ToString("0.00")
                + " Bs";

            lblUtilidad.Text =
    totalUtilidad
    .ToString("0.00")
    + " Bs";

            lblBalance.Text =
                balance
                .ToString("0.00")
                + " Bs";
        }

        private void frmBalance_Load(object sender, EventArgs e)
        {

        }
    }
}
