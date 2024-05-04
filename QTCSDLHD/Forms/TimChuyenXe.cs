using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using QTCSDLHD.Functions;
using Cassandra;
using ServiceStack;
using System.Web.UI.WebControls;

namespace QTCSDLHD
{
    public partial class TimChuyenXe : Form
    {
        TimChuyen control;
        public TimChuyenXe()
        {
            InitializeComponent();
            control = new TimChuyen();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void loadComboxDiemDenDi()
        {
            List<DiaChi> list = control.loadListDiaDiem();
            List<object> DiemDenList = new List<object>(list);
            List<object> DiemDiList = new List<object>(list);
            List<object> DiemDiKhList = new List<object>(list);
            List<object> DiemDenKhList = new List<object>(list);

            comboBoxDiemDi.DataSource = DiemDiList;
            comboBoxDiemDi.DisplayMember = "tinh";
            comboBoxDiemDi.ValueMember = "madiachi";
            
            comboBoxDiemDen.DataSource = DiemDenList;
            comboBoxDiemDen.DisplayMember = "tinh";
            comboBoxDiemDen.ValueMember = "madiachi";

            comboBoxDiemDiKH.DataSource = DiemDiKhList;
            comboBoxDiemDiKH.DisplayMember = "tinh";
            comboBoxDiemDiKH.ValueMember = "madiachi";

            comboBoxDiemDenKH.DataSource = DiemDenKhList;
            comboBoxDiemDenKH.DisplayMember = "tinh";
            comboBoxDiemDenKH.ValueMember = "madiachi";

        }

        private void dataGridViewDSChuyenXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewDSChuyenXe.Rows[e.RowIndex].Cells["mactcx"];
                ChiTietChuyenXe ds = new ChiTietChuyenXe(selectedCell.Value.ToString());
                ds.Show();
            }
        }

        private void buttonTimChuyenXeKH_Click(object sender, EventArgs e)
        {

        }

        private void buttonTimChuyenXe_Click(object sender, EventArgs e)
        {
            List<object> list = control.loadListChuyenXe(comboBoxDiemDen.SelectedValue.ToString(), comboBoxDiemDi.SelectedValue.ToString(), dateTimePickerNgayDi.Value.ToString("yyyy-MM-dd"));
            dataGridViewDSChuyenXe.DataSource = list;
            
            groupBoxBoLocTimKiem.Visible = true;
            groupBoxDSChuyenXe.Visible = true;
        }

        private void TimChuyenXe_Load(object sender, EventArgs e)
        {
            loadComboxDiemDenDi();
        }
    }
}
