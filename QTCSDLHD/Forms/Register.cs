using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;

namespace QTCSDLHD
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btndk_Click(object sender, EventArgs e)
        {
            RedisFunctions.Connect();
            try
            {
                // Lấy dữ liệu từ TextBox hoặc một control khác trong giao diện của bạn
                string dataToAdd = txtBox_tendangnhap.Text;
                string keyToAdd = txtBox_matkhau.Text;

                // Tạo một instance của database Redis
                IDatabase db = RedisFunctions.GetDatabase();

                // Kiểm tra xem key đã tồn tại chưa
                if (db.KeyExists(keyToAdd))
                {
                    MessageBox.Show("Số điện thoại đã được đăng ký. Vui loại chọn số điện thoại khác.");
                    return; // Không thêm dữ liệu nếu key đã tồn tại
                }

                // Thêm dữ liệu vào Redis với một key cụ thể
                db.StringSet(keyToAdd, dataToAdd);

                MessageBox.Show("Đăng ký thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
