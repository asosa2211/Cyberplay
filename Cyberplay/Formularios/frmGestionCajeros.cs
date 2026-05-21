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
    public partial class frmGestionCajeros : Form
    {
        private PersistenciaCajeros persistenciaCajeros = new PersistenciaCajeros();
        private List<Cajero> cajeros = new List<Cajero>();
       
       // CONSTRUCTOR
        public frmGestionCajeros()
        {
            InitializeComponent();
            CargarCajeros();
        }

        //CARGAR CAJEROS
        private void CargarCajeros()
        {
            // cargar
            cajeros = persistenciaCajeros.CargarCajeros();

            //limpiar
            dgvCajeros.Rows.Clear();

            //recorrer
            foreach (Cajero cajero in cajeros)
            {
                dgvCajeros.Rows.Add(cajero.Usuario, cajero.NombreCompleto, cajero.Rol);
            }
        }
    }
}
