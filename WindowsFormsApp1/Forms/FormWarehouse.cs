﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Models.WareHouseModel;
using Controllers.WarehouseController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms
{
    public interface HandleWarehouse
    {
        void OnCreate(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento);
        void OnEdit(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento);
    }

    public partial class FormWarehouse : Form, HandleWarehouse
    {
        List<WareHouseModel> wareHouseData = new List<WareHouseModel>();
        private int wareHouseLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        WareHouseModel selectedWarehouse = null;
        private Dictionary<string, string> departmentsDictionary;

        public FormWarehouse()
        {
            Dictionaries dictionaries = new Dictionaries();
            departmentsDictionary = dictionaries.Departments();
            initializeFormAsync();
        }

        public async void initializeFormAsync()
        {
            InitializeComponent();

            await fetchWareHouseData();

            int lastPageRes = (int)Math.Ceiling((double)wareHouseLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage.ToString();

            // Load mock data on dataGrid
            showRows(actualPage);
            // On double click dataGrid row
            dataGridView.CellClick += new DataGridViewCellEventHandler(handleClickRow);

            // Update buttons image when disabled/enabled
            UpdateButtonImage(btnEditWarehouse, "../../Icons/edit.png", "../../Icons/disabled/edit.png");
            UpdateButtonImage(btnDeleteWarehouse, "../../Icons/delete.png", "../../Icons/disabled/delete.png");
        }

        public async Task fetchWareHouseData()
        {
            try
            {
                WareHouseController wh = new WareHouseController();
                List<WareHouseModel> warehouses = wh.GetAll();
                foreach (WareHouseModel warehouse in warehouses)
                {
                    wareHouseData.Add(warehouse);
                }
                wareHouseLength = warehouses.Count;
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
            
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > wareHouseLength ? wareHouseLength : page * rowsPerPage); i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                string department = departmentsDictionary.ContainsKey(wareHouseData[i].departamento) ? departmentsDictionary[wareHouseData[i].departamento] : wareHouseData[i].departamento;
                newRow.CreateCells(dataGridView, wareHouseData[i].id, wareHouseData[i].descripcion, wareHouseData[i].calle, wareHouseData[i].nro_puerta, wareHouseData[i].cod_postal, wareHouseData[i].capacidad, department);
                dataGridView.Rows.Add(newRow);
            }
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id = row.Cells["id"].Value;
                WareHouseModel wh = wareHouseData.Find(d => d.id == Convert.ToInt32(id));
                selectedWarehouse = wh;
                btnEditWarehouse.Enabled = true;
                btnDeleteWarehouse.Enabled = true;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (wareHouseLength == 0) return;
            if (actualPage == 1) return;

            actualPage = actualPage - 1;
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedWarehouse = null;
            btnEditWarehouse.Enabled = false;
            btnDeleteWarehouse.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (wareHouseLength == 0) return;
            if (actualPage == lastPage) return;

            actualPage = actualPage + 1;
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedWarehouse = null;
            btnEditWarehouse.Enabled = false;
            btnDeleteWarehouse.Enabled = false;
        }

        private void btnCreateWarehouse_Click(object sender, EventArgs e)
        {
            new Forms.Warehouse.CreateWarehouse(this).ShowDialog();
        }

        public void OnCreate(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento)
        {
            WareHouseModel wh = new WareHouseModel(id, descripcion, calle, nro_puerta, cod_postal, capacidad, departamento);
            wareHouseData.Add(wh);
            wareHouseLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)wareHouseLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedWarehouse = null;
            btnEditWarehouse.Enabled = false;
            btnDeleteWarehouse.Enabled = false;
        }

        private void btnEditWarehouse_Click(object sender, EventArgs e)
        {
            Form warehouse = new Forms.Warehouse.EditWarehouse(selectedWarehouse.id, selectedWarehouse.descripcion, selectedWarehouse.calle, selectedWarehouse.nro_puerta, selectedWarehouse.cod_postal, selectedWarehouse.capacidad, selectedWarehouse.departamento, this);
            warehouse.ShowDialog();
        }

        public void OnEdit(int id, string descripcion, string calle, string nro_puerta, string cod_postal, string capacidad, string departamento)
        {
            WareHouseModel editedWarehouse = wareHouseData.Find(wh => wh.id == id);
            if (editedWarehouse == null) return;
            editedWarehouse.descripcion = descripcion;
            editedWarehouse.calle = calle;
            editedWarehouse.nro_puerta = nro_puerta;
            editedWarehouse.cod_postal = cod_postal;
            editedWarehouse.capacidad = capacidad;
            editedWarehouse.departamento = departamento;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedWarehouse = null;
            btnEditWarehouse.Enabled = false;
            btnDeleteWarehouse.Enabled = false;
        }

        private async void btnDeleteWarehouse_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                WareHouseController controller = new WareHouseController();
                bool res = controller.Delete(selectedWarehouse.id);

                if (res == true)
                {
                    wareHouseData.RemoveAll(wh => wh.id == selectedWarehouse.id);
                    // Update DataGrid Table
                    wareHouseLength = wareHouseData.Count;
                    int lastPageRes = (int)Math.Ceiling((double)wareHouseData.Count / rowsPerPage);
                    lastPage = Convert.ToInt32(lastPageRes);
                    /*if ((actualPage - 1) * rowsPerPage == wareHouseLength)
                    {
                        if (wareHouseLength == 0) return;
                        if (actualPage == 1) return;

                        actualPage = actualPage - 1;
                        lblPage.Text = actualPage.ToString() + "/" + lastPage;
                        showRows(actualPage);

                        // Disable buttons and unselect actual warehouse
                        selectedWarehouse = null;
                        btnEditWarehouse.Enabled = false;
                        btnDeleteWarehouse.Enabled = false;
                        return;
                    }*/
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedWarehouse = null;
                    btnEditWarehouse.Enabled = false;
                    btnDeleteWarehouse.Enabled = false;
                }
                else MessageBox.Show("Hubo un error. Refresca la lista de almacenes.");
            }
        }

        private void UpdateButtonImage(Button btn, string enabled, string disabled)
        {
            Image enabledImage = Image.FromFile(enabled);
            Image disabledImage = Image.FromFile(disabled);

            btn.EnabledChanged += (sender, e) =>
            {
                btn.BackgroundImage = btn.Enabled ? enabledImage : disabledImage;
            };
        }
    }
}
