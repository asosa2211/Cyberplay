namespace Cyberplay.Formularios
{
    partial class frmEgresosCaja
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
            this.tbConcepto = new System.Windows.Forms.TextBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.btnRegistrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConcepto
            // 
            this.tbConcepto.Location = new System.Drawing.Point(54, 84);
            this.tbConcepto.Name = "tbConcepto";
            this.tbConcepto.Size = new System.Drawing.Size(100, 20);
            this.tbConcepto.TabIndex = 0;
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 1;
            this.nudMonto.Location = new System.Drawing.Point(184, 85);
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(80, 20);
            this.nudMonto.TabIndex = 1;
            this.nudMonto.ThousandsSeparator = true;
            this.nudMonto.Click += new System.EventHandler(this.nudMonto_Click);
            this.nudMonto.Enter += new System.EventHandler(this.nudMonto_Enter);
            this.nudMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMonto_KeyPress);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(143, 145);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // frmEgresosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 275);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.tbConcepto);
            this.Name = "frmEgresosCaja";
            this.Text = "frmEgresosCaja";
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConcepto;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Button btnRegistrar;
    }
}