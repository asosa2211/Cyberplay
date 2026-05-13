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
            this.pnlps5 = new System.Windows.Forms.Panel();
            this.btnps5Ok = new System.Windows.Forms.Button();
            this.lblps5Tiempo = new System.Windows.Forms.Label();
            this.tbps5Minutos = new System.Windows.Forms.TextBox();
            this.rbps5Limitado = new System.Windows.Forms.RadioButton();
            this.rbps5Libre = new System.Windows.Forms.RadioButton();
            this.btnps5Control = new System.Windows.Forms.Button();
            this.lblps5Total = new System.Windows.Forms.Label();
            this.lblps5Crono = new System.Windows.Forms.Label();
            this.lblps5Titulo = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlps5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlps5
            // 
            this.pnlps5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlps5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlps5.Controls.Add(this.btnps5Ok);
            this.pnlps5.Controls.Add(this.lblps5Tiempo);
            this.pnlps5.Controls.Add(this.tbps5Minutos);
            this.pnlps5.Controls.Add(this.rbps5Limitado);
            this.pnlps5.Controls.Add(this.rbps5Libre);
            this.pnlps5.Controls.Add(this.btnps5Control);
            this.pnlps5.Controls.Add(this.lblps5Total);
            this.pnlps5.Controls.Add(this.lblps5Crono);
            this.pnlps5.Controls.Add(this.lblps5Titulo);
            this.pnlps5.Location = new System.Drawing.Point(55, 46);
            this.pnlps5.Name = "pnlps5";
            this.pnlps5.Size = new System.Drawing.Size(223, 228);
            this.pnlps5.TabIndex = 0;
            // 
            // btnps5Ok
            // 
            this.btnps5Ok.Location = new System.Drawing.Point(187, 201);
            this.btnps5Ok.Name = "btnps5Ok";
            this.btnps5Ok.Size = new System.Drawing.Size(30, 23);
            this.btnps5Ok.TabIndex = 8;
            this.btnps5Ok.Text = "Ok";
            this.btnps5Ok.UseVisualStyleBackColor = true;
            this.btnps5Ok.Click += new System.EventHandler(this.btnps5Ok_Click);
            // 
            // lblps5Tiempo
            // 
            this.lblps5Tiempo.AutoSize = true;
            this.lblps5Tiempo.Location = new System.Drawing.Point(93, 23);
            this.lblps5Tiempo.Name = "lblps5Tiempo";
            this.lblps5Tiempo.Size = new System.Drawing.Size(35, 13);
            this.lblps5Tiempo.TabIndex = 7;
            this.lblps5Tiempo.Text = "label1";
            // 
            // tbps5Minutos
            // 
            this.tbps5Minutos.Location = new System.Drawing.Point(134, 203);
            this.tbps5Minutos.Name = "tbps5Minutos";
            this.tbps5Minutos.Size = new System.Drawing.Size(47, 20);
            this.tbps5Minutos.TabIndex = 6;
            // 
            // rbps5Limitado
            // 
            this.rbps5Limitado.AutoSize = true;
            this.rbps5Limitado.Location = new System.Drawing.Point(64, 206);
            this.rbps5Limitado.Name = "rbps5Limitado";
            this.rbps5Limitado.Size = new System.Drawing.Size(64, 17);
            this.rbps5Limitado.TabIndex = 5;
            this.rbps5Limitado.Text = "Limitado";
            this.rbps5Limitado.UseVisualStyleBackColor = true;
            // 
            // rbps5Libre
            // 
            this.rbps5Libre.AutoSize = true;
            this.rbps5Libre.Checked = true;
            this.rbps5Libre.Location = new System.Drawing.Point(10, 206);
            this.rbps5Libre.Name = "rbps5Libre";
            this.rbps5Libre.Size = new System.Drawing.Size(48, 17);
            this.rbps5Libre.TabIndex = 4;
            this.rbps5Libre.TabStop = true;
            this.rbps5Libre.Text = "Libre";
            this.rbps5Libre.UseVisualStyleBackColor = true;
            // 
            // btnps5Control
            // 
            this.btnps5Control.Location = new System.Drawing.Point(67, 162);
            this.btnps5Control.Name = "btnps5Control";
            this.btnps5Control.Size = new System.Drawing.Size(75, 23);
            this.btnps5Control.TabIndex = 3;
            this.btnps5Control.Text = "Iniciar";
            this.btnps5Control.UseVisualStyleBackColor = true;
            this.btnps5Control.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblps5Total
            // 
            this.lblps5Total.AutoSize = true;
            this.lblps5Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblps5Total.Location = new System.Drawing.Point(60, 111);
            this.lblps5Total.Name = "lblps5Total";
            this.lblps5Total.Size = new System.Drawing.Size(99, 39);
            this.lblps5Total.TabIndex = 2;
            this.lblps5Total.Text = "Bs. 0";
            // 
            // lblps5Crono
            // 
            this.lblps5Crono.AutoSize = true;
            this.lblps5Crono.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblps5Crono.Location = new System.Drawing.Point(33, 72);
            this.lblps5Crono.Name = "lblps5Crono";
            this.lblps5Crono.Size = new System.Drawing.Size(157, 39);
            this.lblps5Crono.TabIndex = 1;
            this.lblps5Crono.Text = "00:00:00";
            // 
            // lblps5Titulo
            // 
            this.lblps5Titulo.AutoSize = true;
            this.lblps5Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblps5Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblps5Titulo.Location = new System.Drawing.Point(10, 9);
            this.lblps5Titulo.Name = "lblps5Titulo";
            this.lblps5Titulo.Size = new System.Drawing.Size(45, 48);
            this.lblps5Titulo.TabIndex = 0;
            this.lblps5Titulo.Text = "5";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 542);
            this.Controls.Add(this.pnlps5);
            this.Name = "frmPrincipal";
            this.Text = "Cyberplay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlps5.ResumeLayout(false);
            this.pnlps5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlps5;
        private System.Windows.Forms.Label lblps5Titulo;
        private System.Windows.Forms.Label lblps5Crono;
        private System.Windows.Forms.Label lblps5Total;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnps5Control;
        private System.Windows.Forms.RadioButton rbps5Libre;
        private System.Windows.Forms.RadioButton rbps5Limitado;
        private System.Windows.Forms.TextBox tbps5Minutos;
        private System.Windows.Forms.Button btnps5Ok;
        private System.Windows.Forms.Label lblps5Tiempo;
    }
}

