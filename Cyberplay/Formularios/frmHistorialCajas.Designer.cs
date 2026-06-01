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
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCajas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialCajas
            // 
            this.dgvHistorialCajas.AllowUserToAddRows = false;
            this.dgvHistorialCajas.AllowUserToResizeRows = false;
            this.dgvHistorialCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialCajas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroCaja,
            this.colCajero,
            this.colApertura,
            this.colCierre,
            this.colTotal});
            this.dgvHistorialCajas.Location = new System.Drawing.Point(40, 36);
            this.dgvHistorialCajas.MultiSelect = false;
            this.dgvHistorialCajas.Name = "dgvHistorialCajas";
            this.dgvHistorialCajas.ReadOnly = true;
            this.dgvHistorialCajas.RowHeadersVisible = false;
            this.dgvHistorialCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialCajas.Size = new System.Drawing.Size(607, 232);
            this.dgvHistorialCajas.TabIndex = 0;
            this.dgvHistorialCajas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialCajas_CellDoubleClick);
            // 
            // colNumeroCaja
            // 
            this.colNumeroCaja.HeaderText = "Nro Caja";
            this.colNumeroCaja.Name = "colNumeroCaja";
            this.colNumeroCaja.ReadOnly = true;
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            this.colCajero.ReadOnly = true;
            // 
            // colApertura
            // 
            this.colApertura.HeaderText = "Apertura";
            this.colApertura.Name = "colApertura";
            this.colApertura.ReadOnly = true;
            this.colApertura.Width = 150;
            // 
            // colCierre
            // 
            this.colCierre.HeaderText = "Cierre";
            this.colCierre.Name = "colCierre";
            this.colCierre.ReadOnly = true;
            this.colCierre.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // frmHistorialCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 313);
            this.Controls.Add(this.dgvHistorialCajas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmHistorialCajas";
            this.ShowIcon = false;
            this.Text = "Historial de cajas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCajas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialCajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}