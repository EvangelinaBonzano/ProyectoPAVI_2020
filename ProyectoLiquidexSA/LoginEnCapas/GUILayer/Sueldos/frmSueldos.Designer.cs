namespace ProyectoLiquidexSA.GUILayer.Sueldos
{
    partial class frmSueldos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSueldos));
            this.btnAgregarA = new System.Windows.Forms.Button();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.dgvAsignaciones = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCantidadA = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblAsignacion = new System.Windows.Forms.Label();
            this.lblCantidadA = new System.Windows.Forms.Label();
            this.lblMontoA = new System.Windows.Forms.Label();
            this.lblImporteA = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMontoD = new System.Windows.Forms.Label();
            this.lblCantidadD = new System.Windows.Forms.Label();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.txtSueldoBruto = new System.Windows.Forms.TextBox();
            this.lblSueldoBruto = new System.Windows.Forms.Label();
            this.dgvDescuentos = new System.Windows.Forms.DataGridView();
            this.NombreD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelarD = new System.Windows.Forms.Button();
            this.btnQuitarD = new System.Windows.Forms.Button();
            this.btnAgregarD = new System.Windows.Forms.Button();
            this.txtImporteD = new System.Windows.Forms.TextBox();
            this.lblImporteD = new System.Windows.Forms.Label();
            this.txtMontoD = new System.Windows.Forms.TextBox();
            this.txtCantidadD = new System.Windows.Forms.TextBox();
            this.cboDescuentos = new System.Windows.Forms.ComboBox();
            this.btnCancelarA = new System.Windows.Forms.Button();
            this.btnQuitarA = new System.Windows.Forms.Button();
            this.txtImporteA = new System.Windows.Forms.TextBox();
            this.txtMontoA = new System.Windows.Forms.TextBox();
            this.cboAsignaciones = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).BeginInit();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarA
            // 
            this.btnAgregarA.Image = global::ProyectoLiquidexSA.Properties.Resources.agregar;
            this.btnAgregarA.Location = new System.Drawing.Point(623, 19);
            this.btnAgregarA.Name = "btnAgregarA";
            this.btnAgregarA.Size = new System.Drawing.Size(45, 37);
            this.btnAgregarA.TabIndex = 0;
            this.btnAgregarA.UseVisualStyleBackColor = true;
            this.btnAgregarA.Click += new System.EventHandler(this.btnAgregarA_Click_1);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(82, 18);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(167, 21);
            this.cboUsuarios.TabIndex = 1;
            // 
            // dgvAsignaciones
            // 
            this.dgvAsignaciones.AllowUserToAddRows = false;
            this.dgvAsignaciones.AllowUserToDeleteRows = false;
            this.dgvAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Monto,
            this.Cantidad,
            this.Importe});
            this.dgvAsignaciones.Location = new System.Drawing.Point(16, 62);
            this.dgvAsignaciones.Name = "dgvAsignaciones";
            this.dgvAsignaciones.ReadOnly = true;
            this.dgvAsignaciones.Size = new System.Drawing.Size(754, 123);
            this.dgvAsignaciones.TabIndex = 2;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "N_asignacion";
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 270;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.Frozen = true;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 150;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 150;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.Frozen = true;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 150;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(25, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(79, 55);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(106, 20);
            this.dtpFecha.TabIndex = 4;
            // 
            // txtCantidadA
            // 
            this.txtCantidadA.Location = new System.Drawing.Point(312, 27);
            this.txtCantidadA.Name = "txtCantidadA";
            this.txtCantidadA.Size = new System.Drawing.Size(59, 20);
            this.txtCantidadA.TabIndex = 5;
            this.txtCantidadA.TextChanged += new System.EventHandler(this.txtCantidadA_TextChanged);
            this.txtCantidadA.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidadA_Validating);
            this.txtCantidadA.Validated += new System.EventHandler(this.txtCantidadA_Validated);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(25, 55);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblAsignacion
            // 
            this.lblAsignacion.AutoSize = true;
            this.lblAsignacion.Location = new System.Drawing.Point(13, 30);
            this.lblAsignacion.Name = "lblAsignacion";
            this.lblAsignacion.Size = new System.Drawing.Size(62, 13);
            this.lblAsignacion.TabIndex = 7;
            this.lblAsignacion.Text = "Asignación:";
            this.lblAsignacion.Click += new System.EventHandler(this.lblAsignacion_Click);
            // 
            // lblCantidadA
            // 
            this.lblCantidadA.AutoSize = true;
            this.lblCantidadA.Location = new System.Drawing.Point(254, 30);
            this.lblCantidadA.Name = "lblCantidadA";
            this.lblCantidadA.Size = new System.Drawing.Size(52, 13);
            this.lblCantidadA.TabIndex = 8;
            this.lblCantidadA.Text = "Cantidad:";
            // 
            // lblMontoA
            // 
            this.lblMontoA.AutoSize = true;
            this.lblMontoA.Location = new System.Drawing.Point(377, 30);
            this.lblMontoA.Name = "lblMontoA";
            this.lblMontoA.Size = new System.Drawing.Size(40, 13);
            this.lblMontoA.TabIndex = 9;
            this.lblMontoA.Text = "Monto:";
            // 
            // lblImporteA
            // 
            this.lblImporteA.AutoSize = true;
            this.lblImporteA.Location = new System.Drawing.Point(494, 30);
            this.lblImporteA.Name = "lblImporteA";
            this.lblImporteA.Size = new System.Drawing.Size(45, 13);
            this.lblImporteA.TabIndex = 10;
            this.lblImporteA.Text = "Importe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, -20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "label7";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(13, 209);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(62, 13);
            this.lblDescuento.TabIndex = 12;
            this.lblDescuento.Text = "Descuento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-17, -51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, -20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "label10";
            // 
            // lblMontoD
            // 
            this.lblMontoD.AutoSize = true;
            this.lblMontoD.Location = new System.Drawing.Point(377, 210);
            this.lblMontoD.Name = "lblMontoD";
            this.lblMontoD.Size = new System.Drawing.Size(40, 13);
            this.lblMontoD.TabIndex = 15;
            this.lblMontoD.Text = "Monto:";
            // 
            // lblCantidadD
            // 
            this.lblCantidadD.AutoSize = true;
            this.lblCantidadD.Location = new System.Drawing.Point(254, 209);
            this.lblCantidadD.Name = "lblCantidadD";
            this.lblCantidadD.Size = new System.Drawing.Size(52, 13);
            this.lblCantidadD.TabIndex = 16;
            this.lblCantidadD.Text = "Cantidad:";
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.txtSueldoBruto);
            this.grpDetalle.Controls.Add(this.lblSueldoBruto);
            this.grpDetalle.Controls.Add(this.dgvDescuentos);
            this.grpDetalle.Controls.Add(this.btnCancelarD);
            this.grpDetalle.Controls.Add(this.btnQuitarD);
            this.grpDetalle.Controls.Add(this.btnAgregarD);
            this.grpDetalle.Controls.Add(this.txtImporteD);
            this.grpDetalle.Controls.Add(this.lblImporteD);
            this.grpDetalle.Controls.Add(this.txtMontoD);
            this.grpDetalle.Controls.Add(this.txtCantidadD);
            this.grpDetalle.Controls.Add(this.cboDescuentos);
            this.grpDetalle.Controls.Add(this.btnCancelarA);
            this.grpDetalle.Controls.Add(this.btnQuitarA);
            this.grpDetalle.Controls.Add(this.txtImporteA);
            this.grpDetalle.Controls.Add(this.txtMontoA);
            this.grpDetalle.Controls.Add(this.cboAsignaciones);
            this.grpDetalle.Controls.Add(this.txtCantidadA);
            this.grpDetalle.Controls.Add(this.lblCantidadD);
            this.grpDetalle.Controls.Add(this.btnAgregarA);
            this.grpDetalle.Controls.Add(this.lblAsignacion);
            this.grpDetalle.Controls.Add(this.lblMontoD);
            this.grpDetalle.Controls.Add(this.dgvAsignaciones);
            this.grpDetalle.Controls.Add(this.lblCantidadA);
            this.grpDetalle.Controls.Add(this.label10);
            this.grpDetalle.Controls.Add(this.lblMontoA);
            this.grpDetalle.Controls.Add(this.label9);
            this.grpDetalle.Controls.Add(this.lblImporteA);
            this.grpDetalle.Controls.Add(this.lblDescuento);
            this.grpDetalle.Controls.Add(this.label7);
            this.grpDetalle.Location = new System.Drawing.Point(12, 81);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(781, 407);
            this.grpDetalle.TabIndex = 17;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Detalle";
            // 
            // txtSueldoBruto
            // 
            this.txtSueldoBruto.Location = new System.Drawing.Point(696, 373);
            this.txtSueldoBruto.Name = "txtSueldoBruto";
            this.txtSueldoBruto.Size = new System.Drawing.Size(74, 20);
            this.txtSueldoBruto.TabIndex = 32;
            // 
            // lblSueldoBruto
            // 
            this.lblSueldoBruto.AutoSize = true;
            this.lblSueldoBruto.Location = new System.Drawing.Point(620, 376);
            this.lblSueldoBruto.Name = "lblSueldoBruto";
            this.lblSueldoBruto.Size = new System.Drawing.Size(70, 13);
            this.lblSueldoBruto.TabIndex = 31;
            this.lblSueldoBruto.Text = "Sueldo bruto:";
            // 
            // dgvDescuentos
            // 
            this.dgvDescuentos.AllowUserToAddRows = false;
            this.dgvDescuentos.AllowUserToDeleteRows = false;
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreD,
            this.MontoD,
            this.CantidadD,
            this.ImporteD});
            this.dgvDescuentos.Location = new System.Drawing.Point(16, 240);
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.ReadOnly = true;
            this.dgvDescuentos.Size = new System.Drawing.Size(754, 123);
            this.dgvDescuentos.TabIndex = 30;
            // 
            // NombreD
            // 
            this.NombreD.DataPropertyName = "N_descuento";
            this.NombreD.Frozen = true;
            this.NombreD.HeaderText = "Nombre";
            this.NombreD.Name = "NombreD";
            this.NombreD.ReadOnly = true;
            this.NombreD.Width = 270;
            // 
            // MontoD
            // 
            this.MontoD.DataPropertyName = "Monto";
            this.MontoD.Frozen = true;
            this.MontoD.HeaderText = "Monto";
            this.MontoD.Name = "MontoD";
            this.MontoD.ReadOnly = true;
            this.MontoD.Width = 150;
            // 
            // CantidadD
            // 
            this.CantidadD.DataPropertyName = "Cantidad";
            this.CantidadD.Frozen = true;
            this.CantidadD.HeaderText = "Cantidad";
            this.CantidadD.Name = "CantidadD";
            this.CantidadD.ReadOnly = true;
            this.CantidadD.Width = 150;
            // 
            // ImporteD
            // 
            this.ImporteD.DataPropertyName = "Importe";
            this.ImporteD.Frozen = true;
            this.ImporteD.HeaderText = "Importe";
            this.ImporteD.Name = "ImporteD";
            this.ImporteD.ReadOnly = true;
            this.ImporteD.Width = 150;
            // 
            // btnCancelarD
            // 
            this.btnCancelarD.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarD.Image")));
            this.btnCancelarD.Location = new System.Drawing.Point(725, 197);
            this.btnCancelarD.Name = "btnCancelarD";
            this.btnCancelarD.Size = new System.Drawing.Size(45, 37);
            this.btnCancelarD.TabIndex = 29;
            this.btnCancelarD.UseVisualStyleBackColor = true;
            this.btnCancelarD.Click += new System.EventHandler(this.btnCancelarD_Click_1);
            // 
            // btnQuitarD
            // 
            this.btnQuitarD.Image = global::ProyectoLiquidexSA.Properties.Resources.eliminar;
            this.btnQuitarD.Location = new System.Drawing.Point(674, 197);
            this.btnQuitarD.Name = "btnQuitarD";
            this.btnQuitarD.Size = new System.Drawing.Size(45, 37);
            this.btnQuitarD.TabIndex = 28;
            this.btnQuitarD.UseVisualStyleBackColor = true;
            this.btnQuitarD.Click += new System.EventHandler(this.btnQuitarD_Click_1);
            // 
            // btnAgregarD
            // 
            this.btnAgregarD.Image = global::ProyectoLiquidexSA.Properties.Resources.agregar;
            this.btnAgregarD.Location = new System.Drawing.Point(623, 197);
            this.btnAgregarD.Name = "btnAgregarD";
            this.btnAgregarD.Size = new System.Drawing.Size(45, 37);
            this.btnAgregarD.TabIndex = 27;
            this.btnAgregarD.UseVisualStyleBackColor = true;
            this.btnAgregarD.Click += new System.EventHandler(this.btnAgregarD_Click_1);
            // 
            // txtImporteD
            // 
            this.txtImporteD.Location = new System.Drawing.Point(545, 206);
            this.txtImporteD.Name = "txtImporteD";
            this.txtImporteD.Size = new System.Drawing.Size(59, 20);
            this.txtImporteD.TabIndex = 26;
            // 
            // lblImporteD
            // 
            this.lblImporteD.AutoSize = true;
            this.lblImporteD.Location = new System.Drawing.Point(494, 209);
            this.lblImporteD.Name = "lblImporteD";
            this.lblImporteD.Size = new System.Drawing.Size(45, 13);
            this.lblImporteD.TabIndex = 25;
            this.lblImporteD.Text = "Importe:";
            // 
            // txtMontoD
            // 
            this.txtMontoD.Location = new System.Drawing.Point(423, 206);
            this.txtMontoD.Name = "txtMontoD";
            this.txtMontoD.Size = new System.Drawing.Size(59, 20);
            this.txtMontoD.TabIndex = 24;
            // 
            // txtCantidadD
            // 
            this.txtCantidadD.Location = new System.Drawing.Point(312, 207);
            this.txtCantidadD.Name = "txtCantidadD";
            this.txtCantidadD.Size = new System.Drawing.Size(59, 20);
            this.txtCantidadD.TabIndex = 23;
            this.txtCantidadD.TextChanged += new System.EventHandler(this.txtCantidadD_TextChanged_1);
            this.txtCantidadD.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidadD_Validating);
            // 
            // cboDescuentos
            // 
            this.cboDescuentos.FormattingEnabled = true;
            this.cboDescuentos.Location = new System.Drawing.Point(81, 206);
            this.cboDescuentos.Name = "cboDescuentos";
            this.cboDescuentos.Size = new System.Drawing.Size(167, 21);
            this.cboDescuentos.TabIndex = 22;
            this.cboDescuentos.SelectedIndexChanged += new System.EventHandler(this.cboDescuentos_SelectedIndexChanged);
            // 
            // btnCancelarA
            // 
            this.btnCancelarA.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarA.Image")));
            this.btnCancelarA.Location = new System.Drawing.Point(725, 19);
            this.btnCancelarA.Name = "btnCancelarA";
            this.btnCancelarA.Size = new System.Drawing.Size(45, 37);
            this.btnCancelarA.TabIndex = 21;
            this.btnCancelarA.UseVisualStyleBackColor = true;
            this.btnCancelarA.Click += new System.EventHandler(this.btnCancelarA_Click_1);
            // 
            // btnQuitarA
            // 
            this.btnQuitarA.Image = global::ProyectoLiquidexSA.Properties.Resources.eliminar;
            this.btnQuitarA.Location = new System.Drawing.Point(674, 19);
            this.btnQuitarA.Name = "btnQuitarA";
            this.btnQuitarA.Size = new System.Drawing.Size(45, 37);
            this.btnQuitarA.TabIndex = 20;
            this.btnQuitarA.UseVisualStyleBackColor = true;
            this.btnQuitarA.Click += new System.EventHandler(this.btnQuitarA_Click_1);
            // 
            // txtImporteA
            // 
            this.txtImporteA.Location = new System.Drawing.Point(545, 27);
            this.txtImporteA.Name = "txtImporteA";
            this.txtImporteA.Size = new System.Drawing.Size(59, 20);
            this.txtImporteA.TabIndex = 19;
            // 
            // txtMontoA
            // 
            this.txtMontoA.Location = new System.Drawing.Point(423, 28);
            this.txtMontoA.Name = "txtMontoA";
            this.txtMontoA.Size = new System.Drawing.Size(59, 20);
            this.txtMontoA.TabIndex = 18;
            // 
            // cboAsignaciones
            // 
            this.cboAsignaciones.FormattingEnabled = true;
            this.cboAsignaciones.Location = new System.Drawing.Point(81, 27);
            this.cboAsignaciones.Name = "cboAsignaciones";
            this.cboAsignaciones.Size = new System.Drawing.Size(167, 21);
            this.cboAsignaciones.TabIndex = 17;
            this.cboAsignaciones.SelectedIndexChanged += new System.EventHandler(this.cboAsignaciones_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(12, 494);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(59, 49);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.Location = new System.Drawing.Point(77, 494);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(59, 49);
            this.btnGrabar.TabIndex = 19;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(142, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(59, 49);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(737, 494);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(59, 49);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmSueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 555);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cboUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSueldos";
            this.Text = "Sueldos";
            this.Load += new System.EventHandler(this.frmSueldos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarA;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.DataGridView dgvAsignaciones;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtCantidadA;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblAsignacion;
        private System.Windows.Forms.Label lblCantidadA;
        private System.Windows.Forms.Label lblMontoA;
        private System.Windows.Forms.Label lblImporteA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMontoD;
        private System.Windows.Forms.Label lblCantidadD;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.TextBox txtSueldoBruto;
        private System.Windows.Forms.Label lblSueldoBruto;
        private System.Windows.Forms.DataGridView dgvDescuentos;
        private System.Windows.Forms.Button btnCancelarD;
        private System.Windows.Forms.Button btnQuitarD;
        private System.Windows.Forms.Button btnAgregarD;
        private System.Windows.Forms.TextBox txtImporteD;
        private System.Windows.Forms.Label lblImporteD;
        private System.Windows.Forms.TextBox txtMontoD;
        private System.Windows.Forms.TextBox txtCantidadD;
        private System.Windows.Forms.ComboBox cboDescuentos;
        private System.Windows.Forms.Button btnCancelarA;
        private System.Windows.Forms.Button btnQuitarA;
        private System.Windows.Forms.TextBox txtImporteA;
        private System.Windows.Forms.TextBox txtMontoA;
        private System.Windows.Forms.ComboBox cboAsignaciones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteD;
    }
}