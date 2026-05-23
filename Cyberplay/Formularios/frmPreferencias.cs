using Cyberplay.Core;
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
    public partial class frmPreferencias : Form
    {
        private PersistenciaConfiguracion persistenciaConfiguracion =
        new PersistenciaConfiguracion();
        public frmPreferencias()
        {
            InitializeComponent();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            // =====================
            // LIMPIAR
            // =====================

            dgvCategorias.Rows.Clear();

            // =====================
            // RECORRER
            // =====================

            foreach (string categoria
                in SesionSistema
                    .Configuracion
                    .Categorias)
            {
                dgvCategorias.Rows.Add(
                    categoria);
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            // =====================
            // NOMBRE
            // =====================

            string categoria =
                tbNombre.Text
                .Trim();

            // =====================
            // VALIDAR
            // =====================

            if (string.IsNullOrWhiteSpace(
                categoria))
            {
                MessageBox.Show(
                    "Ingrese una categoría.");

                return;
            }

            // =====================
            // EXISTE
            // =====================

            if (SesionSistema
                .Configuracion
                .Categorias
                .Contains(categoria))
            {
                MessageBox.Show(
                    "La categoría ya existe.");

                return;
            }

            // =====================
            // AGREGAR
            // =====================

            SesionSistema
                .Configuracion
                .Categorias
                .Add(categoria);

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // LIMPIAR
            // =====================

            tbNombre.Clear();

            // =====================
            // RECARGAR
            // =====================

            CargarCategorias();
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            // =====================
            // VALIDAR
            // =====================

            if (dgvCategorias.CurrentRow
                == null)
            {
                return;
            }

            // =====================
            // CATEGORIA
            // =====================

            string categoria =
                dgvCategorias
                .CurrentRow
                .Cells[0]
                .Value
                .ToString();

            // =====================
            // ELIMINAR
            // =====================

            SesionSistema
                .Configuracion
                .Categorias
                .Remove(categoria);

            // =====================
            // GUARDAR
            // =====================

            persistenciaConfiguracion
                .GuardarConfiguracion(
                    SesionSistema
                        .Configuracion);

            // =====================
            // RECARGAR
            // =====================

            CargarCategorias();
        }
    }
}
