using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1
{
    public partial class Backoffice : Form
    {
        // Fields
        private Button currentButton;
        private Form activeForm;

        public Backoffice()
        {
            InitializeComponent();
            this.FormClosing += onCloseBackoffice;
        }

        private void onCloseBackoffice(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormWarehouse(), sender);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#D8D8D8");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Transparent;
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Controls.Add(childForm);
            Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormUser(), sender);
            ActivateButton(sender);
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormWarehouse(), sender);
            ActivateButton(sender);
        }

        private void btnCamiones_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormTruck(), sender);
            ActivateButton(sender);
        }

        private void btnLotes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormLot(), sender);
            ActivateButton(sender);
        }

        private void btnPaquetes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPackage(), sender);
            ActivateButton(sender);
        }
    }
}
