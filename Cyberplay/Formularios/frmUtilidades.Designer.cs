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
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalEquipos = new System.Windows.Forms.Label();
            this.rbCaja = new System.Windows.Forms.RadioButton();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.nudCajaHasta = new System.Windows.Forms.NumericUpDown();
            this.lblCajaHasta = new System.Windows.Forms.Label();
            this.nudCajaDesde = new System.Windows.Forms.NumericUpDown();
            this.lblCajaDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.gbUtilidadesPorEquipos = new System.Windows.Forms.GroupBox();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.colTipoEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUtilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbUtilidadPorCategorias = new System.Windows.Forms.GroupBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUtilidadCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltros.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).BeginInit();
            this.gbUtilidadesPorEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.gbUtilidadPorCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.gbGeneral);
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
            this.gbFiltros.Size = new System.Drawing.Size(706, 193);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.lblTotalGeneral);
            this.gbGeneral.Controls.Add(this.lblTotalProductos);
            this.gbGeneral.Controls.Add(this.lblTotalEquipos);
            this.gbGeneral.Location = new System.Drawing.Point(507, 20);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(179, 132);
            this.gbGeneral.TabIndex = 3;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "Resumen general";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(8, 95);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(66, 15);
            this.lblTotalGeneral.TabIndex = 2;
            this.lblTotalGeneral.Text = "General: ";
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.Location = new System.Drawing.Point(8, 61);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(79, 15);
            this.lblTotalProductos.TabIndex = 1;
            this.lblTotalProductos.Text = "Productos: ";
            // 
            // lblTotalEquipos
            // 
            this.lblTotalEquipos.AutoSize = true;
            this.lblTotalEquipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEquipos.Location = new System.Drawing.Point(8, 30);
            this.lblTotalEquipos.Name = "lblTotalEquipos";
            this.lblTotalEquipos.Size = new System.Drawing.Size(67, 15);
            this.lblTotalEquipos.TabIndex = 0;
            this.lblTotalEquipos.Text = "Equipos: ";
            // 
            // rbCaja
            // 
            this.rbCaja.AutoSize = true;
            this.rbCaja.Location = new System.Drawing.Point(328, 20);
            this.rbCaja.Name = "rbCaja";
            this.rbCaja.Size = new System.Drawing.Size(96, 17);
            this.rbCaja.TabIndex = 10;
            this.rbCaja.TabStop = true;
            this.rbCaja.Text = "Filtrar por cajas";
            this.rbCaja.UseVisualStyleBackColor = true;
            this.rbCaja.CheckedChanged += new System.EventHandler(this.rbCaja_CheckedChanged);
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
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(245, 150);
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
            this.nudCajaHasta.Click += new System.EventHandler(this.nudCajaHasta_Click);
            this.nudCajaHasta.Enter += new System.EventHandler(this.nudCajaHasta_Enter);
            this.nudCajaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCajaHasta_KeyPress);
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
            this.nudCajaDesde.Click += new System.EventHandler(this.nudCajaDesde_Click);
            this.nudCajaDesde.Enter += new System.EventHandler(this.nudCajaDesde_Enter);
            this.nudCajaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCajaDesde_KeyPress);
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
            // gbUtilidadesPorEquipos
            // 
            this.gbUtilidadesPorEquipos.Controls.Add(this.dgvEquipos);
            this.gbUtilidadesPorEquipos.Location = new System.Drawing.Point(121, 253);
            this.gbUtilidadesPorEquipos.Name = "gbUtilidadesPorEquipos";
            this.gbUtilidadesPorEquipos.Size = new System.Drawing.Size(252, 270);
            this.gbUtilidadesPorEquipos.TabIndex = 1;
            this.gbUtilidadesPorEquipos.TabStop = false;
            this.gbUtilidadesPorEquipos.Text = "Utilidades por equipos";
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToResizeRows = false;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipoEquipo,
            this.colUtilidad});
            this.dgvEquipos.Location = new System.Drawing.Point(15, 23);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(224, 228);
            this.dgvEquipos.TabIndex = 0;
            // 
            // colTipoEquipo
            // 
            this.colTipoEquipo.HeaderText = "Tipo Equipo";
            this.colTipoEquipo.Name = "colTipoEquipo";
            this.colTipoEquipo.ReadOnly = true;
            // 
            // colUtilidad
            // 
            this.colUtilidad.HeaderText = "Utilidad";
            this.colUtilidad.Name = "colUtilidad";
            this.colUtilidad.ReadOnly = true;
            // 
            // gbUtilidadPorCategorias
            // 
            this.gbUtilidadPorCategorias.Controls.Add(this.dgvCategorias);
            this.gbUtilidadPorCategorias.Location = new System.Drawing.Point(391, 253);
            this.gbUtilidadPorCategorias.Name = "gbUtilidadPorCategorias";
            this.gbUtilidadPorCategorias.Size = new System.Drawing.Size(260, 270);
            this.gbUtilidadPorCategorias.TabIndex = 2;
            this.gbUtilidadPorCategorias.TabStop = false;
            this.gbUtilidadPorCategorias.Text = "Utilidades por categorias";
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.AllowUserToResizeRows = false;
            this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoria,
            this.colUtilidadCategoria});
            this.dgvCategorias.Location = new System.Drawing.Point(18, 23);
            this.dgvCategorias.MultiSelect = false;
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(224, 228);
            this.dgvCategorias.TabIndex = 0;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colUtilidadCategoria
            // 
            this.colUtilidadCategoria.HeaderText = "Utilidad";
            this.colUtilidadCategoria.Name = "colUtilidadCategoria";
            this.colUtilidadCategoria.ReadOnly = true;
            // 
            // frmUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 557);
            this.Controls.Add(this.gbUtilidadPorCategorias);
            this.Controls.Add(this.gbUtilidadesPorEquipos);
            this.Controls.Add(this.gbFiltros);
            this.Name = "frmUtilidades";
            this.Text = "Utilidades";
            this.Load += new System.EventHandler(this.frmUtilidades_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).EndInit();
            this.gbUtilidadesPorEquipos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.gbUtilidadPorCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
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