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
    }
}
