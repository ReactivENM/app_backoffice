using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.LotController;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Lot
{
    public partial class EditLot : Form
    {
        private HandleLot callback;
        private int id;

        public EditLot(int id, int id_camion, int almacen_destino, HandleLot callback)
        {
            this.callback = callback;
            this.id = id;
            initializeFormAsync(id_camion, almacen_destino);
        }

        private async void initializeFormAsync(int id_camion, int almacen_destino)
        {
            InitializeComponent();
            await fetchData(id_camion, almacen_destino);
        }

        private async Task fetchData(int id_camion, int almacen_destino)
        {
            Dictionaries dictionaries = new Dictionaries();
            Dictionary<string, string> warehouseSelect = dictionaries.DepartmentByWarehouseID();
            input_almacen.DataSource = new BindingSource(warehouseSelect, null);
            input_almacen.DisplayMember = "Value";
            input_almacen.ValueMember = "Key";
            input_almacen.SelectedValue = almacen_destino.ToString();

            input_id_camion.Text = id_camion.ToString();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_camion = input_id_camion.SelectedValue.ToString();
            string almacen_destino = input_almacen.Text;

            LotController controller = new LotController();
            controller.Edit(id, Convert.ToInt32(id_camion), Convert.ToInt32(almacen_destino));
            callback.OnEdit(id, Convert.ToInt32(id_camion), Convert.ToInt32(almacen_destino));

            this.Close();
        }

        private bool validateFields()
        {
            string id_camion = input_id_camion.SelectedValue.ToString();
            string almacen_destino = input_almacen.Text;
            if (id_camion.Length == 0 || almacen_destino.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
