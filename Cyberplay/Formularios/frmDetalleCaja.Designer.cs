namespace Cyberplay.Formularios
{
    partial class frmDetalleCaja
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
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.dgvEgresos = new System.Windows.Forms.DataGridView();
            this.colConceptoEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConceptoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalleVentaProductos = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNroCaja = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoIngreso,
            this.colTotalIngreso});
            this.dgvIngresos.Location = new System.Drawing.Point(46, 84);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.Size = new System.Drawing.Size(246, 142);
            this.dgvIngresos.TabIndex = 0;
            // 
            // dgvEgresos
            // 
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoEgreso,
            this.colTotalEgreso});
            this.dgvEgresos.Location = new System.Drawing.Point(357, 84);
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.Size = new System.Drawing.Size(270, 150);
            this.dgvEgresos.TabIndex = 1;
            // 
            // colConceptoEgreso
            // 
            this.colConceptoEgreso.HeaderText = "Concepto";
            this.colConceptoEgreso.Name = "colConceptoEgreso";
            // 
            // colTotalEgreso
            // 
            this.colTotalEgreso.HeaderText = "Total";
            this.colTotalEgreso.Name = "colTotalEgreso";
            // 
            // colConceptoIngreso
            // 
            this.colConceptoIngreso.HeaderText = "Concepto";
            this.colConceptoIngreso.Name = "colConceptoIngreso";
            // 
            // colTotalIngreso
            // 
            this.colTotalIngreso.HeaderText = "Total";
            this.colTotalIngreso.Name = "colTotalIngreso";
            // 
            // dgvDetalleVentaProductos
            // 
            this.dgvDetalleVentaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVentaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCategoria,
            this.colPrecio,
            this.colCantidad,
            this.colTotal});
            this.dgvDetalleVentaProductos.Location = new System.Drawing.Point(52, 268);
            this.dgvDetalleVentaProductos.Name = "dgvDetalleVentaProductos";
            this.dgvDetalleVentaProductos.Size = new System.Drawing.Size(575, 150);
            this.dgvDetalleVentaProductos.TabIndex = 2;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
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
            // lblNroCaja
            // 
            this.lblNroCaja.AutoSize = true;
            this.lblNroCaja.Location = new System.Drawing.Point(46, 35);
            this.lblNroCaja.Name = "lblNroCaja";
            this.lblNroCaja.Size = new System.Drawing.Size(35, 13);
            this.lblNroCaja.TabIndex = 3;
            this.lblNroCaja.Text = "label1";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(138, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(35, 13);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "label1";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(237, 35);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(35, 13);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "label1";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(331, 35);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(35, 13);
            this.lblCajero.TabIndex = 6;
            this.lblCajero.Text = "label1";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Location = new System.Drawing.Point(429, 35);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(35, 13);
            this.lblTotalGeneral.TabIndex = 7;
            this.lblTotalGeneral.Text = "label1";
            // 
            // frmDetalleCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 550);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNroCaja);
            this.Controls.Add(this.dgvDetalleVentaProductos);
            this.Controls.Add(this.dgvEgresos);
            this.Controls.Add(this.dgvIngresos);
            this.Name = "frmDetalleCaja";
            this.Text = "frmDetalleCaja";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalIngreso;
        private System.Windows.Forms.DataGridView dgvEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalEgreso;
        private System.Windows.Forms.DataGridView dgvDetalleVentaProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblNroCaja;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblTotalGeneral;
    }
}