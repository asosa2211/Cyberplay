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
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarCategoria = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.TipoEquipos = new System.Windows.Forms.TabPage();
            this.lblCiclos = new System.Windows.Forms.Label();
            this.lbl4M = new System.Windows.Forms.Label();
            this.lbl3M = new System.Windows.Forms.Label();
            this.lbl2M = new System.Windows.Forms.Label();
            this.lblTarifasMultijugador = new System.Windows.Forms.Label();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblNombreTipo = new System.Windows.Forms.Label();
            this.btnEliminarTipoEquipo = new System.Windows.Forms.Button();
            this.btnEditarTipoEquipo = new System.Windows.Forms.Button();
            this.btnAgregarTipoEquipo = new System.Windows.Forms.Button();
            this.nudM4 = new System.Windows.Forms.NumericUpDown();
            this.nudM3 = new System.Windows.Forms.NumericUpDown();
            this.nudM2 = new System.Windows.Forms.NumericUpDown();
            this.nudCiclos = new System.Windows.Forms.NumericUpDown();
            this.cbMultijugador = new System.Windows.Forms.CheckBox();
            this.nudLibre = new System.Windows.Forms.NumericUpDown();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.tbNombreEquipo = new System.Windows.Forms.TextBox();
            this.dgvTiposEquipo = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiclos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoCiclo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colM3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colM4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTolerancia = new System.Windows.Forms.TabPage();
            this.bntGuardarTolerancia = new System.Windows.Forms.Button();
            this.nudTolerancia = new System.Windows.Forms.NumericUpDown();
            this.lblTolerancia = new System.Windows.Forms.Label();
            this.tabEstaciones = new System.Windows.Forms.TabPage();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.lblTotalEstaciones = new System.Windows.Forms.Label();
            this.nudTotalEstaciones = new System.Windows.Forms.NumericUpDown();
            this.lblInicioEstaciones = new System.Windows.Forms.Label();
            this.nudInicioEstaciones = new System.Windows.Forms.NumericUpDown();
            this.btnAplicarTotalEstaciones = new System.Windows.Forms.Button();
            this.lblNumeroEstacion = new System.Windows.Forms.Label();
            this.nudNumeroEstacion = new System.Windows.Forms.NumericUpDown();
            this.lblTipoEstacion = new System.Windows.Forms.Label();
            this.cbTipoEstacion = new System.Windows.Forms.ComboBox();
            this.btnAsignarTipoEstacion = new System.Windows.Forms.Button();
            this.dgvEstaciones = new System.Windows.Forms.DataGridView();
            this.colNumeroEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coDireccionIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMonitoreo = new System.Windows.Forms.Label();
            this.nudMonitor = new System.Windows.Forms.NumericUpDown();
            this.tabPreferencias.SuspendLayout();
            this.tbCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.TipoEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudM4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCiclos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLibre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposEquipo)).BeginInit();
            this.tabTolerancia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTolerancia)).BeginInit();
            this.tabEstaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalEstaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInicioEstaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroEstacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPreferencias
            // 
            this.tabPreferencias.Controls.Add(this.tbCategoria);
            this.tabPreferencias.Controls.Add(this.TipoEquipos);
            this.tabPreferencias.Controls.Add(this.tabTolerancia);
            this.tabPreferencias.Controls.Add(this.tabEstaciones);
            this.tabPreferencias.Location = new System.Drawing.Point(32, 24);
            this.tabPreferencias.Name = "tabPreferencias";
            this.tabPreferencias.SelectedIndex = 0;
            this.tabPreferencias.Size = new System.Drawing.Size(756, 342);
            this.tabPreferencias.TabIndex = 0;
            // 
            // tbCategoria
            // 
            this.tbCategoria.Controls.Add(this.lblNombreCategoria);
            this.tbCategoria.Controls.Add(this.tbNombre);
            this.tbCategoria.Controls.Add(this.dgvCategorias);
            this.tbCategoria.Controls.Add(this.btnEliminarCategoria);
            this.tbCategoria.Controls.Add(this.btnAgregarCategoria);
            this.tbCategoria.Location = new System.Drawing.Point(4, 22);
            this.tbCategoria.Name = "tbCategoria";
            this.tbCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tbCategoria.Size = new System.Drawing.Size(748, 316);
            this.tbCategoria.TabIndex = 0;
            this.tbCategoria.Text = "Categorias";
            this.tbCategoria.UseVisualStyleBackColor = true;
            // 
            // lblNombreCategoria
            // 
            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Location = new System.Drawing.Point(461, 79);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Size = new System.Drawing.Size(86, 13);
            this.lblNombreCategoria.TabIndex = 4;
            this.lblNombreCategoria.Text = "Nueva categoria";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(455, 99);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(100, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategoria});
            this.dgvCategorias.Location = new System.Drawing.Point(56, 66);
            this.dgvCategorias.MultiSelect = false;
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(191, 204);
            this.dgvCategorias.TabIndex = 2;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.Width = 180;
            // 
            // btnEliminarCategoria
            // 
            this.btnEliminarCategoria.Location = new System.Drawing.Point(276, 140);
            this.btnEliminarCategoria.Name = "btnEliminarCategoria";
            this.btnEliminarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarCategoria.TabIndex = 1;
            this.btnEliminarCategoria.Text = "Eliminar";
            this.btnEliminarCategoria.UseVisualStyleBackColor = true;
            this.btnEliminarCategoria.Click += new System.EventHandler(this.btnEliminarCategoria_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(470, 140);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCategoria.TabIndex = 0;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // TipoEquipos
            // 
            this.TipoEquipos.Controls.Add(this.lblCiclos);
            this.TipoEquipos.Controls.Add(this.lbl4M);
            this.TipoEquipos.Controls.Add(this.lbl3M);
            this.TipoEquipos.Controls.Add(this.lbl2M);
            this.TipoEquipos.Controls.Add(this.lblTarifasMultijugador);
            this.TipoEquipos.Controls.Add(this.lblTarifa);
            this.TipoEquipos.Controls.Add(this.lblCantidad);
            this.TipoEquipos.Controls.Add(this.lblNombreTipo);
            this.TipoEquipos.Controls.Add(this.btnEliminarTipoEquipo);
            this.TipoEquipos.Controls.Add(this.btnEditarTipoEquipo);
            this.TipoEquipos.Controls.Add(this.btnAgregarTipoEquipo);
            this.TipoEquipos.Controls.Add(this.nudM4);
            this.TipoEquipos.Controls.Add(this.nudM3);
            this.TipoEquipos.Controls.Add(this.nudM2);
            this.TipoEquipos.Controls.Add(this.nudCiclos);
            this.TipoEquipos.Controls.Add(this.cbMultijugador);
            this.TipoEquipos.Controls.Add(this.nudLibre);
            this.TipoEquipos.Controls.Add(this.nudCantidad);
            this.TipoEquipos.Controls.Add(this.tbNombreEquipo);
            this.TipoEquipos.Controls.Add(this.dgvTiposEquipo);
            this.TipoEquipos.Location = new System.Drawing.Point(4, 22);
            this.TipoEquipos.Name = "TipoEquipos";
            this.TipoEquipos.Padding = new System.Windows.Forms.Padding(3);
            this.TipoEquipos.Size = new System.Drawing.Size(748, 316);
            this.TipoEquipos.TabIndex = 1;
            this.TipoEquipos.Text = "Tipo Equipos";
            this.TipoEquipos.UseVisualStyleBackColor = true;
            // 
            // lblCiclos
            // 
            this.lblCiclos.AutoSize = true;
            this.lblCiclos.Location = new System.Drawing.Point(658, 45);
            this.lblCiclos.Name = "lblCiclos";
            this.lblCiclos.Size = new System.Drawing.Size(35, 13);
            this.lblCiclos.TabIndex = 19;
            this.lblCiclos.Text = "Ciclos";
            // 
            // lbl4M
            // 
            this.lbl4M.AutoSize = true;
            this.lbl4M.Location = new System.Drawing.Point(593, 46);
            this.lbl4M.Name = "lbl4M";
            this.lbl4M.Size = new System.Drawing.Size(22, 13);
            this.lbl4M.TabIndex = 18;
            this.lbl4M.Text = "4M";
            // 
            // lbl3M
            // 
            this.lbl3M.AutoSize = true;
            this.lbl3M.Location = new System.Drawing.Point(510, 48);
            this.lbl3M.Name = "lbl3M";
            this.lbl3M.Size = new System.Drawing.Size(22, 13);
            this.lbl3M.TabIndex = 17;
            this.lbl3M.Text = "3M";
            // 
            // lbl2M
            // 
            this.lbl2M.AutoSize = true;
            this.lbl2M.Location = new System.Drawing.Point(438, 46);
            this.lbl2M.Name = "lbl2M";
            this.lbl2M.Size = new System.Drawing.Size(22, 13);
            this.lbl2M.TabIndex = 16;
            this.lbl2M.Text = "2M";
            // 
            // lblTarifasMultijugador
            // 
            this.lblTarifasMultijugador.AutoSize = true;
            this.lblTarifasMultijugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifasMultijugador.Location = new System.Drawing.Point(507, 17);
            this.lblTarifasMultijugador.Name = "lblTarifasMultijugador";
            this.lblTarifasMultijugador.Size = new System.Drawing.Size(160, 13);
            this.lblTarifasMultijugador.TabIndex = 15;
            this.lblTarifasMultijugador.Text = "TARIFAS MULTIJUGADOR";
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Location = new System.Drawing.Point(254, 46);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(34, 13);
            this.lblTarifa.TabIndex = 14;
            this.lblTarifa.Text = "Tarifa";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(175, 45);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 13;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblNombreTipo
            // 
            this.lblNombreTipo.AutoSize = true;
            this.lblNombreTipo.Location = new System.Drawing.Point(49, 46);
            this.lblNombreTipo.Name = "lblNombreTipo";
            this.lblNombreTipo.Size = new System.Drawing.Size(44, 13);
            this.lblNombreTipo.TabIndex = 12;
            this.lblNombreTipo.Text = "Nombre";
            // 
            // btnEliminarTipoEquipo
            // 
            this.btnEliminarTipoEquipo.Location = new System.Drawing.Point(435, 104);
            this.btnEliminarTipoEquipo.Name = "btnEliminarTipoEquipo";
            this.btnEliminarTipoEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTipoEquipo.TabIndex = 10;
            this.btnEliminarTipoEquipo.Text = "Eliminar";
            this.btnEliminarTipoEquipo.UseVisualStyleBackColor = true;
            this.btnEliminarTipoEquipo.Click += new System.EventHandler(this.btnEliminarTipoEquipo_Click);
            // 
            // btnEditarTipoEquipo
            // 
            this.btnEditarTipoEquipo.Location = new System.Drawing.Point(334, 104);
            this.btnEditarTipoEquipo.Name = "btnEditarTipoEquipo";
            this.btnEditarTipoEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnEditarTipoEquipo.TabIndex = 9;
            this.btnEditarTipoEquipo.Text = "Editar";
            this.btnEditarTipoEquipo.UseVisualStyleBackColor = true;
            this.btnEditarTipoEquipo.Click += new System.EventHandler(this.btnEditarTipoEquipo_Click);
            // 
            // btnAgregarTipoEquipo
            // 
            this.btnAgregarTipoEquipo.Location = new System.Drawing.Point(234, 105);
            this.btnAgregarTipoEquipo.Name = "btnAgregarTipoEquipo";
            this.btnAgregarTipoEquipo.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTipoEquipo.TabIndex = 8;
            this.btnAgregarTipoEquipo.Text = "Agregar";
            this.btnAgregarTipoEquipo.UseVisualStyleBackColor = true;
            this.btnAgregarTipoEquipo.Click += new System.EventHandler(this.btnAgregarTipoEquipo_Click);
            // 
            // nudM4
            // 
            this.nudM4.Location = new System.Drawing.Point(593, 64);
            this.nudM4.Name = "nudM4";
            this.nudM4.Size = new System.Drawing.Size(54, 20);
            this.nudM4.TabIndex = 7;
            // 
            // nudM3
            // 
            this.nudM3.Location = new System.Drawing.Point(513, 64);
            this.nudM3.Name = "nudM3";
            this.nudM3.Size = new System.Drawing.Size(57, 20);
            this.nudM3.TabIndex = 6;
            // 
            // nudM2
            // 
            this.nudM2.Location = new System.Drawing.Point(438, 64);
            this.nudM2.Name = "nudM2";
            this.nudM2.Size = new System.Drawing.Size(54, 20);
            this.nudM2.TabIndex = 5;
            // 
            // nudCiclos
            // 
            this.nudCiclos.Location = new System.Drawing.Point(658, 64);
            this.nudCiclos.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudCiclos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCiclos.Name = "nudCiclos";
            this.nudCiclos.Size = new System.Drawing.Size(54, 20);
            this.nudCiclos.TabIndex = 11;
            this.nudCiclos.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // cbMultijugador
            // 
            this.cbMultijugador.AutoSize = true;
            this.cbMultijugador.Location = new System.Drawing.Point(348, 67);
            this.cbMultijugador.Name = "cbMultijugador";
            this.cbMultijugador.Size = new System.Drawing.Size(83, 17);
            this.cbMultijugador.TabIndex = 4;
            this.cbMultijugador.Text = "Multijugador";
            this.cbMultijugador.UseVisualStyleBackColor = true;
            this.cbMultijugador.CheckedChanged += new System.EventHandler(this.cbMultijugador_CheckedChanged);
            // 
            // nudLibre
            // 
            this.nudLibre.Location = new System.Drawing.Point(256, 64);
            this.nudLibre.Name = "nudLibre";
            this.nudLibre.Size = new System.Drawing.Size(67, 20);
            this.nudLibre.TabIndex = 3;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(175, 64);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(60, 20);
            this.nudCantidad.TabIndex = 2;
            // 
            // tbNombreEquipo
            // 
            this.tbNombreEquipo.Location = new System.Drawing.Point(47, 65);
            this.tbNombreEquipo.Name = "tbNombreEquipo";
            this.tbNombreEquipo.Size = new System.Drawing.Size(100, 20);
            this.tbNombreEquipo.TabIndex = 1;
            // 
            // dgvTiposEquipo
            // 
            this.dgvTiposEquipo.AllowUserToAddRows = false;
            this.dgvTiposEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiposEquipo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colCantidad,
            this.colLibre,
            this.colCiclos,
            this.colCostoCiclo,
            this.colMulti,
            this.colM2,
            this.colM3,
            this.colM4});
            this.dgvTiposEquipo.Location = new System.Drawing.Point(55, 144);
            this.dgvTiposEquipo.MultiSelect = false;
            this.dgvTiposEquipo.Name = "dgvTiposEquipo";
            this.dgvTiposEquipo.ReadOnly = true;
            this.dgvTiposEquipo.RowHeadersVisible = false;
            this.dgvTiposEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTiposEquipo.Size = new System.Drawing.Size(620, 150);
            this.dgvTiposEquipo.TabIndex = 0;
            this.dgvTiposEquipo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiposEquipo_CellClick);
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 80;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 60;
            // 
            // colLibre
            // 
            this.colLibre.HeaderText = "Tarifa";
            this.colLibre.Name = "colLibre";
            this.colLibre.ReadOnly = true;
            this.colLibre.Width = 50;
            // 
            // colCiclos
            // 
            this.colCiclos.HeaderText = "Ciclos";
            this.colCiclos.Name = "colCiclos";
            this.colCiclos.ReadOnly = true;
            this.colCiclos.Width = 50;
            // 
            // colCostoCiclo
            // 
            this.colCostoCiclo.HeaderText = "Costo ciclo";
            this.colCostoCiclo.Name = "colCostoCiclo";
            this.colCostoCiclo.ReadOnly = true;
            this.colCostoCiclo.Width = 150;
            // 
            // colMulti
            // 
            this.colMulti.HeaderText = "Multijugador";
            this.colMulti.Name = "colMulti";
            this.colMulti.ReadOnly = true;
            // 
            // colM2
            // 
            this.colM2.HeaderText = "M2";
            this.colM2.Name = "colM2";
            this.colM2.ReadOnly = true;
            this.colM2.Width = 40;
            // 
            // colM3
            // 
            this.colM3.HeaderText = "M3";
            this.colM3.Name = "colM3";
            this.colM3.ReadOnly = true;
            this.colM3.Width = 40;
            // 
            // colM4
            // 
            this.colM4.HeaderText = "M4";
            this.colM4.Name = "colM4";
            this.colM4.ReadOnly = true;
            this.colM4.Width = 40;
            // 
            // tabTolerancia
            // 
            this.tabTolerancia.Controls.Add(this.nudMonitor);
            this.tabTolerancia.Controls.Add(this.lblMonitoreo);
            this.tabTolerancia.Controls.Add(this.bntGuardarTolerancia);
            this.tabTolerancia.Controls.Add(this.nudTolerancia);
            this.tabTolerancia.Controls.Add(this.lblTolerancia);
            this.tabTolerancia.Location = new System.Drawing.Point(4, 22);
            this.tabTolerancia.Name = "tabTolerancia";
            this.tabTolerancia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTolerancia.Size = new System.Drawing.Size(748, 316);
            this.tabTolerancia.TabIndex = 2;
            this.tabTolerancia.Text = "Tolerancia";
            this.tabTolerancia.UseVisualStyleBackColor = true;
            // 
            // bntGuardarTolerancia
            // 
            this.bntGuardarTolerancia.Location = new System.Drawing.Point(121, 126);
            this.bntGuardarTolerancia.Name = "bntGuardarTolerancia";
            this.bntGuardarTolerancia.Size = new System.Drawing.Size(75, 23);
            this.bntGuardarTolerancia.TabIndex = 2;
            this.bntGuardarTolerancia.Text = "Guardar";
            this.bntGuardarTolerancia.UseVisualStyleBackColor = true;
            this.bntGuardarTolerancia.Click += new System.EventHandler(this.bntGuardarTolerancia_Click);
            // 
            // nudTolerancia
            // 
            this.nudTolerancia.Location = new System.Drawing.Point(170, 37);
            this.nudTolerancia.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudTolerancia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTolerancia.Name = "nudTolerancia";
            this.nudTolerancia.Size = new System.Drawing.Size(65, 20);
            this.nudTolerancia.TabIndex = 1;
            this.nudTolerancia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTolerancia
            // 
            this.lblTolerancia.AutoSize = true;
            this.lblTolerancia.Location = new System.Drawing.Point(52, 39);
            this.lblTolerancia.Name = "lblTolerancia";
            this.lblTolerancia.Size = new System.Drawing.Size(99, 13);
            this.lblTolerancia.TabIndex = 0;
            this.lblTolerancia.Text = "Minutos tolerancia: ";
            // 
            // tabEstaciones
            // 
            this.tabEstaciones.Controls.Add(this.tbIP);
            this.tabEstaciones.Controls.Add(this.lblTotalEstaciones);
            this.tabEstaciones.Controls.Add(this.nudTotalEstaciones);
            this.tabEstaciones.Controls.Add(this.lblInicioEstaciones);
            this.tabEstaciones.Controls.Add(this.nudInicioEstaciones);
            this.tabEstaciones.Controls.Add(this.btnAplicarTotalEstaciones);
            this.tabEstaciones.Controls.Add(this.lblNumeroEstacion);
            this.tabEstaciones.Controls.Add(this.nudNumeroEstacion);
            this.tabEstaciones.Controls.Add(this.lblTipoEstacion);
            this.tabEstaciones.Controls.Add(this.cbTipoEstacion);
            this.tabEstaciones.Controls.Add(this.btnAsignarTipoEstacion);
            this.tabEstaciones.Controls.Add(this.dgvEstaciones);
            this.tabEstaciones.Location = new System.Drawing.Point(4, 22);
            this.tabEstaciones.Name = "tabEstaciones";
            this.tabEstaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstaciones.Size = new System.Drawing.Size(748, 316);
            this.tabEstaciones.TabIndex = 3;
            this.tabEstaciones.Text = "Estaciones";
            this.tabEstaciones.UseVisualStyleBackColor = true;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(528, 7);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 11;
            // 
            // lblTotalEstaciones
            // 
            this.lblTotalEstaciones.AutoSize = true;
            this.lblTotalEstaciones.Location = new System.Drawing.Point(35, 24);
            this.lblTotalEstaciones.Name = "lblTotalEstaciones";
            this.lblTotalEstaciones.Size = new System.Drawing.Size(71, 13);
            this.lblTotalEstaciones.TabIndex = 0;
            this.lblTotalEstaciones.Text = "Total equipos";
            // 
            // nudTotalEstaciones
            // 
            this.nudTotalEstaciones.Location = new System.Drawing.Point(35, 44);
            this.nudTotalEstaciones.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTotalEstaciones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTotalEstaciones.Name = "nudTotalEstaciones";
            this.nudTotalEstaciones.Size = new System.Drawing.Size(80, 20);
            this.nudTotalEstaciones.TabIndex = 1;
            this.nudTotalEstaciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInicioEstaciones
            // 
            this.lblInicioEstaciones.AutoSize = true;
            this.lblInicioEstaciones.Location = new System.Drawing.Point(130, 24);
            this.lblInicioEstaciones.Name = "lblInicioEstaciones";
            this.lblInicioEstaciones.Size = new System.Drawing.Size(50, 13);
            this.lblInicioEstaciones.TabIndex = 2;
            this.lblInicioEstaciones.Text = "Iniciar en";
            // 
            // nudInicioEstaciones
            // 
            this.nudInicioEstaciones.Location = new System.Drawing.Point(130, 44);
            this.nudInicioEstaciones.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudInicioEstaciones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInicioEstaciones.Name = "nudInicioEstaciones";
            this.nudInicioEstaciones.Size = new System.Drawing.Size(80, 20);
            this.nudInicioEstaciones.TabIndex = 3;
            this.nudInicioEstaciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAplicarTotalEstaciones
            // 
            this.btnAplicarTotalEstaciones.Location = new System.Drawing.Point(225, 42);
            this.btnAplicarTotalEstaciones.Name = "btnAplicarTotalEstaciones";
            this.btnAplicarTotalEstaciones.Size = new System.Drawing.Size(75, 23);
            this.btnAplicarTotalEstaciones.TabIndex = 4;
            this.btnAplicarTotalEstaciones.Text = "Aplicar";
            this.btnAplicarTotalEstaciones.UseVisualStyleBackColor = true;
            this.btnAplicarTotalEstaciones.Click += new System.EventHandler(this.btnAplicarTotalEstaciones_Click);
            // 
            // lblNumeroEstacion
            // 
            this.lblNumeroEstacion.AutoSize = true;
            this.lblNumeroEstacion.Location = new System.Drawing.Point(335, 24);
            this.lblNumeroEstacion.Name = "lblNumeroEstacion";
            this.lblNumeroEstacion.Size = new System.Drawing.Size(40, 13);
            this.lblNumeroEstacion.TabIndex = 5;
            this.lblNumeroEstacion.Text = "Equipo";
            // 
            // nudNumeroEstacion
            // 
            this.nudNumeroEstacion.Location = new System.Drawing.Point(335, 44);
            this.nudNumeroEstacion.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNumeroEstacion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroEstacion.Name = "nudNumeroEstacion";
            this.nudNumeroEstacion.Size = new System.Drawing.Size(80, 20);
            this.nudNumeroEstacion.TabIndex = 6;
            this.nudNumeroEstacion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTipoEstacion
            // 
            this.lblTipoEstacion.AutoSize = true;
            this.lblTipoEstacion.Location = new System.Drawing.Point(435, 24);
            this.lblTipoEstacion.Name = "lblTipoEstacion";
            this.lblTipoEstacion.Size = new System.Drawing.Size(28, 13);
            this.lblTipoEstacion.TabIndex = 7;
            this.lblTipoEstacion.Text = "Tipo";
            // 
            // cbTipoEstacion
            // 
            this.cbTipoEstacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoEstacion.FormattingEnabled = true;
            this.cbTipoEstacion.Location = new System.Drawing.Point(435, 44);
            this.cbTipoEstacion.Name = "cbTipoEstacion";
            this.cbTipoEstacion.Size = new System.Drawing.Size(140, 21);
            this.cbTipoEstacion.TabIndex = 8;
            // 
            // btnAsignarTipoEstacion
            // 
            this.btnAsignarTipoEstacion.Location = new System.Drawing.Point(595, 42);
            this.btnAsignarTipoEstacion.Name = "btnAsignarTipoEstacion";
            this.btnAsignarTipoEstacion.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarTipoEstacion.TabIndex = 9;
            this.btnAsignarTipoEstacion.Text = "Asignar";
            this.btnAsignarTipoEstacion.UseVisualStyleBackColor = true;
            this.btnAsignarTipoEstacion.Click += new System.EventHandler(this.btnAsignarTipoEstacion_Click);
            // 
            // dgvEstaciones
            // 
            this.dgvEstaciones.AllowUserToAddRows = false;
            this.dgvEstaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroEstacion,
            this.colTipoEstacion,
            this.coDireccionIP});
            this.dgvEstaciones.Location = new System.Drawing.Point(35, 88);
            this.dgvEstaciones.MultiSelect = false;
            this.dgvEstaciones.Name = "dgvEstaciones";
            this.dgvEstaciones.ReadOnly = true;
            this.dgvEstaciones.RowHeadersVisible = false;
            this.dgvEstaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstaciones.Size = new System.Drawing.Size(660, 200);
            this.dgvEstaciones.TabIndex = 10;
            this.dgvEstaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstaciones_CellClick);
            // 
            // colNumeroEstacion
            // 
            this.colNumeroEstacion.HeaderText = "Equipo";
            this.colNumeroEstacion.Name = "colNumeroEstacion";
            this.colNumeroEstacion.ReadOnly = true;
            this.colNumeroEstacion.Width = 80;
            // 
            // colTipoEstacion
            // 
            this.colTipoEstacion.HeaderText = "Tipo";
            this.colTipoEstacion.Name = "colTipoEstacion";
            this.colTipoEstacion.ReadOnly = true;
            // 
            // coDireccionIP
            // 
            this.coDireccionIP.HeaderText = "IP";
            this.coDireccionIP.Name = "coDireccionIP";
            this.coDireccionIP.ReadOnly = true;
            this.coDireccionIP.Width = 150;
            // 
            // lblMonitoreo
            // 
            this.lblMonitoreo.AutoSize = true;
            this.lblMonitoreo.Location = new System.Drawing.Point(52, 73);
            this.lblMonitoreo.Name = "lblMonitoreo";
            this.lblMonitoreo.Size = new System.Drawing.Size(94, 13);
            this.lblMonitoreo.TabIndex = 3;
            this.lblMonitoreo.Text = "Minutos Monitoreo";
            // 
            // nudMonitor
            // 
            this.nudMonitor.Location = new System.Drawing.Point(170, 71);
            this.nudMonitor.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMonitor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonitor.Name = "nudMonitor";
            this.nudMonitor.Size = new System.Drawing.Size(65, 20);
            this.nudMonitor.TabIndex = 4;
            this.nudMonitor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmPreferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 378);
            this.Controls.Add(this.tabPreferencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPreferencias";
            this.ShowIcon = false;
            this.Text = "Preferencias";
            this.tabPreferencias.ResumeLayout(false);
            this.tbCategoria.ResumeLayout(false);
            this.tbCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.TipoEquipos.ResumeLayout(false);
            this.TipoEquipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudM4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCiclos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLibre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposEquipo)).EndInit();
            this.tabTolerancia.ResumeLayout(false);
            this.tabTolerancia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTolerancia)).EndInit();
            this.tabEstaciones.ResumeLayout(false);
            this.tabEstaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalEstaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInicioEstaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroEstacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPreferencias;
        private System.Windows.Forms.TabPage tbCategoria;
        private System.Windows.Forms.TabPage TipoEquipos;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Button btnEliminarCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.DataGridView dgvTiposEquipo;
        private System.Windows.Forms.Button btnAgregarTipoEquipo;
        private System.Windows.Forms.NumericUpDown nudM4;
        private System.Windows.Forms.NumericUpDown nudM3;
        private System.Windows.Forms.NumericUpDown nudM2;
        private System.Windows.Forms.NumericUpDown nudCiclos;
        private System.Windows.Forms.CheckBox cbMultijugador;
        private System.Windows.Forms.NumericUpDown nudLibre;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox tbNombreEquipo;
        private System.Windows.Forms.Button btnEditarTipoEquipo;
        private System.Windows.Forms.Button btnEliminarTipoEquipo;
        private System.Windows.Forms.TabPage tabTolerancia;
        private System.Windows.Forms.Button bntGuardarTolerancia;
        private System.Windows.Forms.NumericUpDown nudTolerancia;
        private System.Windows.Forms.Label lblTolerancia;
        private System.Windows.Forms.Label lblNombreCategoria;
        private System.Windows.Forms.Label lblNombreTipo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lbl4M;
        private System.Windows.Forms.Label lbl3M;
        private System.Windows.Forms.Label lbl2M;
        private System.Windows.Forms.Label lblTarifasMultijugador;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblCiclos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiclos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoCiclo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colM3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colM4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.TabPage tabEstaciones;
        private System.Windows.Forms.Label lblTotalEstaciones;
        private System.Windows.Forms.NumericUpDown nudTotalEstaciones;
        private System.Windows.Forms.Label lblInicioEstaciones;
        private System.Windows.Forms.NumericUpDown nudInicioEstaciones;
        private System.Windows.Forms.Button btnAplicarTotalEstaciones;
        private System.Windows.Forms.Label lblNumeroEstacion;
        private System.Windows.Forms.NumericUpDown nudNumeroEstacion;
        private System.Windows.Forms.Label lblTipoEstacion;
        private System.Windows.Forms.ComboBox cbTipoEstacion;
        private System.Windows.Forms.Button btnAsignarTipoEstacion;
        private System.Windows.Forms.DataGridView dgvEstaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn coDireccionIP;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.NumericUpDown nudMonitor;
        private System.Windows.Forms.Label lblMonitoreo;
    }
}
