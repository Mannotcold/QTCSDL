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

        private void button2_Click(object sender, EventArgs e)
        {
            RedisFunctions.Connect();
            try
            {
                // Lấy dữ liệu từ TextBox hoặc một control khác trong giao diện của bạn
                string username = textBox1.Text;
                string password = textBox3.Text;

                // Tạo một instance của database Redis
                IDatabase db = RedisFunctions.GetDatabase();

                // Lấy dữ liệu từ Redis với key là tên người dùng
                string storedPassword = db.StringGet(username);

                // Kiểm tra xem mật khẩu đã nhập có khớp với mật khẩu lưu trữ trong Redis không
                if (storedPassword == password)
                {
                    MessageBox.Show("Login successful.");
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dk_Click(object sender, EventArgs e)
        {
            Form form = new Register();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
