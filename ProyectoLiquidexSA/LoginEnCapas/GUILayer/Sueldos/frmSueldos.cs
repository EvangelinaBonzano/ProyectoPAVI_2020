using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.BusinessLayer;


namespace ProyectoLiquidexSA.GUILayer.Sueldos
{
    public partial class frmSueldos : Form
    {
        
        private readonly AsignacionService oAsignacionService;
        private readonly UsuarioService oUsuarioService;
        private readonly DescuentoService oDescuentoService;
        private readonly SueldoService sueldoService;
        private readonly BindingList<SueldoAsignaciones> listaAsignaciones;
        private readonly BindingList<SueldoDescuentos> listaDescuentos;

        public frmSueldos()
        {
            InitializeComponent();
            oAsignacionService = new AsignacionService();
            oUsuarioService = new UsuarioService();
            oDescuentoService = new DescuentoService();
            sueldoService = new SueldoService();
            listaAsignaciones = new BindingList<SueldoAsignaciones>();
            listaDescuentos = new BindingList<SueldoDescuentos>();
            dgvAsignaciones.AutoGenerateColumns = false;
            dgvDescuentos.AutoGenerateColumns = false;

        }


        private void frmSueldos_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.cargarCombo(cboUsuarios, oUsuarioService.ObtenerTodos(), "NombreUsuario", "IdUsuario");
            this.cargarCombo(cboAsignaciones, oAsignacionService.ObtenerTodos(), "N_asignacion", "Id_asignacion");
            this.cargarCombo(cboDescuentos, oDescuentoService.ObtenerTodos(), "N_descuento", "Id_descuento");
            dgvAsignaciones.DataSource = listaAsignaciones;
            dgvDescuentos.DataSource = listaDescuentos;
            this.cboAsignaciones.SelectedIndexChanged += new System.EventHandler(this.cboAsignaciones_SelectedIndexChanged);
            this.cboDescuentos.SelectedIndexChanged += new System.EventHandler(this.cboDescuentos_SelectedIndexChanged);
        }
        private void cargarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAsignaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAsignaciones.SelectedItem != null)
            {
                var asignacion = (Asignacion)cboAsignaciones.SelectedItem;
                txtMontoA.Text = asignacion.Monto.ToString();
                txtCantidadA.Enabled = true;
                btnAgregarA.Enabled = true;
            }
            else
            {
                btnAgregarA.Enabled = false;
                txtCantidadA.Enabled = false;
                txtCantidadA.Text = "";
                txtMontoA.Text = "";
                txtImporteA.Text = "";
            }
        }

        private void txtCantidadA_TextChanged(object sender, EventArgs e)
        {
            
            if (cboAsignaciones.SelectedItem != null)
            {
                int cantidad = 0;
                int.TryParse(txtCantidadA.Text, out cantidad);
                var asignacion = (Asignacion)cboAsignaciones.SelectedItem;
                txtImporteA.Text = (asignacion.Monto * cantidad).ToString();

            }
        }

       
        private double calcularTotal()
        {

            double total = 0;
            for (int i = 0; i < dgvAsignaciones.Rows.Count; i++)
            {
                total += Convert.ToDouble(dgvAsignaciones.Rows[i].Cells[3].Value);
            }
            for (int i = 0; i < dgvDescuentos.Rows.Count; i++)
            {
                total -= Convert.ToDouble(dgvDescuentos.Rows[i].Cells[3].Value);
            }
            return total;

        }

        private void inicializarFormulario()
        {
            cboUsuarios.SelectedIndex = -1;
            inicializarDetalleAsignacion();
            inicializarDetalleDescuento();
            dgvAsignaciones.Rows.Clear();
            dgvDescuentos.Rows.Clear();
            txtSueldoBruto.Text = calcularTotal().ToString();

        }

        private void inicializarDetalleAsignacion()
        {
            cboAsignaciones.SelectedIndex = -1;
            txtCantidadA.Text = "";
            txtMontoA.Text = 0.ToString("N2");
            txtImporteA.Text = 0.ToString("N2");
            
            txtSueldoBruto.Text = calcularTotal().ToString();
        }
        private void inicializarDetalleDescuento()
        {
            cboDescuentos.SelectedIndex = -1;
            txtCantidadD.Text = "";
            txtMontoD.Text = 0.ToString("N2");
            txtImporteD.Text = 0.ToString("N2");
            
            txtSueldoBruto.Text = calcularTotal().ToString();
        }

        private void btnAgregarA_Click_1(object sender, EventArgs e)
        {

            int cantidad = 0;
            int.TryParse(txtCantidadA.Text, out cantidad);
            var asignacion = (Asignacion)cboAsignaciones.SelectedItem;
            var usuario = (Usuario)cboUsuarios.SelectedItem;
            var monto = Convert.ToDouble(txtMontoA.Text);
            var fecha = dtpFecha.Value;
            listaAsignaciones.Add(new SueldoAsignaciones()
            {
                Id_usuario = usuario.IdUsuario,
                Fecha = fecha,
                Asignacion = asignacion,
                Monto = monto,
                Cantidad = cantidad,

            });

            
            inicializarDetalleAsignacion();
        }

        private void btnQuitarA_Click_1(object sender, EventArgs e)
        {

            if (dgvAsignaciones.CurrentRow != null)
            {
                var detalleSeleccionado = (SueldoAsignaciones)dgvAsignaciones.CurrentRow.DataBoundItem;
                listaAsignaciones.Remove(detalleSeleccionado);
                txtSueldoBruto.Text = calcularTotal().ToString();
            }
        }

        private void btnCancelarA_Click_1(object sender, EventArgs e)
        {
            inicializarDetalleAsignacion();
        }

        private void btnAgregarD_Click_1(object sender, EventArgs e)
        {

            int cantidad = 0;
            int.TryParse(txtCantidadD.Text, out cantidad);
            var descuento = (Descuento)cboDescuentos.SelectedItem;
            var usuario = (Usuario)cboUsuarios.SelectedItem;
            var monto = Convert.ToDouble(txtMontoD.Text);
            var fecha = dtpFecha.Value;
            listaDescuentos.Add(new SueldoDescuentos()
            {
                Id_usuario = usuario.IdUsuario,
                Fecha = fecha,
                Descuento = descuento,
                Monto = monto,
                Cantidad = cantidad,

            });

            
            inicializarDetalleDescuento();
            
        }

        private void btnQuitarD_Click_1(object sender, EventArgs e)
        {


            if (dgvDescuentos.CurrentRow != null)
            {
                var detalleSeleccionado = (SueldoDescuentos)dgvDescuentos.CurrentRow.DataBoundItem;
                listaDescuentos.Remove(detalleSeleccionado);
            }
            
            txtSueldoBruto.Text = calcularTotal().ToString();
        }

        private void btnCancelarD_Click_1(object sender, EventArgs e)
        {
            inicializarDetalleDescuento();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var sueldo = new Entities.Sueldos
                {
                        Fecha = dtpFecha.Value,
                        Usuario = (Usuario)cboUsuarios.SelectedItem,
                        Sueldo_bruto = Convert.ToDouble(txtSueldoBruto.Text),
                        SueldoAsignaciones = listaAsignaciones,
                        SueldoDescuentos = listaDescuentos

                };


                if (sueldoService.ValidarDatos(sueldo))
                {
                        sueldoService.Crear(sueldo);

                        MessageBox.Show(string.Concat("El sueldo de: ", sueldo.Usuario.NombreUsuario, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        inicializarFormulario();
                }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el sueldo! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private bool ValidarDatos()
        {
            return true;
        }
    

        private void txtCantidadD_TextChanged_1(object sender, EventArgs e)
        {
            if (cboDescuentos.SelectedItem != null)
            {
                int cantidad = 0;
                int.TryParse(txtCantidadD.Text, out cantidad);
                var descuento = (Descuento)cboDescuentos.SelectedItem;
                txtImporteD.Text = (descuento.Monto * cantidad).ToString();
            }

        }

        private void cboDescuentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDescuentos.SelectedItem != null)
            {
                var descuento = (Descuento)cboDescuentos.SelectedItem;
                txtMontoD.Text = descuento.Monto.ToString();
                txtCantidadD.Enabled = true;
                btnAgregarD.Enabled = true;
            }
            else
            {
                btnAgregarD.Enabled = false;
                txtCantidadD.Enabled = false;
                txtCantidadD.Text = "";
                txtMontoD.Text = "";
                txtImporteD.Text = "";
            }
        }

        private void txtCantidadA_Validated(object sender, EventArgs e)
        {

        }

        private void txtCantidadA_Validating(object sender, CancelEventArgs e)
        {
            int numero;
            if (Int32.TryParse(txtCantidadA.Text, out numero) && int.Parse(txtCantidadA.Text) > 0)
            {
                txtCantidadA_TextChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Debe ingresar una cantidad numérica positiva... ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidadA.Text = "";
            }
        }

        private void txtCantidadD_Validating(object sender, CancelEventArgs e)
        {
            int numero;
            if (Int32.TryParse(txtCantidadD.Text, out numero) && int.Parse(txtCantidadD.Text) > 0)
            {
                txtCantidadD_TextChanged_1(sender, e);
            }
            else
            {
                MessageBox.Show("Debe ingresar una cantidad numérica positiva... ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidadD.Text = "";
            }
        }

        private void lblAsignacion_Click(object sender, EventArgs e)
        {

        }
    }
}

