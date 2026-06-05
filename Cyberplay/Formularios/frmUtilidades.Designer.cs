namespace Cyberplay.Formularios
{
    partial class frmUtilidades
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
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblCajaDesde = new System.Windows.Forms.Label();
            this.nudCajaDesde = new System.Windows.Forms.NumericUpDown();
            this.lblCajaHasta = new System.Windows.Forms.Label();
            this.nudCajaHasta = new System.Windows.Forms.NumericUpDown();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.gbUtilidadesPorEquipos = new System.Windows.Forms.GroupBox();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.colTipoEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUtilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbUtilidadPorCategorias = new System.Windows.Forms.GroupBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUtilidadCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.lblTotalEquipos = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbCaja = new System.Windows.Forms.RadioButton();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).BeginInit();
            this.gbUtilidadesPorEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.gbUtilidadPorCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.gbGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.rbCaja);
            this.gbFiltros.Controls.Add(this.rbFecha);
            this.gbFiltros.Controls.Add(this.btnConsultar);
            this.gbFiltros.Controls.Add(this.nudCajaHasta);
            this.gbFiltros.Controls.Add(this.lblCajaHasta);
            this.gbFiltros.Controls.Add(this.nudCajaDesde);
            this.gbFiltros.Controls.Add(this.lblCajaDesde);
            this.gbFiltros.Controls.Add(this.dtpHasta);
            this.gbFiltros.Controls.Add(this.lblHasta);
            this.gbFiltros.Controls.Add(this.dtpDesde);
            this.gbFiltros.Controls.Add(this.lblDesde);
            this.gbFiltros.Location = new System.Drawing.Point(39, 37);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(597, 133);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
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
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(66, 51);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(294, 51);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(345, 45);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblCajaDesde
            // 
            this.lblCajaDesde.AutoSize = true;
            this.lblCajaDesde.Location = new System.Drawing.Point(25, 91);
            this.lblCajaDesde.Name = "lblCajaDesde";
            this.lblCajaDesde.Size = new System.Drawing.Size(61, 13);
            this.lblCajaDesde.TabIndex = 4;
            this.lblCajaDesde.Text = "Desde caja";
            // 
            // nudCajaDesde
            // 
            this.nudCajaDesde.Location = new System.Drawing.Point(92, 91);
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
            this.nudCajaDesde.Size = new System.Drawing.Size(120, 20);
            this.nudCajaDesde.TabIndex = 5;
            this.nudCajaDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCajaHasta
            // 
            this.lblCajaHasta.AutoSize = true;
            this.lblCajaHasta.Location = new System.Drawing.Point(230, 90);
            this.lblCajaHasta.Name = "lblCajaHasta";
            this.lblCajaHasta.Size = new System.Drawing.Size(58, 13);
            this.lblCajaHasta.TabIndex = 6;
            this.lblCajaHasta.Text = "Hasta caja";
            // 
            // nudCajaHasta
            // 
            this.nudCajaHasta.Location = new System.Drawing.Point(311, 88);
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
            this.nudCajaHasta.Size = new System.Drawing.Size(120, 20);
            this.nudCajaHasta.TabIndex = 7;
            this.nudCajaHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(482, 88);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gbUtilidadesPorEquipos
            // 
            this.gbUtilidadesPorEquipos.Controls.Add(this.dgvEquipos);
            this.gbUtilidadesPorEquipos.Location = new System.Drawing.Point(39, 176);
            this.gbUtilidadesPorEquipos.Name = "gbUtilidadesPorEquipos";
            this.gbUtilidadesPorEquipos.Size = new System.Drawing.Size(370, 216);
            this.gbUtilidadesPorEquipos.TabIndex = 1;
            this.gbUtilidadesPorEquipos.TabStop = false;
            this.gbUtilidadesPorEquipos.Text = "Utilidades por equipos";
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipoEquipo,
            this.colUtilidad});
            this.dgvEquipos.Location = new System.Drawing.Point(25, 46);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.Size = new System.Drawing.Size(323, 150);
            this.dgvEquipos.TabIndex = 0;
            // 
            // colTipoEquipo
            // 
            this.colTipoEquipo.HeaderText = "Tipo Equipo";
            this.colTipoEquipo.Name = "colTipoEquipo";
            // 
            // colUtilidad
            // 
            this.colUtilidad.HeaderText = "Utilidad";
            this.colUtilidad.Name = "colUtilidad";
            // 
            // gbUtilidadPorCategorias
            // 
            this.gbUtilidadPorCategorias.Controls.Add(this.dgvCategorias);
            this.gbUtilidadPorCategorias.Location = new System.Drawing.Point(434, 176);
            this.gbUtilidadPorCategorias.Name = "gbUtilidadPorCategorias";
            this.gbUtilidadPorCategorias.Size = new System.Drawing.Size(370, 216);
            this.gbUtilidadPorCategorias.TabIndex = 2;
            this.gbUtilidadPorCategorias.TabStop = false;
            this.gbUtilidadPorCategorias.Text = "Utilidades por categorias";
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoria,
            this.colUtilidadCategoria});
            this.dgvCategorias.Location = new System.Drawing.Point(25, 46);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.Size = new System.Drawing.Size(323, 150);
            this.dgvCategorias.TabIndex = 0;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            // 
            // colUtilidadCategoria
            // 
            this.colUtilidadCategoria.HeaderText = "Utilidad";
            this.colUtilidadCategoria.Name = "colUtilidadCategoria";
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.lblTotalGeneral);
            this.gbGeneral.Controls.Add(this.lblTotalProductos);
            this.gbGeneral.Controls.Add(this.lblTotalEquipos);
            this.gbGeneral.Location = new System.Drawing.Point(269, 463);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(337, 160);
            this.gbGeneral.TabIndex = 3;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "Resumen general";
            // 
            // lblTotalEquipos
            // 
            this.lblTotalEquipos.AutoSize = true;
            this.lblTotalEquipos.Location = new System.Drawing.Point(67, 29);
            this.lblTotalEquipos.Name = "lblTotalEquipos";
            this.lblTotalEquipos.Size = new System.Drawing.Size(35, 13);
            this.lblTotalEquipos.TabIndex = 0;
            this.lblTotalEquipos.Text = "label1";
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Location = new System.Drawing.Point(70, 59);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(35, 13);
            this.lblTotalProductos.TabIndex = 1;
            this.lblTotalProductos.Text = "label1";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Location = new System.Drawing.Point(67, 96);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(35, 13);
            this.lblTotalGeneral.TabIndex = 2;
            this.lblTotalGeneral.Text = "label1";
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(92, 20);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(103, 17);
            this.rbFecha.TabIndex = 9;
            this.rbFecha.TabStop = true;
            this.rbFecha.Text = "Filtrar por fechas";
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
            // 
            // rbCaja
            // 
            this.rbCaja.AutoSize = true;
            this.rbCaja.Location = new System.Drawing.Point(260, 20);
            this.rbCaja.Name = "rbCaja";
            this.rbCaja.Size = new System.Drawing.Size(96, 17);
            this.rbCaja.TabIndex = 10;
            this.rbCaja.TabStop = true;
            this.rbCaja.Text = "Filtrar por cajas";
            this.rbCaja.UseVisualStyleBackColor = true;
            this.rbCaja.CheckedChanged += new System.EventHandler(this.rbCaja_CheckedChanged);
            // 
            // frmUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 662);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.gbUtilidadPorCategorias);
            this.Controls.Add(this.gbUtilidadesPorEquipos);
            this.Controls.Add(this.gbFiltros);
            this.Name = "frmUtilidades";
            this.Text = "frmUtilidades";
            this.Load += new System.EventHandler(this.frmUtilidades_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).EndInit();
            this.gbUtilidadesPorEquipos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.gbUtilidadPorCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lblCajaHasta;
        private System.Windows.Forms.NumericUpDown nudCajaDesde;
        private System.Windows.Forms.Label lblCajaDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.NumericUpDown nudCajaHasta;
        private System.Windows.Forms.GroupBox gbUtilidadesPorEquipos;
        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUtilidad;
        private System.Windows.Forms.GroupBox gbUtilidadPorCategorias;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUtilidadCategoria;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalEquipos;
        private System.Windows.Forms.RadioButton rbCaja;
        private System.Windows.Forms.RadioButton rbFecha;
    }
}