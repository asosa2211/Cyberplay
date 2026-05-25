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
        
        //CONSTRUCTOR
        public frmIngresosCaja()
        {
            InitializeComponent();
            CargarIngresos();
        }

        private void CargarIngresos()
        {
            // =====================
            // CARGAR
            // =====================

            ingresos =
                persistenciaIngresos
                    .CargarIngresos();

            // =====================
            // LIMPIAR
            // =====================

            dgvIngresos.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (IngresoCaja ingreso
                in ingresos)
            {
                dgvIngresos.Rows.Add(
                    ingreso.Fecha,
                    ingreso.Concepto,
                    ingreso.Monto,
                    ingreso.Cajero);
            }
        }
    }
}
