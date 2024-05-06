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

namespace QTCSDLHD
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            
            MonggoDB.SearchAndDisplay(txtmahd.Text, Date.Text, dgvhd);


        }

        private void txtmahd_TextChanged(object sender, EventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            // Thêm các cột vào DataGridView
            dgvhd.Columns.Add("MaHD", "Mã hóa đơn");
            dgvhd.Columns.Add("NgayLap", "Ngày lập");
            dgvhd.Columns.Add("TongGiaVe", "Tổng giá vé");
            dgvhd.Columns.Add("PhuongThucThanhToan", "Phương thức thanh toán");
            dgvhd.Columns.Add("TongSoVe", "Tổng số vé");
            dgvhd.Columns.Add("TrangThaiThanhToan", "Trạng thái thanh toán");
            dgvhd.Columns.Add("SDT", "Số điện thoại");
            MonggoDB.DisplayAllDocuments(dgvhd);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvhd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvhd.CurrentRow.Index;
            string mahd = dgvhd.Rows[i].Cells[0].Value.ToString();
            MonggoDB.DisplayTicketsByInvoiceID(mahd);
        }

        private void btndisplay_Click(object sender, EventArgs e)
        {
            MonggoDB.DisplayAllDocuments(dgvhd);
        }
    }
}
