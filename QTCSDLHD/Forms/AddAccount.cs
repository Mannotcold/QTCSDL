using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCSDLHD.Forms
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {
            // Cài đặt cho ComboBox giới tính
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường đầu vào cơ bản
            if (string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                cmbGioiTinh.SelectedIndex == -1 ||
                string.IsNullOrEmpty(txtBirth.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtJob.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra định dạng email hợp lệ
            if (!Regex.IsMatch(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            // Tạo một đối tượng mới TaiKhoan
            TaiKhoan newTaiKhoan = new TaiKhoan
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

            try
            {
                // Thêm tài khoản mới vào database
                DatabaseHelper db = new DatabaseHelper();
                db.AddTaiKhoan(newTaiKhoan);

                // Thông báo thành công
                MessageBox.Show("Tài khoản đã được thêm thành công!");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        // Xóa các trường sau khi thêm thành công
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
