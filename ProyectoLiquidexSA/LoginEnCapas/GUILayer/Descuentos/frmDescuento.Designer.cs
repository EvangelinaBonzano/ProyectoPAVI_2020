namespace ProyectoLiquidexSA.GUILayer.Descuentos
{
    partial class frmDescuento
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
            this.lblNombreDescuento = new System.Windows.Forms.Label();
            this.lblMontoDescuento = new System.Windows.Forms.Label();
            this.txtNombreDescuento = new System.Windows.Forms.TextBox();
            this.grdDescuento = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxTodos = new System.Windows.Forms.CheckBox();
            this.lblTodosDescuentos = new System.Windows.Forms.Label();
            this.btnConsultarDescuento = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtMontoDescuento = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDescuento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreDescuento
            // 
            this.lblNombreDescuento.AutoSize = true;
            this.lblNombreDescuento.Location = new System.Drawing.Point(74, 15);
            this.lblNombreDescuento.Name = "lblNombreDescuento";
            this.lblNombreDescuento.Size = new System.Drawing.Size(53, 13);
            this.lblNombreDescuento.TabIndex = 0;
            this.lblNombreDescuento.Text = "Nombre:  ";
            // 
            // lblMontoDescuento
            // 
            this.lblMontoDescuento.AutoSize = true;
            this.lblMontoDescuento.Location = new System.Drawing.Point(74, 46);
            this.lblMontoDescuento.Name = "lblMontoDescuento";
            this.lblMontoDescuento.Size = new System.Drawing.Size(43, 13);
            this.lblMontoDescuento.TabIndex = 1;
            this.lblMontoDescuento.Text = "Monto: ";
            // 
            // txtNombreDescuento
            // 
            this.txtNombreDescuento.Location = new System.Drawing.Point(134, 12);
            this.txtNombreDescuento.Name = "txtNombreDescuento";
            this.txtNombreDescuento.Size = new System.Drawing.Size(121, 20);
            this.txtNombreDescuento.TabIndex = 2;
            // 
            // grdDescuento
            // 
            this.grdDescuento.AllowUserToAddRows = false;
            this.grdDescuento.AllowUserToDeleteRows = false;
            this.grdDescuento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDescuento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Nombre,
            this.Monto});
            this.grdDescuento.Location = new System.Drawing.Point(12, 136);
            this.grdDescuento.Name = "grdDescuento";
            this.grdDescuento.ReadOnly = true;
            this.grdDescuento.Size = new System.Drawing.Size(394, 121);
            this.grdDescuento.TabIndex = 4;
            this.grdDescuento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDescuento_CellContentClick);
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // checkBoxTodos
            // 
            this.checkBoxTodos.AutoSize = true;
            this.checkBoxTodos.Location = new System.Drawing.Point(134, 86);
            this.checkBoxTodos.Name = "checkBoxTodos";
            this.checkBoxTodos.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTodos.TabIndex = 9;
            this.checkBoxTodos.UseVisualStyleBackColor = true;
            this.checkBoxTodos.CheckedChanged += new System.EventHandler(this.checkBoxTodos_CheckedChanged);
            // 
            // lblTodosDescuentos
            // 
            this.lblTodosDescuentos.AutoSize = true;
            this.lblTodosDescuentos.Location = new System.Drawing.Point(77, 86);
            this.lblTodosDescuentos.Name = "lblTodosDescuentos";
            this.lblTodosDescuentos.Size = new System.Drawing.Size(37, 13);
            this.lblTodosDescuentos.TabIndex = 10;
            this.lblTodosDescuentos.Text = "Todos";
            // 
            // btnConsultarDescuento
            // 
            this.btnConsultarDescuento.Location = new System.Drawing.Point(331, 97);
            this.btnConsultarDescuento.Name = "btnConsultarDescuento";
            this.btnConsultarDescuento.Size = new System.Drawing.Size(75, 23);
            this.btnConsultarDescuento.TabIndex = 11;
            this.btnConsultarDescuento.Text = "Consultar";
            this.btnConsultarDescuento.UseVisualStyleBackColor = true;
            this.btnConsultarDescuento.Click += new System.EventHandler(this.btnConsultarDescuento_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::ProyectoLiquidexSA.Properties.Resources.salir;
            this.btnSalir.Location = new System.Drawing.Point(360, 273);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(46, 43);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::ProyectoLiquidexSA.Properties.Resources.eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(148, 273);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(46, 43);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::ProyectoLiquidexSA.Properties.Resources.editar;
            this.btnEditar.Location = new System.Drawing.Point(80, 273);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(46, 43);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::ProyectoLiquidexSA.Properties.Resources.agregar;
            this.btnNuevo.Location = new System.Drawing.Point(12, 273);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 43);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtMontoDescuento
            // 
            this.txtMontoDescuento.Location = new System.Drawing.Point(134, 46);
            this.txtMontoDescuento.Name = "txtMontoDescuento";
            this.txtMontoDescuento.Size = new System.Drawing.Size(121, 20);
            this.txtMontoDescuento.TabIndex = 12;
            this.txtMontoDescuento.TextChanged += new System.EventHandler(this.txtMontoDescuento_TextChanged);
            // 
            // frmDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 328);
            this.Controls.Add(this.txtMontoDescuento);
            this.Controls.Add(this.btnConsultarDescuento);
            this.Controls.Add(this.lblTodosDescuentos);
            this.Controls.Add(this.checkBoxTodos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grdDescuento);
            this.Controls.Add(this.txtNombreDescuento);
            this.Controls.Add(this.lblMontoDescuento);
            this.Controls.Add(this.lblNombreDescuento);
            this.Name = "frmDescuento";
            this.Text = "Descuentos";
            ((System.ComponentModel.ISupportInitialize)(this.grdDescuento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreDescuento;
        private System.Windows.Forms.Label lblMontoDescuento;
        private System.Windows.Forms.TextBox txtNombreDescuento;
        private System.Windows.Forms.DataGridView grdDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox checkBoxTodos;
        private System.Windows.Forms.Label lblTodosDescuentos;
        private System.Windows.Forms.Button btnConsultarDescuento;
        private System.Windows.Forms.TextBox txtMontoDescuento;
    }
}