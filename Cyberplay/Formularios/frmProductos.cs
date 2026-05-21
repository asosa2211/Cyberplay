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
    public partial class frmProductos : Form
    {
        private PersistenciaProductos persistenciaProductos = new PersistenciaProductos();

        private List<Producto> productos = new List<Producto>();
       
        //CONSTRUCTOR
        public frmProductos()
        {
            InitializeComponent();
            CargarProductos();
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
            // LIMPIAR
            // =====================

            dgvProductos.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (Producto producto
                in productos)
            {
                dgvProductos.Rows.Add(
                    producto.Nombre,
                    producto.Categoria,
                    producto.Precio,
                    producto.Stock);
            }
        }
    }
}
