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
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colIngreso,
            this.colEgreso,
            this.colTotal});
            this.dgvSeguimiento.Location = new System.Drawing.Point(72, 47);
            this.dgvSeguimiento.Name = "dgvSeguimiento";
            this.dgvSeguimiento.Size = new System.Drawing.Size(673, 249);
            this.dgvSeguimiento.TabIndex = 0;
            // 
            // colFechaHora
            // 
            this.colFechaHora.HeaderText = "Fecha y Hora";
            this.colFechaHora.Name = "colFechaHora";
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
            this.Controls.Add(this.dgvSeguimiento);
            this.Name = "frmSeguimientoCaja";
            this.Text = "frmSeguimientoCaja";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}