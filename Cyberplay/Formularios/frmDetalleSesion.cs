using Cyberplay.Helpers;
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
    public partial class frmDetalleSesion : Form
    {
        private Sesion sesion;

        private ucPS4 consola;

        private PersistenciaProductos
    persistenciaProductos =
        new PersistenciaProductos();

        private List<Producto>
            productos =
                new List<Producto>();

        public frmDetalleSesion(Sesion sesion, ucPS4 consola)
        {
            InitializeComponent();

            this.sesion = sesion;

            this.consola = consola;

            CargarDetalle();
            

            productos =
    persistenciaProductos
        .CargarProductos();
        }
        public frmDetalleSesion()
        {
            InitializeComponent();
            productos =
    persistenciaProductos
        .CargarProductos();
        }


        private void CargarDetalle()
        {
            // =====================
            // VALIDAR
            // =====================

            if (sesion == null)
            {
                return;
            }

            // =====================
            // LIMPIAR
            // =====================

            dgvDetalleTiempo.Rows.Clear();

            dgvProductos.Rows.Clear();

            dgvHistorial.Rows.Clear();

            // =====================
            // TIEMPO JUGADO
            // =====================

            TimeSpan tiempoJugado =
                sesion
                .Cronometro
                .TiempoTranscurrido;

            // =====================
            // TOTAL TIEMPO
            // =====================

            decimal totalTiempo =
                consola
                .ObtenerTotalTiempo();

            // =====================
            // HORA FIN
            // =====================

            DateTime horaInicioReal =
                sesion
                .Cronometro
                .HoraInicioReal;

            if (horaInicioReal == DateTime.MinValue)
            {
                horaInicioReal =
                    DateTime.Now
                    - tiempoJugado;
            }

            string horaFin =
                horaInicioReal
                .Add(tiempoJugado)
                .ToString("HH:mm:ss");

            // =====================
            // DETALLE TIEMPO
            // =====================

            dgvDetalleTiempo.Rows.Add(
                sesion
                    .UsuarioActual
                    .NombreCuenta,

                consola
                    .Estacion
                    .Nombre,

                horaInicioReal
                    .ToString("HH:mm:ss"),


                horaFin,

                tiempoJugado
                    .ToString(
                        @"hh\:mm\:ss"),

                totalTiempo
                    .ToString("0.00")
            );

            // =====================
            // TOTAL PRODUCTOS
            // =====================

            decimal totalProductos = 0;

            // =====================
            // PRODUCTOS
            // =====================

            foreach (VentaProducto producto
                in sesion
                .ProductosConsumidos)
            {
                dgvProductos.Rows.Add(
                    producto.Detalle,
                    producto.PrecioUnitario.ToString("0.00"),
                    producto.Cantidad,

                    producto.Total
                        .ToString("0.00")
                );

                totalProductos +=
                    producto.Total;
            }

            // =====================
            // LABEL PRODUCTOS
            // =====================

            lblTotalProductos.Text = "Total Productos: " +
                totalProductos
                .ToString("0.00")
                + " Bs";

            // =====================
            // HISTORIAL TARIFAS
            // =====================

            TipoTarifa tarifaAnterior =
                sesion
                .TarifaInicial;

            foreach (CambioTarifa cambio
                in sesion
                .HistorialTarifas)
            {
                // =====================
                // TOTAL HASTA MOMENTO
                // =====================

                decimal totalHastaMomento =
                    consola
                    .ObtenerTotalHasta(
                        cambio.TiempoCambio);

                // =====================
                // AGREGAR
                // =====================

                dgvHistorial.Rows.Add(
                    tarifaAnterior
                        .ToString(),

                    cambio
                        .TarifaNueva
                        .ToString(),

                    cambio
                        .TiempoCambio
                        .ToString(
                            @"hh\:mm\:ss"),

                    totalHastaMomento
                        .ToString("0.00")
                );

                // =====================
                // ACTUALIZAR
                // =====================

                tarifaAnterior =
                    cambio
                    .TarifaNueva;
            }

            // =====================
            // TOTAL GENERAL
            // =====================

            decimal totalGeneral =
                totalTiempo
                + totalProductos;

            lblTotalGeneral.Text = "Total General: " +
                totalGeneral
                .ToString("0.00")
                + " Bs";
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (e.RowIndex < 0)
            {
                return;
            }

            // =====================
            // FILA
            // =====================

            DataGridViewRow fila =
                dgvProductos.Rows[e.RowIndex];

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                fila.Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR PRODUCTO SESION
            // =====================

            VentaProducto venta =
                sesion
                .ProductosConsumidos
                .FirstOrDefault(
                    p =>
                    p.Producto
                    == nombre);

            if (venta == null)
            {
                return;
            }

            // =====================
            // DEVOLVER STOCK
            // =====================

            Producto producto =
                productos
                .FirstOrDefault(
                    p =>
                    p.Nombre
                    == nombre);

            if (producto != null)
            {
                producto.Stock++;
            }

            // =====================
            // DISMINUIR
            // =====================

            venta.Cantidad--;

            // =====================
            // ELIMINAR
            // =====================

            if (venta.Cantidad <= 0)
            {
                sesion
                    .ProductosConsumidos
                    .Remove(
                        venta);
            }

            // =====================
            // GUARDAR STOCK
            // =====================

            persistenciaProductos
                .GuardarProductos(
                    productos);

            // =====================
            // RECARGAR
            // =====================

            CargarDetalle();

            consola.ActualizarTotal();
            consola.ActualizarIndicadorCarrito();
            consola.NotificarEstadoSesionCambiado();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvProductos
                .SelectedRows
                .Count == 0)
            {
                return;
            }

            // =====================
            // FILA
            // =====================

            DataGridViewRow fila =
                dgvProductos
                .SelectedRows[0];

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                fila.Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR VENTA
            // =====================

            VentaProducto venta =
                sesion
                .ProductosConsumidos
                .FirstOrDefault(
                    p =>
                    p.Producto
                    == nombre);

            if (venta == null)
            {
                return;
            }

            // =====================
            // DEVOLVER STOCK
            // =====================

            Producto producto =
                productos
                .FirstOrDefault(
                    p =>
                    p.Nombre
                    == nombre);

            if (producto != null)
            {
                producto.Stock +=
                    venta.Cantidad;
            }

            // =====================
            // ELIMINAR
            // =====================

            sesion
                .ProductosConsumidos
                .Remove(
                    venta);

            // =====================
            // GUARDAR
            // =====================

            persistenciaProductos
                .GuardarProductos(
                    productos);

            // =====================
            // RECARGAR
            // =====================

            CargarDetalle();

            consola.ActualizarTotal();
            consola.ActualizarIndicadorCarrito();
            consola.NotificarEstadoSesionCambiado();
        }

        private void dgvProductos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // =====================
            // CLICK DERECHO
            // =====================

            if (e.Button
                == MouseButtons.Right
                && e.RowIndex >= 0)
            {
                dgvProductos.ClearSelection();

                dgvProductos.Rows[e.RowIndex]
                    .Selected = true;

                dgvProductos.CurrentCell =
                    dgvProductos.Rows[e.RowIndex]
                    .Cells[0];
            }
        }

        private void frmDetalleSesion_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configurar(dgvDetalleTiempo);
            DataGridViewHelper.Configurar(dgvProductos);
            DataGridViewHelper.Configurar(dgvHistorial);
            dgvDetalleTiempo.ClearSelection();
            dgvProductos.ClearSelection();
            dgvHistorial.ClearSelection();
        }
    }
}
