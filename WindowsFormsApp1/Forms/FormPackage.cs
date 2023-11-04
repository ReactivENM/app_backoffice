using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.PackageController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms
{
    public interface HandlePackage
    {
        void OnCreate(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado);
        void OnEdit(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado);
    }

    public partial class FormPackage : Form, HandlePackage
    {
        List<PackageModel> packageData = new List<PackageModel>();
        private int dataLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        PackageModel selectedPackage = null;

        public FormPackage()
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
            PackageController controller = new PackageController();
            List<PackageModel> packages = controller.GetAll();
            foreach (PackageModel package in packages)
            {
                packageData.Add(package);
            }
            dataLength = packages.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > dataLength ? dataLength : page * rowsPerPage); i++)
            {
                Dictionaries dictionaries = new Dictionaries();
                Dictionary<string, string> packageStatus = dictionaries.PackageStatus();
                Dictionary<string, string> clientNames = dictionaries.ClientName();

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, packageData[i].id_interno, packageData[i].id_externo, clientNames[packageData[i].id_cliente.ToString()], packageData[i].peso, packageData[i].dir_envio, packageStatus.ContainsKey(packageData[i].estado) ? packageStatus[packageData[i].estado] : packageData[i].estado);
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
                object id_interno = row.Cells["id_interno"].Value;
                PackageModel package = packageData.Find(p => p.id_interno == Convert.ToInt32(id_interno));
                selectedPackage = package;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
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
            selectedPackage = null;
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
            selectedPackage = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new Forms.Package.CreatePackage(this).ShowDialog();
        }

        public void OnCreate(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            PackageModel package = new PackageModel(id_interno, id_externo, id_cliente, peso, dir_envio, estado);
            packageData.Add(package);
            dataLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)dataLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedPackage = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editPackage = new Forms.Package.EditPackage(selectedPackage.id_interno, selectedPackage.id_externo, selectedPackage.id_cliente, selectedPackage.peso, selectedPackage.dir_envio, selectedPackage.estado, this);
            editPackage.ShowDialog();
        }

        public void OnEdit(int id_interno, string id_externo, int id_cliente, double peso, string dir_envio, string estado)
        {
            PackageModel editedPackage = packageData.Find(package => package.id_interno == id_interno);
            if (editedPackage == null) return;
            editedPackage.id_interno = id_interno;
            editedPackage.id_externo = id_externo;
            editedPackage.id_cliente = id_cliente;
            editedPackage.peso = peso;
            editedPackage.dir_envio = dir_envio;
            editedPackage.estado = estado;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedPackage = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PackageController controller = new PackageController();
            bool res = controller.Delete(selectedPackage.id_interno);

            if (res == true)
            {
                packageData.RemoveAll(package => package.id_interno == selectedPackage.id_interno);
                // Update DataGrid Table
                dataLength = packageData.Count;
                int lastPageRes = (int)Math.Ceiling((double)packageData.Count / rowsPerPage);
                lastPage = Convert.ToInt32(lastPageRes);
                if ((actualPage - 1) * rowsPerPage == dataLength)
                {
                    if (dataLength == 0) return;
                    if (actualPage == 1) return;

                    actualPage = actualPage - 1;
                    lblPage.Text = actualPage.ToString() + "/" + lastPage;
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedPackage = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    return;
                }
                showRows(actualPage);

                // Disable buttons and unselect actual warehouse
                selectedPackage = null;
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
