﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoLiquidexSA.GUILayer.Usuarios;
using ProyectoLiquidexSA.GUILayer.Asistencia;
using ProyectoLiquidexSA.GUILayer.Asignaciones;
using ProyectoLiquidexSA.GUILayer.Descuentos;
using ProyectoLiquidexSA.GUILayer.Sueldos;

namespace ProyectoLiquidexSA.GUILayer
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmLogin login = new frmLogin();
            login.ShowDialog();
            lblUsuarioLogueado.Text = login.UsuarioLogueado;
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rpta;
            rpta = MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.No)
                e.Cancel = true;
        }

        private void consultarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsistencia frmAsist = new frmAsistencia();
            frmAsist.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmDetalle = new frmUsuarios();
            frmDetalle.ShowDialog();
        }

        private void asignacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignaciones frmAsig = new frmAsignaciones();
            frmAsig.ShowDialog();
        }

        private void descuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDescuento frmDto = new frmDescuento();
            frmDto.ShowDialog();
        }

        private void generarSueldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSueldos frmS = new frmSueldos();
            frmS.ShowDialog();
        }
    }

}
