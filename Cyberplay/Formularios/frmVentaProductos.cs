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
    }
}
