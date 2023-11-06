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
            Dictionary<string, string> warehouseSelect = dictionaries.DepartmentByWarehouseID();
            input_almacen.DataSource = new BindingSource(warehouseSelect, null);
            input_almacen.DisplayMember = "Value";
            input_almacen.ValueMember = "Key";

            Dictionary<string, string> statusSelect = dictionaries.PackageStatus();
            input_estado.DataSource = new BindingSource(statusSelect, null);
            input_estado.DisplayMember = "Value";
            input_estado.ValueMember = "Key";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bool fieldsValid = validateFields();
                if (!fieldsValid) return;

                string almacen_destino = input_almacen.SelectedValue.ToString();
                string estado = input_estado.SelectedValue.ToString();

                LotController controller = new LotController();
                int id = controller.Create(Convert.ToInt32(almacen_destino), estado);
                callback.OnCreate(id, Convert.ToInt32(almacen_destino), estado);

                this.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private bool validateFields()
        {
            string almacen_destino = input_almacen.Text;
            string estado = input_estado.Text;
            if (almacen_destino.Length == 0 || estado.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
