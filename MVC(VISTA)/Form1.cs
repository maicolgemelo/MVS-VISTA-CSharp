using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace MVC_VISTA_
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null; //inicializa la instancia
        ClsContactoMgr objContactoMgr = null;//inicializa la instancia
        DataTable Dtt = null;//inicializa la instancia
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Listar() {

            objContacto = new ClsContacto();//completa la istancia
            objContacto.opc = 1;// settter
            objContactoMgr = new ClsContactoMgr(objContacto);//completa la istancia

            Dtt = new DataTable();// completa la istancia
            Dtt = objContactoMgr.Listar();

            if (Dtt.Rows.Count >0) {
                dtregistros.DataSource = Dtt;

            }


        }

        private void Guardar() {

            objContacto = new ClsContacto();
            objContacto.opc = 2;
            objContacto.Id = Convert.ToInt32(txtCodigo.Text);
            objContacto.Nombre = txtNombre.Text;
            objContacto.Telefono = txtTelefono.Text;
            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Guardado exitosamente", "Mensaje");



        }

        private void GuardarCambios()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 3;
            objContacto.Id = Convert.ToInt32(txtCodigo.Text);
            objContacto.Nombre = txtNombre.Text;
            objContacto.Telefono = txtTelefono.Text;
            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Cambios Guardados exitosamente", "Mensaje");

        }

        private void Eliminar() {

            objContacto = new ClsContacto();
            objContacto.opc = 4;
            objContacto.Id = Convert.ToInt32(txtCodigo.Text);
            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.EliminarDatos();
            MessageBox.Show("Registro eliminado exitosamente","Mensaje");




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
            btnGuardarCambios.Enabled = false;
            txtCodigo.Focus();
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos() {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCodigo.Focus();



        }

        private void dtregistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString();
            txtNombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txtTelefono.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();
            btnGuardar.Enabled = false;
            btnGuardarCambios.Enabled = true;
            txtCodigo.Enabled = false;
            btnEliminar.Enabled = true;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Listar();           
            btnGuardar.Enabled = true;
            btnGuardarCambios.Enabled = false;
            txtCodigo.Enabled = true;
            btnEliminar.Enabled = false;
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Listar();
            btnGuardar.Enabled = true;
            btnGuardarCambios.Enabled = false;
            txtCodigo.Enabled = true;           
            btnEliminar.Enabled = false;
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            Listar();
            btnGuardar.Enabled = true;
            btnGuardarCambios.Enabled = false;
            btnEliminar.Enabled = false;
            LimpiarCampos();
            txtCodigo.Focus();
        }
    }
}
    

