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


namespace ProyectoLiquidexSA.GUILayer.Asistencia
{
    public partial class frmABMAsistencia : Form
    {
        private FormMode formMode = FormMode.insert;

        private readonly AsistenciaService oAsistenciaService;
        private readonly EstadosAsistenciaService oEstadosAsistenciaService;
        private AsistenciaUsuarios oAsistenciaUsuariosSelected;
        private UsuarioService oUsuarioService;


        public frmABMAsistencia()
        {
            InitializeComponent();
            oAsistenciaService = new AsistenciaService();
            oEstadosAsistenciaService = new EstadosAsistenciaService();
            oUsuarioService = new UsuarioService();

        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmABMAsistencia_Load(object sender, EventArgs e)
        {
            this.cargarCombo(cboUsuarios, oUsuarioService.ObtenerTodos(), "NombreUsuario", "IdUsuario");
            this.cargarCombo(cboEstados, oEstadosAsistenciaService.ObtenerTodos(), "n_estados_asistencia", "id_estado_asistencia");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nueva Asistencia";
                        cboUsuarios.Enabled = true;
                        dtpFecha.Enabled = true;
                        dtpHoraIngreso.Enabled = true;
                        dtpHoraSalida.Enabled = true;
                        cboEstados.Enabled = true;
                        txtComentario.Enabled = true;
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Asistencia";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        cboUsuarios.Enabled = false;
                        dtpFecha.Enabled = false;
                        dtpHoraIngreso.Enabled = true;
                        dtpHoraSalida.Enabled = true;
                        cboEstados.Enabled = true;
                        txtComentario.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        cboUsuarios.Enabled = false;
                        dtpFecha.Enabled = false;
                        dtpHoraIngreso.Enabled = false;
                        dtpHoraSalida.Enabled = false;
                        cboEstados.Enabled = false;
                        txtComentario.Enabled = false;
                        break;
                    }
            }
        }
        private void cargarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        public void SeleccionarAsistencia(FormMode op, AsistenciaUsuarios asistenciaUsuarioSelected)
        {
            formMode = op;
            oAsistenciaUsuariosSelected = asistenciaUsuarioSelected;
        }
        private void MostrarDatos()
        {
            if (oAsistenciaUsuariosSelected != null)
            {
                cboUsuarios.Text = oAsistenciaUsuariosSelected.Usuario.NombreUsuario;
                dtpFecha.Value = oAsistenciaUsuariosSelected.Fecha;
                dtpHoraIngreso.Value = oAsistenciaUsuariosSelected.Hora_ingreso;
                dtpHoraSalida.Value = oAsistenciaUsuariosSelected.Hora_salida;
                cboEstados.Text = oAsistenciaUsuariosSelected.EstadosAsistencia.N_estados_asistencia;
                txtComentario.Text = oAsistenciaUsuariosSelected.Comentario;
            }
        }
   

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ExisteAsistencia() == false)
                        {
                            if (ValidarCampos())
                            {
                                var oAsistenciaUsuarios = new AsistenciaUsuarios();
                                oAsistenciaUsuarios.Usuario = new Usuario();
                                oAsistenciaUsuarios.Usuario.IdUsuario = (int)cboUsuarios.SelectedValue;
                                oAsistenciaUsuarios.Fecha = dtpFecha.Value;
                                oAsistenciaUsuarios.Hora_ingreso = dtpHoraIngreso.Value;
                                oAsistenciaUsuarios.Hora_salida = dtpHoraSalida.Value;
                                oAsistenciaUsuarios.EstadosAsistencia = new EstadosAsistencia();
                                oAsistenciaUsuarios.EstadosAsistencia.Id_estado_asistencia = (int)cboEstados.SelectedValue;
                                oAsistenciaUsuarios.Comentario = txtComentario.Text;


                                if (oAsistenciaService.CrearAsistencia(oAsistenciaUsuarios))
                                {
                                    MessageBox.Show("Asistencia insertada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Asistencia encontrada!. Ingrese datos diferentes", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oAsistenciaUsuariosSelected.Usuario = new Usuario();
                            oAsistenciaUsuariosSelected.Usuario.IdUsuario = (int)cboUsuarios.SelectedValue;
                            oAsistenciaUsuariosSelected.Fecha = dtpFecha.Value;
                            oAsistenciaUsuariosSelected.Hora_ingreso = dtpHoraIngreso.Value;
                            oAsistenciaUsuariosSelected.Hora_salida = dtpHoraSalida.Value;
                            oAsistenciaUsuariosSelected.EstadosAsistencia = new EstadosAsistencia();
                            oAsistenciaUsuariosSelected.EstadosAsistencia.Id_estado_asistencia = (int)cboEstados.SelectedValue;
                            oAsistenciaUsuariosSelected.Comentario = txtComentario.Text;

                            if (oAsistenciaService.ActualizarAsistencia(oAsistenciaUsuariosSelected))
                            {
                                MessageBox.Show("Asistencia actualizada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la asistencia!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la asistencia seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oAsistenciaService.BorrarAsistencia(oAsistenciaUsuariosSelected))
                            {
                                MessageBox.Show("Asistencia Habilitada/Deshabilitada!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar la asistencia!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }


        }
        private bool ValidarCampos()
        {
            // campos obligatorios
            if (cboUsuarios.Text == string.Empty)
            {
                cboUsuarios.BackColor = Color.Red;
                cboUsuarios.Focus();
                return false;
            }
            else
                cboUsuarios.BackColor = Color.White;

            return true;
        }

        private bool ExisteAsistencia()
        {
            return oAsistenciaService.ObtenerAsistencia((int)cboUsuarios.SelectedValue, dtpFecha.Value) != null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
