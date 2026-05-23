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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tabPreferencias.SuspendLayout();
            this.tbCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPreferencias
            // 
            this.tabPreferencias.Controls.Add(this.tbCategoria);
            this.tabPreferencias.Controls.Add(this.tabPage2);
            this.tabPreferencias.Location = new System.Drawing.Point(107, 24);
            this.tabPreferencias.Name = "tabPreferencias";
            this.tabPreferencias.SelectedIndex = 0;
            this.tabPreferencias.Size = new System.Drawing.Size(434, 293);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPreferencias;
        private System.Windows.Forms.TabPage tbCategoria;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.TextBox tbNombre;
    }
}