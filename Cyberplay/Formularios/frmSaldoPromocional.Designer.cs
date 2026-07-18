namespace Cyberplay.Formularios
{
    partial class frmSaldoPromocional
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
            this.lblCuenta = new System.Windows.Forms.Label();
            this.tbCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoPosterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAgregarSaldo = new System.Windows.Forms.Label();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.tbObservacion = new System.Windows.Forms.TextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.btnAgregarSaldo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(43, 32);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(47, 13);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Cuenta: ";
            // 
            // tbCuenta
            // 
            this.tbCuenta.Location = new System.Drawing.Point(46, 58);
            this.tbCuenta.Name = "tbCuenta";
            this.tbCuenta.ReadOnly = true;
            this.tbCuenta.Size = new System.Drawing.Size(100, 20);
            this.tbCuenta.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(172, 54);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(46, 108);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre: ";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(46, 134);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(106, 13);
            this.lblSaldo.TabIndex = 4;
            this.lblSaldo.Text = "Saldo Inicial: 0.00 Bs";
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colTipo,
            this.colMonto,
            this.colSaldoAnterior,
            this.colSaldoPosterior,
            this.colObservacion,
            this.colCajero});
            this.dgvMovimientos.Location = new System.Drawing.Point(253, 32);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(502, 150);
            this.dgvMovimientos.TabIndex = 5;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colMonto
            // 
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colSaldoAnterior
            // 
            this.colSaldoAnterior.HeaderText = "Saldo anterior";
            this.colSaldoAnterior.Name = "colSaldoAnterior";
            this.colSaldoAnterior.ReadOnly = true;
            // 
            // colSaldoPosterior
            // 
            this.colSaldoPosterior.HeaderText = "Saldo posterior";
            this.colSaldoPosterior.Name = "colSaldoPosterior";
            this.colSaldoPosterior.ReadOnly = true;
            // 
            // colObservacion
            // 
            this.colObservacion.HeaderText = "Observación";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.ReadOnly = true;
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            this.colCajero.ReadOnly = true;
            // 
            // lblAgregarSaldo
            // 
            this.lblAgregarSaldo.AutoSize = true;
            this.lblAgregarSaldo.Location = new System.Drawing.Point(46, 231);
            this.lblAgregarSaldo.Name = "lblAgregarSaldo";
            this.lblAgregarSaldo.Size = new System.Drawing.Size(78, 13);
            this.lblAgregarSaldo.TabIndex = 6;
            this.lblAgregarSaldo.Text = "Agregar saldo: ";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new System.Drawing.Point(130, 231);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(74, 20);
            this.nudMonto.TabIndex = 7;
            this.nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMonto.ThousandsSeparator = true;
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(280, 228);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 8;
            // 
            // tbObservacion
            // 
            this.tbObservacion.Location = new System.Drawing.Point(130, 280);
            this.tbObservacion.Name = "tbObservacion";
            this.tbObservacion.Size = new System.Drawing.Size(164, 20);
            this.tbObservacion.TabIndex = 9;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Location = new System.Drawing.Point(49, 286);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(73, 13);
            this.lblObservacion.TabIndex = 10;
            this.lblObservacion.Text = "Observación: ";
            // 
            // btnAgregarSaldo
            // 
            this.btnAgregarSaldo.Location = new System.Drawing.Point(336, 275);
            this.btnAgregarSaldo.Name = "btnAgregarSaldo";
            this.btnAgregarSaldo.Size = new System.Drawing.Size(99, 23);
            this.btnAgregarSaldo.TabIndex = 11;
            this.btnAgregarSaldo.Text = "Agregar saldo";
            this.btnAgregarSaldo.UseVisualStyleBackColor = true;
            this.btnAgregarSaldo.Click += new System.EventHandler(this.btnAgregarSaldo_Click);
            // 
            // frmSaldoPromocional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAgregarSaldo);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.tbObservacion);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.lblAgregarSaldo);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbCuenta);
            this.Controls.Add(this.lblCuenta);
            this.Name = "frmSaldoPromocional";
            this.Text = "frmSaldoPromocional";
            this.Load += new System.EventHandler(this.frmSaldoPromocional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.TextBox tbCuenta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoPosterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.Label lblAgregarSaldo;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.TextBox tbObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Button btnAgregarSaldo;
    }
}