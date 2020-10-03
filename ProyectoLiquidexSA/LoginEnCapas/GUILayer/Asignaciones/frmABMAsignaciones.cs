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

namespace ProyectoLiquidexSA.GUILayer.Asignaciones
{
    public partial class frmABMAsignaciones : Form
    {
        private FormMode formMode = FormMode.insert;
        private readonly AsignacionService oAsignacionService;
        private Asignacion oAsignacionSelected;
        public frmABMAsignaciones()
        {
            InitializeComponent();
            oAsignacionService = new AsignacionService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void frmABMAsignaciones_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nueva asignacion";
                        txtId.Enabled = false;
                        txtNombre.Enabled = true;
                        txtMonto.Enabled = true;
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar asignacion"; 
                        MostrarDatos();

                        txtId.Enabled = false;
                        txtNombre.Enabled = true;
                        txtMonto.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Asignacion";
                        txtId.Enabled = false;
                        txtNombre.Enabled = false;
                        txtMonto.Enabled = false;
                        break;
                    }
            }
        }
        public void SeleccionarAsignacion(FormMode op, Asignacion asignacionSelected)
        {
            formMode = op;
            oAsignacionSelected = asignacionSelected;
        }

        private void MostrarDatos()
        {
            if (oAsignacionSelected != null)
            {
                txtNombre.Text = oAsignacionSelected.N_asignacion;
                txtId.Text = oAsignacionSelected.Id_asignacion.ToString();
                txtMonto.Text = oAsignacionSelected.Monto.ToString();

            }
        }


        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNombre.Text == string.Empty)
            {
                txtNombre.BackColor = Color.Red;
                txtNombre.Focus();
                return false;
            }
            else
                txtNombre.BackColor = Color.White;
            if (txtMonto.Text == string.Empty)
            {
                txtMonto.BackColor = Color.Red;
                txtMonto.Focus();
                return false;
            }
            else
                txtNombre.BackColor = Color.White;

            int numero;
            if (Int32.TryParse(txtMonto.Text, out numero))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Debe ingresar datos númericos...");
                txtMonto.Clear();
                txtMonto.Focus();
                return false;
            }

            return true;
        }

        private bool ExisteAsignacion()
        {
            return oAsignacionService.ObtenerAsignacion(txtNombre.Text) != null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {

                        if (ExisteAsignacion() == false)
                        {

                            if (ValidarCampos())
                            {
                                var oAsignacion = new Asignacion();
                                oAsignacion.N_asignacion = txtNombre.Text;
                                oAsignacion.Monto = Convert.ToDouble(txtMonto.Text);


                                if (oAsignacionService.CrearAsignacion(oAsignacion))
                                {
                                    MessageBox.Show("Asignacion insertada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Nombre de asignacion encontrada!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oAsignacionSelected.Id_asignacion = int.Parse(txtId.Text);
                            oAsignacionSelected.N_asignacion = txtNombre.Text;
                            oAsignacionSelected.Monto = Convert.ToDouble(txtMonto.Text);

                            if (oAsignacionService.ActualizarAsignacion(oAsignacionSelected))
                            {
                                MessageBox.Show("Asignacion actualizada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la asignacion!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la asignacion seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oAsignacionService.BorrarAsignacion(oAsignacionSelected))
                            {
                                MessageBox.Show("Asignacion Habilitada/Deshabilitada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar la asignacion!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }
    }
}
