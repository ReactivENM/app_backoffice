﻿using System;
using System.Windows.Forms;
using Controllers.TruckController;

namespace WindowsFormsApp1.Forms.Truck
{
    public partial class EditTruck : Form
    {
        private HandleTruck callback;
        private int id;

        public EditTruck(int id, string matricula, string marca, string modelo, double capacidad, HandleTruck callback)
        {
            InitializeComponent();
            inputCapacity.KeyPress += new KeyPressEventHandler(inputCapacity_KeyPress);
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

        private void inputCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese el carácter
            }
        }
    }
}
