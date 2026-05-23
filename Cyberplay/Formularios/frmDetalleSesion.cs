using Cyberplay.Modelos;
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

        public frmDetalleSesion(Sesion sesion, ucPS4 consola)
        {
            InitializeComponent();

            this.sesion = sesion;

            this.consola = consola;

            CargarDetalle();
        }
        public frmDetalleSesion()
        {
            InitializeComponent();
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
            // DATOS
            // =====================

            lblUsuario.Text =
                sesion
                .UsuarioActual
                .NombreCuenta;

            lblEquipo.Text =
                consola
                .Estacion
                .Nombre;

            lblTiempo.Text =
                sesion
                .Cronometro
                .TiempoTranscurrido
                .ToString(
                    @"hh\:mm\:ss");

            // =====================
            // TOTAL TIEMPO
            // =====================

            decimal totalTiempo =
    consola
    .ObtenerTotalTiempo();

            lblTiempoTotal.Text =
                totalTiempo
                .ToString("0.00")
                + " Bs";

            // =====================
            // LIMPIAR
            // =====================

            dgvProductos.Rows.Clear();

            // =====================
            // TOTAL PRODUCTOS
            // =====================

            decimal totalProductos = 0;

            // =====================
            // RECORRER
            // =====================

            foreach (VentaProducto producto
                in sesion
                .ProductosConsumidos)
            {
                dgvProductos.Rows.Add(
                    producto.Producto,
                    producto.Cantidad,
                    producto.Total);

                totalProductos +=
                    producto.Total;
            }

            // =====================
            // LABEL PRODUCTOS
            // =====================

            lblTotalProductos.Text =
                totalProductos
                .ToString("0.00")
                + " Bs";

            // =====================
            // TOTAL GENERAL
            // =====================

            decimal totalGeneral =
                totalTiempo
                + totalProductos;

            lblTotalGeneral.Text =
                totalGeneral
                .ToString("0.00")
                + " Bs";
        }
    }
}
