using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QTCSDLHD
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        //Ket noi server sql
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=QTCSDLHD;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void btntim_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Thực hiện truy vấn
            // ...

            if (txtmahd.Text == "")
            {
                //loaddata();
            }
            else
            {
                connection = new SqlConnection(str);
                connection.Open();
                string Key = txtmahd.Text ;
                DateTime date = Date.Value;
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM HOADON WHERE MaHD = '" + Key + "' OR NgayLap = '" + datetimetracuu.Text + "'";

                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvhd.DataSource = table;
            }
            txtmahd.Clear();

            // Dừng đo thời gian
            stopwatch.Stop();

            // Hiển thị thời gian thực thi
            MessageBox.Show($"Thời gian thực thi: {stopwatch.ElapsedMilliseconds} ms");

        }

        private void txtmahd_TextChanged(object sender, EventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            //// Thêm các cột vào DataGridView
            //dgvhd.Columns.Add("MaHD", "Mã hóa đơn");
            //dgvhd.Columns.Add("NgayLap", "Ngày lập");
            //dgvhd.Columns.Add("TongGiaVe", "Tổng giá vé");
            //dgvhd.Columns.Add("PhuongThucThanhToan", "Phương thức thanh toán");
            //dgvhd.Columns.Add("TongSoVe", "Tổng số vé");
            //dgvhd.Columns.Add("TrangThaiThanhToan", "Trạng thái thanh toán");
            //dgvhd.Columns.Add("SDT", "Số điện thoại");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
