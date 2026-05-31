namespace Cyberplay.Formularios
{
    partial class frmVentaEspecialProducto
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.lblContadorInicial = new System.Windows.Forms.Label();
            this.nudContadorInicial = new System.Windows.Forms.NumericUpDown();
            this.lblContadorFinal = new System.Windows.Forms.Label();
            this.nudContadorFinal = new System.Windows.Forms.NumericUpDown();
            this.lblTotalCopiasValor = new System.Windows.Forms.Label();
            this.lblPromedioValor = new System.Windows.Forms.Label();
            this.lblAproximadoValor = new System.Windows.Forms.Label();
            this.lblDiferenciaValor = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContadorInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContadorFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(35, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total Bs";
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Location = new System.Drawing.Point(145, 24);
            this.nudTotal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(100, 20);
            this.nudTotal.TabIndex = 1;
            this.nudTotal.ValueChanged += new System.EventHandler(this.nudTotal_ValueChanged);
            // 
            // lblContadorInicial
            // 
            this.lblContadorInicial.AutoSize = true;
            this.lblContadorInicial.Location = new System.Drawing.Point(35, 65);
            this.lblContadorInicial.Name = "lblContadorInicial";
            this.lblContadorInicial.Size = new System.Drawing.Size(79, 13);
            this.lblContadorInicial.TabIndex = 2;
            this.lblContadorInicial.Text = "Contador inicial";
            // 
            // nudContadorInicial
            // 
            this.nudContadorInicial.Location = new System.Drawing.Point(145, 61);
            this.nudContadorInicial.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudContadorInicial.Name = "nudContadorInicial";
            this.nudContadorInicial.Size = new System.Drawing.Size(100, 20);
            this.nudContadorInicial.TabIndex = 3;
            this.nudContadorInicial.ValueChanged += new System.EventHandler(this.nudContadorInicial_ValueChanged);
            // 
            // lblContadorFinal
            // 
            this.lblContadorFinal.AutoSize = true;
            this.lblContadorFinal.Location = new System.Drawing.Point(35, 100);
            this.lblContadorFinal.Name = "lblContadorFinal";
            this.lblContadorFinal.Size = new System.Drawing.Size(72, 13);
            this.lblContadorFinal.TabIndex = 4;
            this.lblContadorFinal.Text = "Contador final";
            // 
            // nudContadorFinal
            // 
            this.nudContadorFinal.Location = new System.Drawing.Point(145, 96);
            this.nudContadorFinal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudContadorFinal.Name = "nudContadorFinal";
            this.nudContadorFinal.Size = new System.Drawing.Size(100, 20);
            this.nudContadorFinal.TabIndex = 5;
            this.nudContadorFinal.ValueChanged += new System.EventHandler(this.nudContadorFinal_ValueChanged);
            // 
            // lblTotalCopiasValor
            // 
            this.lblTotalCopiasValor.AutoSize = true;
            this.lblTotalCopiasValor.Location = new System.Drawing.Point(35, 135);
            this.lblTotalCopiasValor.Name = "lblTotalCopiasValor";
            this.lblTotalCopiasValor.Size = new System.Drawing.Size(77, 13);
            this.lblTotalCopiasValor.TabIndex = 6;
            this.lblTotalCopiasValor.Text = "Total copias: 0";
            // 
            // lblPromedioValor
            // 
            this.lblPromedioValor.AutoSize = true;
            this.lblPromedioValor.Location = new System.Drawing.Point(35, 160);
            this.lblPromedioValor.Name = "lblPromedioValor";
            this.lblPromedioValor.Size = new System.Drawing.Size(63, 13);
            this.lblPromedioValor.TabIndex = 7;
            this.lblPromedioValor.Text = "Promedio: 0";
            // 
            // lblAproximadoValor
            // 
            this.lblAproximadoValor.AutoSize = true;
            this.lblAproximadoValor.Location = new System.Drawing.Point(35, 185);
            this.lblAproximadoValor.Name = "lblAproximadoValor";
            this.lblAproximadoValor.Size = new System.Drawing.Size(46, 13);
            this.lblAproximadoValor.TabIndex = 8;
            this.lblAproximadoValor.Text = "Aprox: 0";
            // 
            // lblDiferenciaValor
            // 
            this.lblDiferenciaValor.AutoSize = true;
            this.lblDiferenciaValor.Location = new System.Drawing.Point(35, 210);
            this.lblDiferenciaValor.Name = "lblDiferenciaValor";
            this.lblDiferenciaValor.Size = new System.Drawing.Size(67, 13);
            this.lblDiferenciaValor.TabIndex = 9;
            this.lblDiferenciaValor.Text = "Diferencia: 0";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(96, 251);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(196, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmVentaEspecialProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 310);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblDiferenciaValor);
            this.Controls.Add(this.lblAproximadoValor);
            this.Controls.Add(this.lblPromedioValor);
            this.Controls.Add(this.lblTotalCopiasValor);
            this.Controls.Add(this.nudContadorFinal);
            this.Controls.Add(this.lblContadorFinal);
            this.Controls.Add(this.nudContadorInicial);
            this.Controls.Add(this.lblContadorInicial);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.lblTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVentaEspecialProducto";
            this.ShowIcon = false;
            this.Text = "Venta";
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContadorInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContadorFinal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Label lblContadorInicial;
        private System.Windows.Forms.NumericUpDown nudContadorInicial;
        private System.Windows.Forms.Label lblContadorFinal;
        private System.Windows.Forms.NumericUpDown nudContadorFinal;
        private System.Windows.Forms.Label lblTotalCopiasValor;
        private System.Windows.Forms.Label lblPromedioValor;
        private System.Windows.Forms.Label lblAproximadoValor;
        private System.Windows.Forms.Label lblDiferenciaValor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
