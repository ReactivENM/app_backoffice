using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.PackageController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Package
{
    public partial class EditPackage : Form
    {
        private HandlePackage callback;
        private int id;

        public EditPackage(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado, HandlePackage callback)
        {
            this.callback = callback;
            this.id = id_interno;
            InitializeComponent();
            input_peso.KeyPress += new KeyPressEventHandler(input_peso_KeyPress);
            input_id_externo.Text = id_externo;
            input_peso.Text = peso.ToString();
            input_dir_envio.Text = dir_envio;
            initializeFormAsync(id_cliente, estado);
        }

        private async void initializeFormAsync(int id_cliente, string estado)
        {
            await fetchData(id_cliente, estado);
        }

        private async Task fetchData(int id_cliente, string estado)
        {
            Dictionaries dictionaries = new Dictionaries();
            Dictionary<string, string> clientSelect = dictionaries.ClientName();
            input_cliente.DataSource = new BindingSource(clientSelect, null);
            input_cliente.DisplayMember = "Value";
            input_cliente.ValueMember = "Key";
            input_cliente.SelectedValue = id_cliente.ToString();

            Dictionary<string, string> statusSelect = dictionaries.PackageStatus();
            input_estado.DataSource = new BindingSource(statusSelect, null);
            input_estado.DisplayMember = "Value";
            input_estado.ValueMember = "Key";
            input_estado.SelectedValue = estado;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_externo = input_id_externo.Text;
            string id_cliente = input_cliente.SelectedValue.ToString();
            string peso = input_peso.Text;
            string dir_envio = input_dir_envio.Text;
            string estado = input_estado.SelectedValue.ToString();

            PackageController packageController = new PackageController();
            packageController.Edit(id, id_externo, Convert.ToInt32(id_cliente), Convert.ToDouble(peso), dir_envio, estado);
            callback.OnEdit(id, id_externo, Convert.ToInt32(id_cliente), Convert.ToDouble(peso), dir_envio, estado);

            this.Close();
        }

        private bool validateFields()
        {
            string id_externo = input_id_externo.Text;
            string id_cliente = input_cliente.SelectedValue.ToString();
            string peso = input_peso.Text;
            string dir_envio = input_dir_envio.Text;
            string estado = input_estado.Text;
            if (id_externo.Length == 0 || id_cliente.Length == 0 || peso.Length == 0 || dir_envio.Length == 0 || estado.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void input_peso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
