﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.PackageLotController;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Lot
{
    public partial class AddPackageToLot : Form
    {
        private HandlePackageLot callback;
        private int id_lote;

        public AddPackageToLot(int id_lote, HandlePackageLot callback)
        {
            this.callback = callback;
            this.id_lote = id_lote;
            InitializeComponent();
            input_lote.Text = id_lote.ToString();
            input_lote.Enabled = false;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_interno_paquete = input_paquete.Text;

            PackageLotController controller = new PackageLotController();
            controller.Create(Convert.ToInt32(id_interno_paquete), id_lote);
            callback.OnCreate(Convert.ToInt32(id_interno_paquete), id_lote, 3, DateTime.Now.ToString());

            this.Close();
        }

        private bool validateFields()
        {
            string paquete = input_paquete.Text;
            if (paquete.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}