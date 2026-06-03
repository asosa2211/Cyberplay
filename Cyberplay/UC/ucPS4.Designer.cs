namespace Cyberplay
{
    partial class ucPS4
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPS4));
            this.pnlTarifas = new System.Windows.Forms.Panel();
            this.rb2M = new System.Windows.Forms.RadioButton();
            this.rb3M = new System.Windows.Forms.RadioButton();
            this.rb4M = new System.Windows.Forms.RadioButton();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.cmsSesion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iniciar1HoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciar30MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aumentar1HoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aumentar30MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVenderProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgregarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.pbNota = new System.Windows.Forms.PictureBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTiempoJugado = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTiempoLimite = new System.Windows.Forms.Label();
            this.rbLimitado = new System.Windows.Forms.RadioButton();
            this.rbLibre = new System.Windows.Forms.RadioButton();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCronometro = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.aumentar5MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTarifas.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.cmsSesion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNota)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTarifas
            // 
            this.pnlTarifas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlTarifas.Controls.Add(this.rb2M);
            this.pnlTarifas.Controls.Add(this.rb3M);
            this.pnlTarifas.Controls.Add(this.rb4M);
            this.pnlTarifas.Location = new System.Drawing.Point(53, -7);
            this.pnlTarifas.Name = "pnlTarifas";
            this.pnlTarifas.Size = new System.Drawing.Size(131, 34);
            this.pnlTarifas.TabIndex = 6;
            // 
            // rb2M
            // 
            this.rb2M.AutoSize = true;
            this.rb2M.Checked = true;
            this.rb2M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2M.Location = new System.Drawing.Point(14, 11);
            this.rb2M.Name = "rb2M";
            this.rb2M.Size = new System.Drawing.Size(40, 17);
            this.rb2M.TabIndex = 2;
            this.rb2M.TabStop = true;
            this.rb2M.Text = "2M";
            this.rb2M.UseVisualStyleBackColor = true;
            this.rb2M.CheckedChanged += new System.EventHandler(this.rb2M_CheckedChanged);
            // 
            // rb3M
            // 
            this.rb3M.AutoSize = true;
            this.rb3M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3M.Location = new System.Drawing.Point(54, 11);
            this.rb3M.Name = "rb3M";
            this.rb3M.Size = new System.Drawing.Size(40, 17);
            this.rb3M.TabIndex = 1;
            this.rb3M.Text = "3M";
            this.rb3M.UseVisualStyleBackColor = true;
            this.rb3M.CheckedChanged += new System.EventHandler(this.rb3M_CheckedChanged);
            // 
            // rb4M
            // 
            this.rb4M.AutoSize = true;
            this.rb4M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4M.Location = new System.Drawing.Point(94, 11);
            this.rb4M.Name = "rb4M";
            this.rb4M.Size = new System.Drawing.Size(40, 17);
            this.rb4M.TabIndex = 0;
            this.rb4M.Text = "4M";
            this.rb4M.UseVisualStyleBackColor = true;
            this.rb4M.CheckedChanged += new System.EventHandler(this.rb4M_CheckedChanged);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.ContextMenuStrip = this.cmsSesion;
            this.pnlPrincipal.Controls.Add(this.pbNota);
            this.pnlPrincipal.Controls.Add(this.pnlTarifas);
            this.pnlPrincipal.Controls.Add(this.btnCobrar);
            this.pnlPrincipal.Controls.Add(this.lblUsuario);
            this.pnlPrincipal.Controls.Add(this.lblTiempoJugado);
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.lblTiempoLimite);
            this.pnlPrincipal.Controls.Add(this.rbLimitado);
            this.pnlPrincipal.Controls.Add(this.rbLibre);
            this.pnlPrincipal.Controls.Add(this.btnIniciar);
            this.pnlPrincipal.Controls.Add(this.lblTotal);
            this.pnlPrincipal.Controls.Add(this.lblCronometro);
            this.pnlPrincipal.Controls.Add(this.lblNombre);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(189, 198);
            this.pnlPrincipal.TabIndex = 5;
            this.pnlPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrincipal_Paint);
            this.pnlPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPrincipal_MouseDown);
            // 
            // cmsSesion
            // 
            this.cmsSesion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciar1HoraToolStripMenuItem,
            this.iniciar30MinToolStripMenuItem,
            this.aumentar1HoraToolStripMenuItem,
            this.aumentar30MinToolStripMenuItem,
            this.aumentar5MinToolStripMenuItem,
            this.tsmiVenderProducto,
            this.mnuAgregarNota});
            this.cmsSesion.Name = "cmsSesion";
            this.cmsSesion.Size = new System.Drawing.Size(188, 158);
            // 
            // iniciar1HoraToolStripMenuItem
            // 
            this.iniciar1HoraToolStripMenuItem.Name = "iniciar1HoraToolStripMenuItem";
            this.iniciar1HoraToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.iniciar1HoraToolStripMenuItem.Text = "Iniciar: 1 hora";
            this.iniciar1HoraToolStripMenuItem.Click += new System.EventHandler(this.iniciar1HoraToolStripMenuItem_Click);
            // 
            // iniciar30MinToolStripMenuItem
            // 
            this.iniciar30MinToolStripMenuItem.Name = "iniciar30MinToolStripMenuItem";
            this.iniciar30MinToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.iniciar30MinToolStripMenuItem.Text = "Iniciar: 30 min";
            this.iniciar30MinToolStripMenuItem.Click += new System.EventHandler(this.iniciar30MinToolStripMenuItem_Click);
            // 
            // aumentar1HoraToolStripMenuItem
            // 
            this.aumentar1HoraToolStripMenuItem.Enabled = false;
            this.aumentar1HoraToolStripMenuItem.Name = "aumentar1HoraToolStripMenuItem";
            this.aumentar1HoraToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.aumentar1HoraToolStripMenuItem.Text = "Aumentar: 1 hora";
            this.aumentar1HoraToolStripMenuItem.Click += new System.EventHandler(this.aumentar1HoraToolStripMenuItem_Click);
            // 
            // aumentar30MinToolStripMenuItem
            // 
            this.aumentar30MinToolStripMenuItem.Enabled = false;
            this.aumentar30MinToolStripMenuItem.Name = "aumentar30MinToolStripMenuItem";
            this.aumentar30MinToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.aumentar30MinToolStripMenuItem.Text = "Aumentar: 30 min";
            this.aumentar30MinToolStripMenuItem.Click += new System.EventHandler(this.aumentar30MinToolStripMenuItem_Click);
            // 
            // tsmiVenderProducto
            // 
            this.tsmiVenderProducto.Name = "tsmiVenderProducto";
            this.tsmiVenderProducto.Size = new System.Drawing.Size(187, 22);
            this.tsmiVenderProducto.Text = "Vender Producto";
            this.tsmiVenderProducto.Click += new System.EventHandler(this.venderProductoToolStripMenuItem_Click);
            // 
            // mnuAgregarNota
            // 
            this.mnuAgregarNota.Name = "mnuAgregarNota";
            this.mnuAgregarNota.Size = new System.Drawing.Size(187, 22);
            this.mnuAgregarNota.Text = "Agregar /  Editar nota";
            this.mnuAgregarNota.Click += new System.EventHandler(this.mnuAgregarNota_Click);
            // 
            // pbNota
            // 
            this.pbNota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNota.Image = ((System.Drawing.Image)(resources.GetObject("pbNota.Image")));
            this.pbNota.Location = new System.Drawing.Point(7, 43);
            this.pbNota.Name = "pbNota";
            this.pbNota.Size = new System.Drawing.Size(30, 34);
            this.pbNota.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNota.TabIndex = 12;
            this.pbNota.TabStop = false;
            this.pbNota.Visible = false;
            this.pbNota.Click += new System.EventHandler(this.pbNota_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Location = new System.Drawing.Point(99, 138);
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
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(61, 68);
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
            this.lblTiempoJugado.Location = new System.Drawing.Point(63, 51);
            this.lblTiempoJugado.Name = "lblTiempoJugado";
            this.lblTiempoJugado.Size = new System.Drawing.Size(72, 17);
            this.lblTiempoJugado.TabIndex = 9;
            this.lblTiempoJugado.Text = "00:00:00";
            this.lblTiempoJugado.Click += new System.EventHandler(this.lblTiempoJugado_Click);
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
            this.lblTiempoLimite.ForeColor = System.Drawing.Color.Blue;
            this.lblTiempoLimite.Location = new System.Drawing.Point(52, 34);
            this.lblTiempoLimite.Name = "lblTiempoLimite";
            this.lblTiempoLimite.Size = new System.Drawing.Size(84, 17);
            this.lblTiempoLimite.TabIndex = 7;
            this.lblTiempoLimite.Text = "ILIMITADO";
            this.lblTiempoLimite.Click += new System.EventHandler(this.lblTiempoLimite_Click);
            // 
            // rbLimitado
            // 
            this.rbLimitado.AutoSize = true;
            this.rbLimitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLimitado.Location = new System.Drawing.Point(96, 167);
            this.rbLimitado.Name = "rbLimitado";
            this.rbLimitado.Size = new System.Drawing.Size(64, 17);
            this.rbLimitado.TabIndex = 5;
            this.rbLimitado.Text = "Limitado";
            this.rbLimitado.UseVisualStyleBackColor = true;
            this.rbLimitado.CheckedChanged += new System.EventHandler(this.rbLimitado_CheckedChanged);
            this.rbLimitado.Click += new System.EventHandler(this.rbLimitado_Click);
            // 
            // rbLibre
            // 
            this.rbLibre.AutoSize = true;
            this.rbLibre.Checked = true;
            this.rbLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLibre.Location = new System.Drawing.Point(39, 167);
            this.rbLibre.Name = "rbLibre";
            this.rbLibre.Size = new System.Drawing.Size(48, 17);
            this.rbLibre.TabIndex = 4;
            this.rbLibre.TabStop = true;
            this.rbLibre.Text = "Libre";
            this.rbLibre.UseVisualStyleBackColor = true;
            this.rbLibre.CheckedChanged += new System.EventHandler(this.rbLibre_CheckedChanged);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(17, 138);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.bntIniciar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(54, 110);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(79, 25);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Bs. 0,0";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCronometro.Location = new System.Drawing.Point(46, 87);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(98, 25);
            this.lblCronometro.TabIndex = 1;
            this.lblCronometro.Text = "00:00:00";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(2, 2);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(32, 33);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "5";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            this.lblNombre.DoubleClick += new System.EventHandler(this.lblNombre_DoubleClick);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // aumentar5MinToolStripMenuItem
            // 
            this.aumentar5MinToolStripMenuItem.Enabled = false;
            this.aumentar5MinToolStripMenuItem.Name = "aumentar5MinToolStripMenuItem";
            this.aumentar5MinToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.aumentar5MinToolStripMenuItem.Text = "Aumentar: 5 min";
            this.aumentar5MinToolStripMenuItem.Click += new System.EventHandler(this.aumentar5MinToolStripMenuItem_Click);
            // 
            // ucPS4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "ucPS4";
            this.Size = new System.Drawing.Size(189, 198);
            this.Load += new System.EventHandler(this.ucPS4_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucPS4_MouseDown);
            this.pnlTarifas.ResumeLayout(false);
            this.pnlTarifas.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.cmsSesion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTarifas;
        private System.Windows.Forms.RadioButton rb2M;
        private System.Windows.Forms.RadioButton rb3M;
        private System.Windows.Forms.RadioButton rb4M;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblTiempoJugado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTiempoLimite;
        private System.Windows.Forms.RadioButton rbLimitado;
        private System.Windows.Forms.RadioButton rbLibre;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip cmsSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmiVenderProducto;
        private System.Windows.Forms.ToolStripMenuItem iniciar1HoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciar30MinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aumentar1HoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aumentar30MinToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbNota;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAgregarNota;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolStripMenuItem aumentar5MinToolStripMenuItem;
    }
}
