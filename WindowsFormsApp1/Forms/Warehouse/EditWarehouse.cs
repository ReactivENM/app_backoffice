using System;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.Warehouse;

namespace WindowsFormsApp1.Forms.Warehouse
{
    public partial class EditWarehouse : Form
    {
        private HandleWarehouse callback;
        private int id;

        public EditWarehouse(int id, string calle, string nro_puerta, string cod_postal, string capacidad, HandleWarehouse callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.id = id;
            inputStreet.Text = calle;
            inputNumber.Text = nro_puerta;
            InputPostalCode.Text = cod_postal;
            inputCapacity.Text = capacidad;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string calle = inputStreet.Text;
            string nro_puerta = inputNumber.Text;
            string cod_postal = InputPostalCode.Text;
            int capacidad = int.Parse(inputCapacity.Text);

            WareHouseController controller = new WareHouseController();
            controller.Edit(id, calle, nro_puerta, cod_postal, capacidad);
            callback.OnEditWarehouse(id, calle, nro_puerta, cod_postal, capacidad.ToString());

            this.Close();
        }

        private bool validateFields()
        {
            string calle = inputStreet.Text;
            string nro_puerta = inputNumber.Text;
            string cod_postal = InputPostalCode.Text;
            string capacidad = inputCapacity.Text;
            if (calle.Length == 0 || nro_puerta.Length == 0 || cod_postal.Length == 0 || capacidad.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
