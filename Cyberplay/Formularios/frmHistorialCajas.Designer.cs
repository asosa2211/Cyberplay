namespace Cyberplay.Formularios
{
    partial class frmHistorialCajas
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
            this.dgvHistorialCajas = new System.Windows.Forms.DataGridView();
            this.colNumeroCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCajas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialCajas
            // 
            this.dgvHistorialCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialCajas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroCaja,
            this.colApertura,
            this.colCierre,
            this.colCajero,
            this.colTotal});
            this.dgvHistorialCajas.Location = new System.Drawing.Point(31, 76);
            this.dgvHistorialCajas.Name = "dgvHistorialCajas";
            this.dgvHistorialCajas.Size = new System.Drawing.Size(666, 150);
            this.dgvHistorialCajas.TabIndex = 0;
            // 
            // colNumeroCaja
            // 
            this.colNumeroCaja.HeaderText = "Nro Caja";
            this.colNumeroCaja.Name = "colNumeroCaja";
            // 
            // colApertura
            // 
            this.colApertura.HeaderText = "Apertura";
            this.colApertura.Name = "colApertura";
            // 
            // colCierre
            // 
            this.colCierre.HeaderText = "Cierre";
            this.colCierre.Name = "colCierre";
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            // 
            // frmHistorialCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHistorialCajas);
            this.Name = "frmHistorialCajas";
            this.Text = "frmHistorialCajas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCajas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialCajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}