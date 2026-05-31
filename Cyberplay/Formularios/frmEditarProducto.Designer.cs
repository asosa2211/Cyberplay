namespace Cyberplay.Formularios
{
    partial class frmEditarProducto
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
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.nudPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.nudPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblTipoVenta = new System.Windows.Forms.Label();
            this.cbTipoVenta = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(168, 27);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(121, 20);
            this.tbNombre.TabIndex = 0;
            // 
            // nudPrecioCosto
            // 
            this.nudPrecioCosto.DecimalPlaces = 1;
            this.nudPrecioCosto.Location = new System.Drawing.Point(168, 109);
            this.nudPrecioCosto.Name = "nudPrecioCosto";
            this.nudPrecioCosto.Size = new System.Drawing.Size(61, 20);
            this.nudPrecioCosto.TabIndex = 3;
            this.nudPrecioCosto.Click += new System.EventHandler(this.nudPrecioCosto_Click);
            this.nudPrecioCosto.Enter += new System.EventHandler(this.nudPrecioCosto_Enter);
            this.nudPrecioCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudPrecioCosto_KeyPress);
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(168, 181);
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(61, 20);
            this.nudStock.TabIndex = 5;
            this.nudStock.Click += new System.EventHandler(this.nudStock_Click);
            this.nudStock.Enter += new System.EventHandler(this.nudStock_Enter);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(100, 246);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(197, 246);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbCategorias
            // 
            this.cbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(168, 70);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(121, 21);
            this.cbCategorias.TabIndex = 2;
            // 
            // nudPrecioVenta
            // 
            this.nudPrecioVenta.DecimalPlaces = 1;
            this.nudPrecioVenta.Location = new System.Drawing.Point(168, 146);
            this.nudPrecioVenta.Name = "nudPrecioVenta";
            this.nudPrecioVenta.Size = new System.Drawing.Size(61, 20);
            this.nudPrecioVenta.TabIndex = 4;
            this.nudPrecioVenta.Click += new System.EventHandler(this.nudPrecioVenta_Click);
            this.nudPrecioVenta.Enter += new System.EventHandler(this.nudPrecioVenta_Enter);
            this.nudPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudPrecioVenta_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(84, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(84, 75);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblPrecioCosto
            // 
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Location = new System.Drawing.Point(84, 113);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(66, 13);
            this.lblPrecioCosto.TabIndex = 10;
            this.lblPrecioCosto.Text = "Precio costo";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(84, 150);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(67, 13);
            this.lblPrecioVenta.TabIndex = 11;
            this.lblPrecioVenta.Text = "Precio venta";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(84, 185);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(35, 13);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "Stock";
            // 
            // lblTipoVenta
            // 
            this.lblTipoVenta.AutoSize = true;
            this.lblTipoVenta.Location = new System.Drawing.Point(84, 214);
            this.lblTipoVenta.Name = "lblTipoVenta";
            this.lblTipoVenta.Size = new System.Drawing.Size(58, 13);
            this.lblTipoVenta.TabIndex = 13;
            this.lblTipoVenta.Text = "Tipo venta";
            // 
            // cbTipoVenta
            // 
            this.cbTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoVenta.FormattingEnabled = true;
            this.cbTipoVenta.Location = new System.Drawing.Point(168, 210);
            this.cbTipoVenta.Name = "cbTipoVenta";
            this.cbTipoVenta.Size = new System.Drawing.Size(121, 21);
            this.cbTipoVenta.TabIndex = 6;
            this.cbTipoVenta.SelectedIndexChanged += new System.EventHandler(this.cbTipoVenta_SelectedIndexChanged);
            // 
            // frmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 302);
            this.Controls.Add(this.cbTipoVenta);
            this.Controls.Add(this.lblTipoVenta);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblPrecioCosto);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.nudPrecioVenta);
            this.Controls.Add(this.cbCategorias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.nudPrecioCosto);
            this.Controls.Add(this.tbNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditarProducto";
            this.ShowIcon = false;
            this.Text = "Agregar Producto";
            this.Load += new System.EventHandler(this.frmEditarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.NumericUpDown nudPrecioCosto;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.NumericUpDown nudPrecioVenta;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblTipoVenta;
        private System.Windows.Forms.ComboBox cbTipoVenta;
    }
}
