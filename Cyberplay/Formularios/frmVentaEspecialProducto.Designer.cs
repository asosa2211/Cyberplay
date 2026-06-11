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
            this.lblTotal.Location = new System.Drawing.Point(82, 48);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total Bs";
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Location = new System.Drawing.Point(192, 44);
            this.nudTotal.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(100, 20);
            this.nudTotal.TabIndex = 1;
            this.nudTotal.ValueChanged += new System.EventHandler(this.nudTotal_ValueChanged);
            this.nudTotal.Click += new System.EventHandler(this.nudTotal_Click);
            this.nudTotal.Enter += new System.EventHandler(this.nudTotal_Enter);
            this.nudTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudTotal_KeyPress);
            // 
            // lblContadorInicial
            // 
            this.lblContadorInicial.AutoSize = true;
            this.lblContadorInicial.Location = new System.Drawing.Point(82, 85);
            this.lblContadorInicial.Name = "lblContadorInicial";
            this.lblContadorInicial.Size = new System.Drawing.Size(79, 13);
            this.lblContadorInicial.TabIndex = 2;
            this.lblContadorInicial.Text = "Contador inicial";
            // 
            // nudContadorInicial
            // 
            this.nudContadorInicial.Location = new System.Drawing.Point(192, 81);
            this.nudContadorInicial.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudContadorInicial.Name = "nudContadorInicial";
            this.nudContadorInicial.Size = new System.Drawing.Size(100, 20);
            this.nudContadorInicial.TabIndex = 3;
            this.nudContadorInicial.ValueChanged += new System.EventHandler(this.nudContadorInicial_ValueChanged);
            this.nudContadorInicial.Click += new System.EventHandler(this.nudContadorInicial_Click);
            this.nudContadorInicial.Enter += new System.EventHandler(this.nudContadorInicial_Enter);
            // 
            // lblContadorFinal
            // 
            this.lblContadorFinal.AutoSize = true;
            this.lblContadorFinal.Location = new System.Drawing.Point(82, 120);
            this.lblContadorFinal.Name = "lblContadorFinal";
            this.lblContadorFinal.Size = new System.Drawing.Size(72, 13);
            this.lblContadorFinal.TabIndex = 4;
            this.lblContadorFinal.Text = "Contador final";
            // 
            // nudContadorFinal
            // 
            this.nudContadorFinal.Location = new System.Drawing.Point(192, 116);
            this.nudContadorFinal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudContadorFinal.Name = "nudContadorFinal";
            this.nudContadorFinal.Size = new System.Drawing.Size(100, 20);
            this.nudContadorFinal.TabIndex = 5;
            this.nudContadorFinal.ValueChanged += new System.EventHandler(this.nudContadorFinal_ValueChanged);
            this.nudContadorFinal.Click += new System.EventHandler(this.nudContadorFinal_Click);
            this.nudContadorFinal.Enter += new System.EventHandler(this.nudContadorFinal_Enter);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(99, 192);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(199, 192);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmVentaEspecialProducto
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 254);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
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
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
