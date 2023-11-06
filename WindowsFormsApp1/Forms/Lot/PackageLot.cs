using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.PackageLotController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Lot
{
    public interface HandlePackageLot
    {
        void OnCreate(int id_interno_paquete, int id_lote, int id_usuario, string fecha_hora);
        void OnEdit(int id_interno_paquete, int id_lote, int id_usuario, string fecha_hora);
    }

    public partial class PackageLot : Form, HandlePackageLot
    {
        List<PackageLotModel> packageLotData = new List<PackageLotModel>();
        private int lote;
        private int dataLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        PackageLotModel selectedPackageLot = null;

        public PackageLot(int lote)
        {
            this.lote = lote;
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
            PackageLotController controller = new PackageLotController();
            List<PackageLotModel> packages = controller.GetAllByLotId(lote);
            foreach (PackageLotModel package in packages)
            {
                packageLotData.Add(package);
            }
            dataLength = packages.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > dataLength ? dataLength : page * rowsPerPage); i++)
            {
                if(packageLotData[i].id_lote != lote)
                {
                    return;
                }

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, packageLotData[i].id_interno_paquete, packageLotData[i].id_lote, packageLotData[i].id_usuario, packageLotData[i].fecha_hora);
                dataGridView.Rows.Add(newRow);
            }
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id_interno_paquete = row.Cells["id_interno_paquete"].Value;
                PackageLotModel package = packageLotData.Find(p => p.id_interno_paquete == Convert.ToInt32(id_interno_paquete));
                selectedPackageLot = package;
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
            selectedPackageLot = null;
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
            selectedPackageLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new Forms.Lot.AddPackageToLot(lote, this).ShowDialog();
        }

        public void OnCreate(int id_interno_paquete, int id_lote, int id_usuario, string fecha_hora)
        {
            PackageLotModel packageLot = new PackageLotModel(id_interno_paquete, id_lote, id_usuario, fecha_hora);
            packageLotData.Add(packageLot);
            dataLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)dataLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedPackageLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editPackage = new Forms.Lot.EditPackageToLot(selectedPackageLot.id_interno_paquete, selectedPackageLot.id_lote, this);
            editPackage.ShowDialog();
        }

        public void OnEdit(int id_interno_paquete, int id_lote, int id_usuario, string fecha_hora)
        {
            PackageLotModel editedPackage = packageLotData.Find(package => package.id_interno_paquete == id_interno_paquete);
            if (editedPackage == null) return;
            editedPackage.id_interno_paquete = id_interno_paquete;
            editedPackage.id_lote = id_lote;
            editedPackage.id_usuario = id_usuario;
            editedPackage.fecha_hora = fecha_hora;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedPackageLot = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PackageLotController controller = new PackageLotController();
            bool res = controller.Delete(selectedPackageLot.id_interno_paquete);

            if (res == true)
            {
                packageLotData.RemoveAll(package => package.id_interno_paquete == selectedPackageLot.id_interno_paquete);
                // Update DataGrid Table
                dataLength = packageLotData.Count;
                int lastPageRes = (int)Math.Ceiling((double)packageLotData.Count / rowsPerPage);
                lastPage = Convert.ToInt32(lastPageRes);
                if ((actualPage - 1) * rowsPerPage == dataLength)
                {
                    if (dataLength == 0) return;
                    if (actualPage == 1) return;

                    actualPage = actualPage - 1;
                    lblPage.Text = actualPage.ToString() + "/" + lastPage;
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedPackageLot = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    return;
                }
                showRows(actualPage);

                // Disable buttons and unselect actual warehouse
                selectedPackageLot = null;
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
