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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblNumeroCaja = new System.Windows.Forms.Label();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeshabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPreferencias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.contabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilidadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.utilidadesXProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldoPromocionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.venderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialCobrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fotocopiasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.historialAlertasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.tmrVisitas = new System.Windows.Forms.Timer(this.components);
            this.lblPuerto = new System.Windows.Forms.Label();
            this.lblVisitas = new System.Windows.Forms.Label();
            this.tmrBackup = new System.Windows.Forms.Timer(this.components);
            this.tmrMonitorEquipos = new System.Windows.Forms.Timer(this.components);
            this.gbAsalir = new System.Windows.Forms.GroupBox();
            this.dgvProximasSalidas = new System.Windows.Forms.DataGridView();
            this.colNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoRestante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbUltimosCobros = new System.Windows.Forms.GroupBox();
            this.dgvUltimosCobros = new System.Windows.Forms.DataGridView();
            this.colEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbInfoCaja = new System.Windows.Forms.GroupBox();
            this.tmrInternet = new System.Windows.Forms.Timer(this.components);
            this.lblInternet = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.tmrCaptura = new System.Windows.Forms.Timer(this.components);
            this.msMenu.SuspendLayout();
            this.gbAsalir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProximasSalidas)).BeginInit();
            this.gbUltimosCobros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosCobros)).BeginInit();
            this.gbInfoCaja.SuspendLayout();
            this.pnlInfo.SuspendLayout();
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
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCaja.Location = new System.Drawing.Point(8, 22);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(150, 20);
            this.lblCaja.TabIndex = 5;
            this.lblCaja.Text = "Total: 1007.50 Bs";
            // 
            // lblNumeroCaja
            // 
            this.lblNumeroCaja.AutoSize = true;
            this.lblNumeroCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroCaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumeroCaja.Location = new System.Drawing.Point(174, 22);
            this.lblNumeroCaja.Name = "lblNumeroCaja";
            this.lblNumeroCaja.Size = new System.Drawing.Size(108, 17);
            this.lblNumeroCaja.TabIndex = 6;
            this.lblNumeroCaja.Text = "Caja Nº: 1000";
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.contabilidadToolStripMenuItem,
            this.cajerosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1210, 24);
            this.msMenu.TabIndex = 11;
            this.msMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorToolStripMenuItem,
            this.tsmiPreferencias,
            this.tsmiCerrarSesion});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Sistema";
            // 
            // monitorToolStripMenuItem
            // 
            this.monitorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHabilitar,
            this.mnuDeshabilitar});
            this.monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            this.monitorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.monitorToolStripMenuItem.Text = "Monitor";
            // 
            // mnuHabilitar
            // 
            this.mnuHabilitar.Name = "mnuHabilitar";
            this.mnuHabilitar.Size = new System.Drawing.Size(136, 22);
            this.mnuHabilitar.Text = "Habilitar";
            this.mnuHabilitar.Click += new System.EventHandler(this.habilitarToolStripMenuItem_Click);
            // 
            // mnuDeshabilitar
            // 
            this.mnuDeshabilitar.Name = "mnuDeshabilitar";
            this.mnuDeshabilitar.Size = new System.Drawing.Size(136, 22);
            this.mnuDeshabilitar.Text = "Deshabilitar";
            this.mnuDeshabilitar.Click += new System.EventHandler(this.mnuDeshabilitar_Click);
            // 
            // tsmiPreferencias
            // 
            this.tsmiPreferencias.Name = "tsmiPreferencias";
            this.tsmiPreferencias.Size = new System.Drawing.Size(142, 22);
            this.tsmiPreferencias.Text = "Preferencias";
            this.tsmiPreferencias.Click += new System.EventHandler(this.tsmiPreferencias_Click);
            // 
            // tsmiCerrarSesion
            // 
            this.tsmiCerrarSesion.Name = "tsmiCerrarSesion";
            this.tsmiCerrarSesion.Size = new System.Drawing.Size(142, 22);
            this.tsmiCerrarSesion.Text = "Cerrar sesión";
            this.tsmiCerrarSesion.Click += new System.EventHandler(this.tsmiCerrarSesion_Click);
            // 
            // contabilidadToolStripMenuItem
            // 
            this.contabilidadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilidadesToolStripMenuItem1,
            this.utilidadesXProductoToolStripMenuItem});
            this.contabilidadToolStripMenuItem.Name = "contabilidadToolStripMenuItem";
            this.contabilidadToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.contabilidadToolStripMenuItem.Text = "Contabilidad";
            // 
            // utilidadesToolStripMenuItem1
            // 
            this.utilidadesToolStripMenuItem1.Name = "utilidadesToolStripMenuItem1";
            this.utilidadesToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.utilidadesToolStripMenuItem1.Text = "Utilidad general";
            this.utilidadesToolStripMenuItem1.Click += new System.EventHandler(this.utilidadesToolStripMenuItem1_Click);
            // 
            // utilidadesXProductoToolStripMenuItem
            // 
            this.utilidadesXProductoToolStripMenuItem.Name = "utilidadesXProductoToolStripMenuItem";
            this.utilidadesXProductoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.utilidadesXProductoToolStripMenuItem.Text = "Utilidades x producto";
            this.utilidadesXProductoToolStripMenuItem.Click += new System.EventHandler(this.utilidadesXProductoToolStripMenuItem_Click);
            // 
            // cajerosToolStripMenuItem
            // 
            this.cajerosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarToolStripMenuItem});
            this.cajerosToolStripMenuItem.Name = "cajerosToolStripMenuItem";
            this.cajerosToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.cajerosToolStripMenuItem.Text = "Cajeros";
            // 
            // gestionarToolStripMenuItem
            // 
            this.gestionarToolStripMenuItem.Name = "gestionarToolStripMenuItem";
            this.gestionarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gestionarToolStripMenuItem.Text = "Gestionar";
            this.gestionarToolStripMenuItem.Click += new System.EventHandler(this.gestionarToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verToolStripMenuItem,
            this.rankingToolStripMenuItem,
            this.saldoPromocionalToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.verToolStripMenuItem.Text = "Listado";
            this.verToolStripMenuItem.Click += new System.EventHandler(this.verToolStripMenuItem_Click);
            // 
            // rankingToolStripMenuItem
            // 
            this.rankingToolStripMenuItem.Name = "rankingToolStripMenuItem";
            this.rankingToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.rankingToolStripMenuItem.Text = "Ranking";
            this.rankingToolStripMenuItem.Click += new System.EventHandler(this.rankingToolStripMenuItem_Click);
            // 
            // saldoPromocionalToolStripMenuItem
            // 
            this.saldoPromocionalToolStripMenuItem.Name = "saldoPromocionalToolStripMenuItem";
            this.saldoPromocionalToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.saldoPromocionalToolStripMenuItem.Text = "Credito";
            this.saldoPromocionalToolStripMenuItem.Click += new System.EventHandler(this.saldoPromocionalToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarToolStripMenuItem1,
            this.venderToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gestionarToolStripMenuItem1
            // 
            this.gestionarToolStripMenuItem1.Name = "gestionarToolStripMenuItem1";
            this.gestionarToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.gestionarToolStripMenuItem1.Text = "Listado";
            this.gestionarToolStripMenuItem1.Click += new System.EventHandler(this.gestionarToolStripMenuItem1_Click);
            // 
            // venderToolStripMenuItem
            // 
            this.venderToolStripMenuItem.Name = "venderToolStripMenuItem";
            this.venderToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.venderToolStripMenuItem.Text = "Vender     F5";
            this.venderToolStripMenuItem.Click += new System.EventHandler(this.venderToolStripMenuItem_Click);
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosToolStripMenuItem,
            this.egresosToolStripMenuItem,
            this.detalleToolStripMenuItem,
            this.historialToolStripMenuItem,
            this.historialCobrosToolStripMenuItem,
            this.cerrarCajaToolStripMenuItem});
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cajaToolStripMenuItem.Text = "Caja";
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            this.ingresosToolStripMenuItem.Click += new System.EventHandler(this.ingresosToolStripMenuItem_Click);
            // 
            // egresosToolStripMenuItem
            // 
            this.egresosToolStripMenuItem.Name = "egresosToolStripMenuItem";
            this.egresosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.egresosToolStripMenuItem.Text = "Egresos";
            this.egresosToolStripMenuItem.Click += new System.EventHandler(this.egresosToolStripMenuItem_Click);
            // 
            // detalleToolStripMenuItem
            // 
            this.detalleToolStripMenuItem.Name = "detalleToolStripMenuItem";
            this.detalleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.detalleToolStripMenuItem.Text = "Detalle     F3";
            this.detalleToolStripMenuItem.Click += new System.EventHandler(this.detalleToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.historialToolStripMenuItem.Text = "Historial cajas";
            this.historialToolStripMenuItem.Click += new System.EventHandler(this.historialToolStripMenuItem_Click);
            // 
            // historialCobrosToolStripMenuItem
            // 
            this.historialCobrosToolStripMenuItem.Name = "historialCobrosToolStripMenuItem";
            this.historialCobrosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.historialCobrosToolStripMenuItem.Text = "Historial cobros";
            this.historialCobrosToolStripMenuItem.Click += new System.EventHandler(this.historialCobrosToolStripMenuItem_Click);
            // 
            // cerrarCajaToolStripMenuItem
            // 
            this.cerrarCajaToolStripMenuItem.Name = "cerrarCajaToolStripMenuItem";
            this.cerrarCajaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.cerrarCajaToolStripMenuItem.Text = "Cerrar Caja";
            this.cerrarCajaToolStripMenuItem.Click += new System.EventHandler(this.cerrarCajaToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fotocopiasToolStripMenuItem1,
            this.historialAlertasToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // fotocopiasToolStripMenuItem1
            // 
            this.fotocopiasToolStripMenuItem1.Name = "fotocopiasToolStripMenuItem1";
            this.fotocopiasToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.fotocopiasToolStripMenuItem1.Text = "Fotocopias";
            this.fotocopiasToolStripMenuItem1.Click += new System.EventHandler(this.fotocopiasToolStripMenuItem1_Click);
            // 
            // historialAlertasToolStripMenuItem
            // 
            this.historialAlertasToolStripMenuItem.Name = "historialAlertasToolStripMenuItem";
            this.historialAlertasToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.historialAlertasToolStripMenuItem.Text = "Historial Alertas";
            this.historialAlertasToolStripMenuItem.Click += new System.EventHandler(this.historialAlertasToolStripMenuItem_Click);
            // 
            // tmrAutoSave
            // 
            this.tmrAutoSave.Interval = 1000;
            this.tmrAutoSave.Tick += new System.EventHandler(this.tmrAutoSave_Tick);
            // 
            // tmrVisitas
            // 
            this.tmrVisitas.Interval = 3000;
            this.tmrVisitas.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPuerto.Location = new System.Drawing.Point(209, 11);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(59, 15);
            this.lblPuerto.TabIndex = 12;
            this.lblPuerto.Text = "API: 5000";
            // 
            // lblVisitas
            // 
            this.lblVisitas.AutoSize = true;
            this.lblVisitas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVisitas.Location = new System.Drawing.Point(118, 11);
            this.lblVisitas.Name = "lblVisitas";
            this.lblVisitas.Size = new System.Drawing.Size(42, 13);
            this.lblVisitas.TabIndex = 13;
            this.lblVisitas.Text = "Web: 0";
            // 
            // tmrBackup
            // 
            this.tmrBackup.Interval = 3600000;
            this.tmrBackup.Tick += new System.EventHandler(this.tmrBackup_Tick);
            // 
            // tmrMonitorEquipos
            // 
            this.tmrMonitorEquipos.Interval = 300000;
            this.tmrMonitorEquipos.Tick += new System.EventHandler(this.tmrMonitorEquipos_Tick);
            // 
            // gbAsalir
            // 
            this.gbAsalir.Controls.Add(this.dgvProximasSalidas);
            this.gbAsalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAsalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbAsalir.Location = new System.Drawing.Point(571, 80);
            this.gbAsalir.Name = "gbAsalir";
            this.gbAsalir.Size = new System.Drawing.Size(291, 269);
            this.gbAsalir.TabIndex = 15;
            this.gbAsalir.TabStop = false;
            this.gbAsalir.Text = "Próximos a salir";
            // 
            // dgvProximasSalidas
            // 
            this.dgvProximasSalidas.AllowUserToAddRows = false;
            this.dgvProximasSalidas.AllowUserToDeleteRows = false;
            this.dgvProximasSalidas.AllowUserToResizeColumns = false;
            this.dgvProximasSalidas.AllowUserToResizeRows = false;
            this.dgvProximasSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProximasSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNro,
            this.colTipo,
            this.colTiempoRestante});
            this.dgvProximasSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProximasSalidas.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvProximasSalidas.Location = new System.Drawing.Point(3, 19);
            this.dgvProximasSalidas.MultiSelect = false;
            this.dgvProximasSalidas.Name = "dgvProximasSalidas";
            this.dgvProximasSalidas.ReadOnly = true;
            this.dgvProximasSalidas.RowHeadersVisible = false;
            this.dgvProximasSalidas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvProximasSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProximasSalidas.Size = new System.Drawing.Size(285, 247);
            this.dgvProximasSalidas.TabIndex = 16;
            this.dgvProximasSalidas.SelectionChanged += new System.EventHandler(this.dgvProximasSalidas_SelectionChanged);
            // 
            // colNro
            // 
            this.colNro.HeaderText = "Nº";
            this.colNro.Name = "colNro";
            this.colNro.ReadOnly = true;
            this.colNro.Width = 50;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "TIPO";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 50;
            // 
            // colTiempoRestante
            // 
            this.colTiempoRestante.HeaderText = "TIEMPO RESTANTE";
            this.colTiempoRestante.Name = "colTiempoRestante";
            this.colTiempoRestante.ReadOnly = true;
            this.colTiempoRestante.Width = 190;
            // 
            // gbUltimosCobros
            // 
            this.gbUltimosCobros.Controls.Add(this.dgvUltimosCobros);
            this.gbUltimosCobros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUltimosCobros.ForeColor = System.Drawing.Color.White;
            this.gbUltimosCobros.Location = new System.Drawing.Point(888, 358);
            this.gbUltimosCobros.Name = "gbUltimosCobros";
            this.gbUltimosCobros.Size = new System.Drawing.Size(291, 266);
            this.gbUltimosCobros.TabIndex = 16;
            this.gbUltimosCobros.TabStop = false;
            this.gbUltimosCobros.Text = "Últimos Cobros";
            // 
            // dgvUltimosCobros
            // 
            this.dgvUltimosCobros.AllowUserToAddRows = false;
            this.dgvUltimosCobros.AllowUserToDeleteRows = false;
            this.dgvUltimosCobros.AllowUserToResizeColumns = false;
            this.dgvUltimosCobros.AllowUserToResizeRows = false;
            this.dgvUltimosCobros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUltimosCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUltimosCobros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEquipo,
            this.colTotal});
            this.dgvUltimosCobros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUltimosCobros.Location = new System.Drawing.Point(3, 19);
            this.dgvUltimosCobros.MultiSelect = false;
            this.dgvUltimosCobros.Name = "dgvUltimosCobros";
            this.dgvUltimosCobros.ReadOnly = true;
            this.dgvUltimosCobros.RowHeadersVisible = false;
            this.dgvUltimosCobros.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvUltimosCobros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUltimosCobros.Size = new System.Drawing.Size(285, 244);
            this.dgvUltimosCobros.TabIndex = 0;
            this.dgvUltimosCobros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUltimosCobros_CellDoubleClick);
            this.dgvUltimosCobros.SelectionChanged += new System.EventHandler(this.dgvUltimosCobros_SelectionChanged);
            // 
            // colEquipo
            // 
            this.colEquipo.HeaderText = "Nº";
            this.colEquipo.Name = "colEquipo";
            this.colEquipo.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "TOTAL";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // gbInfoCaja
            // 
            this.gbInfoCaja.Controls.Add(this.lblCaja);
            this.gbInfoCaja.Controls.Add(this.lblNumeroCaja);
            this.gbInfoCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfoCaja.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbInfoCaja.Location = new System.Drawing.Point(888, 40);
            this.gbInfoCaja.Name = "gbInfoCaja";
            this.gbInfoCaja.Size = new System.Drawing.Size(288, 55);
            this.gbInfoCaja.TabIndex = 17;
            this.gbInfoCaja.TabStop = false;
            this.gbInfoCaja.Text = "Caja Nº: 1";
            // 
            // tmrInternet
            // 
            this.tmrInternet.Interval = 30000;
            this.tmrInternet.Tick += new System.EventHandler(this.tmrInternet_Tick);
            // 
            // lblInternet
            // 
            this.lblInternet.AutoSize = true;
            this.lblInternet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInternet.Location = new System.Drawing.Point(9, 11);
            this.lblInternet.Name = "lblInternet";
            this.lblInternet.Size = new System.Drawing.Size(69, 13);
            this.lblInternet.TabIndex = 18;
            this.lblInternet.Text = "TIGO: Online";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblPuerto);
            this.pnlInfo.Controls.Add(this.lblInternet);
            this.pnlInfo.Controls.Add(this.lblVisitas);
            this.pnlInfo.Location = new System.Drawing.Point(574, 358);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(285, 34);
            this.pnlInfo.TabIndex = 19;
            // 
            // tmrCaptura
            // 
            this.tmrCaptura.Interval = 60000;
            this.tmrCaptura.Tick += new System.EventHandler(this.tmrCaptura_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1210, 636);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.gbInfoCaja);
            this.Controls.Add(this.gbUltimosCobros);
            this.Controls.Add(this.gbAsalir);
            this.Controls.Add(this.msMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.Text = "Cyberplay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.gbAsalir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProximasSalidas)).EndInit();
            this.gbUltimosCobros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosCobros)).EndInit();
            this.gbInfoCaja.ResumeLayout(false);
            this.gbInfoCaja.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblNumeroCaja;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem venderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPreferencias;
        private System.Windows.Forms.ToolStripMenuItem tsmiCerrarSesion;
        private System.Windows.Forms.Timer tmrAutoSave;
        private System.Windows.Forms.Timer tmrVisitas;
        private System.Windows.Forms.ToolStripMenuItem detalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.Label lblVisitas;
        private System.Windows.Forms.ToolStripMenuItem cerrarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialCobrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.Timer tmrBackup;
        private System.Windows.Forms.Timer tmrMonitorEquipos;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialAlertasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankingToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbAsalir;
        private System.Windows.Forms.DataGridView dgvProximasSalidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoRestante;
        private System.Windows.Forms.GroupBox gbUltimosCobros;
        private System.Windows.Forms.DataGridView dgvUltimosCobros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.GroupBox gbInfoCaja;
        private System.Windows.Forms.ToolStripMenuItem saldoPromocionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fotocopiasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contabilidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilidadesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem utilidadesXProductoToolStripMenuItem;
        private System.Windows.Forms.Timer tmrInternet;
        private System.Windows.Forms.Label lblInternet;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.ToolStripMenuItem monitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHabilitar;
        private System.Windows.Forms.ToolStripMenuItem mnuDeshabilitar;
        private System.Windows.Forms.Timer tmrCaptura;
    }
}
