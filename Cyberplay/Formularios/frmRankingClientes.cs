using Cyberplay.Helpers;
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
    public partial class frmRankingClientes : Form
    {
        public frmRankingClientes()
        {
            InitializeComponent();
        }

        private void CargarRankingClientes()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvRanking.Rows.Clear();

            // =====================
            // COBROS
            // =====================

            PersistenciaCobros persistencia =
                new PersistenciaCobros();

            List<RegistroCobro> cobros =
                persistencia.CargarCobros();

            // =====================
            // FILTRO FECHA
            // =====================

            if (rbFecha.Checked)
            {
                DateTime desde =
                    dtpDesde.Value.Date;

                DateTime hasta =
                    dtpHasta.Value.Date
                        .AddDays(1)
                        .AddTicks(-1);

                cobros =
                    cobros
                    .Where(
                        x =>
                        x.Fecha >= desde
                        &&
                        x.Fecha <= hasta)
                    .ToList();
            }

            // =====================
            // FILTRO CAJA
            // =====================

            else if (rbCaja.Checked)
            {
                int cajaDesde =
                    (int)nudCajaDesde.Value;

                int cajaHasta =
                    (int)nudCajaHasta.Value;

                cobros =
                    cobros
                    .Where(
                        x =>
                        x.NumeroCaja >= cajaDesde
                        &&
                        x.NumeroCaja <= cajaHasta)
                    .ToList();
            }

            // =====================
            // AGRUPAR CLIENTES
            // =====================

            var ranking =
                cobros
                .Where(
                    x =>
                    !string.IsNullOrWhiteSpace(
                        x.NombreCuenta)
                    &&
                    !x.NombreCuenta.Equals(
                        "Invitado",
                        StringComparison.OrdinalIgnoreCase))
                .GroupBy(
                    x =>
                    x.NombreCuenta)
                .Select(
                    g =>
                    new
                    {
                        Cliente =
                            g.Key,

                        TotalHoras =
    g.Sum(
        x =>
        (x.TiempoJugado
        - x.TiempoCubiertoPorSaldo)
        .TotalHours),

                        TotalMinutos =
    g.Sum(
        x =>
        (x.TiempoJugado
        - x.TiempoCubiertoPorSaldo)
        .TotalMinutes)
                    })
                .OrderByDescending(
                    x =>
                    x.TotalMinutos)
                .ToList();

            // =====================
            // GRID
            // =====================

            int posicion = 1;

            foreach (var item
                in ranking)
            {
                dgvRanking.Rows.Add(
                    posicion,
                    item.Cliente,
                    item.TotalHoras.ToString("0.00"),
                    item.TotalMinutos.ToString("0"));
                

                posicion++;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarRankingClientes();
            dgvRanking.ClearSelection();
        }

        private void frmRankingClientes_Load(object sender, EventArgs e)
        {
            rbFecha.Checked = true;
            DataGridViewHelper.Configurar(dgvRanking);
            dgvRanking.ClearSelection();
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled =
        rbFecha.Checked;

            dtpHasta.Enabled =
                rbFecha.Checked;

            nudCajaDesde.Enabled =
                !rbFecha.Checked;

            nudCajaHasta.Enabled =
                !rbFecha.Checked;
        }

        private void rbCaja_CheckedChanged(object sender, EventArgs e)
        {
            rbFecha_CheckedChanged(
        sender,
        e);
        }
    }
}
