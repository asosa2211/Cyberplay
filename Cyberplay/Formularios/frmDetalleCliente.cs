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

        }

        private void ActualizarEstadisticas(List<RegistroCobro> historial)
        {
            int cantidad = historial.Count;
            lblCantidadSesiones.Text = $"Sesiones: {cantidad}";

            TimeSpan tiempoTotal = TimeSpan.Zero;
            foreach (RegistroCobro cobro in historial)
            {
                tiempoTotal += cobro.TiempoJugado;
            }
            lblTiempoTotal.Text = $"Tiempo total: {FormatearTiempo(tiempoTotal)}";

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
    $"Promedio: {FormatearTiempo(promedio)}";

            if (historial.Any())
            {
                lblUltimaVisita.Text =
                    $"Última visita: {historial.First().Fecha:d}";
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

                dgvHistorial.Rows.Add(
                    cobro.Fecha.ToShortDateString(),
                    cobro.HoraInicio.ToString("HH:mm"),
                    horaFin.ToString("HH:mm"),
                    FormatearTiempo(cobro.TiempoJugado),
                    cobro.EquipoDescripcion,
                    cobro.TarifaFinal,
                    cobro.TotalCobrado.ToString("0.00"),
                    cobro.NumeroCaja);
            }
            lblTotalMostrado.Text =
    $"Total mostrado: {historial.Count} sesiones";
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
            lblCuenta.Text = $"Cuenta: {usuario.NombreCuenta}";
            lblNombre.Text = $"Nombre: {usuario.NombreCliente}";
            lblTelefono.Text = $"Teléfono: {usuario.Telefono}";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarHistorial();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            MostrarHistorial(historialCompleto);
            ActualizarEstadisticas(historialCompleto);
        }
    }
}
