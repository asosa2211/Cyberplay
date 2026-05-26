namespace Cyberplay.Formularios
{
    partial class frmDetalleSesion
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
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalleTiempo = new System.Windows.Forms.DataGridView();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoJugado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalTiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.colTarifaIinicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNuevaTarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Location = new System.Drawing.Point(637, 313);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(82, 13);
            this.lblTotalProductos.TabIndex = 4;
            this.lblTotalProductos.Text = "Total Productos";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Location = new System.Drawing.Point(627, 116);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(71, 13);
            this.lblTotalGeneral.TabIndex = 5;
            this.lblTotalGeneral.Text = "Total General";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colPrecio,
            this.colCantidad,
            this.colTotal});
            this.dgvProductos.Location = new System.Drawing.Point(45, 288);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(448, 150);
            this.dgvProductos.TabIndex = 6;
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
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
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
            this.colTotalTiempo});
            this.dgvDetalleTiempo.Location = new System.Drawing.Point(45, 23);
            this.dgvDetalleTiempo.Name = "dgvDetalleTiempo";
            this.dgvDetalleTiempo.Size = new System.Drawing.Size(653, 79);
            this.dgvDetalleTiempo.TabIndex = 7;
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
            this.colHoraInicio.HeaderText = "Hora Inicio";
            this.colHoraInicio.Name = "colHoraInicio";
            // 
            // colHoraFin
            // 
            this.colHoraFin.HeaderText = "Hora Fin";
            this.colHoraFin.Name = "colHoraFin";
            // 
            // colTiempoJugado
            // 
            this.colTiempoJugado.HeaderText = "Tiempo Jugado";
            this.colTiempoJugado.Name = "colTiempoJugado";
            // 
            // colTotalTiempo
            // 
            this.colTotalTiempo.HeaderText = "Total";
            this.colTotalTiempo.Name = "colTotalTiempo";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTarifaIinicial,
            this.colNuevaTarifa,
            this.colTiempoCambio,
            this.colTotalCambio});
            this.dgvHistorial.Location = new System.Drawing.Point(45, 116);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(448, 166);
            this.dgvHistorial.TabIndex = 8;
            // 
            // colTarifaIinicial
            // 
            this.colTarifaIinicial.HeaderText = "Tarifa Inicial";
            this.colTarifaIinicial.Name = "colTarifaIinicial";
            // 
            // colNuevaTarifa
            // 
            this.colNuevaTarifa.HeaderText = "Nueva Tarifa";
            this.colNuevaTarifa.Name = "colNuevaTarifa";
            // 
            // colTiempoCambio
            // 
            this.colTiempoCambio.HeaderText = "Tiempo Jugado";
            this.colTiempoCambio.Name = "colTiempoCambio";
            // 
            // colTotalCambio
            // 
            this.colTotalCambio.HeaderText = "Total";
            this.colTotalCambio.Name = "colTotalCambio";
            // 
            // frmDetalleSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 605);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.dgvDetalleTiempo);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.lblTotalProductos);
            this.Name = "frmDetalleSesion";
            this.Text = "frmDetalleSesion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvDetalleTiempo;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarifaIinicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNuevaTarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoJugado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalTiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}