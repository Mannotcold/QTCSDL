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
    public partial class QuanLyThongTinTaiKhoan : Form
    {
        private Button btnAdd;
        private Button btnDelete;
        private PictureBox pictureBox1;
        private Button btnViewList;
        private Button btnUpdate;

        public QuanLyThongTinTaiKhoan()
        {
            InitializeComponent();

        }



        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddAccount addForm = new AddAccount();
            addForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteAccount deleteForm = new DeleteAccount();
            deleteForm.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount updateForm = new UpdateAccount();
            updateForm.Show();
        }

        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnViewList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 283);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(217, 94);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(276, 283);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(217, 94);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(527, 283);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(217, 94);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QTCSDLHD.Properties.Resources.background1;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1028, 245);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnViewList
            // 
            this.btnViewList.Location = new System.Drawing.Point(780, 283);
            this.btnViewList.Name = "btnViewList";
            this.btnViewList.Size = new System.Drawing.Size(217, 94);
            this.btnViewList.TabIndex = 0;
            this.btnViewList.Text = "Xem danh sách";
            this.btnViewList.UseVisualStyleBackColor = true;
            this.btnViewList.Click += new System.EventHandler(this.BtnViewList_Click);
            // 
            // QuanLyThongTinTaiKhoan
            // 
            this.ClientSize = new System.Drawing.Size(1027, 407);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnViewList);
            this.Controls.Add(this.btnAdd);
            this.Name = "QuanLyThongTinTaiKhoan";
            this.Load += new System.EventHandler(this.QuanLyThongTinTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnViewList_Click(object sender, EventArgs e)
        {
            ViewList ViewListForm = new ViewList();
            ViewListForm.Show();
        }

        private void QuanLyThongTinTaiKhoan_Load(object sender, EventArgs e)
        {

        }
    }
}

