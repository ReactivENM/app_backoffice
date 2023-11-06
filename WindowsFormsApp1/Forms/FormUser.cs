using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Controllers.UserController;

namespace WindowsFormsApp1.Forms
{
    public interface HandleUser
    {
        void OnCreate(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol);
        void OnEdit(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol);
    }

    public partial class FormUser : Form, HandleUser
    {
        List<UserModel> userData = new List<UserModel>();
        private int dataLength = 0;
        private const int rowsPerPage = 10;

        private int lastPage = 1;
        private int actualPage = 1;

        private bool isRowSelected = false;
        UserModel selectedUser = null;

        public FormUser()
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
            UserController user = new UserController();
            List<UserModel> users = user.GetAll();
            foreach (UserModel u in users)
            {
                userData.Add(u);
            }
            dataLength = users.Count;
        }

        private void showRows(int page)
        {
            dataGridView.Rows.Clear();
            for (int i = (page - 1) * rowsPerPage; i < (page * rowsPerPage > dataLength ? dataLength : page * rowsPerPage); i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, userData[i].id, userData[i].correo, userData[i].nro_documento, userData[i].p_nombre, userData[i].s_nombre, userData[i].p_apellido, userData[i].s_apellido, userData[i].nacionalidad, userData[i].rol);
                dataGridView.Rows.Add(newRow);
            }
        }

        private void handleClickRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isRowSelected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                object id = row.Cells["id_usuario"].Value;
                UserModel user = userData.Find(u => u.id == Convert.ToInt32(id));
                selectedUser = user;
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
            selectedUser = null;
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
            selectedUser = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            new Forms.User.CreateUser(this).ShowDialog();
        }

        public void OnCreate(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol)
        {
            UserModel user = new UserModel(id, correo, p_nombre, s_nombre, p_apellido, s_apellido, nro_documento, nacionalidad, deshabilitado, rol);
            userData.Add(user);
            dataLength += 1;
            int lastPageRes = (int)Math.Ceiling((double)dataLength / rowsPerPage);
            lastPage = Convert.ToInt32(lastPageRes);
            lblPage.Text = actualPage.ToString() + "/" + lastPage;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedUser = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editUser = new Forms.User.EditUser(selectedUser.id, selectedUser.correo, selectedUser.p_nombre, selectedUser.s_nombre, selectedUser.p_apellido, selectedUser.s_apellido, selectedUser.nro_documento, selectedUser.nacionalidad, selectedUser.deshabilitado, selectedUser.rol, this);
            editUser.ShowDialog();
        }

        public void OnEdit(int id, string correo, string p_nombre, string s_nombre, string p_apellido, string s_apellido, string nro_documento, string nacionalidad, int deshabilitado, string rol)
        {
            UserModel editedUser = userData.Find(user => user.id == id);
            if (editedUser == null) return;
            editedUser.correo = correo;
            editedUser.p_nombre = p_nombre;
            editedUser.s_nombre = s_nombre;
            editedUser.p_apellido = p_apellido;
            editedUser.s_apellido = s_apellido;
            editedUser.nro_documento = nro_documento;
            editedUser.nacionalidad = nacionalidad;
            editedUser.deshabilitado = deshabilitado;
            editedUser.rol = rol;
            showRows(actualPage);

            // Disable buttons and unselect actual warehouse
            selectedUser = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                UserController controller = new UserController();
                bool res = controller.Delete(selectedUser.id);

                if (res == true)
                {
                    userData.RemoveAll(wh => wh.id == selectedUser.id);
                    // Update DataGrid Table
                    dataLength = userData.Count;
                    int lastPageRes = (int)Math.Ceiling((double)userData.Count / rowsPerPage);
                    lastPage = Convert.ToInt32(lastPageRes);
                    /*if ((actualPage - 1) * rowsPerPage == dataLength)
                    {
                        if (dataLength == 0) return;
                        if (actualPage == 1) return;

                        actualPage = actualPage - 1;
                        lblPage.Text = actualPage.ToString() + "/" + lastPage;
                        showRows(actualPage);

                        // Disable buttons and unselect actual warehouse
                        selectedUser = null;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        return;
                    }*/
                    showRows(actualPage);

                    // Disable buttons and unselect actual warehouse
                    selectedUser = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
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
