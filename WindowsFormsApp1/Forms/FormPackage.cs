using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.PackageController;

namespace WindowsFormsApp1.Forms
{
    public partial class FormPackage : Form
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
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, packageData[i].id_interno, packageData[i].id_externo, packageData[i].id_almacen, packageData[i].peso, packageData[i].descripcion, packageData[i].dir_envio, packageData[i].estado);
                dataGridView.Rows.Add(newRow);
            }
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id_interno = row.Cells["id_interno"].Value;
                object id_externo = row.Cells["id_externo"].Value;
                object id_almacen = row.Cells["id_almacen"].Value;
                object peso = row.Cells["peso"].Value;
                object descripcion = row.Cells["descripcion"].Value;
                object dir_envio = row.Cells["dir_envio"].Value;
                object estado = row.Cells["estado"].Value;
                PackageModel package = new PackageModel(Convert.ToInt32(id_interno), id_externo.ToString(), Convert.ToInt32(id_almacen), Convert.ToDouble(peso), descripcion.ToString(), dir_envio.ToString(), estado.ToString());
                selectedPackage = package;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
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
