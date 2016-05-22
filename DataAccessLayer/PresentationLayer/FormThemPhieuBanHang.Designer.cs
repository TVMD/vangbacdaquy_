namespace PresentationLayer
{
    partial class FormThemPhieuBanHang
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbKH = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtSoPhieuThu = new System.Windows.Forms.TextBox();
            this.chbKH = new System.Windows.Forms.CheckBox();
            this.cbbKH = new System.Windows.Forms.ComboBox();
            this.dtNgayMua = new System.Windows.Forms.DateTimePicker();
            this.dtNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(257, 123);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(94, 13);
            this.NgayT.TabIndex = 14;
            this.NgayT.Text = "Ngày Thanh Toán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tổng Tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ngày Mua";
            // 
            // lbKH
            // 
            this.lbKH.AutoSize = true;
            this.lbKH.Location = new System.Drawing.Point(257, 76);
            this.lbKH.Name = "lbKH";
            this.lbKH.Size = new System.Drawing.Size(67, 13);
            this.lbKH.TabIndex = 17;
            this.lbKH.Text = "Khách Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Số Phiếu Thu";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(359, 19);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(100, 20);
            this.txtTongTien.TabIndex = 11;
            // 
            // txtSoPhieuThu
            // 
            this.txtSoPhieuThu.Location = new System.Drawing.Point(98, 19);
            this.txtSoPhieuThu.Name = "txtSoPhieuThu";
            this.txtSoPhieuThu.Size = new System.Drawing.Size(100, 20);
            this.txtSoPhieuThu.TabIndex = 9;
            // 
            // chbKH
            // 
            this.chbKH.AutoSize = true;
            this.chbKH.Location = new System.Drawing.Point(23, 71);
            this.chbKH.Name = "chbKH";
            this.chbKH.Size = new System.Drawing.Size(105, 17);
            this.chbKH.TabIndex = 19;
            this.chbKH.Text = "Khách hàng cũ?";
            this.chbKH.UseVisualStyleBackColor = true;
            this.chbKH.CheckedChanged += new System.EventHandler(this.chbKH_CheckedChanged);
            // 
            // cbbKH
            // 
            this.cbbKH.FormattingEnabled = true;
            this.cbbKH.Location = new System.Drawing.Point(359, 69);
            this.cbbKH.Name = "cbbKH";
            this.cbbKH.Size = new System.Drawing.Size(100, 21);
            this.cbbKH.TabIndex = 20;
            // 
            // dtNgayMua
            // 
            this.dtNgayMua.Location = new System.Drawing.Point(98, 117);
            this.dtNgayMua.Name = "dtNgayMua";
            this.dtNgayMua.Size = new System.Drawing.Size(126, 20);
            this.dtNgayMua.TabIndex = 21;
            // 
            // dtNgayThanhToan
            // 
            this.dtNgayThanhToan.Location = new System.Drawing.Point(359, 117);
            this.dtNgayThanhToan.Name = "dtNgayThanhToan";
            this.dtNgayThanhToan.Size = new System.Drawing.Size(126, 20);
            this.dtNgayThanhToan.TabIndex = 21;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(135, 199);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbKH);
            this.groupBox1.Controls.Add(this.txtSoPhieuThu);
            this.groupBox1.Controls.Add(this.dtNgayThanhToan);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.dtNgayMua);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbKH);
            this.groupBox1.Controls.Add(this.chbKH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NgayT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 168);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu thu";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(382, 199);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 22;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FormThemPhieuBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnThem);
            this.Name = "FormThemPhieuBanHang";
            this.Text = "FormThemPhieuBanHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormThemPhieuBanHang_FormClosing);
            this.Load += new System.EventHandler(this.FormThemPhieuBanHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NgayT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtSoPhieuThu;
        private System.Windows.Forms.CheckBox chbKH;
        private System.Windows.Forms.ComboBox cbbKH;
        private System.Windows.Forms.DateTimePicker dtNgayMua;
        private System.Windows.Forms.DateTimePicker dtNgayThanhToan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDong;
    }
}