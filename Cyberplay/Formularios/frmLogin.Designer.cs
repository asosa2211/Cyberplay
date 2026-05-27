namespace Cyberplay.Formularios
{
    partial class frmLogin
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
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.cbCajeros = new System.Windows.Forms.ComboBox();
            this.lblCajeroLogin = new System.Windows.Forms.Label();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(147, 95);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(121, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(117, 152);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // cbCajeros
            // 
            this.cbCajeros.FormattingEnabled = true;
            this.cbCajeros.Location = new System.Drawing.Point(147, 51);
            this.cbCajeros.Name = "cbCajeros";
            this.cbCajeros.Size = new System.Drawing.Size(121, 21);
            this.cbCajeros.TabIndex = 4;
            // 
            // lblCajeroLogin
            // 
            this.lblCajeroLogin.AutoSize = true;
            this.lblCajeroLogin.Location = new System.Drawing.Point(57, 51);
            this.lblCajeroLogin.Name = "lblCajeroLogin";
            this.lblCajeroLogin.Size = new System.Drawing.Size(37, 13);
            this.lblCajeroLogin.TabIndex = 5;
            this.lblCajeroLogin.Text = "Cajero";
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Location = new System.Drawing.Point(57, 95);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(61, 13);
            this.lblLoginPassword.TabIndex = 6;
            this.lblLoginPassword.Text = "Contraseña";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 213);
            this.Controls.Add(this.lblLoginPassword);
            this.Controls.Add(this.lblCajeroLogin);
            this.Controls.Add(this.cbCajeros);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.tbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Text = "Cyberplay Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ComboBox cbCajeros;
        private System.Windows.Forms.Label lblCajeroLogin;
        private System.Windows.Forms.Label lblLoginPassword;
    }
}