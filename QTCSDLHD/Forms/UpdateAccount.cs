using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCSDLHD.Forms
{
    public partial class UpdateAccount : Form
    {


        public UpdateAccount()
        {
            InitializeComponent();

        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {


            TaiKhoan updatedTaiKhoan = new TaiKhoan
            {
                SĐT = txtPhone.Text,
                Email = txtEmail.Text,
                HoTen = txtFullName.Text,
                MatKhau = txtPassword.Text,
                GioiTinh = cmbGioiTinh.SelectedItem.ToString(),
                NgaySinh = txtBirth.Text,
                DiaChi = txtAddress.Text,
                NgheNghiep = txtJob.Text
            };

            DatabaseHelper db = new DatabaseHelper();
            if (db.UpdateTaiKhoan(updatedTaiKhoan))
            {
                MessageBox.Show("Thông tin tài khoản đã được cập nhật thành công.");

            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Kiểm tra lại thông tin nhập.");
            }
        }




        private void UpdateAccount_Load(object sender, EventArgs e)
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0;
        }








        private void ClearFields()
        {
            txtPhone.Clear();
            txtEmail.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            cmbGioiTinh.SelectedIndex = -1;
            txtBirth.Clear();
            txtAddress.Clear();
            txtJob.Clear();
        }




    }
}
