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
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoJugado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTarifas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(281, 14);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(140, 30);
            this.lblTotalGeneral.TabIndex = 0;
            this.lblTotalGeneral.Text = "Total general";
            // 
            // dgvDetalleTiempo
            // 
            this.dgvDetalleTiempo.AllowUserToAddRows = false;
            this.dgvDetalleTiempo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleTiempo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleTiempo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsuario,
            this.colEquipo,
            this.colHoraInicio,
            this.colHoraFin,
            this.colTiempoJugado,
            this.colTotal});
            this.dgvDetalleTiempo.Location = new System.Drawing.Point(36, 52);
            this.dgvDetalleTiempo.MultiSelect = false;
            this.dgvDetalleTiempo.Name = "dgvDetalleTiempo";
            this.dgvDetalleTiempo.ReadOnly = true;
            this.dgvDetalleTiempo.RowHeadersVisible = false;
            this.dgvDetalleTiempo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDetalleTiempo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleTiempo.Size = new System.Drawing.Size(528, 53);
            this.dgvDetalleTiempo.TabIndex = 1;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTarifaInicial,
            this.colNuevaTarifa,
            this.colTiempoCambio,
            this.colTotalCambio});
            this.dgvHistorial.Location = new System.Drawing.Point(36, 139);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(528, 96);
            this.dgvHistorial.TabIndex = 2;
            // 
            // colTarifaInicial
            // 
            this.colTarifaInicial.HeaderText = "Tarifa inicial";
            this.colTarifaInicial.Name = "colTarifaInicial";
            this.colTarifaInicial.ReadOnly = true;
            // 
            // colNuevaTarifa
            // 
            this.colNuevaTarifa.HeaderText = "Nueva tarifa";
            this.colNuevaTarifa.Name = "colNuevaTarifa";
            this.colNuevaTarifa.ReadOnly = true;
            // 
            // colTiempoCambio
            // 
            this.colTiempoCambio.HeaderText = "Tiempo jugado";
            this.colTiempoCambio.Name = "colTiempoCambio";
            this.colTiempoCambio.ReadOnly = true;
            // 
            // colTotalCambio
            // 
            this.colTotalCambio.HeaderText = "Total";
            this.colTotalCambio.Name = "colTotalCambio";
            this.colTotalCambio.ReadOnly = true;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colPrecio,
            this.colCantidad,
            this.colTotalProductos});
            this.dgvProductos.Location = new System.Drawing.Point(36, 273);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(528, 111);
            this.dgvProductos.TabIndex = 3;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colTotalProductos
            // 
            this.colTotalProductos.HeaderText = "Total";
            this.colTotalProductos.Name = "colTotalProductos";
            this.colTotalProductos.ReadOnly = true;
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.Location = new System.Drawing.Point(141, 253);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(38, 15);
            this.lblTotalProductos.TabIndex = 4;
            this.lblTotalProductos.Text = "label1";
            // 
            // lblNroTicket
            // 
            this.lblNroTicket.AutoSize = true;
            this.lblNroTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroTicket.Location = new System.Drawing.Point(89, 26);
            this.lblNroTicket.Name = "lblNroTicket";
            this.lblNroTicket.Size = new System.Drawing.Size(38, 15);
            this.lblNroTicket.TabIndex = 5;
            this.lblNroTicket.Text = "label1";
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colEquipo
            // 
            this.colEquipo.HeaderText = "Equipo";
            this.colEquipo.Name = "colEquipo";
            this.colEquipo.ReadOnly = true;
            // 
            // colHoraInicio
            // 
            this.colHoraInicio.HeaderText = "Hora inicio";
            this.colHoraInicio.Name = "colHoraInicio";
            this.colHoraInicio.ReadOnly = true;
            // 
            // colHoraFin
            // 
            this.colHoraFin.HeaderText = "Hora fin";
            this.colHoraFin.Name = "colHoraFin";
            this.colHoraFin.ReadOnly = true;
            // 
            // colTiempoJugado
            // 
            this.colTiempoJugado.HeaderText = "Jugado";
            this.colTiempoJugado.Name = "colTiempoJugado";
            this.colTiempoJugado.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // lblTarifas
            // 
            this.lblTarifas.AutoSize = true;
            this.lblTarifas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifas.Location = new System.Drawing.Point(36, 120);
            this.lblTarifas.Name = "lblTarifas";
            this.lblTarifas.Size = new System.Drawing.Size(91, 15);
            this.lblTarifas.TabIndex = 6;
            this.lblTarifas.Text = "Historial tarifas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ticket: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total productos: ";
            // 
            // frmDetalleCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 407);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTarifas);
            this.Controls.Add(this.lblNroTicket);
            this.Controls.Add(this.lblTotalProductos);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.dgvDetalleTiempo);
            this.Controls.Add(this.lblTotalGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDetalleCobro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoJugado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblTarifas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}