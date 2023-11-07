using System;
using System.Windows.Forms;
using Controllers.PackageLotController;

namespace WindowsFormsApp1.Forms.Lot
{
    public partial class EditPackageToLot : Form
    {
        private HandlePackageLot callback;
        private string id_externo_paquete;
        private int id_lote;

        public EditPackageToLot(string id_externo_paquete, int id_lote, HandlePackageLot callback)
        {
            this.callback = callback;
            this.id_externo_paquete = id_externo_paquete;
            this.id_lote = id_lote;
            InitializeComponent();
            input_paquete.Text = id_externo_paquete;
            input_lote.Text = id_lote.ToString();

            input_paquete.KeyPress += new KeyPressEventHandler(input_paquete_KeyPress);
            input_lote.KeyPress += new KeyPressEventHandler(input_lote_KeyPress);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool fieldsValid = validateFields();
            if (!fieldsValid) return;

            string id_externo_paquete = input_paquete.Text;
            string id_lote = input_lote.Text;

            PackageLotController controller = new PackageLotController();
            controller.Edit(id_externo_paquete, Convert.ToInt32(id_lote), 3, DateTime.Now);
            callback.OnEdit(id_externo_paquete, Convert.ToInt32(id_lote), 3, DateTime.Now.ToString());

            this.Close();
        }

        private bool validateFields()
        {
            string paquete = input_paquete.Text;
            string lote = input_lote.Text;
            if (paquete.Length == 0 || lote.Length == 0)
            {
                MessageBox.Show("Debes llenar todos los campos!", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void input_paquete_KeyPress(object sender, KeyPressEventArgs e)
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
