namespace QTCSDLHD
{
    partial class ChiTietChuyenXe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTietChuyenXe));
            this.tabControlChiTietChuyenXe = new System.Windows.Forms.TabControl();
            this.tabPageLichTrinh = new System.Windows.Forms.TabPage();
            this.dataGridViewLichTrinh = new System.Windows.Forms.DataGridView();
            this.malichtrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machuyenxe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageTrungChuyen = new System.Windows.Forms.TabPage();
            this.buttonTimChuyenXeKH = new System.Windows.Forms.Button();
            this.tabPageChinhSach = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlChiTietChuyenXe.SuspendLayout();
            this.tabPageLichTrinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLichTrinh)).BeginInit();
            this.tabPageTrungChuyen.SuspendLayout();
            this.tabPageChinhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlChiTietChuyenXe
            // 
            this.tabControlChiTietChuyenXe.Controls.Add(this.tabPageLichTrinh);
            this.tabControlChiTietChuyenXe.Controls.Add(this.tabPageTrungChuyen);
            this.tabControlChiTietChuyenXe.Controls.Add(this.tabPageChinhSach);
            this.tabControlChiTietChuyenXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlChiTietChuyenXe.Location = new System.Drawing.Point(0, 0);
            this.tabControlChiTietChuyenXe.Name = "tabControlChiTietChuyenXe";
            this.tabControlChiTietChuyenXe.SelectedIndex = 0;
            this.tabControlChiTietChuyenXe.Size = new System.Drawing.Size(1000, 453);
            this.tabControlChiTietChuyenXe.TabIndex = 0;
            // 
            // tabPageLichTrinh
            // 
            this.tabPageLichTrinh.Controls.Add(this.dataGridViewLichTrinh);
            this.tabPageLichTrinh.Location = new System.Drawing.Point(4, 31);
            this.tabPageLichTrinh.Name = "tabPageLichTrinh";
            this.tabPageLichTrinh.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLichTrinh.Size = new System.Drawing.Size(992, 310);
            this.tabPageLichTrinh.TabIndex = 1;
            this.tabPageLichTrinh.Text = "Lịch trình";
            this.tabPageLichTrinh.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLichTrinh
            // 
            this.dataGridViewLichTrinh.AllowUserToDeleteRows = false;
            this.dataGridViewLichTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLichTrinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.malichtrinh,
            this.Column1,
            this.machuyenxe,
            this.mota});
            this.dataGridViewLichTrinh.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLichTrinh.Name = "dataGridViewLichTrinh";
            this.dataGridViewLichTrinh.ReadOnly = true;
            this.dataGridViewLichTrinh.RowHeadersWidth = 51;
            this.dataGridViewLichTrinh.RowTemplate.Height = 24;
            this.dataGridViewLichTrinh.Size = new System.Drawing.Size(992, 325);
            this.dataGridViewLichTrinh.TabIndex = 0;
            // 
            // malichtrinh
            // 
            this.malichtrinh.DataPropertyName = "malichtrinh";
            this.malichtrinh.HeaderText = "Mã lịch trình";
            this.malichtrinh.MinimumWidth = 6;
            this.malichtrinh.Name = "malichtrinh";
            this.malichtrinh.ReadOnly = true;
            this.malichtrinh.Visible = false;
            this.malichtrinh.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "mactcx";
            this.Column1.HeaderText = "Mã chi tiết";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // machuyenxe
            // 
            this.machuyenxe.DataPropertyName = "machuyenxe";
            this.machuyenxe.HeaderText = "Mã chuyến xe";
            this.machuyenxe.MinimumWidth = 6;
            this.machuyenxe.Name = "machuyenxe";
            this.machuyenxe.ReadOnly = true;
            this.machuyenxe.Visible = false;
            this.machuyenxe.Width = 125;
            // 
            // mota
            // 
            this.mota.DataPropertyName = "mota";
            this.mota.HeaderText = "Mô tả";
            this.mota.MinimumWidth = 6;
            this.mota.Name = "mota";
            this.mota.ReadOnly = true;
            this.mota.Width = 125;
            // 
            // tabPageTrungChuyen
            // 
            this.tabPageTrungChuyen.Controls.Add(this.buttonTimChuyenXeKH);
            this.tabPageTrungChuyen.Location = new System.Drawing.Point(4, 31);
            this.tabPageTrungChuyen.Name = "tabPageTrungChuyen";
            this.tabPageTrungChuyen.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrungChuyen.Size = new System.Drawing.Size(992, 350);
            this.tabPageTrungChuyen.TabIndex = 2;
            this.tabPageTrungChuyen.Text = "Trung chuyển";
            this.tabPageTrungChuyen.UseVisualStyleBackColor = true;
            // 
            // buttonTimChuyenXeKH
            // 
            this.buttonTimChuyenXeKH.BackColor = System.Drawing.Color.White;
            this.buttonTimChuyenXeKH.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonTimChuyenXeKH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTimChuyenXeKH.Location = new System.Drawing.Point(0, 0);
            this.buttonTimChuyenXeKH.Name = "buttonTimChuyenXeKH";
            this.buttonTimChuyenXeKH.Size = new System.Drawing.Size(992, 238);
            this.buttonTimChuyenXeKH.TabIndex = 93;
            this.buttonTimChuyenXeKH.Text = resources.GetString("buttonTimChuyenXeKH.Text");
            this.buttonTimChuyenXeKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTimChuyenXeKH.UseVisualStyleBackColor = false;
            // 
            // tabPageChinhSach
            // 
            this.tabPageChinhSach.Controls.Add(this.button1);
            this.tabPageChinhSach.Location = new System.Drawing.Point(4, 31);
            this.tabPageChinhSach.Name = "tabPageChinhSach";
            this.tabPageChinhSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChinhSach.Size = new System.Drawing.Size(992, 418);
            this.tabPageChinhSach.TabIndex = 3;
            this.tabPageChinhSach.Text = "Chính sách";
            this.tabPageChinhSach.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(991, 415);
            this.button1.TabIndex = 94;
            this.button1.Text = resources.GetString("button1.Text");
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ChiTietChuyenXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 453);
            this.Controls.Add(this.tabControlChiTietChuyenXe);
            this.Name = "ChiTietChuyenXe";
            this.Text = "ChiTietChuyenXe";
            this.tabControlChiTietChuyenXe.ResumeLayout(false);
            this.tabPageLichTrinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLichTrinh)).EndInit();
            this.tabPageTrungChuyen.ResumeLayout(false);
            this.tabPageChinhSach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlChiTietChuyenXe;
        private System.Windows.Forms.TabPage tabPageLichTrinh;
        private System.Windows.Forms.TabPage tabPageTrungChuyen;
        private System.Windows.Forms.TabPage tabPageChinhSach;
        private System.Windows.Forms.DataGridView dataGridViewLichTrinh;
        private System.Windows.Forms.Button buttonTimChuyenXeKH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn malichtrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn machuyenxe;
        private System.Windows.Forms.DataGridViewTextBoxColumn mota;
    }
}