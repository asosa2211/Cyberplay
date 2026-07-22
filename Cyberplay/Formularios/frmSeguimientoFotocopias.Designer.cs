namespace Cyberplay.Formularios
{
    partial class frmSeguimientoFotocopias
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblCajero = new System.Windows.Forms.Label();
            this.cbCajero = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvSeguimiento = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCopias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalBs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAprox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(18, 18);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(65, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(195, 18);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(240, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(370, 18);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(37, 13);
            this.lblCajero.TabIndex = 4;
            this.lblCajero.Text = "Cajero";
            // 
            // cbCajero
            // 
            this.cbCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCajero.FormattingEnabled = true;
            this.cbCajero.Location = new System.Drawing.Point(420, 14);
            this.cbCajero.Name = "cbCajero";
            this.cbCajero.Size = new System.Drawing.Size(155, 21);
            this.cbCajero.TabIndex = 5;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(595, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(85, 23);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvSeguimiento
            // 
            this.dgvSeguimiento.AllowUserToAddRows = false;
            this.dgvSeguimiento.AllowUserToDeleteRows = false;
            this.dgvSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeguimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeguimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colCajero,
            this.colEntrada,
            this.colSalida,
            this.colTotalCopias,
            this.colTotalBs,
            this.colPromedio,
            this.colAprox,
            this.colDiferencia});
            this.dgvSeguimiento.Location = new System.Drawing.Point(18, 55);
            this.dgvSeguimiento.MultiSelect = false;
            this.dgvSeguimiento.Name = "dgvSeguimiento";
            this.dgvSeguimiento.ReadOnly = true;
            this.dgvSeguimiento.RowHeadersVisible = false;
            this.dgvSeguimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeguimiento.Size = new System.Drawing.Size(930, 390);
            this.dgvSeguimiento.TabIndex = 7;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            this.colCajero.ReadOnly = true;
            // 
            // colEntrada
            // 
            this.colEntrada.HeaderText = "Entrada";
            this.colEntrada.Name = "colEntrada";
            this.colEntrada.ReadOnly = true;
            // 
            // colSalida
            // 
            this.colSalida.HeaderText = "Salida";
            this.colSalida.Name = "colSalida";
            this.colSalida.ReadOnly = true;
            // 
            // colTotalCopias
            // 
            this.colTotalCopias.HeaderText = "Total Copias";
            this.colTotalCopias.Name = "colTotalCopias";
            this.colTotalCopias.ReadOnly = true;
            // 
            // colTotalBs
            // 
            this.colTotalBs.HeaderText = "Total bs";
            this.colTotalBs.Name = "colTotalBs";
            this.colTotalBs.ReadOnly = true;
            // 
            // colPromedio
            // 
            this.colPromedio.HeaderText = "Promedio";
            this.colPromedio.Name = "colPromedio";
            this.colPromedio.ReadOnly = true;
            // 
            // colAprox
            // 
            this.colAprox.HeaderText = "Aprox";
            this.colAprox.Name = "colAprox";
            this.colAprox.ReadOnly = true;
            // 
            // colDiferencia
            // 
            this.colDiferencia.HeaderText = "Diferencia";
            this.colDiferencia.Name = "colDiferencia";
            this.colDiferencia.ReadOnly = true;
            // 
            // frmSeguimientoFotocopias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 520);
            this.Controls.Add(this.dgvSeguimiento);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbCajero);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblDesde);
            this.MinimumSize = new System.Drawing.Size(900, 420);
            this.Name = "frmSeguimientoFotocopias";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento de fotocopias";
            this.Load += new System.EventHandler(this.frmSeguimientoFotocopias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.ComboBox cbCajero;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvSeguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCopias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAprox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferencia;
    }
}
