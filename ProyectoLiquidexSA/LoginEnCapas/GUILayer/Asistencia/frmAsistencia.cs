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
    public partial class frmAsistencia : Form
    {
        private AsistenciaService oAsistenciaService;
        private EstadosAsistenciaService oEstadosAsistenciaService;

        public frmAsistencia()
        {
            InitializeComponent();
            InitializeDataGridView();
            oAsistenciaService = new AsistenciaService();
            oEstadosAsistenciaService = new EstadosAsistenciaService();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmABMAsistencia frmABM = new frmABMAsistencia();
            var asistencia = (AsistenciaUsuarios)grdAsistencia.CurrentRow.DataBoundItem;
            frmABM.SeleccionarAsistencia(frmABMAsistencia.FormMode.update, asistencia);
            frmABM.ShowDialog();
            btnConsultar_Click(sender, e);
            this.habilitar(true);
            frmAsistencia_Load(sender, e);
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMAsistencia frmABM = new frmABMAsistencia();
            frmABM.ShowDialog();
            btnConsultar_Click(sender, e);
            habilitar(true);
            frmAsistencia_Load(sender, e);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones="";
            var filters = new Dictionary<string, object>();
            //usa filters para pasar los parámetros
            //usa condiciones para no usar parámetros en la consulta

            if (!chkTodos.Checked)
            {
                // Validar si el combo box 'Estados' esta seleccionado.
                if (cboEstados.Text != string.Empty)
                    {
                    // Si el combo tiene un estado seleccionado, la recuperamos con el value
                    filters.Add("a.id_estado_asistencia", cboEstados.SelectedValue);
                    condiciones += " AND e.id_estado_asistencia=" + cboEstados.SelectedValue.ToString();
                    cboEstados.SelectedIndex = -1;
                    
                }

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("u.usuario", txtNombre.Text);
                    condiciones += " AND u.usuario LIKE " +"'%"+  txtNombre.Text + "%'";
                    txtNombre.Clear();
                }

                if (filters.Count > 0)
                {
                    //si agrego alguna condicion
                    //SIN PARAMETROS

                    MessageBox.Show("condiciones para el where del sql " + condiciones, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    grdAsistencia.DataSource = oAsistenciaService.ConsultarConFiltrosSinParametros(condiciones);

                    //CON PARAMETROS
                    //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);
                }
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                //selecciono el checkbox(todos)
                grdAsistencia.DataSource = oAsistenciaService.ObtenerTodos();
        }

        private void frmAsistencia_Load(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.CenterToParent();
            this.cargarCombo(cboEstados,oEstadosAsistenciaService.ObtenerTodos(),"n_estados_asistencia", "id_estado_asistencia");
        }

        private void habilitar(bool x)
        {
            btnEditar.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnEliminar.Enabled = !x;
        }

        private void cargarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1; 
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    if (chkTodos.Checked)
                    {
                        txtNombre.Enabled = false;
                        cboEstados.Enabled = false;
                    }
                    else
                    {
                        txtNombre.Enabled = true;
                        cboEstados.Enabled = true;
                    }
                }
            }
        }

        private void grpFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdAsistencia.ColumnCount = 3;
            grdAsistencia.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdAsistencia.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdAsistencia.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdAsistencia.Columns[0].Name = "Nombre";
            grdAsistencia.Columns[0].DataPropertyName = "Usuario";
            // Definimos el ancho de la columna.

            grdAsistencia.Columns[1].Name = "Fecha";
            grdAsistencia.Columns[1].DataPropertyName = "Fecha";

            grdAsistencia.Columns[2].Name = "Estado";
            grdAsistencia.Columns[2].DataPropertyName = "EstadosAsistencia";



            // Cambia el tamaño de la altura de los encabezados de columna.
            grdAsistencia.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdAsistencia.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMAsistencia frmABM = new frmABMAsistencia();
            var asistencia = (AsistenciaUsuarios)grdAsistencia.CurrentRow.DataBoundItem;
            frmABM.SeleccionarAsistencia(frmABMAsistencia.FormMode.delete, asistencia);
            frmABM.ShowDialog();
            btnConsultar_Click(sender, e);
            frmAsistencia_Load(sender, e);
            
        }
    }

}
