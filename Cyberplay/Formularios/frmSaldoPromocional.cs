using Cyberplay.Core;
using Cyberplay.enums;
using Cyberplay.Helpers;
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

        public frmSaldoPromocional(
    GestorUsuarios gestorUsuarios,
    string nombreCuenta)
    : this(gestorUsuarios)
        {
            Usuario usuario =
                gestorUsuarios.BuscarUsuario(
                    nombreCuenta);

            if (usuario != null)
            {
                usuarioSeleccionado =
                    usuario;

                CargarUsuario();
            }
        }

        private void DeshabilitarOrdenamiento(DataGridView dgv)
        {
            foreach (DataGridViewColumn columna
                in dgv.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void CargarTiposMovimiento()
        {
            cbTipo.DataSource = new List<TipoMovimientoSaldo>
{
    TipoMovimientoSaldo.Ranking,
    TipoMovimientoSaldo.Ajuste
};
        }
        private void frmSaldoPromocional_Load(object sender, EventArgs e)
        {
            DeshabilitarOrdenamiento(dgvMovimientos);
            DataGridViewHelper.Configurar(dgvMovimientos, new DataGridViewOptions
            {
                HeaderHeight = 35,
                HeaderFontSize = 9,
                RowFontSize = 9,
                RowFontStyle = FontStyle.Regular
            });
        }

        private void CargarUsuario()
        {
            if (usuarioSeleccionado == null)
            {
               // tbCuenta.Clear();

                lblNombreValor.Text = "Sin seleccionar";

                lblSaldoValor.Text = "0.00 Bs";

                dgvMovimientos.Rows.Clear();

                return;
            }

            lblCuentaValor.Text =
                usuarioSeleccionado.NombreCuenta;

            lblNombreValor.Text =
                usuarioSeleccionado.NombreCliente;

            decimal saldo =
                gestorSaldo.ObtenerSaldo(
                    usuarioSeleccionado.NombreCuenta);

            lblSaldoValor.Text =
                $"{saldo:N2} Bs";

            CargarHistorial();
        }

        private void CargarHistorial()
        {
            PersistenciaCobros persistenciaCobros =
    new PersistenciaCobros();

            List<RegistroCobro> cobros =
                persistenciaCobros.CargarCobros();

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
                int indice =
                    dgvMovimientos.Rows.Add(
                        movimiento.Fecha.ToString("dd/MM/yyyy"),
                        movimiento.Tipo,
                        movimiento.Monto.ToString("N2"),
                        movimiento.SaldoAnterior.ToString("N2"),
                        movimiento.SaldoPosterior.ToString("N2"),
                        movimiento.Observacion,
                        movimiento.Cajero);

                RegistroCobro cobro =
                    cobros.FirstOrDefault(
                        x => x.TicketId == movimiento.TicketId);

                dgvMovimientos.Rows[indice].Tag =
                    cobro;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios(gestorUsuarios);

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

        private void lblCuentaValor_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios(gestorUsuarios);

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

        private void btnResetSaldo_Click(object sender, EventArgs e)
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
            // SIN SALDO
            // =====================

            if (usuarioSeleccionado.SaldoPromocional <= 0)
            {
                MessageBox.Show(
                    "El usuario no tiene saldo promocional.");

                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    $"Se eliminarán {usuarioSeleccionado.SaldoPromocional:0.00} Bs del saldo promocional.\n\n¿Desea continuar?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                return;
            }

            // =====================
            // CADUCAR SALDO
            // =====================

            try
            {
                gestorSaldo.CaducarSaldo(
                    usuarioSeleccionado.NombreCuenta,

                    "Caducidad del saldo promocional.",

                    SesionSistema.CajeroActual.Usuario,

                    SesionSistema.CajaActual.NumeroCaja);

                MessageBox.Show(
                    "El saldo fue eliminado correctamente.");

                CargarUsuario();
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

        private void dgvMovimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {// =====================
         // VALIDAR FILA
         // =====================

            if (e.RowIndex < 0)
            {
                return;
            }

            // =====================
            // VALIDAR TIPO
            // =====================

            TipoMovimientoSaldo tipo =
                (TipoMovimientoSaldo)
                dgvMovimientos.Rows[e.RowIndex]
                    .Cells["colTipo"]
                    .Value;

            if (tipo != TipoMovimientoSaldo.Consumo)
            {
                MessageBox.Show(
                    "Este movimiento no corresponde a un cobro, por lo que no existe un detalle para mostrar.",
                    "Detalle no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // =====================
            // OBTENER COBRO
            // =====================

            RegistroCobro cobro =
                dgvMovimientos.Rows[e.RowIndex]
                    .Tag as RegistroCobro;

            if (cobro == null)
            {
                MessageBox.Show(
                    "No fue posible encontrar el cobro asociado a este movimiento.",
                    "Detalle no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // =====================
            // MOSTRAR DETALLE
            // =====================

            frmDetalleCobro frm =
                new frmDetalleCobro(cobro);

            frm.ShowDialog();
        }
    }
}
