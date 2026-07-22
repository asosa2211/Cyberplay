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
            this.lblCuentaValor = new System.Windows.Forms.Label();
            this.lblNombreValor = new System.Windows.Forms.Label();
            this.lblSaldoValor = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.gbSaldo = new System.Windows.Forms.GroupBox();
            this.lblTipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.gbInfo.SuspendLayout();
            this.gbSaldo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(9, 27);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(55, 13);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Cuenta: ";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(176, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre: ";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(350, 27);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(47, 13);
            this.lblSaldo.TabIndex = 4;
            this.lblSaldo.Text = "Saldo: ";
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
            this.dgvMovimientos.Location = new System.Drawing.Point(32, 187);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(570, 239);
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
            this.lblAgregarSaldo.Location = new System.Drawing.Point(9, 30);
            this.lblAgregarSaldo.Name = "lblAgregarSaldo";
            this.lblAgregarSaldo.Size = new System.Drawing.Size(42, 13);
            this.lblAgregarSaldo.TabIndex = 6;
            this.lblAgregarSaldo.Text = "Monto";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMonto.Location = new System.Drawing.Point(12, 46);
            this.nudMonto.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(64, 20);
            this.nudMonto.TabIndex = 7;
            this.nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMonto.ThousandsSeparator = true;
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(93, 45);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(121, 21);
            this.cbTipo.TabIndex = 8;
            // 
            // tbObservacion
            // 
            this.tbObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservacion.Location = new System.Drawing.Point(236, 45);
            this.tbObservacion.Name = "tbObservacion";
            this.tbObservacion.Size = new System.Drawing.Size(124, 20);
            this.tbObservacion.TabIndex = 9;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Location = new System.Drawing.Point(239, 30);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(86, 13);
            this.lblObservacion.TabIndex = 10;
            this.lblObservacion.Text = "Observación: ";
            // 
            // btnAgregarSaldo
            // 
            this.btnAgregarSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarSaldo.Location = new System.Drawing.Point(381, 43);
            this.btnAgregarSaldo.Name = "btnAgregarSaldo";
            this.btnAgregarSaldo.Size = new System.Drawing.Size(82, 23);
            this.btnAgregarSaldo.TabIndex = 11;
            this.btnAgregarSaldo.Text = "Agregar saldo";
            this.btnAgregarSaldo.UseVisualStyleBackColor = true;
            this.btnAgregarSaldo.Click += new System.EventHandler(this.btnAgregarSaldo_Click);
            // 
            // lblCuentaValor
            // 
            this.lblCuentaValor.AutoSize = true;
            this.lblCuentaValor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCuentaValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaValor.Location = new System.Drawing.Point(63, 27);
            this.lblCuentaValor.Name = "lblCuentaValor";
            this.lblCuentaValor.Size = new System.Drawing.Size(48, 13);
            this.lblCuentaValor.TabIndex = 12;
            this.lblCuentaValor.Text = "buscar...";
            this.lblCuentaValor.Click += new System.EventHandler(this.lblCuentaValor_Click);
            // 
            // lblNombreValor
            // 
            this.lblNombreValor.AutoSize = true;
            this.lblNombreValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreValor.Location = new System.Drawing.Point(233, 27);
            this.lblNombreValor.Name = "lblNombreValor";
            this.lblNombreValor.Size = new System.Drawing.Size(79, 13);
            this.lblNombreValor.TabIndex = 13;
            this.lblNombreValor.Text = "Sin seleccionar";
            // 
            // lblSaldoValor
            // 
            this.lblSaldoValor.AutoSize = true;
            this.lblSaldoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoValor.Location = new System.Drawing.Point(410, 27);
            this.lblSaldoValor.Name = "lblSaldoValor";
            this.lblSaldoValor.Size = new System.Drawing.Size(43, 13);
            this.lblSaldoValor.TabIndex = 14;
            this.lblSaldoValor.Text = "0.00 Bs";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lblNombreValor);
            this.gbInfo.Controls.Add(this.lblSaldoValor);
            this.gbInfo.Controls.Add(this.lblCuenta);
            this.gbInfo.Controls.Add(this.lblNombre);
            this.gbInfo.Controls.Add(this.lblCuentaValor);
            this.gbInfo.Controls.Add(this.lblSaldo);
            this.gbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.Location = new System.Drawing.Point(32, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(570, 59);
            this.gbInfo.TabIndex = 15;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Información";
            // 
            // gbSaldo
            // 
            this.gbSaldo.Controls.Add(this.lblTipo);
            this.gbSaldo.Controls.Add(this.tbObservacion);
            this.gbSaldo.Controls.Add(this.lblAgregarSaldo);
            this.gbSaldo.Controls.Add(this.btnAgregarSaldo);
            this.gbSaldo.Controls.Add(this.nudMonto);
            this.gbSaldo.Controls.Add(this.lblObservacion);
            this.gbSaldo.Controls.Add(this.cbTipo);
            this.gbSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSaldo.Location = new System.Drawing.Point(32, 81);
            this.gbSaldo.Name = "gbSaldo";
            this.gbSaldo.Size = new System.Drawing.Size(570, 85);
            this.gbSaldo.TabIndex = 16;
            this.gbSaldo.TabStop = false;
            this.gbSaldo.Text = "Agregar saldo";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(93, 30);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(32, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Tipo";
            // 
            // frmSaldoPromocional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 450);
            this.Controls.Add(this.gbSaldo);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.dgvMovimientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSaldoPromocional";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ganadores";
            this.Load += new System.EventHandler(this.frmSaldoPromocional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbSaldo.ResumeLayout(false);
            this.gbSaldo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Label lblAgregarSaldo;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.TextBox tbObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Button btnAgregarSaldo;
        private System.Windows.Forms.Label lblCuentaValor;
        private System.Windows.Forms.Label lblNombreValor;
        private System.Windows.Forms.Label lblSaldoValor;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbSaldo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoPosterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
    }
}