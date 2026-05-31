using Cyberplay.Core;
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
    public partial class frmVentaProductos : Form
    {
        private const string CategoriaTodas = "Todas";

        private PersistenciaProductos persistenciaProductos = new PersistenciaProductos();

        private PersistenciaVentasProductos persistenciaVentas = new PersistenciaVentasProductos();
        private PersistenciaIngresosCaja persistenciaIngresos = new PersistenciaIngresosCaja();

        private List<Producto> productos = new List<Producto>();

        private List<VentaProducto> ventas = new List<VentaProducto>();

        private string equipoSeleccionado = "0";

        //CONSTRUCTOR
        public frmVentaProductos()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

            CargarProductos();
            CargarCategorias();
            CargarEquipos();
        }

        public frmVentaProductos(
    string equipo)
        {
            InitializeComponent();

            equipoSeleccionado = equipo;

            CargarProductos();

            CargarCategorias();

            CargarEquipos();
        }

        private void CargarEquipos()
        {
            // =====================
            // LIMPIAR
            // =====================

            cbEquipo.Items.Clear();

            // =====================
            // OPCION NORMAL
            // =====================

            cbEquipo.Items.Add(
                "0");

            // =====================
            // OBTENER PRINCIPAL
            // =====================

            frmPrincipal principal =
                Application.OpenForms
                .OfType<frmPrincipal>()
                .FirstOrDefault();

            if (principal == null)
            {
                cbEquipo.SelectedItem =
                    "0";

                return;
            }

            // =====================
            // RECORRER CONTROLES
            // =====================

            foreach (Control control
                in principal.Controls)
            {
                // =====================
                // SOLO ucPS4
                // =====================

                if (control is ucPS4 consola)
                {
                    cbEquipo.Items.Add(
                        EquipoIdentidad.Formatear(
                            consola.Estacion.NumeroEquipo,
                            consola.Estacion.TipoEquipo));
                }
            }

            // =====================
            // SELECCIONAR
            // =====================

            string equipoParaSeleccionar =
                null;

            int numeroSeleccionado =
                EquipoIdentidad.ObtenerNumero(
                    equipoSeleccionado);

            foreach (object item
                in cbEquipo.Items)
            {
                string texto =
                    item.ToString();

                if (texto == equipoSeleccionado
                    || (numeroSeleccionado > 0
                        && EquipoIdentidad.ObtenerNumero(texto)
                        == numeroSeleccionado))
                {
                    equipoParaSeleccionar =
                        texto;

                    break;
                }
            }

            if (equipoParaSeleccionar != null)
            {
                cbEquipo.SelectedItem =
                    equipoParaSeleccionar;
            }

            else
            {
                cbEquipo.SelectedItem =
                    "0";
            }
        }

        private ucPS4 ObtenerConsola(
            string equipo)
        {
            frmPrincipal principal =
                Application.OpenForms
                .OfType<frmPrincipal>()
                .FirstOrDefault();

            if (principal == null)
            {
                return null;
            }

            foreach (Control control
                in principal.Controls)
            {
                ucPS4 consola =
                    control as ucPS4;

                if (consola == null)
                {
                    continue;
                }

                if (consola.Estacion.NumeroEquipo
                    == EquipoIdentidad.ObtenerNumero(
                        equipo))
                {
                    return consola;
                }
            }

            return null;
        }
        private void CargarProductos()
        {
            // =====================
            // CARGAR
            // =====================

            productos =
                persistenciaProductos
                    .CargarProductos();

            ventas =
                persistenciaVentas
                    .CargarVentas();

            // =====================
            // COMBO
            // =====================

            
        }

       

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductosCategoria();

            if (cbCategorias.Focused)
            {
                dgvProductos.Focus();
            }
            
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
                    categoria == CategoriaTodas
                    || p.Categoria
                    == categoria)
                .Where(
                    p =>
                    p.Nombre != null)
                .OrderBy(
                    p =>
                    p.Nombre,
                    StringComparer.CurrentCultureIgnoreCase)
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
                    producto.TipoVenta == TipoVentaProducto.ConStock
                    ? producto.Stock.ToString()
                    : "No aplica");
            }
        }


        private void CargarCategorias()
        {
            // =====================
            // LIMPIAR
            // =====================

            cbCategorias.Items.Clear();

            cbCategorias.Items.Add(
                CategoriaTodas);

            // =====================
            // RECORRER
            // =====================

            foreach (string categoria
                in SesionSistema
                    .Configuracion
                    .Categorias)
            {
                if (string.Equals(
                    categoria,
                    CategoriaTodas,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                cbCategorias.Items.Add(
                    categoria);
            }

            // =====================
            // SELECCIONAR
            // =====================

            if (cbCategorias.Items.Count > 0)
            {
                cbCategorias.SelectedIndex = 0;
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            
        }



        private void btnVender_Click(
     object sender,
     EventArgs e)
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
            // EQUIPO
            // =====================

            string equipo =
                cbEquipo
                .SelectedItem
                .ToString();

            ucPS4 consolaDestino =
                null;

            if (equipo != "0")
            {
                consolaDestino =
                    ObtenerConsola(
                        equipo);

                if (consolaDestino == null
                    || consolaDestino.Sesion == null)
                {
                    MessageBox.Show(
                        "El equipo no tiene sesión activa.");

                    return;
                }
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Confirmar venta?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }

            // =====================
            // TOTALES
            // =====================

            decimal totalGeneral = 0;

            decimal utilidadGeneral = 0;

            // =====================
            // PRODUCTOS VENDIDOS
            // =====================

            List<VentaProducto>
                carritoVentas =
                    new List<VentaProducto>();

            // =====================
            // RECORRER CARRITO
            // =====================

            foreach (DataGridViewRow fila
                in dgvCarrito.Rows)
            {
                VentaProducto ventaEspecial =
                    fila.Tag as VentaProducto;

                if (ventaEspecial != null)
                {
                    ventaEspecial.Cajero =
                        SesionSistema
                            .CajeroActual
                            .Usuario;

                    ventaEspecial.NumeroCaja =
                        SesionSistema
                            .CajaActual
                            .NumeroCaja;

                    ventas.Add(
                        ventaEspecial);

                    carritoVentas.Add(
                        ventaEspecial);

                    totalGeneral +=
                        ventaEspecial.Total;

                    utilidadGeneral +=
                        ventaEspecial.Utilidad;

                    continue;
                }

                // =====================
                // DATOS
                // =====================

                string nombre =
                    fila.Cells[0]
                    .Value
                    .ToString();

                int cantidad =
                    Convert.ToInt32(
                        fila.Cells[2]
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

                if (producto.TipoVenta == TipoVentaProducto.ConStock
                    && cantidad
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
                 .Usuario,

         Categoria =
             producto.Categoria,

         NumeroCaja =
             SesionSistema
                 .CajaActual
                 .NumeroCaja,

         TipoVenta =
             producto.TipoVenta
     };

                // =====================
                // AGREGAR VENTA
                // =====================

                ventas.Add(
                    venta);

                carritoVentas.Add(
                    venta);

                // =====================
                // DESCONTAR STOCK
                // =====================

                if (producto.TipoVenta == TipoVentaProducto.ConStock)
                {
                    producto.Stock -=
                        cantidad;
                }

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
            // VENTA NORMAL
            // =====================

            if (equipo == "0")
            {
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
                    principal
                        .ActualizarCaja();
                }
            }

            // =====================
            // VENTA A EQUIPO
            // =====================

            else
            {
                consolaDestino
                    .Sesion
                    .ProductosConsumidos
                    .AddRange(
                        carritoVentas);

                consolaDestino
                    .ActualizarTotal();
            }

            // =====================
            // LIMPIAR
            // =====================

            dgvCarrito.Rows.Clear();

            ActualizarTotalVenta();

            CargarProductosCategoria();

            Close();

            
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

            if (producto.TipoVenta != TipoVentaProducto.ConStock)
            {
                frmVentaEspecialProducto frm =
                    new frmVentaEspecialProducto(
                        producto);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    VentaProducto venta =
                        frm.Venta;

                    DataGridViewRow fila =
                        new DataGridViewRow();

                    int indice =
                        dgvCarrito.Rows.Add(
                            venta.Producto,
                            venta.PrecioUnitario,
                            venta.Cantidad,
                            venta.Total);

                    dgvCarrito.Rows[indice].Tag =
                        venta;

                    ActualizarTotalVenta();
                }

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
                            fila.Cells[2]
                            .Value);

                    cantidad++;

                    fila.Cells[2].Value =
                        cantidad;

                    // =====================
                    // ACTUALIZAR TOTAL
                    // =====================

                    fila.Cells[3].Value =
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
                producto.PrecioVenta,
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
                        fila.Cells[3]
                        .Value);
            }

            // =====================
            // LABEL
            // =====================

            lblTotalVenta.Text = "TOTAL: " + total.ToString("0.0") + " Bs.";
        }

        private void frmVentaProductos_Load(object sender, EventArgs e)
        {
            colNombreCarrito.ReadOnly =
    true;

            colPrecioCarrito.ReadOnly =
                true;

            colTotalCarrito.ReadOnly =
                true;

            colCantidadCarrito.ReadOnly =
                false;
        }

        private void dgvCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                dgvCarrito.Rows[e.RowIndex];

            if (fila.Tag is VentaProducto)
            {
                dgvCarrito.Rows.Remove(
                    fila);

                ActualizarTotalVenta();

                return;
            }

            // =====================
            // CANTIDAD
            // =====================

            int cantidad =
                Convert.ToInt32(
                    fila.Cells[2]
                    .Value);

            // =====================
            // DISMINUIR
            // =====================

            cantidad--;

            // =====================
            // ELIMINAR
            // =====================

            if (cantidad <= 0)
            {
                dgvCarrito.Rows.Remove(
                    fila);
            }

            // =====================
            // ACTUALIZAR
            // =====================

            else
            {
                // =====================
                // NOMBRE
                // =====================

                string nombre =
                    fila.Cells[0]
                    .Value
                    .ToString();

                // =====================
                // PRODUCTO
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
                // CANTIDAD
                // =====================

                fila.Cells[2].Value =
                    cantidad;

                // =====================
                // TOTAL
                // =====================

                fila.Cells[3].Value =
                    cantidad
                    * producto.PrecioVenta;
            }

            // =====================
            // TOTAL GENERAL
            // =====================

            ActualizarTotalVenta();
        }

        private void dgvCarrito_CellEndEdit(
     object sender,
     DataGridViewCellEventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (e.RowIndex < 0)
            {
                return;
            }

            // =====================
            // SOLO CANTIDAD
            // =====================

            if (e.ColumnIndex != 2)
            {
                return;
            }

            // =====================
            // FILA
            // =====================

            DataGridViewRow fila =
                dgvCarrito.Rows[e.RowIndex];

            if (fila.Tag is VentaProducto ventaEspecial)
            {
                fila.Cells[1].Value =
                    ventaEspecial.PrecioUnitario;

                fila.Cells[2].Value =
                    ventaEspecial.Cantidad;

                fila.Cells[3].Value =
                    ventaEspecial.Total;

                return;
            }

            // =====================
            // VALIDAR VALOR
            // =====================

            if (fila.Cells[2].Value
                == null)
            {
                return;
            }

            // =====================
            // CANTIDAD
            // =====================

            int cantidad;

            bool ok =
                int.TryParse(
                    fila.Cells[2]
                    .Value
                    .ToString(),
                    out cantidad);

            if (!ok)
            {
                MessageBox.Show(
                    "Cantidad inválida.");

                fila.Cells[2].Value = 1;

                return;
            }

            // =====================
            // ELIMINAR
            // =====================

            if (cantidad <= 0)
            {
                dgvCarrito.Rows.Remove(
                    fila);

                ActualizarTotalVenta();

                return;
            }

            // =====================
            // NOMBRE
            // =====================

            string nombre =
                fila.Cells[0]
                .Value
                .ToString();

            // =====================
            // PRODUCTO
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
            // VALIDAR STOCK
            // =====================

            if (cantidad
                > producto.Stock)
            {
                MessageBox.Show(
                    "Stock insuficiente.");

                fila.Cells[2].Value =
                    producto.Stock;

                cantidad =
                    producto.Stock;
            }

            // =====================
            // TOTAL
            // =====================

            fila.Cells[3].Value =
                cantidad
                * producto.PrecioVenta;

            // =====================
            // ACTUALIZAR
            // =====================

            ActualizarTotalVenta();
        }

        private void btnVaciarCarrito_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvCarrito.Rows.Count == 0)
            {
                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Vaciar carrito?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }

            // =====================
            // LIMPIAR
            // =====================

            dgvCarrito.Rows.Clear();

            // =====================
            // ACTUALIZAR TOTAL
            // =====================

            ActualizarTotalVenta();
        }

        private void cmsCarrito_Opening(
            object sender,
            CancelEventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

        private void tsmiEliminarProducto_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                return;
            }

            dgvCarrito.Rows.Remove(
                dgvCarrito.CurrentRow);

            ActualizarTotalVenta();
        }

        private void dgvCarrito_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right
                || e.RowIndex < 0)
            {
                return;
            }

            dgvCarrito.ClearSelection();

            dgvCarrito.Rows[e.RowIndex]
                .Selected = true;

            dgvCarrito.CurrentCell =
                dgvCarrito.Rows[e.RowIndex]
                .Cells[e.ColumnIndex < 0 ? 0 : e.ColumnIndex];
        }
    }
}
