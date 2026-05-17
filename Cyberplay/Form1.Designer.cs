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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTiempoJugado = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTiempoLimite = new System.Windows.Forms.Label();
            this.rbLimitado = new System.Windows.Forms.RadioButton();
            this.rbLibre = new System.Windows.Forms.RadioButton();
            this.bntIniciar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTarifas = new System.Windows.Forms.Panel();
            this.rb2M = new System.Windows.Forms.RadioButton();
            this.rb3M = new System.Windows.Forms.RadioButton();
            this.rb4M = new System.Windows.Forms.RadioButton();
            this.lblCaja = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.pnlTarifas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.btnCobrar);
            this.pnlPrincipal.Controls.Add(this.lblUsuario);
            this.pnlPrincipal.Controls.Add(this.lblTiempoJugado);
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.lblTiempoLimite);
            this.pnlPrincipal.Controls.Add(this.rbLimitado);
            this.pnlPrincipal.Controls.Add(this.rbLibre);
            this.pnlPrincipal.Controls.Add(this.bntIniciar);
            this.pnlPrincipal.Controls.Add(this.lblTotal);
            this.pnlPrincipal.Controls.Add(this.lblCronometro);
            this.pnlPrincipal.Controls.Add(this.lblTitulo);
            this.pnlPrincipal.Location = new System.Drawing.Point(51, 46);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(223, 228);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(115, 170);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(75, 23);
            this.btnCobrar.TabIndex = 11;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Red;
            this.lblUsuario.Location = new System.Drawing.Point(90, 80);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(65, 17);
            this.lblUsuario.TabIndex = 10;
            this.lblUsuario.Text = "invitado";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // lblTiempoJugado
            // 
            this.lblTiempoJugado.AutoSize = true;
            this.lblTiempoJugado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoJugado.Location = new System.Drawing.Point(89, 63);
            this.lblTiempoJugado.Name = "lblTiempoJugado";
            this.lblTiempoJugado.Size = new System.Drawing.Size(72, 17);
            this.lblTiempoJugado.TabIndex = 9;
            this.lblTiempoJugado.Text = "00:00:00";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-11, -31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 24);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblTiempoLimite
            // 
            this.lblTiempoLimite.AutoSize = true;
            this.lblTiempoLimite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTiempoLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoLimite.Location = new System.Drawing.Point(85, 42);
            this.lblTiempoLimite.Name = "lblTiempoLimite";
            this.lblTiempoLimite.Size = new System.Drawing.Size(84, 17);
            this.lblTiempoLimite.TabIndex = 7;
            this.lblTiempoLimite.Text = "ILIMITADO";
            this.lblTiempoLimite.Click += new System.EventHandler(this.lblps5Tiempo_Click);
            this.lblTiempoLimite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblps5Tiempo_MouseUp);
            // 
            // rbLimitado
            // 
            this.rbLimitado.AutoSize = true;
            this.rbLimitado.Location = new System.Drawing.Point(108, 206);
            this.rbLimitado.Name = "rbLimitado";
            this.rbLimitado.Size = new System.Drawing.Size(64, 17);
            this.rbLimitado.TabIndex = 5;
            this.rbLimitado.Text = "Limitado";
            this.rbLimitado.UseVisualStyleBackColor = true;
            this.rbLimitado.CheckedChanged += new System.EventHandler(this.rbps5Limitado_CheckedChanged);
            // 
            // rbLibre
            // 
            this.rbLibre.AutoSize = true;
            this.rbLibre.Checked = true;
            this.rbLibre.Location = new System.Drawing.Point(54, 206);
            this.rbLibre.Name = "rbLibre";
            this.rbLibre.Size = new System.Drawing.Size(48, 17);
            this.rbLibre.TabIndex = 4;
            this.rbLibre.TabStop = true;
            this.rbLibre.Text = "Libre";
            this.rbLibre.UseVisualStyleBackColor = true;
            this.rbLibre.CheckedChanged += new System.EventHandler(this.rbps5Libre_CheckedChanged);
            // 
            // bntIniciar
            // 
            this.bntIniciar.Location = new System.Drawing.Point(34, 170);
            this.bntIniciar.Name = "bntIniciar";
            this.bntIniciar.Size = new System.Drawing.Size(75, 23);
            this.bntIniciar.TabIndex = 3;
            this.bntIniciar.Text = "Iniciar";
            this.bntIniciar.UseVisualStyleBackColor = true;
            this.bntIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(65, 130);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 31);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Bs. 0";
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCronometro.Location = new System.Drawing.Point(39, 98);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(128, 31);
            this.lblCronometro.TabIndex = 1;
            this.lblCronometro.Text = "00:00:00";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(10, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(45, 48);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "5";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlTarifas
            // 
            this.pnlTarifas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlTarifas.Controls.Add(this.rb2M);
            this.pnlTarifas.Controls.Add(this.rb3M);
            this.pnlTarifas.Controls.Add(this.rb4M);
            this.pnlTarifas.Location = new System.Drawing.Point(110, 49);
            this.pnlTarifas.Name = "pnlTarifas";
            this.pnlTarifas.Size = new System.Drawing.Size(161, 40);
            this.pnlTarifas.TabIndex = 4;
            // 
            // rb2M
            // 
            this.rb2M.AutoSize = true;
            this.rb2M.Checked = true;
            this.rb2M.Location = new System.Drawing.Point(15, 11);
            this.rb2M.Name = "rb2M";
            this.rb2M.Size = new System.Drawing.Size(40, 17);
            this.rb2M.TabIndex = 2;
            this.rb2M.TabStop = true;
            this.rb2M.Text = "2M";
            this.rb2M.UseVisualStyleBackColor = true;
            this.rb2M.CheckedChanged += new System.EventHandler(this.rbps52M_CheckedChanged);
            // 
            // rb3M
            // 
            this.rb3M.AutoSize = true;
            this.rb3M.Location = new System.Drawing.Point(61, 11);
            this.rb3M.Name = "rb3M";
            this.rb3M.Size = new System.Drawing.Size(40, 17);
            this.rb3M.TabIndex = 1;
            this.rb3M.Text = "3M";
            this.rb3M.UseVisualStyleBackColor = true;
            this.rb3M.CheckedChanged += new System.EventHandler(this.rbps53M_CheckedChanged);
            // 
            // rb4M
            // 
            this.rb4M.AutoSize = true;
            this.rb4M.Location = new System.Drawing.Point(109, 11);
            this.rb4M.Name = "rb4M";
            this.rb4M.Size = new System.Drawing.Size(40, 17);
            this.rb4M.TabIndex = 0;
            this.rb4M.Text = "4M";
            this.rb4M.UseVisualStyleBackColor = true;
            this.rb4M.CheckedChanged += new System.EventHandler(this.rbps54M_CheckedChanged);
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.Location = new System.Drawing.Point(317, 19);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(85, 25);
            this.lblCaja.TabIndex = 5;
            this.lblCaja.Text = "0.00 Bs";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 542);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.pnlTarifas);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.button1);
            this.Name = "frmPrincipal";
            this.Text = "Cyberplay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlTarifas.ResumeLayout(false);
            this.pnlTarifas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button bntIniciar;
        private System.Windows.Forms.RadioButton rbLibre;
        private System.Windows.Forms.RadioButton rbLimitado;
        private System.Windows.Forms.Label lblTiempoLimite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlTarifas;
        private System.Windows.Forms.RadioButton rb2M;
        private System.Windows.Forms.RadioButton rb3M;
        private System.Windows.Forms.RadioButton rb4M;
        private System.Windows.Forms.Label lblTiempoJugado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Label lblCaja;
    }
}

