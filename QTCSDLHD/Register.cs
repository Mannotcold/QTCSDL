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

        private void DK_Click(object sender, EventArgs e)
        {
            RedisFunctions.Connect();
            try
            {
                // Lấy dữ liệu từ TextBox hoặc một control khác trong giao diện của bạn
                string dataToAdd = textBox1.Text;

                // Tạo một instance của database Redis
                IDatabase db = RedisFunctions.GetDatabase();

                // Thêm dữ liệu vào Redis với một key cụ thể
                db.StringSet(textBox3.Text, dataToAdd);

                MessageBox.Show("Data added to Redis successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
