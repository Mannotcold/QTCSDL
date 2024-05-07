using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using QTCSDLHD.Functions;
using Cassandra;
using ServiceStack;
using System.Web.UI.WebControls;
using System.Diagnostics;

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
        private void SetupDataGridView()
        {
            // Thêm cột button
            DataGridViewButtonColumn btnSelect = new DataGridViewButtonColumn();
            btnSelect.HeaderText = "Chọn Chuyến";
            btnSelect.Name = "selectColumn";
            btnSelect.Text = "Chọn";
            btnSelect.UseColumnTextForButtonValue = true; // Đặt text mặc định cho tất cả các cell
            dataGridViewDSChuyenXe.Columns.Add(btnSelect);
        }

        private void dataGridViewDSChuyenXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDSChuyenXe.Columns["selectColumn"].Index && e.RowIndex >= 0)
            {
                DatVe chiTietForm = new DatVe();
                chiTietForm.Show();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridViewDSChuyenXe.Rows[e.RowIndex].Cells["mactcx"];
                if (selectedCell != null && selectedCell.Value != null)
                {
                    ChiTietChuyenXe ds = new ChiTietChuyenXe(selectedCell.Value.ToString());
                    ds.Show();
                }
            }

        }

        private void buttonTimChuyenXeKH_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<object> list = control.loadListChuyenXeKH(comboBoxDiemDenKH.SelectedValue.ToString(), comboBoxDiemDiKH.SelectedValue.ToString(), dateTimePickerNgayDiKH.Value.ToString("yyyy-MM-dd"), dateTimePickerNgayVeKH.Value.ToString("yyyy-MM-dd"));
            dataGridViewDSChuyenXe.DataSource = list;
            groupBoxDSChuyenXe.Visible = true;
            stopwatch.Stop();
            MessageBox.Show($"Thời gian thực thi: {stopwatch.ElapsedMilliseconds} ms");

        }

        private void buttonTimChuyenXe_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<object> list = control.loadListChuyenXe(comboBoxDiemDen.SelectedValue.ToString(), comboBoxDiemDi.SelectedValue.ToString(), dateTimePickerNgayDi.Value.ToString("yyyy-MM-dd"));
            dataGridViewDSChuyenXe.DataSource = list;
            groupBoxDSChuyenXe.Visible = true;
            stopwatch.Stop();
            MessageBox.Show($"Thời gian thực thi: {stopwatch.ElapsedMilliseconds} ms");
        }

        private void TimChuyenXe_Load(object sender, EventArgs e)
        {
            loadComboxDiemDenDi();
            SetupDataGridView();
        }
    }
}
