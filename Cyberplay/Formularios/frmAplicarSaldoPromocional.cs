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
    public partial class frmAplicarSaldoPromocional : Form
    {
        
      
        private decimal costoTiempo;
        private decimal totalProductos;
        public decimal SaldoDisponible { get; set; }
        public Usuario Usuario { get; set; }

        public decimal CostoTiempo
        {
            get => costoTiempo;
            set => costoTiempo = value;
        }

        public decimal TotalProductos
        {
            get => totalProductos;
            set => totalProductos = value;
        }

        public decimal SaldoAplicado { get; private set; }
        public frmAplicarSaldoPromocional()
        {
            InitializeComponent();
            AcceptButton = btnAceptar;
            CancelButton = btnCancelar;
        }

        private void CargarDatos()
        {
            // =====================
            // VALIDAR
            // =====================

            if (Usuario == null)
            {
                Close();
                return;
            }

           

            // =====================
            // CLIENTE
            // =====================

            lblNombreCliente.Text =
                Usuario.NombreCuenta;

            // =====================
            // MOSTRAR DATOS
            // =====================

            lblSaldoDisponibleValor.Text =
                $"{SaldoDisponible:0.00} Bs";

            lblCostoTiempoValor.Text =
                $"{CostoTiempo:0.00} Bs";

            lblProductosValor.Text =
                $"{TotalProductos:0.00} Bs";

            // =====================
            // CONFIGURAR NUMERIC
            // =====================

            nudSaldoAplicar.Minimum = 0;

            nudSaldoAplicar.Maximum =
                Math.Min(
                    SaldoDisponible,
                    CostoTiempo);

            nudSaldoAplicar.Value = 0;

            // =====================
            // CALCULAR
            // =====================

            ActualizarTotales();
            nudSaldoAplicar.Focus();
            nudSaldoAplicar.Select(0, nudSaldoAplicar.Text.Length);
        }

        private void ActualizarTotales()
        {
            decimal saldoAplicado =
                nudSaldoAplicar.Value;

            decimal tiempoAPagar =
                CostoTiempo
                - saldoAplicado;

            decimal total =
                tiempoAPagar
                + TotalProductos;

            decimal saldoRestante =
                SaldoDisponible
                - saldoAplicado;

            lblTiempoPagarValor.Text =
                $"{tiempoAPagar:0.00} Bs";

            lblTotalCobrarValor.Text =
                $"{total:0.00} Bs";

            lblSaldoRestanteValor.Text =
                $"{saldoRestante:0.00} Bs";
        }

        private void frmAplicarSaldoPromocional_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void nudSaldoAplicar_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        private void btnUsarTodo_Click(object sender, EventArgs e)
        {
            nudSaldoAplicar.Value = nudSaldoAplicar.Maximum;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SaldoAplicado = nudSaldoAplicar.Value;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void nudSaldoAplicar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}
