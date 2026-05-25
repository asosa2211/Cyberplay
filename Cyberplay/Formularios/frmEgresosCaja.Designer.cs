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
            this.dgvEgresos = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
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
            this.nudMonto.Location = new System.Drawing.Point(184, 85);
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(80, 20);
            this.nudMonto.TabIndex = 1;
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
            // dgvEgresos
            // 
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colConcepto,
            this.colMonto,
            this.colCajero});
            this.dgvEgresos.Location = new System.Drawing.Point(270, 36);
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.Size = new System.Drawing.Size(450, 150);
            this.dgvEgresos.TabIndex = 3;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colConcepto
            // 
            this.colConcepto.HeaderText = "Concepto";
            this.colConcepto.Name = "colConcepto";
            // 
            // colMonto
            // 
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            // 
            // frmEgresosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEgresos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.tbConcepto);
            this.Name = "frmEgresosCaja";
            this.Text = "frmEgresosCaja";
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConcepto;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
    }
}