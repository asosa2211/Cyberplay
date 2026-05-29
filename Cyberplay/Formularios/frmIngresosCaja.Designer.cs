namespace Cyberplay.Formularios
{
    partial class frmIngresosCaja
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
            this.btnIngresoCaja = new System.Windows.Forms.Button();
            this.tbConcepto = new System.Windows.Forms.TextBox();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngresoCaja
            // 
            this.btnIngresoCaja.Location = new System.Drawing.Point(120, 148);
            this.btnIngresoCaja.Name = "btnIngresoCaja";
            this.btnIngresoCaja.Size = new System.Drawing.Size(75, 23);
            this.btnIngresoCaja.TabIndex = 0;
            this.btnIngresoCaja.Text = "Registrar";
            this.btnIngresoCaja.UseVisualStyleBackColor = true;
            this.btnIngresoCaja.Click += new System.EventHandler(this.btnIngresoCaja_Click);
            // 
            // tbConcepto
            // 
            this.tbConcepto.Location = new System.Drawing.Point(197, 42);
            this.tbConcepto.Name = "tbConcepto";
            this.tbConcepto.Size = new System.Drawing.Size(125, 20);
            this.tbConcepto.TabIndex = 1;
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 1;
            this.nudTotal.Location = new System.Drawing.Point(197, 86);
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(85, 20);
            this.nudTotal.TabIndex = 2;
            this.nudTotal.ThousandsSeparator = true;
            this.nudTotal.Click += new System.EventHandler(this.nudTotal_Click);
            this.nudTotal.Enter += new System.EventHandler(this.nudTotal_Enter);
            this.nudTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudTotal_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(231, 148);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(99, 49);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(40, 13);
            this.lblDetalle.TabIndex = 4;
            this.lblDetalle.Text = "Detalle";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(99, 93);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(37, 13);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "Monto";
            // 
            // frmIngresosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 243);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.tbConcepto);
            this.Controls.Add(this.btnIngresoCaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmIngresosCaja";
            this.ShowIcon = false;
            this.Text = "Registrar ingreso";
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresoCaja;
        private System.Windows.Forms.TextBox tbConcepto;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblMonto;
    }
}