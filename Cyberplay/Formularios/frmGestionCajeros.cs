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
    public partial class frmGestionCajeros : Form
    {
        private PersistenciaCajeros persistenciaCajeros = new PersistenciaCajeros();
        private List<Cajero> cajeros = new List<Cajero>();
       
       // CONSTRUCTOR
        public frmGestionCajeros()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEditarCajero frm = new frmEditarCajero();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //agregar
                cajeros.Add(frm.CajeroCreado);

                //guardar
                persistenciaCajeros.GuardarCajeros(cajeros);

                //recargar lista de cajeros
                CargarCajeros();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvCajeros
                .SelectedRows.Count
                == 0)
            {
                MessageBox.Show(
                    "Seleccione un cajero.");

                return;
            }

            // =====================
            // OBTENER USUARIO
            // =====================

            string usuario =
                dgvCajeros
                .SelectedRows[0]
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // BUSCAR
            // =====================

            Cajero cajero =
                cajeros
                .FirstOrDefault(
                    c =>
                    c.Usuario
                    == usuario);

            if (cajero == null)
            {
                return;
            }

            // =====================
            // ABRIR FORM
            // =====================

            frmEditarCajero frm =
                new frmEditarCajero(
                    cajero);

            // =====================
            // RESULTADO
            // =====================

            if (frm.ShowDialog()
                == DialogResult.OK)
            {
                // =====================
                // GUARDAR
                // =====================

                persistenciaCajeros
                    .GuardarCajeros(
                        cajeros);

                // =====================
                // RECARGAR
                // =====================

                CargarCajeros();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR SELECCION
            // =====================

            if (dgvCajeros
                .SelectedRows.Count
                == 0)
            {
                MessageBox.Show(
                    "Seleccione un cajero.");

                return;
            }

            // =====================
            // OBTENER USUARIO
            // =====================

            string usuario =
                dgvCajeros
                .SelectedRows[0]
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // PROTEGER ADMIN
            // =====================

            if (usuario.ToLower()
                == "admin")
            {
                MessageBox.Show(
                    "No se puede eliminar el administrador.");

                return;
            }

            // =====================
            // PROTEGER SESION ACTUAL
            // =====================

            if (usuario
                ==
                SesionSistema
                    .CajeroActual
                    .Usuario)
            {
                MessageBox.Show(
                    "No puede eliminar el cajero actual.");

                return;
            }

            // =====================
            // CONFIRMAR
            // =====================

            DialogResult resultado =
                MessageBox.Show(
                    "¿Eliminar cajero?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado
                == DialogResult.No)
            {
                return;
            }

            // =====================
            // BUSCAR
            // =====================

            Cajero cajero =
                cajeros
                .FirstOrDefault(
                    c =>
                    c.Usuario
                    == usuario);

            if (cajero == null)
            {
                return;
            }

            // =====================
            // ELIMINAR
            // =====================

            cajeros.Remove(
                cajero);

            // =====================
            // GUARDAR
            // =====================

            persistenciaCajeros
                .GuardarCajeros(
                    cajeros);

            // =====================
            // RECARGAR
            // =====================

            CargarCajeros();
        }

        private void frmGestionCajeros_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Configurar(dgvCajeros);
            dgvCajeros.ClearSelection();
        }
    }
}
