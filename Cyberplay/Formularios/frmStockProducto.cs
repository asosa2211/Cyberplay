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
    public partial class frmStockProducto : Form
    {
        private Producto producto;

        private PersistenciaProductos persistenciaProductos =
                new PersistenciaProductos();

        private List<Producto> productos =
                new List<Producto>();
        public frmStockProducto()
        {
            InitializeComponent();
        }

        public frmStockProducto(Producto producto)
        {
            InitializeComponent();

            this.producto =
                producto;

            CargarDatos();
        }

        private void CargarDatos()
        {
            lblProducto.Text =
                producto.Nombre;

            lblStockActual.Text =
                producto.Stock
                .ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // =====================
            // CANTIDAD
            // =====================

            int cantidad =
                (int)nudCantidad.Value;

            // =====================
            // VALIDAR
            // =====================

            if (cantidad <= 0)
            {
                return;
            }

            // =====================
            // SUMAR
            // =====================

            producto.Stock +=
                cantidad;

            // =====================
            // GUARDAR
            // =====================

            GuardarCambios();

            // =====================
            // ACTUALIZAR
            // =====================

            CargarDatos();

            // =====================
            // RESET
            // =====================

            nudCantidad.Value = 0;

            // =====================
            // OK
            // =====================

            MessageBox.Show(
                "Stock agregado.");
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!Permisos.EsAdmin())
            {
                MessageBox.Show(
                    "Acceso denegado",
                    "Permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // =====================
            // CANTIDAD
            // =====================

            int cantidad =
                (int)nudCantidad.Value;

            // =====================
            // VALIDAR
            // =====================

            if (cantidad <= 0)
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

                return;
            }

            // =====================
            // RESTAR
            // =====================

            producto.Stock -=
                cantidad;

            // =====================
            // GUARDAR
            // =====================

            GuardarCambios();

            // =====================
            // ACTUALIZAR
            // =====================

            CargarDatos();

            // =====================
            // RESET
            // =====================

            nudCantidad.Value = 0;

            // =====================
            // OK
            // =====================

            MessageBox.Show(
                "Stock descontado.");
        }

        private void GuardarCambios()
        {
            // =====================
            // CARGAR
            // =====================

            productos =
                persistenciaProductos
                    .CargarProductos();

            // =====================
            // BUSCAR
            // =====================

            Producto existente =
                productos
                .FirstOrDefault(
                    p =>
                    p.Nombre
                    == producto.Nombre);

            if (existente == null)
            {
                return;
            }

            // =====================
            // ACTUALIZAR
            // =====================

            existente.Stock =
                producto.Stock;

            // =====================
            // GUARDAR
            // =====================

            persistenciaProductos
                .GuardarProductos(
                    productos);
        }

    }
}
