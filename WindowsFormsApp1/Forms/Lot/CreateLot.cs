using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.LotController;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Lot
{
    public partial class CreateLot : Form
    {
        private HandleLot callback;

        public CreateLot(HandleLot callback)
        {
            this.callback = callback;
            initializeFormAsync();
        }

        private async void initializeFormAsync()
        {
            InitializeComponent();
            await fetchData();
        }

        private async Task fetchData()
        {
            Dictionaries dictionaries = new Dictionaries();
            Dictionary<string, string> warehouseSelect = dictionaries.Departments();
            input_almacen.DataSource = new BindingSource(warehouseSelect, null);
            input_almacen.DisplayMember = "Value";
            input_almacen.ValueMember = "Key";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;
            
            string id_camion = input_id_camion.Text;
            string almacen_destino = input_almacen.Text;

            LotController controller = new LotController();
            int id = controller.Create(Convert.ToInt32(id_camion), Convert.ToInt32(almacen_destino));
            callback.OnCreate(id, Convert.ToInt32(id_camion), Convert.ToInt32(almacen_destino));

            this.Close();
        }

        private bool validateFields()
        {
            string id_camion = input_id_camion.Text;
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
