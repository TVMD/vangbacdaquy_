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
            this.toolStripButtonThem = new System.Windows.Forms.ToolStripButton();
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaSPTK = new System.Windows.Forms.TextBox();
            this.txtThanhTienmax = new System.Windows.Forms.TextBox();
            this.txtThanhTienmin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDonGiamax = new System.Windows.Forms.TextBox();
            this.txtDonGiamin = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSlmax = new System.Windows.Forms.TextBox();
            this.txtSlmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewCT = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSoTienTra = new System.Windows.Forms.TextBox();
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
            this.toolStripButtonThem,
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
            this.toolStripLuu.Click += new System.EventHandler(this.toolStripLuu_Click);
            // 
            // toolStripButtonThem
            // 
            this.toolStripButtonThem.Image = global::PresentationLayer.Properties.Resources.Custom_Icon_Design_Office_Add_1;
            this.toolStripButtonThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonThem.Name = "toolStripButtonThem";
            this.toolStripButtonThem.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonThem.Text = "Thêm CT";
            this.toolStripButtonThem.Click += new System.EventHandler(this.toolStripButtonThem_Click);
            // 
            // toolStripSửa
            // 
            this.toolStripSửa.Image = global::PresentationLayer.Properties.Resources.edit__1_;
            this.toolStripSửa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSửa.Name = "toolStripSửa";
            this.toolStripSửa.Size = new System.Drawing.Size(64, 22);
            this.toolStripSửa.Text = "Sửa CT";
            this.toolStripSửa.ToolTipText = "Sửa";
            this.toolStripSửa.Click += new System.EventHandler(this.toolStripSửa_Click);
            // 
            // toolStripXoa
            // 
            this.toolStripXoa.Image = global::PresentationLayer.Properties.Resources.Delete_icon1;
            this.toolStripXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoa.Name = "toolStripXoa";
            this.toolStripXoa.Size = new System.Drawing.Size(65, 22);
            this.toolStripXoa.Text = "Xóa CT";
            this.toolStripXoa.Click += new System.EventHandler(this.toolStripXoa_Click);
            // 
            // toolStripTimkiem
            // 
            this.toolStripTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTimkiem.Image")));
            this.toolStripTimkiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTimkiem.Name = "toolStripTimkiem";
            this.toolStripTimkiem.Size = new System.Drawing.Size(77, 22);
            this.toolStripTimkiem.Text = "Tìm kiếm";
            this.toolStripTimkiem.ToolTipText = "Tìm kiếm";
            this.toolStripTimkiem.Click += new System.EventHandler(this.toolStripTimkiem_Click);
            // 
            // groupBoxPhieuBan
            // 
            this.groupBoxPhieuBan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPhieuBan.Controls.Add(this.label16);
            this.groupBoxPhieuBan.Controls.Add(this.txtSoTienTra);
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
            this.groupBoxPhieuBan.Size = new System.Drawing.Size(248, 467);
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
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
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
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtMaSPTK);
            this.groupBox2.Controls.Add(this.txtThanhTienmax);
            this.groupBox2.Controls.Add(this.txtThanhTienmin);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDonGiamax);
            this.groupBox2.Controls.Add(this.txtDonGiamin);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSlmax);
            this.groupBox2.Controls.Add(this.txtSlmin);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(268, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 127);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết phiếu bán";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Mã SP";
            // 
            // txtMaSPTK
            // 
            this.txtMaSPTK.Location = new System.Drawing.Point(47, 52);
            this.txtMaSPTK.Name = "txtMaSPTK";
            this.txtMaSPTK.Size = new System.Drawing.Size(91, 20);
            this.txtMaSPTK.TabIndex = 30;
            this.txtMaSPTK.Text = "0";
            // 
            // txtThanhTienmax
            // 
            this.txtThanhTienmax.Location = new System.Drawing.Point(406, 77);
            this.txtThanhTienmax.Name = "txtThanhTienmax";
            this.txtThanhTienmax.Size = new System.Drawing.Size(122, 20);
            this.txtThanhTienmax.TabIndex = 26;
            this.txtThanhTienmax.Text = "0";
            // 
            // txtThanhTienmin
            // 
            this.txtThanhTienmin.Location = new System.Drawing.Point(160, 77);
            this.txtThanhTienmin.Name = "txtThanhTienmin";
            this.txtThanhTienmin.Size = new System.Drawing.Size(122, 20);
            this.txtThanhTienmin.TabIndex = 25;
            this.txtThanhTienmin.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = " ≤ Thành tiền  ≤";
            // 
            // txtDonGiamax
            // 
            this.txtDonGiamax.Location = new System.Drawing.Point(406, 49);
            this.txtDonGiamax.Name = "txtDonGiamax";
            this.txtDonGiamax.Size = new System.Drawing.Size(122, 20);
            this.txtDonGiamax.TabIndex = 23;
            this.txtDonGiamax.Text = "0";
            // 
            // txtDonGiamin
            // 
            this.txtDonGiamin.Location = new System.Drawing.Point(160, 49);
            this.txtDonGiamin.Name = "txtDonGiamin";
            this.txtDonGiamin.Size = new System.Drawing.Size(122, 20);
            this.txtDonGiamin.TabIndex = 22;
            this.txtDonGiamin.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(304, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = " ≤ Đơn giá  ≤";
            // 
            // txtSlmax
            // 
            this.txtSlmax.Location = new System.Drawing.Point(406, 19);
            this.txtSlmax.Name = "txtSlmax";
            this.txtSlmax.Size = new System.Drawing.Size(122, 20);
            this.txtSlmax.TabIndex = 20;
            this.txtSlmax.Text = "0";
            // 
            // txtSlmin
            // 
            this.txtSlmin.Location = new System.Drawing.Point(160, 19);
            this.txtSlmin.Name = "txtSlmin";
            this.txtSlmin.Size = new System.Drawing.Size(122, 20);
            this.txtSlmin.TabIndex = 19;
            this.txtSlmin.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(304, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = " ≤ Số lượng  ≤";
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
            this.dataGridViewCT.Location = new System.Drawing.Point(268, 225);
            this.dataGridViewCT.Name = "dataGridViewCT";
            this.dataGridViewCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCT.Size = new System.Drawing.Size(551, 299);
            this.dataGridViewCT.TabIndex = 5;
            this.dataGridViewCT.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCT_CellMouseDoubleClick);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(280, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(532, 34);
            this.label13.TabIndex = 16;
            this.label13.Text = "Danh sách chi tiết phiếu bán";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 222);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Số tiền trả";
            // 
            // txtSoTienTra
            // 
            this.txtSoTienTra.Location = new System.Drawing.Point(120, 219);
            this.txtSoTienTra.Name = "txtSoTienTra";
            this.txtSoTienTra.Size = new System.Drawing.Size(121, 20);
            this.txtSoTienTra.TabIndex = 32;
            this.txtSoTienTra.Text = "0";
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.M_PhieuBanHanhEdit_FormClosing);
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
        private System.Windows.Forms.TextBox txtThanhTienmax;
        private System.Windows.Forms.TextBox txtThanhTienmin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDonGiamax;
        private System.Windows.Forms.TextBox txtDonGiamin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSlmax;
        private System.Windows.Forms.TextBox txtSlmin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewCT;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMaSPTK;
        private System.Windows.Forms.ToolStripButton toolStripButtonThem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSoTienTra;
    }
}