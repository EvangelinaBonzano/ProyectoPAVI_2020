using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoLiquidexSA.BusinessLayer;
using ProyectoLiquidexSA.Entities;

namespace ProyectoLiquidexSA.GUILayer.Descuentos
{
    public partial class frmABMCDescuento : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly DescuentoService oDescuentoService;
        private Descuento oDescuentoSelected;

        public enum FormMode
        {
            insert,
            update,
            delete
        }


        public frmABMCDescuento()
        {
            InitializeComponent();
            oDescuentoService = new DescuentoService();
        }

        private void frmABMCDescuento_Load(object sender, EventArgs e)
        {
           

            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Descuento";
                        txtIdDescuento.Enabled = false;
                        txtNombreDescuento.Enabled = true;
                        txtMonto.Enabled = true;

                        txtNombreDescuento.Focus();

                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Descuento";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtIdDescuento.Enabled = false;
                        txtNombreDescuento.Enabled = false;
                        txtMonto.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Descuento";
                        txtIdDescuento.Enabled = false;
                        txtNombreDescuento.Enabled = false;
                        txtMonto.Enabled = false;
                        break;
                    }
            }
        }

   

        private void MostrarDatos()
        {
            if (oDescuentoSelected != null)
            {
                txtIdDescuento.Text = oDescuentoSelected.Id_descuento.ToString();
                txtNombreDescuento.Text = oDescuentoSelected.N_descuento;
                txtMonto.Text = oDescuentoSelected.Monto.ToString();
            }
        }

        public void SeleccionarDescuento(FormMode op, Descuento descuentoSelected)
        {
            formMode = op;
            oDescuentoSelected = descuentoSelected;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteDescuento() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oDescuento = new Descuento();

                                
                                oDescuento.N_descuento = txtNombreDescuento.Text;
                                oDescuento.Monto = Convert.ToInt32(txtMonto.Text.ToString());


                                if (oDescuentoService.CrearDescuento(oDescuento))
                                {
                                    MessageBox.Show("Descuento insertado !", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Ingrese datos diferentes !", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                           
                            oDescuentoSelected.N_descuento = txtNombreDescuento.Text;
                            oDescuentoSelected.Monto = Convert.ToInt32(txtMonto.Text.ToString());



                            if (oDescuentoService.ActualizarDescuento(oDescuentoSelected))
                            {
                                MessageBox.Show("Descuento actualizado !", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el descuento !", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el descuento seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oDescuentoService.BorrarDescuento(oDescuentoSelected))
                            {
                                MessageBox.Show("Descuento Habilitado/Deshabilitado !", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el descuento !", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }

        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNombreDescuento.Text == string.Empty)
            {
                txtNombreDescuento.BackColor = Color.Red;
                txtNombreDescuento.Focus();
                return false;
            }
            else
                txtNombreDescuento.BackColor = Color.White;

            if (txtMonto.Text == string.Empty)
            {
                txtMonto.BackColor = Color.Red;
                txtMonto.Focus();
                return false;
            }
            else
                txtMonto.BackColor = Color.White;

            //int numero;
            //if (Int32.TryParse(txtMonto.Text, out numero))
            //{
            //    return true;
            //}

            //else
            //{
            //    MessageBox.Show("Debe ingresar datos numéricos ...");
            //    txtMonto.Clear();
            //    txtMonto.Focus();
            //    return false;
            //}

            return true;
        }

        private bool ExisteDescuento()
        {
            return oDescuentoService.ObtenerDescuento(txtNombreDescuento.Text) != null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            double x;
            if (txtMonto.Text != "")
            {
                int numero;
                if (Int32.TryParse(txtMonto.Text, out numero))
                {
                    x = Convert.ToDouble(txtMonto.Text);
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad numérica...");
                    this.txtMonto.Clear();
                    txtMonto.Focus();
                }

            }
        }
    }
}
