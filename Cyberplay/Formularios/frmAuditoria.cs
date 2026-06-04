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
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
            CargarAlertas();
        }

        private void CargarAlertas()
        {
            dgvAlertas.Rows.Clear();

            PersistenciaAlertasEquipos
                persistencia =
                    new PersistenciaAlertasEquipos();

            List<AlertaEquipo> alertas =
                persistencia
                    .CargarAlertas()
                    .OrderByDescending(
                        x => x.FechaHora)
                    .ToList();

            foreach (AlertaEquipo alerta
                in alertas)
            {
                dgvAlertas.Rows.Add(
                    alerta.Cajero,
                    alerta.FechaHora
                        .ToString(
                            "dd/MM/yyyy HH:mm:ss"),
                    alerta.NumeroEquipo);
            }
        }
    }
}
