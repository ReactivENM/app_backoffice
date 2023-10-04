﻿using System;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.UserController;

namespace WindowsFormsApp1.Forms.User
{
    public partial class EditUser : Form
    {
        private HandleUser callback;
        private int id;

        public EditUser(int id, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, string rol, HandleUser callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.id = id;
            inputPNombre.Text = p_nombre;
            inputSNombre.Text = s_nombre;
            inputPApellido.Text = p_apellido;
            inputSApellido.Text = s_apellido;
            inputDocumento.Text = nro_documento;
            inputNacionalidad.Text = nacionalidad;
            inputRol.Text = rol;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string p_nombre = inputPNombre.Text;
            string s_nombre = inputSNombre.Text;
            string p_apellido = inputPApellido.Text;
            string s_apellido = inputSApellido.Text;
            string nro_documento = inputDocumento.Text;
            string nacionalidad = inputNacionalidad.Text;
            string rol = inputRol.Text;

            UserController controller = new UserController();
            Console.WriteLine("start");
            controller.Edit(id, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol);
            callback.OnEdit(id, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, rol);
            Console.WriteLine("end");

            this.Close();
        }

        private bool validateFields()
        {
            string p_nombre = inputPNombre.Text;
            string s_nombre = inputSNombre.Text;
            string p_apellido = inputPApellido.Text;
            string s_apellido = inputSApellido.Text;
            string nro_documento = inputDocumento.Text;
            string nacionalidad = inputNacionalidad.Text;
            string rol = inputRol.Text;
            if (p_nombre.Length == 0 || s_nombre.Length == 0 || p_apellido.Length == 0 || s_apellido.Length == 0 || nacionalidad.Length == 0 || rol.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nro_documento.Length > 12)
            {
                MessageBox.Show("Nº de documento debe ser menor a 12 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}