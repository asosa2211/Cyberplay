using Cyberplay.Core;
using Cyberplay.enums;
using Cyberplay.Modelos;
using Cyberplay.Servicios;
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
    public partial class frmSaldoPromocional : Form
    {
        private readonly GestorSaldoPromocional gestorSaldo;

        private readonly GestorUsuarios gestorUsuarios;

        private Usuario usuarioSeleccionado;
        public frmSaldoPromocional(GestorUsuarios gestorUsuarios)
        {
            InitializeComponent();

            this.gestorUsuarios = gestorUsuarios;

            gestorSaldo =
                new GestorSaldoPromocional(
                    gestorUsuarios);

            CargarTiposMovimiento();
        }

        private void CargarTiposMovimiento()
        {
            cbTipo.DataSource = new List<TipoMovimientoSaldo>
{
    TipoMovimientoSaldo.PremioRanking,
    TipoMovimientoSaldo.AjusteManual
};
        }
        private void frmSaldoPromocional_Load(object sender, EventArgs e)
        {

        }

        private void CargarUsuario()
        {
            if (usuarioSeleccionado == null)
            {
                tbCuenta.Clear();

                lblNombre.Text = "Sin seleccionar";

                lblSaldo.Text = "0.00 Bs";

                dgvMovimientos.Rows.Clear();

                return;
            }

            tbCuenta.Text =
                usuarioSeleccionado.NombreCuenta;

            lblNombre.Text =
                usuarioSeleccionado.NombreCliente;

            decimal saldo =
                gestorSaldo.ObtenerSaldo(
                    usuarioSeleccionado.NombreCuenta);

            lblSaldo.Text =
                $"{saldo:N2} Bs";

            CargarHistorial();
        }

        private void CargarHistorial()
        {
            dgvMovimientos.Rows.Clear();

            if (usuarioSeleccionado == null)
            {
                return;
            }

            List<MovimientoSaldo> historial =
                gestorSaldo.ObtenerHistorial(
                    usuarioSeleccionado.NombreCuenta);

            foreach (MovimientoSaldo movimiento in historial)
            {
                dgvMovimientos.Rows.Add(
                    movimiento.Fecha,
                    movimiento.Tipo,
                    movimiento.Monto.ToString("N2"),
                    movimiento.SaldoAnterior.ToString("N2"),
                    movimiento.SaldoPosterior.ToString("N2"),
                    movimiento.Observacion,
                    movimiento.Cajero);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmUsuarios frm =
         new frmUsuarios(
             gestorUsuarios);

            frm.ModoSeleccion = true;

            if (frm.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            usuarioSeleccionado =
                frm.UsuarioSeleccionado;

            if (usuarioSeleccionado == null)
            {
                return;
            }

            CargarUsuario();
        }

        private void btnAgregarSaldo_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR USUARIO
            // =====================

            if (usuarioSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.");

                return;
            }

            // =====================
            // VALIDAR MONTO
            // =====================

            if (nudMonto.Value <= 0)
            {
                MessageBox.Show(
                    "Ingrese un monto mayor a cero.");

                return;
            }

            // =====================
            // VALIDAR OBSERVACIÓN
            // =====================

            if (string.IsNullOrWhiteSpace(
                tbObservacion.Text))
            {
                MessageBox.Show(
                    "Ingrese una observación.");

                return;
            }

            try
            {
                TipoMovimientoSaldo tipo =
                    (TipoMovimientoSaldo)cbTipo.SelectedItem;

                gestorSaldo.AgregarSaldo(
                    usuarioSeleccionado.NombreCuenta,

                    (decimal)nudMonto.Value,

                    tipo,

                    tbObservacion.Text.Trim(),

                    SesionSistema
                        .CajeroActual
                        .Usuario,

                    SesionSistema
                        .CajaActual
                        .NumeroCaja);

                MessageBox.Show(
                    "Saldo agregado correctamente.");

                CargarUsuario();

                nudMonto.Value = 0;

                tbObservacion.Clear();

                cbTipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
