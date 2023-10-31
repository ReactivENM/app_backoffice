using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.TruckController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Truck
{
    public partial class EditTruck : Form
    {
        private HandleTruck callback;
        private int id;

        public EditTruck(int id, string matricula, string marca, string modelo, double capacidad, HandleTruck callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.id = id;
            inputMatricula.Text = matricula;
            inputMarca.Text = marca;
            inputModelo.Text = modelo;
            inputCapacity.Text = capacidad.ToString();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string matricula = inputMatricula.Text;
            string marca = inputMarca.Text;
            string modelo = inputModelo.Text;
            double capacidad = double.Parse(inputCapacity.Text);

            TruckController controller = new TruckController();
            controller.Edit(id, matricula, marca, modelo, capacidad);
            callback.OnEditWarehouse(id, matricula, marca, modelo, capacidad);

            this.Close();
        }

        private bool validateFields()
        {
            string matricula = inputMatricula.Text;
            string marca = inputMarca.Text;
            string modelo = inputModelo.Text;
            string capacidad = inputCapacity.Text;
            if (matricula.Length == 0 || marca.Length == 0 || modelo.Length == 0 || capacidad.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (matricula.Length > 8)
            {
                MessageBox.Show("La matricula debe ser menor o igual a 15 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (marca.Length > 15)
            {
                MessageBox.Show("La marca debe ser menor o igual a 15 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (modelo.Length > 15)
            {
                MessageBox.Show("El modelo debe ser menor o igual a 15 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
