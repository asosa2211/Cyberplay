namespace Cyberplay.Formularios
{
    partial class frmVentaProductos
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
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.btnVender = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCarrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidadCarrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCarrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVaciarCarrito = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCategorias
            // 
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(22, 42);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(121, 21);
            this.cbCategorias.TabIndex = 0;
            this.cbCategorias.SelectedIndexChanged += new System.EventHandler(this.cbProductos_SelectedIndexChanged);
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Location = new System.Drawing.Point(161, 82);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(31, 13);
            this.lblTotalVenta.TabIndex = 3;
            this.lblTotalVenta.Text = "Total";
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(363, 150);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 4;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colPrecio,
            this.colStock});
            this.dgvProductos.Location = new System.Drawing.Point(35, 232);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(346, 150);
            this.dgvProductos.TabIndex = 5;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombreCarrito,
            this.colCantidadCarrito,
            this.colTotalCarrito});
            this.dgvCarrito.Location = new System.Drawing.Point(432, 232);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.Size = new System.Drawing.Size(359, 150);
            this.dgvCarrito.TabIndex = 6;
            this.dgvCarrito.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrito_CellDoubleClick);
            this.dgvCarrito.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrito_CellEndEdit);
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // colStock
            // 
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            // 
            // colNombreCarrito
            // 
            this.colNombreCarrito.HeaderText = "Nombre";
            this.colNombreCarrito.Name = "colNombreCarrito";
            // 
            // colCantidadCarrito
            // 
            this.colCantidadCarrito.HeaderText = "Cantidad";
            this.colCantidadCarrito.Name = "colCantidadCarrito";
            // 
            // colTotalCarrito
            // 
            this.colTotalCarrito.HeaderText = "Total";
            this.colTotalCarrito.Name = "colTotalCarrito";
            // 
            // btnVaciarCarrito
            // 
            this.btnVaciarCarrito.Location = new System.Drawing.Point(483, 150);
            this.btnVaciarCarrito.Name = "btnVaciarCarrito";
            this.btnVaciarCarrito.Size = new System.Drawing.Size(75, 23);
            this.btnVaciarCarrito.TabIndex = 7;
            this.btnVaciarCarrito.Text = "Vaciar";
            this.btnVaciarCarrito.UseVisualStyleBackColor = true;
            this.btnVaciarCarrito.Click += new System.EventHandler(this.btnVaciarCarrito_Click);
            // 
            // frmVentaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 526);
            this.Controls.Add(this.btnVaciarCarrito);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.lblTotalVenta);
            this.Controls.Add(this.cbCategorias);
            this.Name = "frmVentaProductos";
            this.Text = "frmVentaProductos";
            this.Load += new System.EventHandler(this.frmVentaProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidadCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCarrito;
        private System.Windows.Forms.Button btnVaciarCarrito;
    }
}