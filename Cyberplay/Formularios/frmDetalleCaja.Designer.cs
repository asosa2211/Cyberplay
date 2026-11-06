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
            this.colConceptoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgvDetalleMultijugador = new System.Windows.Forms.DataGridView();
            this.colTarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarifaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalleStock = new System.Windows.Forms.DataGridView();
            this.colProductoStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntradaStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecibidoStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntregadoStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetiroStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiferenciaStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDetalleVentas = new System.Windows.Forms.Label();
            this.lblDetalleTarifas = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.numcaja = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleMultijugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleStock)).BeginInit();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AllowUserToResizeRows = false;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoIngreso,
            this.colTotalIngreso});
            this.dgvIngresos.Location = new System.Drawing.Point(20, 109);
            this.dgvIngresos.MultiSelect = false;
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(255, 146);
            this.dgvIngresos.TabIndex = 0;
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
            // dgvEgresos
            // 
            this.dgvEgresos.AllowUserToAddRows = false;
            this.dgvEgresos.AllowUserToResizeRows = false;
            this.dgvEgresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoEgreso,
            this.colTotalEgreso});
            this.dgvEgresos.Location = new System.Drawing.Point(20, 287);
            this.dgvEgresos.MultiSelect = false;
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.ReadOnly = true;
            this.dgvEgresos.RowHeadersVisible = false;
            this.dgvEgresos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvEgresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEgresos.Size = new System.Drawing.Size(255, 156);
            this.dgvEgresos.TabIndex = 1;
            // 
            // colConceptoEgreso
            // 
            this.colConceptoEgreso.HeaderText = "Concepto";
            this.colConceptoEgreso.Name = "colConceptoEgreso";
            this.colConceptoEgreso.ReadOnly = true;
            this.colConceptoEgreso.Width = 150;
            // 
            // colTotalEgreso
            // 
            this.colTotalEgreso.HeaderText = "Total";
            this.colTotalEgreso.Name = "colTotalEgreso";
            this.colTotalEgreso.ReadOnly = true;
            // 
            // dgvDetalleVentaProductos
            // 
            this.dgvDetalleVentaProductos.AllowUserToAddRows = false;
            this.dgvDetalleVentaProductos.AllowUserToResizeRows = false;
            this.dgvDetalleVentaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVentaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVentaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCategoria,
            this.colPrecio,
            this.colCantidad,
            this.colTotal});
            this.dgvDetalleVentaProductos.Location = new System.Drawing.Point(301, 108);
            this.dgvDetalleVentaProductos.MultiSelect = false;
            this.dgvDetalleVentaProductos.Name = "dgvDetalleVentaProductos";
            this.dgvDetalleVentaProductos.ReadOnly = true;
            this.dgvDetalleVentaProductos.RowHeadersVisible = false;
            this.dgvDetalleVentaProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleVentaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleVentaProductos.Size = new System.Drawing.Size(557, 256);
            this.dgvDetalleVentaProductos.TabIndex = 2;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
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
            // lblNroCaja
            // 
            this.lblNroCaja.AutoSize = true;
            this.lblNroCaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroCaja.Location = new System.Drawing.Point(71, 22);
            this.lblNroCaja.Name = "lblNroCaja";
            this.lblNroCaja.Size = new System.Drawing.Size(21, 15);
            this.lblNroCaja.TabIndex = 3;
            this.lblNroCaja.Text = "Nº";
            // 
            // lblApertura
            // 
            this.lblApertura.AutoSize = true;
            this.lblApertura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApertura.Location = new System.Drawing.Point(294, 23);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(53, 15);
            this.lblApertura.TabIndex = 4;
            this.lblApertura.Text = "Apertura";
            // 
            // lblCierre
            // 
            this.lblCierre.AutoSize = true;
            this.lblCierre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierre.Location = new System.Drawing.Point(294, 43);
            this.lblCierre.Name = "lblCierre";
            this.lblCierre.Size = new System.Drawing.Size(38, 15);
            this.lblCierre.TabIndex = 5;
            this.lblCierre.Text = "Cierre";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajero.Location = new System.Drawing.Point(71, 43);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(41, 15);
            this.lblCajero.TabIndex = 6;
            this.lblCajero.Text = "Cajero";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(672, 23);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(61, 30);
            this.lblTotalGeneral.TabIndex = 7;
            this.lblTotalGeneral.Text = "Total";
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.Location = new System.Drawing.Point(23, 89);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(88, 13);
            this.lblTotalIngresos.TabIndex = 8;
            this.lblTotalIngresos.Text = "Total Ingresos";
            // 
            // lblTotalEgresos
            // 
            this.lblTotalEgresos.AutoSize = true;
            this.lblTotalEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEgresos.Location = new System.Drawing.Point(22, 267);
            this.lblTotalEgresos.Name = "lblTotalEgresos";
            this.lblTotalEgresos.Size = new System.Drawing.Size(85, 13);
            this.lblTotalEgresos.TabIndex = 9;
            this.lblTotalEgresos.Text = "Total Egresos";
            // 
            // dgvDetalleMultijugador
            // 
            this.dgvDetalleMultijugador.AllowUserToAddRows = false;
            this.dgvDetalleMultijugador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleMultijugador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleMultijugador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTarifa,
            this.colTipo,
            this.colTarifaTotal});
            this.dgvDetalleMultijugador.Location = new System.Drawing.Point(20, 476);
            this.dgvDetalleMultijugador.MultiSelect = false;
            this.dgvDetalleMultijugador.Name = "dgvDetalleMultijugador";
            this.dgvDetalleMultijugador.ReadOnly = true;
            this.dgvDetalleMultijugador.RowHeadersVisible = false;
            this.dgvDetalleMultijugador.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleMultijugador.Size = new System.Drawing.Size(255, 131);
            this.dgvDetalleMultijugador.TabIndex = 10;
            // 
            // colTarifa
            // 
            this.colTarifa.HeaderText = "Tarifa";
            this.colTarifa.Name = "colTarifa";
            this.colTarifa.ReadOnly = true;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colTarifaTotal
            // 
            this.colTarifaTotal.HeaderText = "Total";
            this.colTarifaTotal.Name = "colTarifaTotal";
            this.colTarifaTotal.ReadOnly = true;
            // 
            // dgvDetalleStock
            // 
            this.dgvDetalleStock.AllowUserToAddRows = false;
            this.dgvDetalleStock.AllowUserToResizeRows = false;
            this.dgvDetalleStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductoStock,
            this.colCategoriaStock,
            this.colEntradaStock,
            this.colRecibidoStock,
            this.colEntregadoStock,
            this.colRetiroStock,
            this.colDiferenciaStock});
            this.dgvDetalleStock.Location = new System.Drawing.Point(301, 394);
            this.dgvDetalleStock.MultiSelect = false;
            this.dgvDetalleStock.Name = "dgvDetalleStock";
            this.dgvDetalleStock.ReadOnly = true;
            this.dgvDetalleStock.RowHeadersVisible = false;
            this.dgvDetalleStock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalleStock.Size = new System.Drawing.Size(554, 213);
            this.dgvDetalleStock.TabIndex = 11;
            // 
            // colProductoStock
            // 
            this.colProductoStock.HeaderText = "Producto";
            this.colProductoStock.Name = "colProductoStock";
            this.colProductoStock.ReadOnly = true;
            // 
            // colCategoriaStock
            // 
            this.colCategoriaStock.HeaderText = "Categoria";
            this.colCategoriaStock.Name = "colCategoriaStock";
            this.colCategoriaStock.ReadOnly = true;
            // 
            // colEntradaStock
            // 
            this.colEntradaStock.HeaderText = "Entrada";
            this.colEntradaStock.Name = "colEntradaStock";
            this.colEntradaStock.ReadOnly = true;
            // 
            // colRecibidoStock
            // 
            this.colRecibidoStock.HeaderText = "Recibido";
            this.colRecibidoStock.Name = "colRecibidoStock";
            this.colRecibidoStock.ReadOnly = true;
            // 
            // colEntregadoStock
            // 
            this.colEntregadoStock.HeaderText = "Entregado";
            this.colEntregadoStock.Name = "colEntregadoStock";
            this.colEntregadoStock.ReadOnly = true;
            // 
            // colRetiroStock
            // 
            this.colRetiroStock.HeaderText = "Retiro";
            this.colRetiroStock.Name = "colRetiroStock";
            this.colRetiroStock.ReadOnly = true;
            // 
            // colDiferenciaStock
            // 
            this.colDiferenciaStock.HeaderText = "Diferencia";
            this.colDiferenciaStock.Name = "colDiferenciaStock";
            this.colDiferenciaStock.ReadOnly = true;
            // 
            // lblDetalleVentas
            // 
            this.lblDetalleVentas.AutoSize = true;
            this.lblDetalleVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVentas.Location = new System.Drawing.Point(301, 92);
            this.lblDetalleVentas.Name = "lblDetalleVentas";
            this.lblDetalleVentas.Size = new System.Drawing.Size(232, 13);
            this.lblDetalleVentas.TabIndex = 12;
            this.lblDetalleVentas.Text = "DETALLE DE PRODUCTOS VENDIDOS";
            // 
            // lblDetalleTarifas
            // 
            this.lblDetalleTarifas.AutoSize = true;
            this.lblDetalleTarifas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleTarifas.Location = new System.Drawing.Point(23, 456);
            this.lblDetalleTarifas.Name = "lblDetalleTarifas";
            this.lblDetalleTarifas.Size = new System.Drawing.Size(229, 13);
            this.lblDetalleTarifas.TabIndex = 13;
            this.lblDetalleTarifas.Text = "DETALLE DE INGRESOS POR TARIFA";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(298, 378);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(128, 13);
            this.lblStock.TabIndex = 14;
            this.lblStock.Text = "DETALLE DE STOCK";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.numcaja);
            this.gbInfo.Controls.Add(this.lblNroCaja);
            this.gbInfo.Controls.Add(this.lblCajero);
            this.gbInfo.Controls.Add(this.lblApertura);
            this.gbInfo.Controls.Add(this.lblCierre);
            this.gbInfo.Controls.Add(this.lblTotalGeneral);
            this.gbInfo.Location = new System.Drawing.Point(26, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(829, 70);
            this.gbInfo.TabIndex = 15;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Información";
            // 
            // numcaja
            // 
            this.numcaja.AutoSize = true;
            this.numcaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numcaja.Location = new System.Drawing.Point(7, 22);
            this.numcaja.Name = "numcaja";
            this.numcaja.Size = new System.Drawing.Size(52, 15);
            this.numcaja.TabIndex = 4;
            this.numcaja.Text = "Caja Nº: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cajero: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Apertura: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cierre: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "TOTAL GENERAL: ";
            // 
            // frmDetalleCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(882, 619);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblDetalleTarifas);
            this.Controls.Add(this.lblDetalleVentas);
            this.Controls.Add(this.dgvDetalleStock);
            this.Controls.Add(this.dgvDetalleMultijugador);
            this.Controls.Add(this.lblTotalEgresos);
            this.Controls.Add(this.lblTotalIngresos);
            this.Controls.Add(this.dgvDetalleVentaProductos);
            this.Controls.Add(this.dgvEgresos);
            this.Controls.Add(this.dgvIngresos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmDetalleCaja";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de caja";
            this.Load += new System.EventHandler(this.frmDetalleCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVentaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleMultijugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleStock)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.DataGridView dgvEgresos;
        private System.Windows.Forms.DataGridView dgvDetalleVentaProductos;
        private System.Windows.Forms.Label lblNroCaja;
        private System.Windows.Forms.Label lblApertura;
        private System.Windows.Forms.Label lblCierre;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label lblTotalEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalIngreso;
        private System.Windows.Forms.DataGridView dgvDetalleMultijugador;
        private System.Windows.Forms.DataGridView dgvDetalleStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarifaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblDetalleVentas;
        private System.Windows.Forms.Label lblDetalleTarifas;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntradaStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecibidoStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntregadoStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetiroStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferenciaStock;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label numcaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}