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
            this.callback = callback;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string calle = inputAddress.Text;
            string nro_puerta = inputNumber.Text;
            string cod_postal = inputPostalCode.Text;
            string capacidad = inputCapacity.Text;

            WareHouseController controller = new WareHouseController();
            int id = controller.Create(calle, nro_puerta, cod_postal, int.Parse(capacidad));
            callback.OnCreateWarehouse(id, calle, nro_puerta, cod_postal, capacidad.ToString());

            this.Close();
        }

        private bool validateFields()
        {
            string name = inputAddress.Text;
            string address = inputNumber.Text;
            if(name.Length == 0 || address.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
