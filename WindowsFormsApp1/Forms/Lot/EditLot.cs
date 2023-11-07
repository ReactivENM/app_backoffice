using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.LotController;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Lot
{
    public partial class EditLot : Form
    {
        private HandleLot callback;
        private int id;

        public EditLot(int id, int almacen_destino, string estado, HandleLot callback)
        {
            this.callback = callback;
            this.id = id;
            initializeFormAsync(almacen_destino, estado);
        }

        private async void initializeFormAsync(int almacen_destino, string estado)
        {
            InitializeComponent();
            await fetchData(almacen_destino, estado);
        }

        private async Task fetchData(int almacen_destino, string estado)
        {
            Dictionaries dictionaries = new Dictionaries();
            Dictionary<string, string> warehouseSelect = dictionaries.DepartmentByWarehouseID();
            input_almacen.DataSource = new BindingSource(warehouseSelect, null);
            input_almacen.DisplayMember = "Value";
            input_almacen.ValueMember = "Key";
            input_almacen.SelectedValue = almacen_destino.ToString();

            Dictionary<string, string> statusSelect = dictionaries.PackageStatus();
            input_estado.DataSource = new BindingSource(statusSelect, null);
            input_estado.DisplayMember = "Value";
            input_estado.ValueMember = "Key";
            input_estado.SelectedValue = estado;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string almacen_destino = input_almacen.SelectedValue.ToString();
            string estado = input_estado.SelectedValue.ToString();

            LotController controller = new LotController();
            controller.Edit(id, Convert.ToInt32(almacen_destino), estado);
            callback.OnEdit(id, Convert.ToInt32(almacen_destino), estado);

            this.Close();
        }

        private bool validateFields()
        {
            string almacen_destino = input_almacen.SelectedValue.ToString();
            string estado = input_almacen.Text;
            if (almacen_destino.Length == 0 || estado.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
