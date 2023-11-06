using System;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.UserController;

namespace WindowsFormsApp1.Forms.User
{
    public partial class EditUser : Form
    {
        private HandleUser callback;
        private int id;

        public EditUser(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol, HandleUser callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.id = id;
            inputDocumento.KeyPress += new KeyPressEventHandler(inputDocumento_KeyPress);
            inputCorreo.Text = correo;
            inputPNombre.Text = p_nombre;
            inputSNombre.Text = s_nombre;
            inputPApellido.Text = p_apellido;
            inputSApellido.Text = s_apellido;
            inputDocumento.Text = nro_documento;
            inputNacionalidad.Text = nacionalidad;
            checkDisabled.Checked = deshabilitado == 0 ? false : true;
            inputRol.Text = rol;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string correo = inputCorreo.Text;
            string p_nombre = inputPNombre.Text;
            string s_nombre = inputSNombre.Text;
            string p_apellido = inputPApellido.Text;
            string s_apellido = inputSApellido.Text;
            string nro_documento = inputDocumento.Text;
            string nacionalidad = inputNacionalidad.Text;
            int deshabilitado = checkDisabled.Checked ? 1 : 0;
            string rol = inputRol.Text;

            UserController controller = new UserController();
            controller.Edit(id, correo, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, deshabilitado, rol);
            callback.OnEdit(id, correo, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, deshabilitado, rol);

            this.Close();
        }

        private bool validateFields()
        {
            string correo = inputCorreo.Text;
            string p_nombre = inputPNombre.Text;
            string s_nombre = inputSNombre.Text;
            string p_apellido = inputPApellido.Text;
            string s_apellido = inputSApellido.Text;
            string nro_documento = inputDocumento.Text;
            string nacionalidad = inputNacionalidad.Text;
            string rol = inputRol.Text;
            if (correo.Length == 0 || p_nombre.Length == 0 || p_apellido.Length == 0 || nacionalidad.Length == 0 || rol.Length == 0)
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
        
        private void inputDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
