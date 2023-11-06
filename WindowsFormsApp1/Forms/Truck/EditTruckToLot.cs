using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controllers.TruckLotController;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Dictionary;

namespace WindowsFormsApp1.Forms.Truck
{
    public partial class EditTruckToLot : Form
    {
        private HandleTruckLot callback;
        private int id;

        public EditTruckToLot(int id, int id_camion, int id_lote, HandleTruckLot callback)
        {
            this.callback = callback;
            this.id = id;
            InitializeComponent();
            input_camion.KeyPress += new KeyPressEventHandler(input_camion_KeyPress);
            input_lote.KeyPress += new KeyPressEventHandler(input_lote_KeyPress);
            input_camion.Text = id_camion.ToString();
            input_lote.Text = id_lote.ToString();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_camion = input_camion.Text;
            string id_lote = input_lote.Text;

            TruckLotController controller = new TruckLotController();
            controller.Edit(id, Convert.ToInt32(id_camion), Convert.ToInt32(id_lote));
            callback.OnEdit(id, Convert.ToInt32(id_camion), Convert.ToInt32(id_lote));

            this.Close();
        }

        private bool validateFields()
        {
            string camion = input_camion.Text;
            string lote = input_lote.Text;
            if (camion.Length == 0 || lote.Length == 0)
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
