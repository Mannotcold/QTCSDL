using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack.Redis;
using StackExchange.Redis;

namespace QTCSDLHD
{
    public partial class Form1 : Form
    {
        private readonly ConnectionMultiplexer redis;

        public Form1()
        {
            InitializeComponent();
            // Tạo connection multiplexer để kết nối đến Redis
            redis = ConnectionMultiplexer.Connect("localhost:6379");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem kết nối đã được thiết lập thành công hay không
                if (redis.IsConnected)
                {
                    MessageBox.Show("Connected to Redis");
                }
                else
                {
                    MessageBox.Show("Failed to connect to Redis");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ TextBox hoặc một control khác trong giao diện của bạn
                string dataToAdd = "camera";

                // Tạo một instance của database Redis
                IDatabase db = redis.GetDatabase();

                // Thêm dữ liệu vào Redis với một key cụ thể
                db.StringSet("1", dataToAdd);

                MessageBox.Show("Data added to Redis successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo một instance của database Redis
            IDatabase db = redis.GetDatabase();

            // Lấy dữ liệu từ Redis với key cụ thể
            RedisValue data = db.StringGet("1");
            MessageBox.Show(data.ToString());
        }
    }
}