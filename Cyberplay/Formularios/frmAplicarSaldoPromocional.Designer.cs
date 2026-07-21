namespace Cyberplay.Formularios
{
    partial class frmAplicarSaldoPromocional
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
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblSaldoDisponible = new System.Windows.Forms.Label();
            this.lblSaldoDisponibleValor = new System.Windows.Forms.Label();
            this.lblCostoTiempo = new System.Windows.Forms.Label();
            this.lblCostoTiempoValor = new System.Windows.Forms.Label();
            this.lblAplicarSaldo = new System.Windows.Forms.Label();
            this.lblTiempoPagar = new System.Windows.Forms.Label();
            this.lblTiempoPagarValor = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblProductosValor = new System.Windows.Forms.Label();
            this.lblTotalCobrar = new System.Windows.Forms.Label();
            this.lblTotalCobrarValor = new System.Windows.Forms.Label();
            this.lblSaldoRestante = new System.Windows.Forms.Label();
            this.lblSaldoRestanteValor = new System.Windows.Forms.Label();
            this.nudSaldoAplicar = new System.Windows.Forms.NumericUpDown();
            this.btnUsarTodo = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCuenta2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldoAplicar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(142, 18);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(50, 15);
            this.lblNombreCliente.TabIndex = 0;
            this.lblNombreCliente.Text = "invitado";
            // 
            // lblSaldoDisponible
            // 
            this.lblSaldoDisponible.AutoSize = true;
            this.lblSaldoDisponible.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDisponible.Location = new System.Drawing.Point(30, 43);
            this.lblSaldoDisponible.Name = "lblSaldoDisponible";
            this.lblSaldoDisponible.Size = new System.Drawing.Size(102, 15);
            this.lblSaldoDisponible.TabIndex = 1;
            this.lblSaldoDisponible.Text = "Saldo disponible: ";
            // 
            // lblSaldoDisponibleValor
            // 
            this.lblSaldoDisponibleValor.AutoSize = true;
            this.lblSaldoDisponibleValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDisponibleValor.Location = new System.Drawing.Point(142, 43);
            this.lblSaldoDisponibleValor.Name = "lblSaldoDisponibleValor";
            this.lblSaldoDisponibleValor.Size = new System.Drawing.Size(46, 15);
            this.lblSaldoDisponibleValor.TabIndex = 2;
            this.lblSaldoDisponibleValor.Text = "0.00 Bs.";
            // 
            // lblCostoTiempo
            // 
            this.lblCostoTiempo.AutoSize = true;
            this.lblCostoTiempo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTiempo.Location = new System.Drawing.Point(30, 69);
            this.lblCostoTiempo.Name = "lblCostoTiempo";
            this.lblCostoTiempo.Size = new System.Drawing.Size(87, 15);
            this.lblCostoTiempo.TabIndex = 3;
            this.lblCostoTiempo.Text = "Costo tiempo: ";
            // 
            // lblCostoTiempoValor
            // 
            this.lblCostoTiempoValor.AutoSize = true;
            this.lblCostoTiempoValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTiempoValor.Location = new System.Drawing.Point(142, 71);
            this.lblCostoTiempoValor.Name = "lblCostoTiempoValor";
            this.lblCostoTiempoValor.Size = new System.Drawing.Size(43, 15);
            this.lblCostoTiempoValor.TabIndex = 4;
            this.lblCostoTiempoValor.Text = "0.00 Bs";
            // 
            // lblAplicarSaldo
            // 
            this.lblAplicarSaldo.AutoSize = true;
            this.lblAplicarSaldo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicarSaldo.Location = new System.Drawing.Point(30, 94);
            this.lblAplicarSaldo.Name = "lblAplicarSaldo";
            this.lblAplicarSaldo.Size = new System.Drawing.Size(82, 15);
            this.lblAplicarSaldo.TabIndex = 5;
            this.lblAplicarSaldo.Text = "Aplicar saldo: ";
            // 
            // lblTiempoPagar
            // 
            this.lblTiempoPagar.AutoSize = true;
            this.lblTiempoPagar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoPagar.Location = new System.Drawing.Point(235, 18);
            this.lblTiempoPagar.Name = "lblTiempoPagar";
            this.lblTiempoPagar.Size = new System.Drawing.Size(98, 15);
            this.lblTiempoPagar.TabIndex = 6;
            this.lblTiempoPagar.Text = "Tiempo a pagar: ";
            // 
            // lblTiempoPagarValor
            // 
            this.lblTiempoPagarValor.AutoSize = true;
            this.lblTiempoPagarValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoPagarValor.Location = new System.Drawing.Point(351, 19);
            this.lblTiempoPagarValor.Name = "lblTiempoPagarValor";
            this.lblTiempoPagarValor.Size = new System.Drawing.Size(43, 15);
            this.lblTiempoPagarValor.TabIndex = 7;
            this.lblTiempoPagarValor.Text = "0.00 Bs";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(235, 43);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(69, 15);
            this.lblProductos.TabIndex = 8;
            this.lblProductos.Text = "Productos: ";
            // 
            // lblProductosValor
            // 
            this.lblProductosValor.AutoSize = true;
            this.lblProductosValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosValor.Location = new System.Drawing.Point(351, 43);
            this.lblProductosValor.Name = "lblProductosValor";
            this.lblProductosValor.Size = new System.Drawing.Size(43, 15);
            this.lblProductosValor.TabIndex = 9;
            this.lblProductosValor.Text = "0.00 Bs";
            // 
            // lblTotalCobrar
            // 
            this.lblTotalCobrar.AutoSize = true;
            this.lblTotalCobrar.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCobrar.Location = new System.Drawing.Point(235, 69);
            this.lblTotalCobrar.Name = "lblTotalCobrar";
            this.lblTotalCobrar.Size = new System.Drawing.Size(89, 15);
            this.lblTotalCobrar.TabIndex = 10;
            this.lblTotalCobrar.Text = "Total a Cobrar: ";
            // 
            // lblTotalCobrarValor
            // 
            this.lblTotalCobrarValor.AutoSize = true;
            this.lblTotalCobrarValor.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCobrarValor.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalCobrarValor.Location = new System.Drawing.Point(351, 70);
            this.lblTotalCobrarValor.Name = "lblTotalCobrarValor";
            this.lblTotalCobrarValor.Size = new System.Drawing.Size(47, 15);
            this.lblTotalCobrarValor.TabIndex = 11;
            this.lblTotalCobrarValor.Text = "0.00 Bs";
            // 
            // lblSaldoRestante
            // 
            this.lblSaldoRestante.AutoSize = true;
            this.lblSaldoRestante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoRestante.Location = new System.Drawing.Point(235, 94);
            this.lblSaldoRestante.Name = "lblSaldoRestante";
            this.lblSaldoRestante.Size = new System.Drawing.Size(93, 15);
            this.lblSaldoRestante.TabIndex = 12;
            this.lblSaldoRestante.Text = "Saldo restante: ";
            // 
            // lblSaldoRestanteValor
            // 
            this.lblSaldoRestanteValor.AutoSize = true;
            this.lblSaldoRestanteValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoRestanteValor.Location = new System.Drawing.Point(351, 93);
            this.lblSaldoRestanteValor.Name = "lblSaldoRestanteValor";
            this.lblSaldoRestanteValor.Size = new System.Drawing.Size(43, 15);
            this.lblSaldoRestanteValor.TabIndex = 13;
            this.lblSaldoRestanteValor.Text = "0.00 Bs";
            // 
            // nudSaldoAplicar
            // 
            this.nudSaldoAplicar.DecimalPlaces = 2;
            this.nudSaldoAplicar.Location = new System.Drawing.Point(143, 93);
            this.nudSaldoAplicar.Name = "nudSaldoAplicar";
            this.nudSaldoAplicar.Size = new System.Drawing.Size(51, 20);
            this.nudSaldoAplicar.TabIndex = 14;
            this.nudSaldoAplicar.ThousandsSeparator = true;
            this.nudSaldoAplicar.ValueChanged += new System.EventHandler(this.nudSaldoAplicar_ValueChanged);
            // 
            // btnUsarTodo
            // 
            this.btnUsarTodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsarTodo.Location = new System.Drawing.Point(83, 146);
            this.btnUsarTodo.Name = "btnUsarTodo";
            this.btnUsarTodo.Size = new System.Drawing.Size(75, 23);
            this.btnUsarTodo.TabIndex = 15;
            this.btnUsarTodo.Text = "Usar todo";
            this.btnUsarTodo.UseVisualStyleBackColor = true;
            this.btnUsarTodo.Click += new System.EventHandler(this.btnUsarTodo_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(280, 146);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(183, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCuenta2
            // 
            this.lblCuenta2.AutoSize = true;
            this.lblCuenta2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta2.Location = new System.Drawing.Point(31, 18);
            this.lblCuenta2.Name = "lblCuenta2";
            this.lblCuenta2.Size = new System.Drawing.Size(52, 15);
            this.lblCuenta2.TabIndex = 18;
            this.lblCuenta2.Text = "Cuenta: ";
            // 
            // frmAplicarSaldoPromocional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 199);
            this.Controls.Add(this.lblCuenta2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnUsarTodo);
            this.Controls.Add(this.nudSaldoAplicar);
            this.Controls.Add(this.lblSaldoRestanteValor);
            this.Controls.Add(this.lblSaldoRestante);
            this.Controls.Add(this.lblTotalCobrarValor);
            this.Controls.Add(this.lblTotalCobrar);
            this.Controls.Add(this.lblProductosValor);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.lblTiempoPagarValor);
            this.Controls.Add(this.lblTiempoPagar);
            this.Controls.Add(this.lblAplicarSaldo);
            this.Controls.Add(this.lblCostoTiempoValor);
            this.Controls.Add(this.lblCostoTiempo);
            this.Controls.Add(this.lblSaldoDisponibleValor);
            this.Controls.Add(this.lblSaldoDisponible);
            this.Controls.Add(this.lblNombreCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAplicarSaldoPromocional";
            this.ShowIcon = false;
            this.Text = "Descontar credito";
            this.Load += new System.EventHandler(this.frmAplicarSaldoPromocional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldoAplicar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblSaldoDisponible;
        private System.Windows.Forms.Label lblSaldoDisponibleValor;
        private System.Windows.Forms.Label lblCostoTiempo;
        private System.Windows.Forms.Label lblCostoTiempoValor;
        private System.Windows.Forms.Label lblAplicarSaldo;
        private System.Windows.Forms.Label lblTiempoPagar;
        private System.Windows.Forms.Label lblTiempoPagarValor;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblProductosValor;
        private System.Windows.Forms.Label lblTotalCobrar;
        private System.Windows.Forms.Label lblTotalCobrarValor;
        private System.Windows.Forms.Label lblSaldoRestante;
        private System.Windows.Forms.Label lblSaldoRestanteValor;
        private System.Windows.Forms.NumericUpDown nudSaldoAplicar;
        private System.Windows.Forms.Button btnUsarTodo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCuenta2;
    }
}