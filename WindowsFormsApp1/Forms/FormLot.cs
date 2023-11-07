using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Models.LotModel;
using Controllers.LotController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms
{
    public interface HandleLot
    {
        void OnCreate(int id, int almacen_destino, string estado);
        void OnEdit(int id, int almacen_destino, string estado);
    }

    public partial class FormLot : Form, HandleLot
    {
        List<LotModel> lotData = new List<LotModel>();
        private int dataLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        LotModel selectedLot = null;

        public FormLot()
        {
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
            LotController controller = new LotController();
            List<LotModel> lots = controller.GetAll();
            foreach (LotModel lot in lots)
            {
                lotData.Add(lot);
            }
            dataLength = lots.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > dataLength ? dataLength : page * rowsPerPage); i++)
            {
                Dictionaries dictionaries = new Dictionaries();
                Dictionary<string, string> warehouseSelect = dictionaries.DepartmentByWarehouseID();
                Dictionary<string, string> packageStatus = dictionaries.PackageStatus();

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, lotData[i].id, warehouseSelect[lotData[i].almacen_destino.ToString()], packageStatus.ContainsKey(lotData[i].estado) ? packageStatus[lotData[i].estado] : lotData[i].estado);
                dataGridView.Rows.Add(newRow);
            }
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id_lot = row.Cells["id_lot"].Value;
                LotModel lot = lotData.Find(p => p.id == Convert.ToInt32(id_lot));
                selectedLot = lot;
                btnPackages.Enabled = true;
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
            selectedLot = null;
            btnPackages.Enabled = false;
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
            selectedLot = null;
            btnPackages.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new Forms.Lot.CreateLot(this).ShowDialog();
        }

        public void OnCreate(int id_lot, int almacen_destino, string estado)
        {
            LotModel package = new LotModel(id_lot, almacen_destino, estado);
            lotData.Add(package);
            dataLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)dataLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual lot
            selectedLot = null;
            btnPackages.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editLot = new Forms.Lot.EditLot(selectedLot.id, selectedLot.almacen_destino, selectedLot.estado, this);
            editLot.ShowDialog();
        }

        public void OnEdit(int id_lot, int almacen_destino, string estado)
        {
            LotModel editedLot = lotData.Find(lot => lot.id == id_lot);
            if (editedLot == null) return;
            editedLot.id = id_lot;
            editedLot.almacen_destino = almacen_destino;
            editedLot.estado = estado;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedLot = null;
            btnPackages.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LotController controller = new LotController();
            bool res = controller.Delete(selectedLot.id);

            if (res == true)
            {
                lotData.RemoveAll(lot => lot.id == selectedLot.id);
                // Update DataGrid Table
                dataLength = lotData.Count;
                int lastPageRes = (int)Math.Ceiling((double)lotData.Count / rowsPerPage);
                lastPage = Convert.ToInt32(lastPageRes);
                /*if ((actualPage - 1) * rowsPerPage == dataLength)
                {
                    if (dataLength == 0) return;
                    if (actualPage == 1) return;

                    actualPage = actualPage - 1;
                    lblPage.Text = actualPage.ToString() + "/" + lastPage;
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedLot = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    return;
                }*/
                showRows(actualPage);

                // Disable buttons and unselect actual warehouse
                selectedLot = null;
                btnPackages.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else MessageBox.Show("Hubo un error. Refresca la lista de almacenes.");
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            new Forms.Lot.PackageLot(selectedLot.id).ShowDialog();
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
