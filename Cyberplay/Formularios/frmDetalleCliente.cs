using Cyberplay.Helpers;
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
    public partial class frmDetalleCliente : Form
    {
        private readonly Usuario usuario;
        private readonly GestorHistorialClientes gestorHistorial;
        private List<RegistroCobro> historialCompleto;
        public frmDetalleCliente(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            gestorHistorial = new GestorHistorialClientes();
            CargarDatosCliente();
            CargarHistorial();
        }

        private void frmDetalleCliente_Load(object sender, EventArgs e)
        {
            dgvHistorial.CellDoubleClick +=
    dgvHistorial_CellDoubleClick;
            DataGridViewHelper.Configurar(dgvHistorial);
            dgvHistorial.ClearSelection();
        }

        private void ActualizarEstadisticas(List<RegistroCobro> historial)
        {
            int cantidad = historial.Count;
            lblCantidadSesiones.Text = $"{cantidad}";

            TimeSpan tiempoTotal = TimeSpan.Zero;
            foreach (RegistroCobro cobro in historial)
            {
                tiempoTotal += cobro.TiempoJugado;
            }
            lblTiempoTotal.Text = $"{FormatearTiempo(tiempoTotal)}";

            TimeSpan promedio =
    TimeSpan.Zero;

            if (cantidad > 0)
            {
                promedio =
                    TimeSpan.FromTicks(
                        (long)historial
                            .Average(c =>
                                c.TiempoJugado.Ticks));
            }
            lblPromedio.Text =
    $"{FormatearTiempo(promedio)}";

            if (historial.Any())
            {
                lblUltimaVisita.Text =
                    $"{historial.First().Fecha:d}";
            }
            else
            {
                lblUltimaVisita.Text =
                    "Última visita: -";
            }

        }
        private string FormatearTiempo(TimeSpan tiempo)
        {
            return $"{(int)tiempo.TotalHours}h {tiempo.Minutes}m";
        }
        private void CargarHistorial()
        {
            historialCompleto =
    gestorHistorial.ObtenerHistorial(
        usuario.NombreCuenta);
            MostrarHistorial(historialCompleto);


            ActualizarEstadisticas(historialCompleto);
        }

        private void MostrarHistorial(List<RegistroCobro> historial)
        {
            dgvHistorial.Rows.Clear();

            foreach (RegistroCobro cobro in historial)
            {
                DateTime horaFin =
                    cobro.HoraInicio + cobro.TiempoJugado;

                int indice =
    dgvHistorial.Rows.Add(
        cobro.Fecha.ToShortDateString(),
        cobro.HoraInicio.ToString("HH:mm"),
        horaFin.ToString("HH:mm"),
        FormatearTiempo(cobro.TiempoJugado),
        cobro.NumeroEquipo,
        cobro.TipoEquipo,
        cobro.TotalCobrado.ToString("0.00"),
        cobro.NumeroCaja);

                dgvHistorial.Rows[indice].Tag =
                    cobro;
            }
        } 

        private void FiltrarHistorial()
        {
            DateTime desde = dtpDesde.Value.Date;

            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            List<RegistroCobro> historialFiltrado =
    historialCompleto
        .Where(c =>
            c.Fecha >= desde &&
            c.Fecha <= hasta)
        .ToList();

            MostrarHistorial(historialFiltrado);
            ActualizarEstadisticas(historialFiltrado);
        }
        private void CargarDatosCliente()
        {
            lblCuenta.Text = $"{usuario.NombreCuenta}";
            lblNombre.Text = $"{usuario.NombreCliente}";
            lblTelefono.Text = $"{usuario.Telefono}";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarHistorial();
            dgvHistorial.ClearSelection();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            MostrarHistorial(historialCompleto);
            ActualizarEstadisticas(historialCompleto);
            dgvHistorial.ClearSelection();
        }

        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (e.RowIndex < 0)
            {
                return;
            }

            // =====================
            // OBTENER COBRO
            // =====================

            RegistroCobro cobro =
                dgvHistorial.Rows[e.RowIndex]
                    .Tag as RegistroCobro;

            if (cobro == null)
            {
                return;
            }

            // =====================
            // ABRIR DETALLE
            // =====================

            frmDetalleCobro frm =
                new frmDetalleCobro(
                    cobro);

            frm.ShowDialog();
        }
    }
}
