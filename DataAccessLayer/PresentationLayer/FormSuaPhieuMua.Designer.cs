namespace PresentationLayer
{
    partial class FormSuaPhieuMua
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemKhachHang = new System.Windows.Forms.Button();
            this.cbbKH = new System.Windows.Forms.ComboBox();
            this.dtNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.dtNgayMua = new System.Windows.Forms.DateTimePicker();
            this.lbKH = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NgayT = new System.Windows.Forms.Label();
            this.cbbSoPhieuMua = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.cbbSoPhieuMua);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 144);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu mua";
            // 
            // btnThemKhachHang
            // 
            this.btnThemKhachHang.Image = global::PresentationLayer.Properties.Resources.Custom_Icon_Design_Office_Add_1;
            this.btnThemKhachHang.Location = new System.Drawing.Point(222, 43);
            this.btnThemKhachHang.Name = "btnThemKhachHang";
            this.btnThemKhachHang.Size = new System.Drawing.Size(28, 23);
            this.btnThemKhachHang.TabIndex = 29;
            this.btnThemKhachHang.UseVisualStyleBackColor = true;
            this.btnThemKhachHang.Click += new System.EventHandler(this.btnThemKhachHang_Click);
            // 
            // cbbKH
            // 
            this.cbbKH.FormattingEnabled = true;
            this.cbbKH.Location = new System.Drawing.Point(124, 45);
            this.cbbKH.Name = "cbbKH";
            this.cbbKH.Size = new System.Drawing.Size(100, 21);
            this.cbbKH.TabIndex = 26;
            // 
            // dtNgayThanhToan
            // 
            this.dtNgayThanhToan.Location = new System.Drawing.Point(124, 99);
            this.dtNgayThanhToan.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtNgayThanhToan.Name = "dtNgayThanhToan";
            this.dtNgayThanhToan.Size = new System.Drawing.Size(126, 20);
            this.dtNgayThanhToan.TabIndex = 27;
            // 
            // dtNgayMua
            // 
            this.dtNgayMua.Location = new System.Drawing.Point(124, 72);
            this.dtNgayMua.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtNgayMua.Name = "dtNgayMua";
            this.dtNgayMua.Size = new System.Drawing.Size(126, 20);
            this.dtNgayMua.TabIndex = 28;
            // 
            // lbKH
            // 
            this.lbKH.AutoSize = true;
            this.lbKH.Location = new System.Drawing.Point(20, 53);
            this.lbKH.Name = "lbKH";
            this.lbKH.Size = new System.Drawing.Size(67, 13);
            this.lbKH.TabIndex = 25;
            this.lbKH.Text = "Khách Hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Ngày Mua";
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(22, 105);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(94, 13);
            this.NgayT.TabIndex = 23;
            this.NgayT.Text = "Ngày Thanh Toán";
            // 
            // cbbSoPhieuMua
            // 
            this.cbbSoPhieuMua.FormattingEnabled = true;
            this.cbbSoPhieuMua.Location = new System.Drawing.Point(124, 19);
            this.cbbSoPhieuMua.Name = "cbbSoPhieuMua";
            this.cbbSoPhieuMua.Size = new System.Drawing.Size(100, 21);
            this.cbbSoPhieuMua.TabIndex = 20;
            this.cbbSoPhieuMua.SelectedIndexChanged += new System.EventHandler(this.cbbSoPhieuMua_SelectedIndexChanged);
            this.cbbSoPhieuMua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSoPhieuMua_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Số Phiếu Mua";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(161, 188);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 24;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(31, 188);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 25;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // FormSuaPhieuMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 241);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnSua);
            this.Name = "FormSuaPhieuMua";
            this.Text = "Sửa Phiếu Mua";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuaPhieuMua_FormClosing);
            this.Load += new System.EventHandler(this.FormSuaPhieuMua_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbSoPhieuMua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThemKhachHang;
        private System.Windows.Forms.ComboBox cbbKH;
        private System.Windows.Forms.DateTimePicker dtNgayThanhToan;
        private System.Windows.Forms.DateTimePicker dtNgayMua;
        private System.Windows.Forms.Label lbKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label NgayT;
    }
}