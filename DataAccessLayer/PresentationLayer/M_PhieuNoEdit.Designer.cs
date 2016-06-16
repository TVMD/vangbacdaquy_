namespace PresentationLayer
{
    partial class M_PhieuNoEdit
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
            this.groupKhachHang = new System.Windows.Forms.GroupBox();
            this.comboBoxPhieuBan = new System.Windows.Forms.ComboBox();
            this.dateTimePickerNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerNgayNo = new System.Windows.Forms.DateTimePicker();
            this.NgayT = new System.Windows.Forms.Label();
            this.txtSoPhieuNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoTienTra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.groupKhachHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupKhachHang
            // 
            this.groupKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupKhachHang.Controls.Add(this.comboBoxPhieuBan);
            this.groupKhachHang.Controls.Add(this.dateTimePickerNgayThanhToan);
            this.groupKhachHang.Controls.Add(this.label1);
            this.groupKhachHang.Controls.Add(this.dateTimePickerNgayNo);
            this.groupKhachHang.Controls.Add(this.NgayT);
            this.groupKhachHang.Controls.Add(this.txtSoPhieuNo);
            this.groupKhachHang.Controls.Add(this.label4);
            this.groupKhachHang.Controls.Add(this.txtConLai);
            this.groupKhachHang.Controls.Add(this.label5);
            this.groupKhachHang.Controls.Add(this.label3);
            this.groupKhachHang.Controls.Add(this.txtSoTienTra);
            this.groupKhachHang.Controls.Add(this.label2);
            this.groupKhachHang.Location = new System.Drawing.Point(12, 40);
            this.groupKhachHang.Name = "groupKhachHang";
            this.groupKhachHang.Size = new System.Drawing.Size(422, 252);
            this.groupKhachHang.TabIndex = 14;
            this.groupKhachHang.TabStop = false;
            this.groupKhachHang.Text = "Thông tin phiếu nợ";
            // 
            // comboBoxPhieuBan
            // 
            this.comboBoxPhieuBan.FormattingEnabled = true;
            this.comboBoxPhieuBan.Location = new System.Drawing.Point(107, 63);
            this.comboBoxPhieuBan.Name = "comboBoxPhieuBan";
            this.comboBoxPhieuBan.Size = new System.Drawing.Size(153, 21);
            this.comboBoxPhieuBan.TabIndex = 21;
            this.comboBoxPhieuBan.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhieuBan_SelectedIndexChanged);
            // 
            // dateTimePickerNgayThanhToan
            // 
            this.dateTimePickerNgayThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayThanhToan.Location = new System.Drawing.Point(107, 133);
            this.dateTimePickerNgayThanhToan.Name = "dateTimePickerNgayThanhToan";
            this.dateTimePickerNgayThanhToan.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerNgayThanhToan.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ngày thanh toán";
            // 
            // dateTimePickerNgayNo
            // 
            this.dateTimePickerNgayNo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayNo.Location = new System.Drawing.Point(107, 99);
            this.dateTimePickerNgayNo.Name = "dateTimePickerNgayNo";
            this.dateTimePickerNgayNo.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerNgayNo.TabIndex = 11;
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(11, 167);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(55, 13);
            this.NgayT.TabIndex = 8;
            this.NgayT.Text = "Số tiền trả";
            // 
            // txtSoPhieuNo
            // 
            this.txtSoPhieuNo.Location = new System.Drawing.Point(107, 29);
            this.txtSoPhieuNo.Name = "txtSoPhieuNo";
            this.txtSoPhieuNo.Size = new System.Drawing.Size(153, 20);
            this.txtSoPhieuNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số tiền còn lại";
            // 
            // txtConLai
            // 
            this.txtConLai.Enabled = false;
            this.txtConLai.Location = new System.Drawing.Point(107, 203);
            this.txtConLai.Name = "txtConLai";
            this.txtConLai.Size = new System.Drawing.Size(153, 20);
            this.txtConLai.TabIndex = 5;
            this.txtConLai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConLai_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số phiếu bán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày nợ";
            // 
            // txtSoTienTra
            // 
            this.txtSoTienTra.Location = new System.Drawing.Point(107, 164);
            this.txtSoTienTra.Multiline = true;
            this.txtSoTienTra.Name = "txtSoTienTra";
            this.txtSoTienTra.Size = new System.Drawing.Size(153, 20);
            this.txtSoTienTra.TabIndex = 7;
            this.txtSoTienTra.TextChanged += new System.EventHandler(this.txtSoTienTra_TextChanged);
            this.txtSoTienTra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTienTra_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Số phiếu nợ";
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(76, 310);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(75, 23);
            this.buttonLuu.TabIndex = 15;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Location = new System.Drawing.Point(235, 310);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(75, 23);
            this.buttonThoat.TabIndex = 16;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // M_PhieuNoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 396);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.groupKhachHang);
            this.Name = "M_PhieuNoEdit";
            this.Text = "Phiếu nợ";
            this.Load += new System.EventHandler(this.M_PhieuNoEdit_Load);
            this.groupKhachHang.ResumeLayout(false);
            this.groupKhachHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupKhachHang;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayNo;
        private System.Windows.Forms.Label NgayT;
        private System.Windows.Forms.TextBox txtSoPhieuNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoTienTra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPhieuBan;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.Button buttonThoat;
    }
}