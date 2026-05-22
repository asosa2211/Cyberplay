using Cyberplay.Core;
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
    public partial class frmVentaProductos : Form
    {
        private PersistenciaProductos persistenciaProductos = new PersistenciaProductos();

        private PersistenciaVentasProductos persistenciaVentas = new PersistenciaVentasProductos();
        private PersistenciaIngresosCaja persistenciaIngresos = new PersistenciaIngresosCaja();

        private List<Producto> productos = new List<Producto>();

        private List<VentaProducto> ventas = new List<VentaProducto>();

        //CONSTRUCTOR
        public frmVentaProductos()
        {
            InitializeComponent();
            CargarProductos();
            CargarVentas();
        }

        private void CargarProductos()
        {
            // =====================
            // CARGAR
            // =====================

            productos =
                persistenciaProductos
                    .CargarProductos();

            // =====================
            // COMBO
            // =====================

            cbProductos.DataSource =
                null;

            cbProductos.DataSource =
                productos;

            cbProductos.DisplayMember =
                "Nombre";
        }

        private void CargarVentas()
        {
            // =====================
            // CARGAR
            // =====================

            ventas =
                persistenciaVentas
                    .CargarVentas();

            // =====================
            // LIMPIAR
            // =====================

            dgvVentas.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (VentaProducto venta
                in ventas)
            {
                dgvVentas.Rows.Add(
                    venta.Producto,
                    venta.Cantidad,
                    venta.Total,
                    venta.Cajero,
                    venta.Fecha);
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            // =====================
            // VALIDAR
            // =====================

            if (cbProductos.SelectedItem
                == null)
            {
                return;
            }

            // =====================
            // PRODUCTO
            // =====================

            Producto producto =
                (Producto)
                cbProductos.SelectedItem;

            // =====================
            // PRECIO
            // =====================

            lblPrecio.Text =
                producto.Precio
                .ToString("0.00")
                + " Bs";

            // =====================
            // TOTAL
            // =====================

            decimal total =
                producto.Precio
                *
                nudCantidad.Value;

            lblTotal.Text =
                total.ToString("0.00")
                + " Bs";
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (cbProductos.SelectedItem
                == null)
            {
                return;
            }

            // =====================
            // PRODUCTO
            // =====================

            Producto producto =
                (Producto)
                cbProductos.SelectedItem;

            // =====================
            // CANTIDAD
            // =====================

            int cantidad =
                (int)nudCantidad.Value;

            // =====================
            // VALIDAR CANTIDAD
            // =====================

            if (cantidad <= 0)
            {
                MessageBox.Show(
                    "Ingrese cantidad válida.");

                return;
            }

            // =====================
            // VALIDAR STOCK
            // =====================

            if (cantidad
                > producto.Stock)
            {
                MessageBox.Show(
                    "Stock insuficiente.");

                return;
            }

            // =====================
            // TOTAL
            // =====================

            decimal total =
                producto.Precio
                * cantidad;

            // =====================
            // CREAR VENTA
            // =====================

            VentaProducto venta =
                new VentaProducto()
                {
                    Producto =
                        producto.Nombre,

                    Cantidad =
                        cantidad,

                    PrecioUnitario =
                        producto.Precio,

                    Total =
                        total,

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario
                };

            // =====================
            // DESCONTAR STOCK
            // =====================

            producto.Stock -=
                cantidad;

            // =====================
            // AGREGAR VENTA
            // =====================

            ventas.Add(venta);

            // =====================
            // INGRESO CAJA
            // =====================

            List<IngresoCaja> ingresos =
                persistenciaIngresos
                    .CargarIngresos();

            IngresoCaja ingreso =
                new IngresoCaja()
                {
                    Concepto =
                        "Venta producto: "
                        + producto.Nombre,

                    Monto =
                        total,

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario
                };

            ingresos.Add(
                ingreso);

            // =====================
            // GUARDAR
            // =====================

            persistenciaIngresos
                .GuardarIngresos(
                    ingresos);

            // =====================
            // GUARDAR VENTAS
            // =====================

            persistenciaVentas
                .GuardarVentas(
                    ventas);

            // =====================
            // GUARDAR PRODUCTOS
            // =====================

            persistenciaProductos
                .GuardarProductos(
                    productos);

            // =====================
            // RECARGAR
            // =====================

            CargarProductos();

            CargarVentas();

            // =====================
            // RESET
            // =====================

            nudCantidad.Value = 1;

            ActualizarTotales();

            // =====================
            // OK
            // =====================

            MessageBox.Show(
                "Venta realizada correctamente.");
        }
    }
}
