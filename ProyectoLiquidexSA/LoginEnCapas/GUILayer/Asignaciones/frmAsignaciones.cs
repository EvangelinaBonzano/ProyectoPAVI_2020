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
    public partial class frmAsignaciones : Form
    {
        private AsignacionService oAsignacionService;
        public frmAsignaciones()
        {
            InitializeComponent();
            InitializeDataGridView();
            oAsignacionService = new AsignacionService();

        }

        private void frmAsignaciones_Load(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.CenterToParent();
            this.cargarCombo(cboNombre, oAsignacionService.ObtenerTodos(), "n_asignacion", "id_asignacion");
        }

        private void cargarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void habilitar(bool x)
        {
            btnEditar.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnEliminar.Enabled = !x;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMAsignaciones frmABMA = new frmABMAsignaciones();
            frmABMA.ShowDialog();
            habilitar(true);
            btnConsultar_Click(sender, e);
            frmAsignaciones_Load(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMAsignaciones frmABMA = new frmABMAsignaciones();
            var asignacion = (Asignacion)dgvAsignaciones.CurrentRow.DataBoundItem;
            frmABMA.SeleccionarAsignacion(frmABMAsignaciones.FormMode.update, asignacion);
            frmABMA.ShowDialog();
            btnConsultar_Click(sender, e);
            this.habilitar(true);
            frmAsignaciones_Load(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvAsignaciones.ColumnCount = 2;
            dgvAsignaciones.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvAsignaciones.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvAsignaciones.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvAsignaciones.Columns[0].Name = "Nombre";
            dgvAsignaciones.Columns[0].DataPropertyName = "N_asignacion";
            // Definimos el ancho de la columna.

            dgvAsignaciones.Columns[1].Name = "Monto";
            dgvAsignaciones.Columns[1].DataPropertyName = "Monto";

           

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvAsignaciones.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvAsignaciones.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkTodos.Checked)
                {
                    cboNombre.Enabled = false; 
                }
                else
                {
                    cboNombre.Enabled = true; 
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();
            //usa filters para pasar los parámetros
            //usa condiciones para no usar parámetros en la consulta

            if (!chkTodos.Checked)
            {
               
                // Validar si el textBox 'Nombre' esta vacio.
                if (cboNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("id_asignacion", cboNombre.SelectedValue);
                    condiciones += " AND id_asignacion=" + cboNombre.SelectedValue.ToString();
                    cboNombre.SelectedIndex = -1;
                }

                if (filters.Count > 0)
                {
                    //si agrego alguna condicion
                    //SIN PARAMETROS

                    MessageBox.Show("condiciones para el where del sql " + condiciones, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    dgvAsignaciones.DataSource = oAsignacionService.ConsultarConFiltrosSinParametros(condiciones);

                    //CON PARAMETROS
                    //dgvAsignaciones.DataSource = oAsignacionService.ConsultarConFiltrosConParametros(filters);
                }
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                //selecciono el checkbox(todos)
                dgvAsignaciones.DataSource = oAsignacionService.ObtenerTodos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMAsignaciones frmABMA = new frmABMAsignaciones();
            var asignacion = (Asignacion)dgvAsignaciones.CurrentRow.DataBoundItem;
            frmABMA.SeleccionarAsignacion(frmABMAsignaciones.FormMode.delete, asignacion);
            frmABMA.ShowDialog();
            btnConsultar_Click(sender, e);
            frmAsignaciones_Load(sender, e);
        }
    }
}
