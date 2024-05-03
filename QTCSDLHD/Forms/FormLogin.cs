using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCSDLHD
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        // mở 1 form con
        private Form activeform = null;

        private void openChildForm(Form childForm, Form parentForm)
        {
            if (childForm == null)
            {
                // Xử lý trường hợp childForm là null
                return;
            }

            if (activeform != null)
            {
                activeform.Close();
            }

            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            if (guna2Panel3 == null)
            {
                // Xử lý trường hợp guna2Panel3 là null
                return;
            }

            guna2Panel3.Controls.Clear();
            guna2Panel3.Controls.Add(childForm);
            guna2Panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btndn_Click(object sender, EventArgs e)
        {
            openChildForm(new Login(), this);
        }

        private void btndk_Click(object sender, EventArgs e)
        {
            openChildForm(new Register(), this);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

            openChildForm(new Login(), this);
        }

        public void CloseParentForm()
        {
            this.Close(); // Đóng form cha
        }
    }
}
