using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.WarehouseController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Warehouse
{
    public partial class EditWarehouse : Form
    {
        private HandleWarehouse callback;
        private int id;

        public EditWarehouse(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento, HandleWarehouse callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.id = id;
            inputDescripcion.Text = descripcion;
            inputAddress.Text = calle;
            inputNumber.Text = nro_puerta;
            inputPostalCode.Text = cod_postal;
            inputCapacity.Text = capacidad;

            Dictionaries dictionaries = new Dictionaries();
            Dictionary<string, string> departmentsSelect = dictionaries.Departments();
            inputDepartamento.DataSource = new BindingSource(departmentsSelect, null);
            inputDepartamento.DisplayMember = "Value";
            inputDepartamento.ValueMember = "Key";
            inputDepartamento.SelectedValue = departamento;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string descripcion = inputDescripcion.Text;
            string calle = inputAddress.Text;
            string nro_puerta = inputNumber.Text;
            string cod_postal = inputPostalCode.Text;
            int capacidad = int.Parse(inputCapacity.Text);
            string departamento = inputDepartamento.SelectedValue.ToString();

            WareHouseController controller = new WareHouseController();
            controller.Edit(id, descripcion, calle, nro_puerta, cod_postal, capacidad, departamento);
            callback.OnEdit(id, descripcion, calle, nro_puerta, cod_postal, capacidad.ToString(), departamento);

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
    }
}
