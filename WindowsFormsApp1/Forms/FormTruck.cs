using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.TruckController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms
{
    public interface HandleTruck
    {
        void OnCreateWarehouse(int id, string matricula, string marca, string modelo, double capacidad);
        void OnEditWarehouse(int id, string matricula, string marca, string modelo, double capacidad);
    }

    public partial class FormTruck : Form, HandleTruck
    {
        List<TruckModel> truckData = new List<TruckModel>();
        private int truckLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        TruckModel selectedTruck = null;
        
        public FormTruck()
        {
            initializeFormAsync();
        }

        public async void initializeFormAsync()
        {
            InitializeComponent();

            await fetchTruckData();

            int lastPageRes = (int)Math.Ceiling((double)truckLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage.ToString();

            // Load mock data on dataGrid
            showRows(actualPage);
            // On double click dataGrid row
            dataGridView.CellClick += new DataGridViewCellEventHandler(handleClickRow);

            // Update buttons image when disabled/enabled
            UpdateButtonImage(btnEditTruck, "../../Icons/edit.png", "../../Icons/disabled/edit.png");
            UpdateButtonImage(btnDeleteTruck, "../../Icons/delete.png", "../../Icons/disabled/delete.png");
        }

        public async Task fetchTruckData()
        {
            TruckController wh = new TruckController();
            List<TruckModel> trucks = wh.GetAll();
            foreach (TruckModel truck in trucks)
            {
                truckData.Add(truck);
            }
            truckLength = trucks.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > truckLength ? truckLength : page * rowsPerPage); i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, truckData[i].id, truckData[i].matricula, truckData[i].marca, truckData[i].modelo, truckData[i].capacidad);
                dataGridView.Rows.Add(newRow);
            }
            dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id = row.Cells["id"].Value;
                TruckModel wh = truckData.Find(d => d.id == Convert.ToInt32(id));
                selectedTruck = wh;
                btnLot.Enabled = true;
                btnEditTruck.Enabled = true;
                btnDeleteTruck.Enabled = true;
                dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (truckLength == 0) return;
            if (actualPage == 1) return;

            actualPage = actualPage - 1;
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruck = null;
            btnLot.Enabled = false;
            btnEditTruck.Enabled = false;
            btnDeleteTruck.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (truckLength == 0) return;
            if (actualPage == lastPage) return;

            actualPage = actualPage + 1;
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruck = null;
            btnLot.Enabled = false;
            btnEditTruck.Enabled = false;
            btnDeleteTruck.Enabled = false;
        }

        private void btnCreateTruck_Click(object sender, EventArgs e)
        {
            new Forms.Truck.CreateTruck(this).ShowDialog();
        }

        public void OnCreateWarehouse(int id, string matricula, string marca, string modelo, double capacidad)
        {
            TruckModel wh = new TruckModel(id, matricula, marca, modelo, capacidad);
            truckData.Add(wh);
            truckLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)truckLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruck = null;
            btnLot.Enabled = false;
            btnEditTruck.Enabled = false;
            btnDeleteTruck.Enabled = false;
        }

        private void btnEditTruck_Click(object sender, EventArgs e)
        {
            Form truck = new Forms.Truck.EditTruck(selectedTruck.id, selectedTruck.matricula, selectedTruck.marca, selectedTruck.modelo, selectedTruck.capacidad, this);
            truck.ShowDialog();
        }

        public void OnEditWarehouse(int id, string matricula, string marca, string modelo, double capacidad)
        {
            TruckModel editedTruck = truckData.Find(truck => truck.id == id);
            if (editedTruck == null) return;
            editedTruck.matricula = matricula;
            editedTruck.marca = marca;
            editedTruck.modelo = modelo;
            editedTruck.capacidad = capacidad;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruck = null;
            btnLot.Enabled = false;
            btnEditTruck.Enabled = false;
            btnDeleteTruck.Enabled = false;
        }

        private void btnLot_Click(object sender, EventArgs e)
        {
            new Forms.Truck.TruckLot(selectedTruck.id).ShowDialog();
        }

        private void btnDeleteTruck_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                TruckController controller = new TruckController();
                bool res = controller.Delete(selectedTruck.id);

                if (res == true)
                {
                    truckData.RemoveAll(truck => truck.id == selectedTruck.id);
                    // Update DataGrid Table
                    truckLength = truckData.Count;
                    int lastPageRes = (int)Math.Ceiling((double)truckData.Count / rowsPerPage);
                    lastPage = Convert.ToInt32(lastPageRes);
                    if ((actualPage - 1) * rowsPerPage == truckLength)
                    {
                        if (truckLength == 0) return;
                        if (actualPage == 1) return;

                        actualPage = actualPage - 1;
                        lblPage.Text = actualPage.ToString() + "/" + lastPage;
                        showRows(actualPage);

                        // Disable buttons and unselect actual warehouse
                        selectedTruck = null;
                        btnLot.Enabled = false;
                        btnEditTruck.Enabled = false;
                        btnDeleteTruck.Enabled = false;
                        return;
                    }
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedTruck = null;
                    btnLot.Enabled = false;
                    btnEditTruck.Enabled = false;
                    btnDeleteTruck.Enabled = false;
                }
                else MessageBox.Show("Hubo un error. Refresca la lista de camiones.");
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
