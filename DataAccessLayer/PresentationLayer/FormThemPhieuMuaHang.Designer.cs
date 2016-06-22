namespace PresentationLayer
{
    partial class FormThemPhieuMuaHang
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
            this.NgayT = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbKH = new System.Windows.Forms.Label();
            this.cbbKH = new System.Windows.Forms.ComboBox();
            this.dtNgayMua = new System.Windows.Forms.DateTimePicker();
            this.dtNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemKhachHang = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(21, 78);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(94, 13);
            this.NgayT.TabIndex = 14;
            this.NgayT.Text = "Ngày Thanh Toán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ngày Mua";
            // 
            // lbKH
            // 
            this.lbKH.AutoSize = true;
            this.lbKH.Location = new System.Drawing.Point(19, 26);
            this.lbKH.Name = "lbKH";
            this.lbKH.Size = new System.Drawing.Size(67, 13);
            this.lbKH.TabIndex = 17;
            this.lbKH.Text = "Khách Hàng";
            // 
            // cbbKH
            // 
            this.cbbKH.FormattingEnabled = true;
            this.cbbKH.Location = new System.Drawing.Point(123, 18);
            this.cbbKH.Name = "cbbKH";
            this.cbbKH.Size = new System.Drawing.Size(100, 21);
            this.cbbKH.TabIndex = 20;
            // 
            // dtNgayMua
            // 
            this.dtNgayMua.Location = new System.Drawing.Point(123, 45);
            this.dtNgayMua.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtNgayMua.Name = "dtNgayMua";
            this.dtNgayMua.Size = new System.Drawing.Size(126, 20);
            this.dtNgayMua.TabIndex = 21;
            // 
            // dtNgayThanhToan
            // 
            this.dtNgayThanhToan.Location = new System.Drawing.Point(123, 72);
            this.dtNgayThanhToan.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtNgayThanhToan.Name = "dtNgayThanhToan";
            this.dtNgayThanhToan.Size = new System.Drawing.Size(126, 20);
            this.dtNgayThanhToan.TabIndex = 21;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(29, 162);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemKhachHang);
            this.groupBox1.Controls.Add(this.cbbKH);
            this.groupBox1.Controls.Add(this.dtNgayThanhToan);
            this.groupBox1.Controls.Add(this.dtNgayMua);
            this.groupBox1.Controls.Add(this.lbKH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NgayT);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 127);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu thu";
            // 
            // btnThemKhachHang
            // 
            this.btnThemKhachHang.Image = global::PresentationLayer.Properties.Resources.Custom_Icon_Design_Office_Add_1;
            this.btnThemKhachHang.Location = new System.Drawing.Point(221, 16);
            this.btnThemKhachHang.Name = "btnThemKhachHang";
            this.btnThemKhachHang.Size = new System.Drawing.Size(28, 23);
            this.btnThemKhachHang.TabIndex = 22;
            this.btnThemKhachHang.UseVisualStyleBackColor = true;
            this.btnThemKhachHang.Click += new System.EventHandler(this.btnThemKhachHang_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(186, 162);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 22;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FormThemPhieuMuaHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnThem);
            this.Name = "FormThemPhieuMuaHang";
            this.Text = "Thêm Phiếu Mua Hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormThemPhieuBanHang_FormClosing);
            this.Load += new System.EventHandler(this.FormThemPhieuBanHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NgayT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbKH;
        private System.Windows.Forms.ComboBox cbbKH;
        private System.Windows.Forms.DateTimePicker dtNgayMua;
        private System.Windows.Forms.DateTimePicker dtNgayThanhToan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnThemKhachHang;
    }
}