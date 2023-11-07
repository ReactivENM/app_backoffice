using System;
using System.Windows.Forms;
using Controllers.UserController;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            bool passedValidation = validateFields();
            if (!passedValidation) return;

            bool validCredentials = validateCredentials();
            if(!validCredentials)
            {
                 ThrowErrorMessage("Las credenciales que ingresaste son incorrectas!", "Error de validación");
                 return;
            }
            
            Hide();
            new Backoffice().Show();  
        }

        private bool validateCredentials()
        {
            string correo = inputEmail.Text;
            string contrasena = inputPassword.Text;

            UserController controller = new UserController();
            bool res = controller.Login(correo, contrasena);

            return res;
        }

        private bool validateFields()
        {
            if (inputEmail.Text.Length == 0)
            {
                ThrowErrorMessage("Debes escribir un nombre de usuario!", "Error de validación");
                return false;
            }
            if (inputPassword.Text.Length == 0)
            {
                ThrowErrorMessage("Debes escribir una contraseña!", "Error de validación");
                return false;
            }

            return true;
        }

        private static void ThrowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
