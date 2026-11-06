namespace Cyberplay.Formularios
{
    partial class frmSeguimientoCaja
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
            this.dgvSeguimiento = new System.Windows.Forms.DataGridView();
            this.tbNroCaja = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSeguimiento
            // 
            this.dgvSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeguimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaHora,
            this.colConcepto,
            this.colIngreso,
            this.colEgreso,
            this.colTotal});
            this.dgvSeguimiento.Location = new System.Drawing.Point(73, 122);
            this.dgvSeguimiento.Name = "dgvSeguimiento";
            this.dgvSeguimiento.Size = new System.Drawing.Size(673, 249);
            this.dgvSeguimiento.TabIndex = 0;
            // 
            // tbNroCaja
            // 
            this.tbNroCaja.Location = new System.Drawing.Point(73, 70);
            this.tbNroCaja.Name = "tbNroCaja";
            this.tbNroCaja.Size = new System.Drawing.Size(100, 20);
            this.tbNroCaja.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(193, 66);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "button1";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // colFechaHora
            // 
            this.colFechaHora.HeaderText = "Fecha y Hora";
            this.colFechaHora.Name = "colFechaHora";
            // 
            // colConcepto
            // 
            this.colConcepto.HeaderText = "Concepto";
            this.colConcepto.Name = "colConcepto";
            // 
            // colIngreso
            // 
            this.colIngreso.HeaderText = "Ingreso";
            this.colIngreso.Name = "colIngreso";
            // 
            // colEgreso
            // 
            this.colEgreso.HeaderText = "Egreso";
            this.colEgreso.Name = "colEgreso";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            // 
            // frmSeguimientoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 512);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.tbNroCaja);
            this.Controls.Add(this.dgvSeguimiento);
            this.Name = "frmSeguimientoCaja";
            this.Text = "frmSeguimientoCaja";
            this.Load += new System.EventHandler(this.frmSeguimientoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeguimiento;
        private System.Windows.Forms.TextBox tbNroCaja;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}