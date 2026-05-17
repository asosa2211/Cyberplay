using Cyberplay.Core;
using Cyberplay.enums;
using Cyberplay.Modelos;
using Cyberplay.Persistencia;
using Cyberplay.Servicios;
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
    public partial class frmLogin : Form
    {
        private GestorCajeros gestorCajeros = new GestorCajeros();

        private PersistenciaCajeros persistenciaCajeros = new PersistenciaCajeros();
        public frmLogin()
        {
            InitializeComponent();
            CargarCajeros();
        }

        private void CargarCajeros()
        {
            List<Cajero> cajeros =
                persistenciaCajeros
                    .CargarCajeros();
            if (cajeros.Count == 0)
            {
                Cajero admin =
                    new Cajero(
                        "admin",
                        "Administrador",
                        "123",
                        RolUsuario.Admin);

                cajeros.Add(admin);

                persistenciaCajeros
                    .GuardarCajeros(
                        cajeros);
            }

            foreach (Cajero cajero
                in cajeros)
            {
                gestorCajeros
                    .AgregarCajero(
                        cajero);
            }

            cbCajeros.DataSource =
                gestorCajeros
                    .ObtenerCajeros();

            cbCajeros.DisplayMember =
                "Usuario";
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(
    object sender,
    EventArgs e)
        {
            // =====================
            // VALIDAR SELECCION
            // =====================

            if (cbCajeros.SelectedItem
                == null)
            {
                MessageBox.Show(
                    "Seleccione un cajero.");

                return;
            }

            // =====================
            // OBTENER CAJERO
            // =====================

            Cajero cajero =
                (Cajero)
                cbCajeros.SelectedItem;

            // =====================
            // VALIDAR PASSWORD
            // =====================

            if (cajero.Password
                != tbPassword.Text)
            {
                MessageBox.Show(
                    "Contraseña incorrecta.");

                return;
            }

            // =====================
            // GUARDAR SESION
            // =====================

            SesionSistema.CajeroActual =
                cajero;

            // =====================
            // ABRIR PRINCIPAL
            // =====================

            this.DialogResult =
     DialogResult.OK;

            this.Close();
        }
    }
}
