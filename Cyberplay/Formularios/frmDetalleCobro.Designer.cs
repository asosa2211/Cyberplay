namespace Cyberplay.Formularios
{
    partial class frmDetalleCobro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.dgvDetalleTiempo = new System.Windows.Forms.DataGridView();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoJugado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.colTarifaInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNuevaTarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblNroTicket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Location = new System.Drawing.Point(366, 25);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(69, 13);
            this.lblTotalGeneral.TabIndex = 0;
            this.lblTotalGeneral.Text = "Total general";
            // 
            // dgvDetalleTiempo
            // 
            this.dgvDetalleTiempo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleTiempo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsuario,
            this.colEquipo,
            this.colHoraInicio,
            this.colHoraFin,
            this.colTiempoJugado,
            this.colTotal});
            this.dgvDetalleTiempo.Location = new System.Drawing.Point(36, 52);
            this.dgvDetalleTiempo.Name = "dgvDetalleTiempo";
            this.dgvDetalleTiempo.Size = new System.Drawing.Size(665, 65);
            this.dgvDetalleTiempo.TabIndex = 1;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            // 
            // colEquipo
            // 
            this.colEquipo.HeaderText = "Equipo";
            this.colEquipo.Name = "colEquipo";
            // 
            // colHoraInicio
            // 
            this.colHoraInicio.HeaderText = "Hora inicio";
            this.colHoraInicio.Name = "colHoraInicio";
            // 
            // colHoraFin
            // 
            this.colHoraFin.HeaderText = "Hora fin";
            this.colHoraFin.Name = "colHoraFin";
            // 
            // colTiempoJugado
            // 
            this.colTiempoJugado.HeaderText = "Tiempo jugado";
            this.colTiempoJugado.Name = "colTiempoJugado";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTarifaInicial,
            this.colNuevaTarifa,
            this.colTiempoCambio,
            this.colTotalCambio});
            this.dgvHistorial.Location = new System.Drawing.Point(36, 145);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(539, 150);
            this.dgvHistorial.TabIndex = 2;
            // 
            // colTarifaInicial
            // 
            this.colTarifaInicial.HeaderText = "Tarifa inicial";
            this.colTarifaInicial.Name = "colTarifaInicial";
            // 
            // colNuevaTarifa
            // 
            this.colNuevaTarifa.HeaderText = "Nueva tarifa";
            this.colNuevaTarifa.Name = "colNuevaTarifa";
            // 
            // colTiempoCambio
            // 
            this.colTiempoCambio.HeaderText = "Tiempo jugado";
            this.colTiempoCambio.Name = "colTiempoCambio";
            // 
            // colTotalCambio
            // 
            this.colTotalCambio.HeaderText = "Total";
            this.colTotalCambio.Name = "colTotalCambio";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colPrecio,
            this.colCantidad,
            this.colTotalProductos});
            this.dgvProductos.Location = new System.Drawing.Point(36, 357);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(622, 150);
            this.dgvProductos.TabIndex = 3;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colTotalProductos
            // 
            this.colTotalProductos.HeaderText = "Total";
            this.colTotalProductos.Name = "colTotalProductos";
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Location = new System.Drawing.Point(33, 341);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(35, 13);
            this.lblTotalProductos.TabIndex = 4;
            this.lblTotalProductos.Text = "label1";
            // 
            // lblNroTicket
            // 
            this.lblNroTicket.AutoSize = true;
            this.lblNroTicket.Location = new System.Drawing.Point(36, 25);
            this.lblNroTicket.Name = "lblNroTicket";
            this.lblNroTicket.Size = new System.Drawing.Size(35, 13);
            this.lblNroTicket.TabIndex = 5;
            this.lblNroTicket.Text = "label1";
            // 
            // frmDetalleCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 655);
            this.Controls.Add(this.lblNroTicket);
            this.Controls.Add(this.lblTotalProductos);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.dgvDetalleTiempo);
            this.Controls.Add(this.lblTotalGeneral);
            this.Name = "frmDetalleCobro";
            this.Text = "Detalle del cobro";
            this.Load += new System.EventHandler(this.frmDetalleCobro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.DataGridView dgvDetalleTiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoJugado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarifaInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNuevaTarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCambio;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalProductos;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblNroTicket;
    }
}