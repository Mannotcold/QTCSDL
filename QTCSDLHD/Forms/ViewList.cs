using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTCSDLHD.Forms
{
    public partial class ViewList : Form
    {


        public ViewList()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }





        private void ViewList_Load(object sender, EventArgs e)
        {

            LoadDataFromMongoDB();
        }



        private void LoadDataFromMongoDB()
        {
            DatabaseHelper db = new DatabaseHelper();
            dataGridView1.DataSource = db.GetTaiKhoan(); // Giả định phương thức GetTaiKhoan() trả về List<TaiKhoan>
            dataGridView1.Columns["colNgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Refresh();
        }







        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colNgaySinh" && e.Value != null)
            {
                DateTime date;
                if (DateTime.TryParse(e.Value.ToString(), out date))
                {
                    e.Value = date.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

    }
}
