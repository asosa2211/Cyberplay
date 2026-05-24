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
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngresoCaja
            // 
            this.btnIngresoCaja.Location = new System.Drawing.Point(371, 101);
            this.btnIngresoCaja.Name = "btnIngresoCaja";
            this.btnIngresoCaja.Size = new System.Drawing.Size(75, 23);
            this.btnIngresoCaja.TabIndex = 0;
            this.btnIngresoCaja.Text = "Ingresar";
            this.btnIngresoCaja.UseVisualStyleBackColor = true;
            this.btnIngresoCaja.Click += new System.EventHandler(this.btnIngresoCaja_Click);
            // 
            // tbConcepto
            // 
            this.tbConcepto.Location = new System.Drawing.Point(48, 103);
            this.tbConcepto.Name = "tbConcepto";
            this.tbConcepto.Size = new System.Drawing.Size(125, 20);
            this.tbConcepto.TabIndex = 1;
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 1;
            this.nudTotal.Location = new System.Drawing.Point(214, 103);
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(93, 20);
            this.nudTotal.TabIndex = 2;
            this.nudTotal.ThousandsSeparator = true;
            this.nudTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudTotal_KeyPress);
            // 
            // frmIngresosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.tbConcepto);
            this.Controls.Add(this.btnIngresoCaja);
            this.Name = "frmIngresosCaja";
            this.Text = "frmIngresosCaja";
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresoCaja;
        private System.Windows.Forms.TextBox tbConcepto;
        private System.Windows.Forms.NumericUpDown nudTotal;
    }
}