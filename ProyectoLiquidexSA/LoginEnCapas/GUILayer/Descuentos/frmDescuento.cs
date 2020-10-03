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
    public partial class frmDescuento : Form
    {
        private DescuentoService oDescuentoService;
        
        public frmDescuento()
        {
            InitializeComponent();
            InitializeDataGridView();
            oDescuentoService = new DescuentoService();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMCDescuento frmABMC = new frmABMCDescuento();
            var descuento = (Descuento)grdDescuento.CurrentRow.DataBoundItem;
            frmABMC.SeleccionarDescuento(frmABMCDescuento.FormMode.update, descuento);
            frmABMC.ShowDialog();
            btnConsultarDescuento_Click(sender, e);
            this.habilitar(true);
            frmDescuento_Load(sender, e);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMCDescuento frmABM = new frmABMCDescuento();
            frmABM.ShowDialog();
            btnConsultarDescuento_Click(sender, e);
            habilitar(true);
            frmDescuento_Load(sender, e);
            this.txtNombreDescuento.Focus();
        }

        private void btnConsultarDescuento_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            var filters = new Dictionary<string, object>();
            //usa filters para pasar los parámetros
            //usa condiciones para no usar parámetros en la consulta

            if (!checkBoxTodos.Checked)
            {
                //// Validar si el combo box 'Estados' esta seleccionado.
                //if (cboMontoDescuento.Text != string.Empty)
                //{
                //    // Si el combo tiene un estado seleccionado, la recuperamos con el value
                //    filters.Add("a.monto", cboMontoDescuento.SelectedValue);
                //    condiciones += " AND d.monto=" + cboMontoDescuento.SelectedValue.ToString();
                //    cboMontoDescuento.SelectedIndex = -1;

                //}

                if (txtMontoDescuento.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("d.monto", txtMontoDescuento.Text);
                    condiciones += " AND d.monto LIKE " + "'%" + txtMontoDescuento.Text + "%'";
                    txtNombreDescuento.Clear();
                }


                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombreDescuento.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("d.n_descuento", txtNombreDescuento.Text);
                    condiciones += " AND d.n_descuento LIKE " + "'%" + txtNombreDescuento.Text + "%'";
                    txtNombreDescuento.Clear();
                }

                if (filters.Count > 0)
                {
                    //si agrego alguna condicion
                    //SIN PARAMETROS

                    MessageBox.Show("condiciones para el where del sql " + condiciones, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    grdDescuento.DataSource = oDescuentoService.ConsultarConFiltrosSinParametros(condiciones);

                    //CON PARAMETROS
                    //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);
                }
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                //selecciono el checkbox(todos)
                grdDescuento.DataSource = oDescuentoService.ObtenerTodos();

            txtNombreDescuento.Clear();
            txtMontoDescuento.Clear();
        }

        private void frmDescuento_Load(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.CenterToParent();
            //this.cargarCombo(cboMontoDescuento,oDescuentoService.ObtenerTodos(),"Monto", "Id_descuento");
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

        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    if (checkBoxTodos.Checked)
                    {
                        txtNombreDescuento.Enabled = false;
                        txtMontoDescuento.Enabled = false;
                    }
                    else
                    {
                        txtNombreDescuento.Enabled = true;
                        txtMontoDescuento.Enabled = true;
                    }
                }
            }
        }

        private void grdDescuento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdDescuento.ColumnCount = 3;
            grdDescuento.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdDescuento.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdDescuento.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdDescuento.Columns[0].Name = "Numero";
            grdDescuento.Columns[0].DataPropertyName = "Id_descuento";
            // Definimos el ancho de la columna.

            grdDescuento.Columns[1].Name = "Nombre";
            grdDescuento.Columns[1].DataPropertyName = "N_descuento";

            grdDescuento.Columns[2].Name = "Monto";
            grdDescuento.Columns[2].DataPropertyName = "Monto";



            // Cambia el tamaño de la altura de los encabezados de columna.
            grdDescuento.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdDescuento.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMCDescuento frmABM = new frmABMCDescuento();
            var asistencia = (Descuento)grdDescuento.CurrentRow.DataBoundItem;
            frmABM.SeleccionarDescuento(frmABMCDescuento.FormMode.delete, asistencia);
            frmABM.ShowDialog();
            btnConsultarDescuento_Click(sender, e);
            frmDescuento_Load(sender, e);
        }

        private void txtMontoDescuento_TextChanged(object sender, EventArgs e)
        {
            double x;
            if (txtMontoDescuento.Text != "" )
            {
                int numero;
                if (Int32.TryParse(txtMontoDescuento.Text, out numero))
                {
                    x = Convert.ToDouble(txtMontoDescuento.Text);
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad numérica...");
                    this.txtMontoDescuento.Clear();
                    txtMontoDescuento.Focus();
                }  
            
            }
        }
    }
}
