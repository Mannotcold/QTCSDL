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

        private void openChildForm(Form childForm)
        {
            if (activeform != null)
            {
                activeform.Close();
            }

            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            guna2Panel3.Controls.Clear(); // Xóa tất cả các controls hiện tại trong panel trước khi thêm form con mới
            guna2Panel3.Controls.Add(childForm);
            guna2Panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btndn_Click(object sender, EventArgs e)
        {
            openChildForm(new Login());
        }

        private void btndk_Click(object sender, EventArgs e)
        {
            openChildForm(new Register());
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            openChildForm(new Login());
        }
    }
}
