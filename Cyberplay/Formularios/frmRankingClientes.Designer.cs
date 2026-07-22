namespace Cyberplay.Formularios
{
    partial class frmRankingClientes
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
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.colPosicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalMinutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRanking
            // 
            this.dgvRanking.AllowUserToAddRows = false;
            this.dgvRanking.AllowUserToResizeRows = false;
            this.dgvRanking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPosicion,
            this.colCliente,
            this.colTotalHoras,
            this.colTotalMinutos});
            this.dgvRanking.Location = new System.Drawing.Point(29, 252);
            this.dgvRanking.MultiSelect = false;
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.ReadOnly = true;
            this.dgvRanking.RowHeadersVisible = false;
            this.dgvRanking.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRanking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRanking.Size = new System.Drawing.Size(496, 237);
            this.dgvRanking.TabIndex = 0;
            // 
            // colPosicion
            // 
            this.colPosicion.HeaderText = "#";
            this.colPosicion.Name = "colPosicion";
            this.colPosicion.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colTotalHoras
            // 
            this.colTotalHoras.HeaderText = "Total Horas";
            this.colTotalHoras.Name = "colTotalHoras";
            this.colTotalHoras.ReadOnly = true;
            // 
            // colTotalMinutos
            // 
            this.colTotalMinutos.HeaderText = "Total Minutos";
            this.colTotalMinutos.Name = "colTotalMinutos";
            this.colTotalMinutos.ReadOnly = true;
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
            this.gbFiltros.Location = new System.Drawing.Point(29, 19);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(496, 213);
            this.gbFiltros.TabIndex = 1;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // rbCaja
            // 
            this.rbCaja.AutoSize = true;
            this.rbCaja.Location = new System.Drawing.Point(320, 19);
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
            this.rbFecha.Location = new System.Drawing.Point(112, 19);
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
            this.btnConsultar.Location = new System.Drawing.Point(211, 167);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // nudCajaHasta
            // 
            this.nudCajaHasta.Location = new System.Drawing.Point(384, 110);
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
            this.nudCajaHasta.Size = new System.Drawing.Size(61, 20);
            this.nudCajaHasta.TabIndex = 7;
            this.nudCajaHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCajaHasta
            // 
            this.lblCajaHasta.AutoSize = true;
            this.lblCajaHasta.Location = new System.Drawing.Point(320, 112);
            this.lblCajaHasta.Name = "lblCajaHasta";
            this.lblCajaHasta.Size = new System.Drawing.Size(58, 13);
            this.lblCajaHasta.TabIndex = 6;
            this.lblCajaHasta.Text = "Hasta caja";
            // 
            // nudCajaDesde
            // 
            this.nudCajaDesde.Location = new System.Drawing.Point(384, 63);
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
            this.nudCajaDesde.Size = new System.Drawing.Size(61, 20);
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
            this.lblCajaDesde.Location = new System.Drawing.Point(317, 65);
            this.lblCajaDesde.Name = "lblCajaDesde";
            this.lblCajaDesde.Size = new System.Drawing.Size(61, 13);
            this.lblCajaDesde.TabIndex = 4;
            this.lblCajaDesde.Text = "Desde caja";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(72, 108);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(214, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(32, 112);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(72, 62);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(212, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(28, 65);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // frmRankingClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 514);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.dgvRanking);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRankingClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ranking Clientes";
            this.Load += new System.EventHandler(this.frmRankingClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCajaDesde)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.RadioButton rbCaja;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.NumericUpDown nudCajaHasta;
        private System.Windows.Forms.Label lblCajaHasta;
        private System.Windows.Forms.NumericUpDown nudCajaDesde;
        private System.Windows.Forms.Label lblCajaDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalHoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalMinutos;
    }
}