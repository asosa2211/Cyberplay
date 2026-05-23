namespace Cyberplay.Formularios
{
    partial class frmPreferencias
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
            this.tabPreferencias = new System.Windows.Forms.TabControl();
            this.tbCategoria = new System.Windows.Forms.TabPage();
            this.TipoEquipos = new System.Windows.Forms.TabPage();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.dgvTiposEquipo = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colM3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colM4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNombreEquipo = new System.Windows.Forms.TextBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.nudLibre = new System.Windows.Forms.NumericUpDown();
            this.cbMultijugador = new System.Windows.Forms.CheckBox();
            this.nudM2 = new System.Windows.Forms.NumericUpDown();
            this.nudM3 = new System.Windows.Forms.NumericUpDown();
            this.nudM4 = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarTipoEquipo = new System.Windows.Forms.Button();
            this.tabPreferencias.SuspendLayout();
            this.tbCategoria.SuspendLayout();
            this.TipoEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposEquipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLibre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPreferencias
            // 
            this.tabPreferencias.Controls.Add(this.tbCategoria);
            this.tabPreferencias.Controls.Add(this.TipoEquipos);
            this.tabPreferencias.Location = new System.Drawing.Point(32, 24);
            this.tabPreferencias.Name = "tabPreferencias";
            this.tabPreferencias.SelectedIndex = 0;
            this.tabPreferencias.Size = new System.Drawing.Size(740, 335);
            this.tabPreferencias.TabIndex = 0;
            // 
            // tbCategoria
            // 
            this.tbCategoria.Controls.Add(this.tbNombre);
            this.tbCategoria.Controls.Add(this.dgvCategorias);
            this.tbCategoria.Controls.Add(this.btnEliminarCategoria);
            this.tbCategoria.Controls.Add(this.btnAgregarCategoria);
            this.tbCategoria.Location = new System.Drawing.Point(4, 22);
            this.tbCategoria.Name = "tbCategoria";
            this.tbCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tbCategoria.Size = new System.Drawing.Size(426, 267);
            this.tbCategoria.TabIndex = 0;
            this.tbCategoria.Text = "Categorias";
            this.tbCategoria.UseVisualStyleBackColor = true;
            // 
            // TipoEquipos
            // 
            this.TipoEquipos.Controls.Add(this.btnAgregarTipoEquipo);
            this.TipoEquipos.Controls.Add(this.nudM4);
            this.TipoEquipos.Controls.Add(this.nudM3);
            this.TipoEquipos.Controls.Add(this.nudM2);
            this.TipoEquipos.Controls.Add(this.cbMultijugador);
            this.TipoEquipos.Controls.Add(this.nudLibre);
            this.TipoEquipos.Controls.Add(this.nudCantidad);
            this.TipoEquipos.Controls.Add(this.tbNombreEquipo);
            this.TipoEquipos.Controls.Add(this.dgvTiposEquipo);
            this.TipoEquipos.Location = new System.Drawing.Point(4, 22);
            this.TipoEquipos.Name = "TipoEquipos";
            this.TipoEquipos.Padding = new System.Windows.Forms.Padding(3);
            this.TipoEquipos.Size = new System.Drawing.Size(732, 309);
            this.TipoEquipos.TabIndex = 1;
            this.TipoEquipos.Text = "Tipo Equipos";
            this.TipoEquipos.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(152, 28);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCategoria.TabIndex = 0;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Location = new System.Drawing.Point(233, 28);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCategoria.TabIndex = 1;
            this.btnEliminarCategoria.Text = "Eliminar";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoria});
            this.dgvCategorias.Location = new System.Drawing.Point(43, 66);
            this.dgvCategorias.MultiSelect = false;
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(240, 150);
            this.dgvCategorias.TabIndex = 2;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(43, 31);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(100, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // dgvTiposEquipo
            // 
            this.dgvTiposEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiposEquipo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colCantidad,
            this.colLibre,
            this.colMulti,
            this.colM2,
            this.colM3,
            this.colM4});
            this.dgvTiposEquipo.Location = new System.Drawing.Point(6, 153);
            this.dgvTiposEquipo.Name = "dgvTiposEquipo";
            this.dgvTiposEquipo.Size = new System.Drawing.Size(720, 150);
            this.dgvTiposEquipo.TabIndex = 0;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colLibre
            // 
            this.colLibre.HeaderText = "Libre";
            this.colLibre.Name = "colLibre";
            // 
            // colMulti
            // 
            this.colMulti.HeaderText = "Multijugador";
            this.colMulti.Name = "colMulti";
            // 
            // colM2
            // 
            this.colM2.HeaderText = "M2";
            this.colM2.Name = "colM2";
            // 
            // colM3
            // 
            this.colM3.HeaderText = "M3";
            this.colM3.Name = "colM3";
            // 
            // colM4
            // 
            this.colM4.HeaderText = "M4";
            this.colM4.Name = "colM4";
            // 
            // tbNombreEquipo
            // 
            this.tbNombreEquipo.Location = new System.Drawing.Point(56, 58);
            this.tbNombreEquipo.Name = "tbNombreEquipo";
            this.tbNombreEquipo.Size = new System.Drawing.Size(100, 20);
            this.tbNombreEquipo.TabIndex = 1;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(184, 57);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(60, 20);
            this.nudCantidad.TabIndex = 2;
            // 
            // nudLibre
            // 
            this.nudLibre.Location = new System.Drawing.Point(265, 57);
            this.nudLibre.Name = "nudLibre";
            this.nudLibre.Size = new System.Drawing.Size(67, 20);
            this.nudLibre.TabIndex = 3;
            // 
            // cbMultijugador
            // 
            this.cbMultijugador.AutoSize = true;
            this.cbMultijugador.Location = new System.Drawing.Point(357, 60);
            this.cbMultijugador.Name = "cbMultijugador";
            this.cbMultijugador.Size = new System.Drawing.Size(83, 17);
            this.cbMultijugador.TabIndex = 4;
            this.cbMultijugador.Text = "Multijugador";
            this.cbMultijugador.UseVisualStyleBackColor = true;
            this.cbMultijugador.CheckedChanged += new System.EventHandler(this.cbMultijugador_CheckedChanged);
            // 
            // nudM2
            // 
            this.nudM2.Location = new System.Drawing.Point(447, 57);
            this.nudM2.Name = "nudM2";
            this.nudM2.Size = new System.Drawing.Size(54, 20);
            this.nudM2.TabIndex = 5;
            // 
            // nudM3
            // 
            this.nudM3.Location = new System.Drawing.Point(522, 57);
            this.nudM3.Name = "nudM3";
            this.nudM3.Size = new System.Drawing.Size(57, 20);
            this.nudM3.TabIndex = 6;
            // 
            // nudM4
            // 
            this.nudM4.Location = new System.Drawing.Point(602, 57);
            this.nudM4.Name = "nudM4";
            this.nudM4.Size = new System.Drawing.Size(54, 20);
            this.nudM4.TabIndex = 7;
            // 
            // btnAgregarTipoEquipo
            // 
            this.btnAgregarTipoEquipo.Location = new System.Drawing.Point(56, 97);
            this.btnAgregarTipoEquipo.Name = "btnAgregarTipoEquipo";
            this.btnAgregarTipoEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTipoEquipo.TabIndex = 8;
            this.btnAgregarTipoEquipo.Text = "Agregar";
            this.btnAgregarTipoEquipo.UseVisualStyleBackColor = true;
            this.btnAgregarTipoEquipo.Click += new System.EventHandler(this.btnAgregarTipoEquipo_Click);
            // 
            // frmPreferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabPreferencias);
            this.Name = "frmPreferencias";
            this.Text = "frmPreferencias";
            this.tabPreferencias.ResumeLayout(false);
            this.tbCategoria.ResumeLayout(false);
            this.tbCategoria.PerformLayout();
            this.TipoEquipos.ResumeLayout(false);
            this.TipoEquipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposEquipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLibre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPreferencias;
        private System.Windows.Forms.TabPage tbCategoria;
        private System.Windows.Forms.TabPage TipoEquipos;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.DataGridView dgvTiposEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colM3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colM4;
        private System.Windows.Forms.Button btnAgregarTipoEquipo;
        private System.Windows.Forms.NumericUpDown nudM4;
        private System.Windows.Forms.NumericUpDown nudM3;
        private System.Windows.Forms.NumericUpDown nudM2;
        private System.Windows.Forms.CheckBox cbMultijugador;
        private System.Windows.Forms.NumericUpDown nudLibre;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox tbNombreEquipo;
    }
}