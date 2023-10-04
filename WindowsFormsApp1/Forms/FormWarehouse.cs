using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.WarehouseController;

namespace WindowsFormsApp1.Forms
{
    public interface HandleWarehouse
    {
        void OnCreateWarehouse(int id, string calle, string nro_puerta, string cod_postal, string capacidad);
        void OnEditWarehouse(int id, string calle, string nro_puerta, string cod_postal, string capacidad);
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

        public FormWarehouse()
        {
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
            WareHouseController wh = new WareHouseController();
            List<WareHouseModel> warehouses = wh.GetAll();
            foreach (WareHouseModel warehouse in warehouses)
            {
                wareHouseData.Add(warehouse);
            }
            wareHouseLength = warehouses.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > wareHouseLength ? wareHouseLength : page * rowsPerPage); i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, wareHouseData[i].id, wareHouseData[i].calle, wareHouseData[i].nro_puerta, wareHouseData[i].cod_postal, wareHouseData[i].capacidad);
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
                object calle = row.Cells["calle"].Value;
                object nro_puerta = row.Cells["nro_puerta"].Value;
                object cod_postal = row.Cells["cod_postal"].Value;
                object capacidad = row.Cells["capacidad"].Value;
                WareHouseModel wh = new WareHouseModel(Convert.ToInt32(id), calle.ToString(), nro_puerta.ToString(), cod_postal.ToString(), capacidad.ToString());
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

        public void OnCreateWarehouse(int id, string calle, string nro_puerta, string cod_postal, string capacidad)
        {
            WareHouseModel wh = new WareHouseModel(id, calle, nro_puerta, cod_postal, capacidad);
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
            Form warehouse = new Forms.Warehouse.EditWarehouse(selectedWarehouse.id, selectedWarehouse.calle, selectedWarehouse.nro_puerta, selectedWarehouse.cod_postal, selectedWarehouse.capacidad, this);
            warehouse.ShowDialog();
        }

        public void OnEditWarehouse(int id, string calle, string nro_puerta, string cod_postal, string capacidad)
        {
            WareHouseModel editedWarehouse = wareHouseData.Find(wh => wh.id == id);
            if (editedWarehouse == null) return;
            editedWarehouse.calle = calle;
            editedWarehouse.nro_puerta = nro_puerta;
            editedWarehouse.cod_postal = cod_postal;
            editedWarehouse.capacidad = capacidad;
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
                    if ((actualPage - 1) * rowsPerPage == wareHouseLength)
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
                    }
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
