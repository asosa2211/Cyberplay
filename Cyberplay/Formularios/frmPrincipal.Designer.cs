namespace Cyberplay
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblNumeroCaja = new System.Windows.Forms.Label();
            this.lblCajero = new System.Windows.Forms.Label();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.lvProximasSalidas = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.Location = new System.Drawing.Point(262, 3);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(85, 25);
            this.lblCaja.TabIndex = 5;
            this.lblCaja.Text = "0.00 Bs";
            // 
            // lblNumeroCaja
            // 
            this.lblNumeroCaja.AutoSize = true;
            this.lblNumeroCaja.Location = new System.Drawing.Point(45, 9);
            this.lblNumeroCaja.Name = "lblNumeroCaja";
            this.lblNumeroCaja.Size = new System.Drawing.Size(35, 13);
            this.lblNumeroCaja.TabIndex = 6;
            this.lblNumeroCaja.Text = "label1";
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(192, 9);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(35, 13);
            this.lblCajero.TabIndex = 7;
            this.lblCajero.Text = "label1";
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Location = new System.Drawing.Point(442, 4);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarCaja.TabIndex = 8;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // lvProximasSalidas
            // 
            this.lvProximasSalidas.FullRowSelect = true;
            this.lvProximasSalidas.GridLines = true;
            this.lvProximasSalidas.HideSelection = false;
            this.lvProximasSalidas.Location = new System.Drawing.Point(381, 98);
            this.lvProximasSalidas.MultiSelect = false;
            this.lvProximasSalidas.Name = "lvProximasSalidas";
            this.lvProximasSalidas.Size = new System.Drawing.Size(229, 246);
            this.lvProximasSalidas.TabIndex = 9;
            this.lvProximasSalidas.UseCompatibleStateImageBehavior = false;
            this.lvProximasSalidas.View = System.Windows.Forms.View.Details;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(992, 487);
            this.Controls.Add(this.lvProximasSalidas);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.lblNumeroCaja);
            this.Controls.Add(this.lblCaja);
            this.Name = "frmPrincipal";
            this.Text = "Cyberplay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblNumeroCaja;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.ListView lvProximasSalidas;
    }
}

