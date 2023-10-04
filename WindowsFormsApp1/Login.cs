using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //bool validCredentials = await validateCredentialsAsync();
            //if(!validCredentials)
            //{
            //     ThrowErrorMessage("Las credenciales que ingresaste son incorrectas!", "Error de validación");
            //     return;
            //}

            Hide();
            new Backoffice().Show();  
        }

        public class AuthResponse
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }
        }

        private async Task<bool> validateCredentialsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63375/");

                Dictionary<string, string> jsonContent = new Dictionary<string, string>();
                jsonContent.Add("username", inputUser.Text);
                jsonContent.Add("password", inputPassword.Text);
                StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(jsonContent), UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/v1/auth/login", bodyContent);

                string jsonString = await response.Content.ReadAsStringAsync();

                AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(JsonConvert.DeserializeObject<string>(jsonString));

                string code = authResponse.Code;
                if (code == "LOGIN_SUCCESS") return true;
            }
            return false;
        }

        private bool validateFields()
        {
            if (inputUser.Text.Length == 0)
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
