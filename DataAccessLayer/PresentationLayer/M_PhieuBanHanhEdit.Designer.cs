namespace PresentationLayer
{
    partial class M_PhieuBanHanhEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M_PhieuBanHanhEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSửa = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripTimkiem = new System.Windows.Forms.ToolStripButton();
            this.groupBoxPhieuBan = new System.Windows.Forms.GroupBox();
            this.dateTimePickerNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayBan = new System.Windows.Forms.DateTimePicker();
            this.comboBoxKhachHang = new System.Windows.Forms.ComboBox();
            this.buttonThemKH = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSPhieu = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSanPham = new System.Windows.Forms.ComboBox();
            this.buttonThemCT = new System.Windows.Forms.Button();
            this.ThanhTienmax = new System.Windows.Forms.TextBox();
            this.textBoxThanhTienmin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDonGiamax = new System.Windows.Forms.TextBox();
            this.textBoxDonGiamin = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSlmax = new System.Windows.Forms.TextBox();
            this.textBoxSlmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDongGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewCT = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBoxPhieuBan.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLuu,
            this.toolStripSửa,
            this.toolStripXoa,
            this.toolStripTimkiem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLuu
            // 
            this.toolStripLuu.Image = global::PresentationLayer.Properties.Resources.Save_icon;
            this.toolStripLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLuu.Name = "toolStripLuu";
            this.toolStripLuu.Size = new System.Drawing.Size(116, 22);
            this.toolStripLuu.Text = "Lưu Xuống CSDL";
            // 
            // toolStripSửa
            // 
            this.toolStripSửa.Image = global::PresentationLayer.Properties.Resources.edit__1_;
            this.toolStripSửa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSửa.Name = "toolStripSửa";
            this.toolStripSửa.Size = new System.Drawing.Size(64, 22);
            this.toolStripSửa.Text = "Sửa CT";
            this.toolStripSửa.ToolTipText = "Sửa";
            // 
            // toolStripXoa
            // 
            this.toolStripXoa.Image = global::PresentationLayer.Properties.Resources.Delete_icon1;
            this.toolStripXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoa.Name = "toolStripXoa";
            this.toolStripXoa.Size = new System.Drawing.Size(65, 22);
            this.toolStripXoa.Text = "Xóa CT";
            // 
            // toolStripTimkiem
            // 
            this.toolStripTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTimkiem.Image")));
            this.toolStripTimkiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTimkiem.Name = "toolStripTimkiem";
            this.toolStripTimkiem.Size = new System.Drawing.Size(77, 22);
            this.toolStripTimkiem.Text = "Tìm kiếm";
            this.toolStripTimkiem.ToolTipText = "Tìm kiếm";
            // 
            // groupBoxPhieuBan
            // 
            this.groupBoxPhieuBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPhieuBan.Controls.Add(this.dateTimePickerNgayThanhToan);
            this.groupBoxPhieuBan.Controls.Add(this.dateTimePickerNgayBan);
            this.groupBoxPhieuBan.Controls.Add(this.comboBoxKhachHang);
            this.groupBoxPhieuBan.Controls.Add(this.buttonThemKH);
            this.groupBoxPhieuBan.Controls.Add(this.label5);
            this.groupBoxPhieuBan.Controls.Add(this.txtTongTien);
            this.groupBoxPhieuBan.Controls.Add(this.label4);
            this.groupBoxPhieuBan.Controls.Add(this.label3);
            this.groupBoxPhieuBan.Controls.Add(this.label1);
            this.groupBoxPhieuBan.Controls.Add(this.label2);
            this.groupBoxPhieuBan.Controls.Add(this.txtSPhieu);
            this.groupBoxPhieuBan.Location = new System.Drawing.Point(0, 38);
            this.groupBoxPhieuBan.Name = "groupBoxPhieuBan";
            this.groupBoxPhieuBan.Size = new System.Drawing.Size(248, 265);
            this.groupBoxPhieuBan.TabIndex = 2;
            this.groupBoxPhieuBan.TabStop = false;
            this.groupBoxPhieuBan.Text = "Thông tin phiếu bán";
            // 
            // dateTimePickerNgayThanhToan
            // 
            this.dateTimePickerNgayThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayThanhToan.Location = new System.Drawing.Point(121, 151);
            this.dateTimePickerNgayThanhToan.Name = "dateTimePickerNgayThanhToan";
            this.dateTimePickerNgayThanhToan.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerNgayThanhToan.TabIndex = 22;
            // 
            // dateTimePickerNgayBan
            // 
            this.dateTimePickerNgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayBan.Location = new System.Drawing.Point(120, 124);
            this.dateTimePickerNgayBan.Name = "dateTimePickerNgayBan";
            this.dateTimePickerNgayBan.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerNgayBan.TabIndex = 21;
            // 
            // comboBoxKhachHang
            // 
            this.comboBoxKhachHang.FormattingEnabled = true;
            this.comboBoxKhachHang.Location = new System.Drawing.Point(120, 61);
            this.comboBoxKhachHang.Name = "comboBoxKhachHang";
            this.comboBoxKhachHang.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKhachHang.TabIndex = 20;
            // 
            // buttonThemKH
            // 
            this.buttonThemKH.Location = new System.Drawing.Point(167, 88);
            this.buttonThemKH.Name = "buttonThemKH";
            this.buttonThemKH.Size = new System.Drawing.Size(75, 23);
            this.buttonThemKH.TabIndex = 18;
            this.buttonThemKH.Text = "Thêm mới";
            this.buttonThemKH.UseVisualStyleBackColor = true;
            this.buttonThemKH.Click += new System.EventHandler(this.buttonThemKH_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(120, 184);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(122, 20);
            this.txtTongTien.TabIndex = 16;
            this.txtTongTien.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ngày thanh toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ngày bán";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số phiếu bán";
            // 
            // txtSPhieu
            // 
            this.txtSPhieu.Location = new System.Drawing.Point(120, 36);
            this.txtSPhieu.Name = "txtSPhieu";
            this.txtSPhieu.ReadOnly = true;
            this.txtSPhieu.Size = new System.Drawing.Size(122, 20);
            this.txtSPhieu.TabIndex = 4;
            this.txtSPhieu.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboBoxSanPham);
            this.groupBox2.Controls.Add(this.buttonThemCT);
            this.groupBox2.Controls.Add(this.ThanhTienmax);
            this.groupBox2.Controls.Add(this.textBoxThanhTienmin);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxDonGiamax);
            this.groupBox2.Controls.Add(this.textBoxDonGiamin);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBoxSlmax);
            this.groupBox2.Controls.Add(this.textBoxSlmin);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDongGia);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSL);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(281, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 265);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết phiếu bán";
            // 
            // comboBoxSanPham
            // 
            this.comboBoxSanPham.FormattingEnabled = true;
            this.comboBoxSanPham.Location = new System.Drawing.Point(115, 25);
            this.comboBoxSanPham.Name = "comboBoxSanPham";
            this.comboBoxSanPham.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSanPham.TabIndex = 28;
            this.comboBoxSanPham.SelectedIndexChanged += new System.EventHandler(this.comboBoxSanPham_SelectedIndexChanged);
            // 
            // buttonThemCT
            // 
            this.buttonThemCT.Location = new System.Drawing.Point(230, 231);
            this.buttonThemCT.Name = "buttonThemCT";
            this.buttonThemCT.Size = new System.Drawing.Size(102, 23);
            this.buttonThemCT.TabIndex = 27;
            this.buttonThemCT.Text = "Thêm xuống bảng";
            this.buttonThemCT.UseVisualStyleBackColor = true;
            // 
            // ThanhTienmax
            // 
            this.ThanhTienmax.Location = new System.Drawing.Point(343, 192);
            this.ThanhTienmax.Name = "ThanhTienmax";
            this.ThanhTienmax.Size = new System.Drawing.Size(122, 20);
            this.ThanhTienmax.TabIndex = 26;
            this.ThanhTienmax.Text = "0";
            // 
            // textBoxThanhTienmin
            // 
            this.textBoxThanhTienmin.Location = new System.Drawing.Point(97, 192);
            this.textBoxThanhTienmin.Name = "textBoxThanhTienmin";
            this.textBoxThanhTienmin.Size = new System.Drawing.Size(122, 20);
            this.textBoxThanhTienmin.TabIndex = 25;
            this.textBoxThanhTienmin.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = " ≤ Thành tiền  ≤";
            // 
            // textBoxDonGiamax
            // 
            this.textBoxDonGiamax.Location = new System.Drawing.Point(343, 154);
            this.textBoxDonGiamax.Name = "textBoxDonGiamax";
            this.textBoxDonGiamax.Size = new System.Drawing.Size(122, 20);
            this.textBoxDonGiamax.TabIndex = 23;
            this.textBoxDonGiamax.Text = "0";
            // 
            // textBoxDonGiamin
            // 
            this.textBoxDonGiamin.Location = new System.Drawing.Point(97, 154);
            this.textBoxDonGiamin.Name = "textBoxDonGiamin";
            this.textBoxDonGiamin.Size = new System.Drawing.Size(122, 20);
            this.textBoxDonGiamin.TabIndex = 22;
            this.textBoxDonGiamin.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = " ≤ Đơn giá  ≤";
            // 
            // textBoxSlmax
            // 
            this.textBoxSlmax.Location = new System.Drawing.Point(343, 108);
            this.textBoxSlmax.Name = "textBoxSlmax";
            this.textBoxSlmax.Size = new System.Drawing.Size(122, 20);
            this.textBoxSlmax.TabIndex = 20;
            this.textBoxSlmax.Text = "0";
            // 
            // textBoxSlmin
            // 
            this.textBoxSlmin.Location = new System.Drawing.Point(97, 108);
            this.textBoxSlmin.Name = "textBoxSlmin";
            this.textBoxSlmin.Size = new System.Drawing.Size(122, 20);
            this.textBoxSlmin.TabIndex = 19;
            this.textBoxSlmin.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(241, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = " ≤ Số lượng  ≤";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(384, 64);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(122, 20);
            this.txtThanhTien.TabIndex = 16;
            this.txtThanhTien.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Đơn giá";
            // 
            // txtDongGia
            // 
            this.txtDongGia.Location = new System.Drawing.Point(114, 64);
            this.txtDongGia.Name = "txtDongGia";
            this.txtDongGia.ReadOnly = true;
            this.txtDongGia.Size = new System.Drawing.Size(122, 20);
            this.txtDongGia.TabIndex = 14;
            this.txtDongGia.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Số lượng ";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(384, 28);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(122, 20);
            this.txtSL.TabIndex = 12;
            this.txtSL.Text = "0";
            this.txtSL.TextChanged += new System.EventHandler(this.txtSL_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mã sản phẩm";
            // 
            // dataGridViewCT
            // 
            this.dataGridViewCT.AllowUserToAddRows = false;
            this.dataGridViewCT.AllowUserToDeleteRows = false;
            this.dataGridViewCT.AllowUserToOrderColumns = true;
            this.dataGridViewCT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCT.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCT.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridViewCT.Location = new System.Drawing.Point(8, 357);
            this.dataGridViewCT.Name = "dataGridViewCT";
            this.dataGridViewCT.Size = new System.Drawing.Size(811, 171);
            this.dataGridViewCT.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 314);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(803, 34);
            this.label13.TabIndex = 16;
            this.label13.Text = "Danh sách chi tiết phiếu bán";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Thành tiền";
            // 
            // M_PhieuBanHanhEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 536);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridViewCT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxPhieuBan);
            this.Controls.Add(this.toolStrip1);
            this.Name = "M_PhieuBanHanhEdit";
            this.Text = "Chi tiết phiếu bán hàng";
            this.Load += new System.EventHandler(this.M_PhieuBanHanhEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxPhieuBan.ResumeLayout(false);
            this.groupBoxPhieuBan.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripLuu;
        private System.Windows.Forms.ToolStripButton toolStripSửa;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripButton toolStripTimkiem;
        private System.Windows.Forms.GroupBox groupBoxPhieuBan;
        private System.Windows.Forms.TextBox txtSPhieu;
        private System.Windows.Forms.Button buttonThemKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxKhachHang;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayThanhToan;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayBan;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDongGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSanPham;
        private System.Windows.Forms.Button buttonThemCT;
        private System.Windows.Forms.TextBox ThanhTienmax;
        private System.Windows.Forms.TextBox textBoxThanhTienmin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDonGiamax;
        private System.Windows.Forms.TextBox textBoxDonGiamin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSlmax;
        private System.Windows.Forms.TextBox textBoxSlmin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewCT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
    }
}