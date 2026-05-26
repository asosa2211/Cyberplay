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
            this.dgvDetalleVentaProductos = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNroCaja = new System.Windows.Forms.Label();
            this.lblApertura = new System.Windows.Forms.Label();
            this.lblCierre = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.lblTotalEgresos = new System.Windows.Forms.Label();
            this.colConceptoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoIngreso,
            this.colTotalIngreso});
            this.dgvIngresos.Location = new System.Drawing.Point(49, 119);
            this.dgvIngresos.MultiSelect = false;
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(255, 214);
            this.dgvIngresos.TabIndex = 0;
            // 
            // dgvEgresos
            // 
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoEgreso,
            this.colTotalEgreso});
            this.dgvEgresos.Location = new System.Drawing.Point(351, 119);
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.Size = new System.Drawing.Size(270, 214);
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
            // dgvDetalleVentaProductos
            // 
            this.dgvDetalleVentaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVentaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCategoria,
            this.colPrecio,
            this.colCantidad,
            this.colTotal});
            this.dgvDetalleVentaProductos.Location = new System.Drawing.Point(46, 339);
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
            this.lblNroCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroCaja.Location = new System.Drawing.Point(49, 35);
            this.lblNroCaja.Name = "lblNroCaja";
            this.lblNroCaja.Size = new System.Drawing.Size(46, 17);
            this.lblNroCaja.TabIndex = 3;
            this.lblNroCaja.Text = "label1";
            // 
            // lblApertura
            // 
            this.lblApertura.AutoSize = true;
            this.lblApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApertura.Location = new System.Drawing.Point(49, 65);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(46, 17);
            this.lblApertura.TabIndex = 4;
            this.lblApertura.Text = "label1";
            // 
            // lblCierre
            // 
            this.lblCierre.AutoSize = true;
            this.lblCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierre.Location = new System.Drawing.Point(303, 65);
            this.lblCierre.Name = "lblCierre";
            this.lblCierre.Size = new System.Drawing.Size(46, 17);
            this.lblCierre.TabIndex = 5;
            this.lblCierre.Text = "label1";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajero.Location = new System.Drawing.Point(159, 35);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(46, 17);
            this.lblCajero.TabIndex = 6;
            this.lblCajero.Text = "label1";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(303, 35);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(46, 17);
            this.lblTotalGeneral.TabIndex = 7;
            this.lblTotalGeneral.Text = "label1";
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.Location = new System.Drawing.Point(165, 99);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(41, 13);
            this.lblTotalIngresos.TabIndex = 8;
            this.lblTotalIngresos.Text = "label1";
            // 
            // lblTotalEgresos
            // 
            this.lblTotalEgresos.AutoSize = true;
            this.lblTotalEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEgresos.Location = new System.Drawing.Point(486, 99);
            this.lblTotalEgresos.Name = "lblTotalEgresos";
            this.lblTotalEgresos.Size = new System.Drawing.Size(41, 13);
            this.lblTotalEgresos.TabIndex = 9;
            this.lblTotalEgresos.Text = "label1";
            // 
            // colConceptoIngreso
            // 
            this.colConceptoIngreso.HeaderText = "Concepto";
            this.colConceptoIngreso.Name = "colConceptoIngreso";
            this.colConceptoIngreso.ReadOnly = true;
            this.colConceptoIngreso.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colConceptoIngreso.Width = 150;
            // 
            // colTotalIngreso
            // 
            this.colTotalIngreso.HeaderText = "Total";
            this.colTotalIngreso.Name = "colTotalIngreso";
            this.colTotalIngreso.ReadOnly = true;
            // 
            // frmDetalleCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 550);
            this.Controls.Add(this.lblTotalEgresos);
            this.Controls.Add(this.lblTotalIngresos);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.lblCierre);
            this.Controls.Add(this.lblApertura);
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
        private System.Windows.Forms.Label lblApertura;
        private System.Windows.Forms.Label lblCierre;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label lblTotalEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalIngreso;
    }
}