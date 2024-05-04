using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTCSDLHD;

namespace QTCSDLHD
{
    public partial class DatVe : Form
    {
        public DatVe()
        {
            InitializeComponent();
            MonggoDB.Connect("ChuyenXe");
            MonggoDB monggoDB = new MonggoDB();

            // Gọi phương thức LoadMaGheToCheckedListBox để hiển thị dữ liệu trong CheckedListBox
            monggoDB.LoadMaGheToCheckedListBox(checkedListBoxChonghe, 1);
        }

        private void checkedListBoxChonghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tạo một danh sách để lưu các thông tin của các ghế được chọn
            List<string[]> selectedGheInfoList = new List<string[]>();
                        
            MonggoDB monggoDB = new MonggoDB();
            monggoDB.LoadThongTinGheToDGV(dgvGhe, selectedGheInfoList, checkedListBoxChonghe, 1);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string Hovaten = txtBoxHovaten.Text.ToString();
            string Sdt = txtBoxSdt.Text.ToString();
            string Email = txtBoxEmail.Text.ToString();
            MonggoDB.InsertDataVe(Hovaten, Sdt, Email, dgvGhe);
            /*if(txtBoxHovaten.Text != null)
            {
                string Hovaten = txtBoxHovaten.Text;
                if (txtBoxSdt.Text != null)
                {
                    string Sdt = txtBoxSdt.Text;
                    if (txtBoxEmail.Text != null)
                    {
                        string Email = txtBoxEmail.Text;
                        MonggoDB.InsertDataVe(Hovaten, Sdt, Email, dgvGhe);
                    } 
                }
            }
            
            MessageBox.Show("Điền đầy đủ Họ và tên, số điện thoại, email");*/
        }
    }
}
