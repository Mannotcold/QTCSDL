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
    public partial class DeleteAccount : Form
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {
            // Có thể thêm các thiết lập khởi tạo nếu cần
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sdt = txtPhone.Text; // Giả định txtPhone là TextBox nhập SĐT
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập SĐT của tài khoản cần xóa.");
                return;
            }

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                bool isDeleted = db.DeleteTaiKhoan(sdt);
                if (isDeleted)
                {
                    MessageBox.Show("Tài khoản đã được xóa thành công.");
                    txtPhone.Clear(); // Xóa trường sau khi xóa tài khoản thành công
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản với SĐT đã nhập hoặc xóa không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }


    }
}
