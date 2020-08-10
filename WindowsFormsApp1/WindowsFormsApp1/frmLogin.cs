using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
<<<<<<< HEAD
{
=======
{ // comentario algo
>>>>>>> 27e8692ee22c8e88a740f7e5fe2d08d1989f71d3
    public partial class frmLogin : Form
    {
        string user = "admin";
        string pass = "1234";


        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        { //if (this.txtUsuario.Text=="")

          if (this.txtUsuario.Text == string.Empty)
          {
                MessageBox.Show("Debe ingresar usuario...");
                this.txtUsuario.Focus();
                return;

           }
           //if (this.txtClave.Text=="")
           if (string.IsNullOrEmpty(this.txtClave.Text))
            { 
                MessageBox.Show("Debe ingresar clave...");
                this.txtClave.Focus();
                return;
            
            }
            //Validar usuario y clave
            string msj = "";
            if (this.txtUsuario.Text == this.user && this.txtClave.Text == this.pass)
            {
                msj = "Login OK";

                MessageBox.Show(msj, "Ingreso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                msj = "Usuario y/o clave incorrectos";

                MessageBox.Show(msj, "Ingreso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUsuario.Text = "";
                this.txtClave.Text = string.Empty;
                this.txtUsuario.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}  
