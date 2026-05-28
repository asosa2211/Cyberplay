namespace Cyberplay
{
    partial class frmHistorialCobros
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
            this.dgvCobros = new System.Windows.Forms.DataGridView();
            this.colTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCaja = new System.Windows.Forms.TextBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.lblCajaActual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCobros
            // 
            this.dgvCobros.AllowUserToAddRows = false;
            this.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTicket,
            this.colEquipo,
            this.colUsuario,
            this.colTotal,
            this.colFecha});
            this.dgvCobros.Location = new System.Drawing.Point(62, 123);
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.Size = new System.Drawing.Size(649, 150);
            this.dgvCobros.TabIndex = 0;
            this.dgvCobros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobros_CellDoubleClick);
            // 
            // colTicket
            // 
            this.colTicket.HeaderText = "Ticket";
            this.colTicket.Name = "colTicket";
            // 
            // colEquipo
            // 
            this.colEquipo.HeaderText = "Equipo";
            this.colEquipo.Name = "colEquipo";
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // tbCaja
            // 
            this.tbCaja.Location = new System.Drawing.Point(62, 88);
            this.tbCaja.Name = "tbCaja";
            this.tbCaja.Size = new System.Drawing.Size(100, 20);
            this.tbCaja.TabIndex = 1;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(193, 88);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 2;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // lblCajaActual
            // 
            this.lblCajaActual.AutoSize = true;
            this.lblCajaActual.Location = new System.Drawing.Point(315, 94);
            this.lblCajaActual.Name = "lblCajaActual";
            this.lblCajaActual.Size = new System.Drawing.Size(35, 13);
            this.lblCajaActual.TabIndex = 3;
            this.lblCajaActual.Text = "label1";
            // 
            // frmHistorialCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCajaActual);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.tbCaja);
            this.Controls.Add(this.dgvCobros);
            this.Name = "frmHistorialCobros";
            this.Text = "frmHistorialCobros";
            this.Load += new System.EventHandler(this.frmHistorialCobros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCobros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.TextBox tbCaja;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label lblCajaActual;
    }
}