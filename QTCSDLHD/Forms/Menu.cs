using QTCSDLHD.Forms;
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
    public partial class Menu : Form
    {

        string SĐT;
        string MK;
        public Menu(string sdt, string mk)
        {
            InitializeComponent();
            SĐT = sdt;
            MK = mk;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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

            guna2Panel1.Controls.Clear(); // Xóa tất cả các controls hiện tại trong panel trước khi thêm form con mới
            guna2Panel1.Controls.Add(childForm);
            guna2Panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            //openChildForm(new TimChuyenXe());
        }

        private void btntc_Click(object sender, EventArgs e)
        {
            //openChildForm(new TimChuyenXe());
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
            openChildForm(new HoaDon());
        }

        private void btnqltt_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyThongTinTaiKhoan());
        }

        private void btninfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được bảo trì. Vui lòng quay lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
