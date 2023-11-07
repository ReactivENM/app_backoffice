using System;
using System.Windows.Forms;
using Controllers.TruckLotController;

namespace WindowsFormsApp1.Forms.Truck
{
    public partial class AddTruckToLot : Form
    {
        private HandleTruckLot callback;
        private int id_camion;

        public AddTruckToLot(int id_camion, HandleTruckLot callback)
        {
            this.callback = callback;
            this.id_camion = id_camion;
            InitializeComponent();
            input_camion.KeyPress += new KeyPressEventHandler(input_camion_KeyPress);
            input_lote.KeyPress += new KeyPressEventHandler(input_lote_KeyPress);
            input_camion.Text = id_camion.ToString();
            input_camion.Enabled = false;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_lote = input_lote.Text;

            TruckLotController controller = new TruckLotController();
            int id = controller.Create(id_camion, Convert.ToInt32(id_lote));
            callback.OnCreate(id, id_camion, Convert.ToInt32(id_lote));

            this.Close();
        }

        private bool validateFields()
        {
            string lote = input_lote.Text;
            if (lote.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void input_camion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void input_lote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
