namespace Cyberplay.Formularios
{
    partial class frmAuditoria
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
            this.dgvAlertas = new System.Windows.Forms.DataGridView();
            this.colCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlertas
            // 
            this.dgvAlertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCajero,
            this.colFecha,
            this.colEquipo});
            this.dgvAlertas.Location = new System.Drawing.Point(81, 99);
            this.dgvAlertas.Name = "dgvAlertas";
            this.dgvAlertas.Size = new System.Drawing.Size(592, 150);
            this.dgvAlertas.TabIndex = 0;
            // 
            // colCajero
            // 
            this.colCajero.HeaderText = "Cajero";
            this.colCajero.Name = "colCajero";
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha y Hora";
            this.colFecha.Name = "colFecha";
            // 
            // colEquipo
            // 
            this.colEquipo.HeaderText = "Nro Equipo";
            this.colEquipo.Name = "colEquipo";
            // 
            // frmAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAlertas);
            this.Name = "frmAuditoria";
            this.Text = "frmAuditoria";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
    }
}