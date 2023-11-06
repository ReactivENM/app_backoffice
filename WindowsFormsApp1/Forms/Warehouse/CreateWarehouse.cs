using System;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.WarehouseController;

namespace WindowsFormsApp1.Forms.Warehouse
{
    public partial class CreateWarehouse : Form
    {
        private HandleWarehouse callback;

        public CreateWarehouse(HandleWarehouse callback)
        {
            InitializeComponent();
            inputCapacity.KeyPress += new KeyPressEventHandler(inputCapacity_KeyPress);
            this.callback = callback;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string descripcion = inputDescripcion.Text;
            string calle = inputAddress.Text;
            string nro_puerta = inputNumber.Text;
            string cod_postal = inputPostalCode.Text;
            string capacidad = inputCapacity.Text;
            string departamento = inputDeparamento.Text;

            WareHouseController controller = new WareHouseController();
            int id = controller.Create(descripcion, calle, nro_puerta, cod_postal, int.Parse(capacidad), departamento);
            callback.OnCreate(id, descripcion, calle, nro_puerta, cod_postal, capacidad.ToString(), departamento);

            this.Close();
        }

        private bool validateFields()
        {
            string calle = inputAddress.Text;
            string nro_puerta = inputNumber.Text;
            string cod_postal = inputPostalCode.Text;
            string capacidad = inputCapacity.Text;
            if (calle.Length == 0 || nro_puerta.Length == 0 || cod_postal.Length == 0 || capacidad.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (calle.Length > 30)
            {
                MessageBox.Show("La dirección debe ser menor o igual a 30 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nro_puerta.Length > 4)
            {
                MessageBox.Show("Número de puerta debe ser menor o igual a 4 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cod_postal.Length > 5)
            {
                MessageBox.Show("El código postal debe ser menor o igual a 5 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void inputCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
