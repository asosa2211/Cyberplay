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
            this.components = new System.ComponentModel.Container();
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
            this.cmsProductos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEliminarProducto = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.cmsProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.Location = new System.Drawing.Point(28, 296);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(123, 17);
            this.lblTotalProductos.TabIndex = 4;
            this.lblTotalProductos.Text = "Total Productos";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(29, 24);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(108, 17);
            this.lblTotalGeneral.TabIndex = 5;
            this.lblTotalGeneral.Text = "Total General";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colPrecio,
            this.colCantidad,
            this.colTotal});
            this.dgvProductos.ContextMenuStrip = this.cmsProductos;
            this.dgvProductos.Location = new System.Drawing.Point(26, 319);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(407, 178);
            this.dgvProductos.TabIndex = 6;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            this.dgvProductos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductos_CellMouseDown);
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
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // dgvDetalleTiempo
            // 
            this.dgvDetalleTiempo.AllowUserToAddRows = false;
            this.dgvDetalleTiempo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleTiempo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsuario,
            this.colEquipo,
            this.colHoraInicio,
            this.colHoraFin,
            this.colTiempoJugado,
            this.colTotalTiempo});
            this.dgvDetalleTiempo.Location = new System.Drawing.Point(26, 50);
            this.dgvDetalleTiempo.MultiSelect = false;
            this.dgvDetalleTiempo.Name = "dgvDetalleTiempo";
            this.dgvDetalleTiempo.ReadOnly = true;
            this.dgvDetalleTiempo.RowHeadersVisible = false;
            this.dgvDetalleTiempo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleTiempo.Size = new System.Drawing.Size(626, 47);
            this.dgvDetalleTiempo.TabIndex = 7;
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
            this.colHoraInicio.HeaderText = "Hora Inicio";
            this.colHoraInicio.Name = "colHoraInicio";
            this.colHoraInicio.ReadOnly = true;
            // 
            // colHoraFin
            // 
            this.colHoraFin.HeaderText = "Hora Fin";
            this.colHoraFin.Name = "colHoraFin";
            this.colHoraFin.ReadOnly = true;
            // 
            // colTiempoJugado
            // 
            this.colTiempoJugado.HeaderText = "Tiempo Jugado";
            this.colTiempoJugado.Name = "colTiempoJugado";
            this.colTiempoJugado.ReadOnly = true;
            this.colTiempoJugado.Width = 120;
            // 
            // colTotalTiempo
            // 
            this.colTotalTiempo.HeaderText = "Total";
            this.colTotalTiempo.Name = "colTotalTiempo";
            this.colTotalTiempo.ReadOnly = true;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTarifaIinicial,
            this.colNuevaTarifa,
            this.colTiempoCambio,
            this.colTotalCambio});
            this.dgvHistorial.Location = new System.Drawing.Point(26, 125);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(426, 158);
            this.dgvHistorial.TabIndex = 8;
            // 
            // colTarifaIinicial
            // 
            this.colTarifaIinicial.HeaderText = "Tarifa Inicial";
            this.colTarifaIinicial.Name = "colTarifaIinicial";
            this.colTarifaIinicial.ReadOnly = true;
            // 
            // colNuevaTarifa
            // 
            this.colNuevaTarifa.HeaderText = "Nueva Tarifa";
            this.colNuevaTarifa.Name = "colNuevaTarifa";
            this.colNuevaTarifa.ReadOnly = true;
            // 
            // colTiempoCambio
            // 
            this.colTiempoCambio.HeaderText = "Tiempo Jugado";
            this.colTiempoCambio.Name = "colTiempoCambio";
            this.colTiempoCambio.ReadOnly = true;
            this.colTiempoCambio.Width = 120;
            // 
            // colTotalCambio
            // 
            this.colTotalCambio.HeaderText = "Total";
            this.colTotalCambio.Name = "colTotalCambio";
            this.colTotalCambio.ReadOnly = true;
            // 
            // cmsProductos
            // 
            this.cmsProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEliminarProducto});
            this.cmsProductos.Name = "cmsProductos";
            this.cmsProductos.Size = new System.Drawing.Size(170, 26);
            // 
            // tsmiEliminarProducto
            // 
            this.tsmiEliminarProducto.Name = "tsmiEliminarProducto";
            this.tsmiEliminarProducto.Size = new System.Drawing.Size(169, 22);
            this.tsmiEliminarProducto.Text = "Eliminar producto";
            this.tsmiEliminarProducto.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // frmDetalleSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 523);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.dgvDetalleTiempo);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.lblTotalProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDetalleSesion";
            this.Text = "Detalle de Sesión";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.cmsProductos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvDetalleTiempo;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoJugado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalTiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarifaIinicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNuevaTarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCambio;
        private System.Windows.Forms.ContextMenuStrip cmsProductos;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarProducto;
    }
}