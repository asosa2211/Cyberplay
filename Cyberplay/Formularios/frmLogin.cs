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

        private bool soloAdmin = false;

        public frmLogin()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

            CargarCajeros();
        }

        public frmLogin(bool soloAdmin)
        {
            InitializeComponent();

            this.soloAdmin =
                soloAdmin;

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode)
            {
                return;
            }

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

                Cajero cajero1 =
                    new Cajero(
                        "juan",
                        "Juan Perez",
                        "123",
                        RolUsuario.Cajero);

                Cajero cajero2 =
                    new Cajero(
                        "maria",
                        "Maria Lopez",
                        "123",
                        RolUsuario.Cajero);

                cajeros.Add(admin);

                cajeros.Add(cajero1);

                cajeros.Add(cajero2);

                persistenciaCajeros
                    .GuardarCajeros(
                        cajeros);
            }

            IEnumerable<Cajero> cajerosDisponibles =
                cajeros;

            if (soloAdmin)
            {
                cajerosDisponibles =
                    cajeros
                    .Where(
                        c =>
                        c.Rol == RolUsuario.Admin);
            }

            foreach (Cajero cajero
                in cajerosDisponibles)
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

            if (soloAdmin
                && cajero.Rol != RolUsuario.Admin)
            {
                MessageBox.Show(
                    "Acceso denegado",
                    "Permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

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

            PersistenciaConfiguracion
    persistenciaConfiguracion =
        new PersistenciaConfiguracion();

            SesionSistema
                .Configuracion =
                    persistenciaConfiguracion
                    .CargarConfiguracion();



            // =====================
            // ABRIR PRINCIPAL
            // =====================

            this.DialogResult =
     DialogResult.OK;

            this.Close();
        }
    }
}
