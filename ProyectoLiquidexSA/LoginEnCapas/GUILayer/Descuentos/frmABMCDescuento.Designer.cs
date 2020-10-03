namespace ProyectoLiquidexSA.GUILayer.Descuentos
{
    partial class frmABMCDescuento
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
            this.lblIdDescuento = new System.Windows.Forms.Label();
            this.lblNombreDescuento = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtIdDescuento = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombreDescuento = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIdDescuento
            // 
            this.lblIdDescuento.AutoSize = true;
            this.lblIdDescuento.Location = new System.Drawing.Point(21, 22);
            this.lblIdDescuento.Name = "lblIdDescuento";
            this.lblIdDescuento.Size = new System.Drawing.Size(79, 13);
            this.lblIdDescuento.TabIndex = 0;
            this.lblIdDescuento.Text = "Nro Descuento";
            // 
            // lblNombreDescuento
            // 
            this.lblNombreDescuento.AutoSize = true;
            this.lblNombreDescuento.Location = new System.Drawing.Point(21, 59);
            this.lblNombreDescuento.Name = "lblNombreDescuento";
            this.lblNombreDescuento.Size = new System.Drawing.Size(44, 13);
            this.lblNombreDescuento.TabIndex = 1;
            this.lblNombreDescuento.Text = "Nombre";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(21, 98);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(37, 13);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto";
            // 
            // txtIdDescuento
            // 
            this.txtIdDescuento.Location = new System.Drawing.Point(113, 22);
            this.txtIdDescuento.Name = "txtIdDescuento";
            this.txtIdDescuento.Size = new System.Drawing.Size(137, 20);
            this.txtIdDescuento.TabIndex = 3;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(113, 98);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(137, 20);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(38, 144);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(204, 144);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombreDescuento
            // 
            this.txtNombreDescuento.Location = new System.Drawing.Point(113, 59);
            this.txtNombreDescuento.Name = "txtNombreDescuento";
            this.txtNombreDescuento.Size = new System.Drawing.Size(137, 20);
            this.txtNombreDescuento.TabIndex = 8;
            // 
            // frmABMCDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 181);
            this.Controls.Add(this.txtNombreDescuento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtIdDescuento);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblNombreDescuento);
            this.Controls.Add(this.lblIdDescuento);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmABMCDescuento";
            this.Text = "A B M C Descuentos";
            this.Load += new System.EventHandler(this.frmABMCDescuento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdDescuento;
        private System.Windows.Forms.Label lblNombreDescuento;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtIdDescuento;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombreDescuento;
    }
}