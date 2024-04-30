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
    class RedisFunctions
    {
        // server chính xác
        private static ConnectionMultiplexer redis;



        public static void Connect()
        {
            redis = ConnectionMultiplexer.Connect("localhost:6379");
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

        public static void Disconnect()
        {
            
        }

        // lấy ConnectString với mỗi loại user
        public static string get_ConnectString(string tendangnhap, string matkhau)
        {
            string s = "";
            s = "Data Source=.;Initial Catalog=DOANHQT;User ID=" + tendangnhap + ";Password=" + matkhau + "";
            return s;
        }

        public static IDatabase GetDatabase()
        {
            if (redis == null || !redis.IsConnected)
            {
                Connect(); // Kết nối đến Redis nếu chưa được kết nối
            }

            return redis.GetDatabase();
        }
    }


}
