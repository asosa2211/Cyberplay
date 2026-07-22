namespace Cyberplay.Formularios
{
    partial class frmUtilidadxProducto
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
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.rbCajas = new System.Windows.Forms.RadioButton();
            this.rbFechas = new System.Windows.Forms.RadioButton();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.nudCajaHasta = new System.Windows.Forms.NumericUpDown();
            this.lblCajaHasta = new System.Windows.Forms.Label();
            this.nudCajaDesde = new System.Windows.Forms.NumericUpDown();
            this.lblCajaDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUtilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportar = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnExportar);
            this.gbFiltros.Controls.Add(this.cbCategorias);
            this.gbFiltros.Controls.Add(this.rbCajas);
            this.gbFiltros.Controls.Add(this.rbFechas);
            this.gbFiltros.Controls.Add(this.btnConsultar);
            this.gbFiltros.Controls.Add(this.nudCajaHasta);
            this.gbFiltros.Controls.Add(this.lblCajaHasta);
            this.gbFiltros.Controls.Add(this.nudCajaDesde);
            this.gbFiltros.Controls.Add(this.lblCajaDesde);
            this.gbFiltros.Controls.Add(this.dtpHasta);
            this.gbFiltros.Controls.Add(this.lblHasta);
            this.gbFiltros.Controls.Add(this.dtpDesde);
            this.gbFiltros.Controls.Add(this.lblDesde);
            this.gbFiltros.Location = new System.Drawing.Point(44, 21);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(476, 193);
            this.gbFiltros.TabIndex = 1;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // cbCategorias
            // 
            this.cbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(108, 150);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(121, 21);
            this.cbCategorias.TabIndex = 3;
            this.cbCategorias.SelectedIndexChanged += new System.EventHandler(this.cbCategorias_SelectedIndexChanged);
            // 
            // rbCajas
            // 
            this.rbCajas.AutoSize = true;
            this.rbCajas.Location = new System.Drawing.Point(328, 20);
            this.rbCajas.Name = "rbCajas";
            this.rbCajas.Size = new System.Drawing.Size(96, 17);
            this.rbCajas.TabIndex = 10;
            this.rbCajas.TabStop = true;
            this.rbCajas.Text = "Filtrar por cajas";
            this.rbCajas.UseVisualStyleBackColor = true;
            this.rbCajas.CheckedChanged += new System.EventHandler(this.rbCajas_CheckedChanged);
            // 
            // rbFechas
            // 
            this.rbFechas.AutoSize = true;
            this.rbFechas.Location = new System.Drawing.Point(92, 20);
            this.rbFechas.Name = "rbFechas";
            this.rbFechas.Size = new System.Drawing.Size(103, 17);
            this.rbFechas.TabIndex = 9;
            this.rbFechas.TabStop = true;
            this.rbFechas.Text = "Filtrar por fechas";
            this.rbFechas.UseVisualStyleBackColor = true;
            this.rbFechas.CheckedChanged += new System.EventHandler(this.rbFechas_CheckedChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(266, 148);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // nudCajaHasta
            // 
            this.nudCajaHasta.Location = new System.Drawing.Point(382, 96);
            this.nudCajaHasta.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCajaHasta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCajaHasta.Name = "nudCajaHasta";
            this.nudCajaHasta.Size = new System.Drawing.Size(69, 20);
            this.nudCajaHasta.TabIndex = 6;
            this.nudCajaHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCajaHasta
            // 
            this.lblCajaHasta.AutoSize = true;
            this.lblCajaHasta.Location = new System.Drawing.Point(315, 98);
            this.lblCajaHasta.Name = "lblCajaHasta";
            this.lblCajaHasta.Size = new System.Drawing.Size(58, 13);
            this.lblCajaHasta.TabIndex = 6;
            this.lblCajaHasta.Text = "Hasta caja";
            // 
            // nudCajaDesde
            // 
            this.nudCajaDesde.Location = new System.Drawing.Point(382, 50);
            this.nudCajaDesde.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCajaDesde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCajaDesde.Name = "nudCajaDesde";
            this.nudCajaDesde.Size = new System.Drawing.Size(69, 20);
            this.nudCajaDesde.TabIndex = 5;
            this.nudCajaDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCajaDesde
            // 
            this.lblCajaDesde.AutoSize = true;
            this.lblCajaDesde.Location = new System.Drawing.Point(315, 51);
            this.lblCajaDesde.Name = "lblCajaDesde";
            this.lblCajaDesde.Size = new System.Drawing.Size(61, 13);
            this.lblCajaDesde.TabIndex = 4;
            this.lblCajaDesde.Text = "Desde caja";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(66, 91);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(212, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(25, 93);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(66, 51);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(212, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(22, 51);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCategoria,
            this.colPrecio,
            this.colCantidad,
            this.colTotal,
            this.colUtilidad});
            this.dgvProductos.Location = new System.Drawing.Point(44, 230);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductos.Size = new System.Drawing.Size(476, 248);
            this.dgvProductos.TabIndex = 2;
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
            // colUtilidad
            // 
            this.colUtilidad.HeaderText = "Utilidad";
            this.colUtilidad.Name = "colUtilidad";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(382, 147);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 11;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmUtilidadxProducto
            // 
            this.AcceptButton = this.btnConsultar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 509);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.gbFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmUtilidadxProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilidades por producto";
            this.Load += new System.EventHandler(this.frmUtilidadxProducto_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.RadioButton rbCajas;
        private System.Windows.Forms.RadioButton rbFechas;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.NumericUpDown nudCajaHasta;
        private System.Windows.Forms.Label lblCajaHasta;
        private System.Windows.Forms.NumericUpDown nudCajaDesde;
        private System.Windows.Forms.Label lblCajaDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUtilidad;
        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.Button btnExportar;
    }
}