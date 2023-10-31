using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.TruckLotController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Truck
{
    public interface HandleTruckLot
    {
        void OnCreate(int id, int id_camion, int id_lote);
        void OnEdit(int id, int id_camion, int id_lote);
    }

    public partial class TruckLot : Form, HandleTruckLot
    {
        List<TruckLotModel> truckLot = new List<TruckLotModel>();
        private int truck;
        private int dataLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        TruckLotModel selectedTruckLot = null;

        public TruckLot(int truck)
        {
            this.truck = truck;
            initializeFormAsync();
        }

        public async void initializeFormAsync()
        {
            InitializeComponent();

            await fetchData();

            int lastPageRes = (int)Math.Ceiling((double)dataLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage.ToString();

            // Load mock data on dataGrid
            showRows(actualPage);
            // On double click dataGrid row
            dataGridView.CellClick += new DataGridViewCellEventHandler(handleClickRow);

            // Update buttons image when disabled/enabled
            UpdateButtonImage(btnEdit, "../../Icons/edit.png", "../../Icons/disabled/edit.png");
            UpdateButtonImage(btnDelete, "../../Icons/delete.png", "../../Icons/disabled/delete.png");
        }

        public async Task fetchData()
        {
            TruckLotController controller = new TruckLotController();
            List<TruckLotModel> lots = controller.GetAllByTruckId(truck);
            foreach (TruckLotModel lot in lots)
            {
                truckLot.Add(lot);
            }
            dataLength = lots.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > dataLength ? dataLength : page * rowsPerPage); i++)
            {
                if(truckLot[i].id_camion != truck)
                {
                    return;
                }
                Console.WriteLine(truckLot[i].id_camion + ", " + truck);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, truckLot[i].id, truckLot[i].id_camion, truckLot[i].id_lote);
                dataGridView.Rows.Add(newRow);
            }
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id_trucklot = row.Cells["id"].Value;
                TruckLotModel truck = truckLot.Find(p => p.id == Convert.ToInt32(id_trucklot));
                selectedTruckLot = truck;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (dataLength == 0) return;
            if (actualPage == 1) return;

            actualPage = actualPage - 1;
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruckLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dataLength == 0) return;
            if (actualPage == lastPage) return;

            actualPage = actualPage + 1;
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruckLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new Forms.Truck.AddTruckToLot(truck, this).ShowDialog();
        }

        public void OnCreate(int id, int id_camion, int id_lote)
        {
            TruckLotModel packageLot = new TruckLotModel(id, id_camion, id_lote);
            truckLot.Add(packageLot);
            dataLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)dataLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruckLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editPackage = new Forms.Truck.EditTruckToLot(selectedTruckLot.id, selectedTruckLot.id_camion, selectedTruckLot.id_lote, this);
            editPackage.ShowDialog();
        }

        public void OnEdit(int id, int id_camion, int id_lote)
        {
            TruckLotModel editedLot = truckLot.Find(truckLot => truckLot.id == id);
            if (editedLot == null) return;
            editedLot.id_camion = id_camion;
            editedLot.id_lote = id_lote;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedTruckLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TruckLotController controller = new TruckLotController();
            bool res = controller.Delete(selectedTruckLot.id);

            if (res == true)
            {
                truckLot.RemoveAll(package => package.id == selectedTruckLot.id);
                // Update DataGrid Table
                dataLength = truckLot.Count;
                int lastPageRes = (int)Math.Ceiling((double)truckLot.Count / rowsPerPage);
                lastPage = Convert.ToInt32(lastPageRes);
                if ((actualPage - 1) * rowsPerPage == dataLength)
                {
                    if (dataLength == 0) return;
                    if (actualPage == 1) return;

                    actualPage = actualPage - 1;
                    lblPage.Text = actualPage.ToString() + "/" + lastPage;
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedTruckLot = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    return;
                }
                showRows(actualPage);

                // Disable buttons and unselect actual warehouse
                selectedTruckLot = null;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else MessageBox.Show("Hubo un error. Refresca la lista de almacenes.");
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

        private void Form_Resize(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height = dataGridView.ClientSize.Height / dataGridView.RowCount;
                row.MinimumHeight = dataGridView.ClientSize.Height / dataGridView.RowCount;
            }
        }
    }
}
