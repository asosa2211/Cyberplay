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
            CargarCategorias();
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

            
        }

       

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductosCategoria();
            
        }

        private void CargarProductosCategoria()
        {
            // =====================
            // VALIDAR
            // =====================

            if (cbCategorias.SelectedItem
                == null)
            {
                return;
            }

            // =====================
            // CATEGORIA
            // =====================

            string categoria =
                cbCategorias
                .SelectedItem
                .ToString();

            // =====================
            // FILTRAR
            // =====================

            List<Producto> filtrados =
                productos
                .Where(
                    p =>
                    p.Categoria
                    == categoria)
                .OrderBy(
                    p =>
                    p.Nombre)
                .ToList();

            // =====================
            // LIMPIAR
            // =====================

            dgvProductos.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (Producto producto
                in filtrados)
            {
                dgvProductos.Rows.Add(
                    producto.Nombre,
                    producto.PrecioVenta,
                    producto.Stock);
            }
        }

        private void CargarCategorias()
        {
            // =====================
            // LIMPIAR
            // =====================

            //cbCategorias.Items.Clear();
            cbCategorias.Items.Clear();

            // =====================
            // OBTENER
            // =====================

            List<string> categorias =
                productos
                .Select(
                    p => p.Categoria)
                .Distinct()
                .OrderBy(
                    c => c)
                .ToList();

            // =====================
            // AGREGAR
            // =====================

            foreach (string categoria
                in categorias)
            {
                cbCategorias.Items.Add(
                    categoria);
            }

            // =====================
            // SELECCIONAR
            // =====================

            if (cbCategorias.Items.Count
                > 0)
            {
                cbCategorias.SelectedIndex = 0;
            }
        }
        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            
        }

        

        private void btnVender_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay productos en el carrito.");

                return;
            }

            // =====================
            // TOTALES
            // =====================

            decimal totalGeneral = 0;

            decimal utilidadGeneral = 0;

            // =====================
            // RECORRER CARRITO
            // =====================

            foreach (DataGridViewRow fila
                in dgvCarrito.Rows)
            {
                // =====================
                // DATOS
                // =====================

                string nombre =
                    fila.Cells[0]
                    .Value
                    .ToString();

                int cantidad =
                    Convert.ToInt32(
                        fila.Cells[1]
                        .Value);

                // =====================
                // BUSCAR PRODUCTO
                // =====================

                Producto producto =
                    productos
                    .FirstOrDefault(
                        p =>
                        p.Nombre
                        == nombre);

                if (producto == null)
                {
                    continue;
                }

                // =====================
                // VALIDAR STOCK
                // =====================

                if (cantidad
                    > producto.Stock)
                {
                    MessageBox.Show(
                        "Stock insuficiente para: "
                        + producto.Nombre);

                    return;
                }

                // =====================
                // TOTAL
                // =====================

                decimal total =
                    producto.PrecioVenta
                    * cantidad;

                // =====================
                // UTILIDAD
                // =====================

                decimal utilidad =
                    (producto.PrecioVenta
                    - producto.PrecioCosto)
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
                            producto.PrecioVenta,

                        Total =
                            total,

                        Utilidad =
                            utilidad,

                        Cajero =
                            SesionSistema
                                .CajeroActual
                                .Usuario
                    };

                // =====================
                // AGREGAR
                // =====================

                ventas.Add(
                    venta);

                // =====================
                // DESCONTAR STOCK
                // =====================

                producto.Stock -=
                    cantidad;

                // =====================
                // ACUMULAR
                // =====================

                totalGeneral +=
                    total;

                utilidadGeneral +=
                    utilidad;
            }

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
            // INGRESO CAJA
            // =====================

            List<IngresoCaja> ingresos =
                persistenciaIngresos
                    .CargarIngresos();

            IngresoCaja ingreso =
                new IngresoCaja()
                {
                    Concepto =
                        "Venta productos",

                    Monto =
                        totalGeneral,

                    Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario
                };

            ingresos.Add(
                ingreso);

            // =====================
            // GUARDAR INGRESOS
            // =====================

            persistenciaIngresos
                .GuardarIngresos(
                    ingresos);

            // =====================
            // ACTUALIZAR CAJA
            // =====================

            SesionSistema
                .CajaActual
                .TotalCobrado
                += totalGeneral;

            // =====================
            // REFRESCAR UI
            // =====================

            frmPrincipal principal =
                Application.OpenForms
                .OfType<frmPrincipal>()
                .FirstOrDefault();

            if (principal != null)
            {
                principal.ActualizarCaja();
            }

            // =====================
            // LIMPIAR
            // =====================

            dgvCarrito.Rows.Clear();

            ActualizarTotalVenta();

            CargarProductosCategoria();

            // =====================
            // OK
            // =====================

            MessageBox.Show(
                "Venta realizada correctamente.");
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
            // NOMBRE
            // =====================

            string nombre =
                dgvProductos
                .Rows[e.RowIndex]
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR PRODUCTO
            // =====================

            Producto producto =
                productos
                .FirstOrDefault(
                    p =>
                    p.Nombre
                    == nombre);

            if (producto == null)
            {
                return;
            }

            // =====================
            // BUSCAR EN CARRITO
            // =====================

            foreach (DataGridViewRow fila
                in dgvCarrito.Rows)
            {
                if (fila.Cells[0]
                    .Value
                    .ToString()
                    == producto.Nombre)
                {
                    // =====================
                    // AUMENTAR CANTIDAD
                    // =====================

                    int cantidad =
                        Convert.ToInt32(
                            fila.Cells[1]
                            .Value);

                    cantidad++;

                    fila.Cells[1].Value =
                        cantidad;

                    // =====================
                    // ACTUALIZAR TOTAL
                    // =====================

                    fila.Cells[2].Value =
                        cantidad
                        * producto.PrecioVenta;

                    ActualizarTotalVenta();

                    return;
                }
            }

            // =====================
            // NUEVO EN CARRITO
            // =====================

            dgvCarrito.Rows.Add(
                producto.Nombre,
                1,
                producto.PrecioVenta);

            // =====================
            // TOTAL
            // =====================

            ActualizarTotalVenta();
        }

        private void ActualizarTotalVenta()
        {
            decimal total = 0;

            // =====================
            // RECORRER
            // =====================

            foreach (DataGridViewRow fila
                in dgvCarrito.Rows)
            {
                total +=
                    Convert.ToDecimal(
                        fila.Cells[2]
                        .Value);
            }

            // =====================
            // LABEL
            // =====================

            lblTotalVenta.Text =
                "Bs. "
                + total.ToString("0.0");
        }

        private void frmVentaProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
