using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTCSDLHD;
using StackExchange.Redis;

namespace QTCSDLHD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void btntc_Click(object sender, EventArgs e)
        {
            RedisFunctions.Connect();
            try
            {
                // Lấy dữ liệu từ TextBox hoặc một control khác trong giao diện của bạn
                string username = txtBox_tendangnhap.Text;
                string password = txtBox_matkhau.Text;

                // nếu chưa có dữ liệu 
                if (username.Length == 0 | password.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Tạo một instance của database Redis
                IDatabase db = RedisFunctions.GetDatabase();

                // Lấy dữ liệu từ Redis với key là tên người dùng
                string storedPassword = db.StringGet(username);

                // Kiểm tra xem mật khẩu đã nhập có khớp với mật khẩu lưu trữ trong Redis không
                if (storedPassword == password)
                {
                    MessageBox.Show("Đăng nhập thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Form form = new Menu(username, password);
                    // Lấy tham chiếu tới form cha
                    
                    form.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
