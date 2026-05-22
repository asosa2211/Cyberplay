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


        //CONSTRUCTOR
        public frmBalance()
        {
            InitializeComponent();
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

            // =====================
            // TOTALES
            // =====================

            decimal totalIngresos =
                ingresos.Sum(
                    i => i.Monto);

            decimal totalEgresos =
                egresos.Sum(
                    e => e.Monto);

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

            lblBalance.Text =
                balance
                .ToString("0.00")
                + " Bs";
        }
    }
}
