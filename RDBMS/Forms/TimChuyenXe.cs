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
namespace QTCSDLHD
{
    public partial class TimChuyenXe : Form
    {
        public TimChuyenXe()
        {
            InitializeComponent();
        }
        //Ket noi server sql
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=.;Initial Catalog=TicketBookingWithSQL;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void buttonTimChuyenXe_Click(object sender, EventArgs e)
        {


            // Thực hiện truy vấn
            // ...

            string diemdi = comboBoxDiemDi.Text;
            string diemden = comboBoxDiemDen.Text;

                DateTime date = dateTimePickerNgayDi.Value;
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT NgayDi, GioDi, GioDen, DiemDi, DiemDen, LoaiXe, GiaTien FROM ChuyenXe CX JOIN ChiTietChuyenXe CTCX ON CX.MaChuyenXe = CTCX.MaChuyenXe WHERE DiemDi = '" + diemdi + "' AND DiemDen = '" + diemden + "' AND NgayDi = '" + dateTimePickerNgayDi.Text + "' ";
            
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
            dataGridViewDSChuyenXe.DataSource = table;
            
        }
    }
}
