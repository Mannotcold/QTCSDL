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
using System.Data.SqlClient;
namespace QTCSDLHD
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QTCSDLHD;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

            private void btndk_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtBox_tendangnhap.Text;
                string password = txtBox_matkhau.Text;

                connection = new SqlConnection(str);
                connection.Open();
                SqlCommand com = new SqlCommand();
                //Lấy dữ liệu về từ kết quả câu lệnh trên
                //ExecuteReader() dùng với select
                //ExecuteNonquery(); với inserrt update delete
                //com.ExecuteNonQuery();
                //MAPHIEUDP();
                com.CommandType = CommandType.Text;
                com.CommandText = "insert into TAIKHOAN(SĐT,Matkhau) VALUES ('" + username + "','" + password + "')";
                com.Connection = connection;


                int kq = com.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đăng ký thàng công!");

                }
                else
                {
                    MessageBox.Show("Đăng ký không thàng công! Vui lòng xem lại tài khoản/mật khẩu.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
        }
    }
}
