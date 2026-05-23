namespace Cyberplay.Formularios
{
    partial class frmDetalleSesion
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(49, 45);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(116, 45);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(40, 13);
            this.lblEquipo.TabIndex = 1;
            this.lblEquipo.Text = "Equipo";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(188, 45);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(42, 13);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Text = "Tiempo";
            // 
            // lblTiempoTotal
            // 
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.Location = new System.Drawing.Point(276, 45);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.Size = new System.Drawing.Size(69, 13);
            this.lblTiempoTotal.TabIndex = 3;
            this.lblTiempoTotal.Text = "Tiempo Total";
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.AutoSize = true;
            this.lblTotalProductos.Location = new System.Drawing.Point(397, 45);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(82, 13);
            this.lblTotalProductos.TabIndex = 4;
            this.lblTotalProductos.Text = "Total Productos";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Location = new System.Drawing.Point(517, 45);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(71, 13);
            this.lblTotalGeneral.TabIndex = 5;
            this.lblTotalGeneral.Text = "Total General";
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCantidad,
            this.colTotal});
            this.dgvProductos.Location = new System.Drawing.Point(52, 97);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(360, 150);
            this.dgvProductos.TabIndex = 6;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            // 
            // frmDetalleSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.lblTotalProductos);
            this.Controls.Add(this.lblTiempoTotal);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.lblUsuario);
            this.Name = "frmDetalleSesion";
            this.Text = "frmDetalleSesion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblTiempoTotal;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}