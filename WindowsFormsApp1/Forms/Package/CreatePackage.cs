﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.PackageController;
using WindowsFormsApp1.Controllers.WarehouseController;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Package
{
    public partial class CreatePackage : Form
    {
        private HandlePackage callback;

        public CreatePackage(HandlePackage callback)
        {
            this.callback = callback;
            initializeFormAsync();
        }

        private async void initializeFormAsync()
        {
            InitializeComponent();
            await fetchWarehouse();
        }

        private async Task fetchWarehouse()
        {
            Dictionaries dictionaries = new Dictionaries();
            Dictionary<string, string> warehouseSelect = dictionaries.DepartmentByWarehouseID();
            input_almacen.DataSource = new BindingSource(warehouseSelect, null);
            input_almacen.DisplayMember = "Value";
            input_almacen.ValueMember = "Key";

            Dictionary<string, string> statusSelect = dictionaries.PackageStatus();
            input_estado.DataSource = new BindingSource(statusSelect, null);
            input_estado.DisplayMember = "Value";
            input_estado.ValueMember = "Key";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_externo = input_id_externo.Text;
            string id_almacen = input_almacen.SelectedValue.ToString();
            string peso = input_peso.Text;
            string descripcion = input_descripcion.Text;
            string dir_envio = input_dir_envio.Text;
            string estado = input_estado.SelectedValue.ToString();

            PackageController controller = new PackageController();
            int id_interno = controller.Create(id_externo, Convert.ToInt32(id_almacen), Convert.ToDouble(peso), descripcion, dir_envio, estado);
            callback.OnCreate(id_interno, id_externo, Convert.ToInt32(id_almacen), Convert.ToDouble(peso), descripcion, dir_envio, estado);

            this.Close();
        }

        private bool validateFields()
        {
            string id_externo = input_id_externo.Text;
            string id_almacen = input_almacen.SelectedValue.ToString();
            string peso = input_peso.Text;
            string descripcion = input_descripcion.Text;
            string dir_envio = input_dir_envio.Text;
            string estado = input_estado.Text;
            if (id_externo.Length == 0 || id_almacen.Length == 0 || peso.Length == 0 || descripcion.Length == 0 || dir_envio.Length == 0 || estado.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}