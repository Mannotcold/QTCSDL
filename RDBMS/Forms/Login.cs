using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QTCSDLHD;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();


        private void btntc_Click(object sender, EventArgs e)
        {
            if (txtBox_tendangnhap.Text == "")
            {
                MessageBox.Show("ID không được để trống");
                return;
            }
            if (txtBox_matkhau.Text == "")
            {
                MessageBox.Show("Pass không được để trống");
                return;
            }

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
                com.CommandText = "select * from TaiKhoan WHERE SĐT = '" + username + "' AND Matkhau = '" + password + "'";
                com.Connection = connection;
                //loaddata_PhieuThu();

                SqlDataReader dta = com.ExecuteReader();


                if (dta.Read() == true)
                {
                    Form quanLy = new Menu(username, password);
                    this.Hide();
                    quanLy.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công! Vui lòng kiểm tra lại tài khoản, mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối");
            }
        }
    }
}
