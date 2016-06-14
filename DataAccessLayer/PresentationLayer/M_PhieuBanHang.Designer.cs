namespace PresentationLayer
{
    partial class M_PhieuBanHang
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSửa = new System.Windows.Forms.ToolStripButton();
            this.toolStripTimkiem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXem = new System.Windows.Forms.ToolStripButton();
            this.datagridviewPhieuBan = new System.Windows.Forms.DataGridView();
            this.groupPhieuBan = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtSoTienTraMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoTienTraMin = new System.Windows.Forms.TextBox();
            this.txtTongTienMax = new System.Windows.Forms.TextBox();
            this.dateTimePickerNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayban = new System.Windows.Forms.DateTimePicker();
            this.NgayT = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTienMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewPhieuBan)).BeginInit();
            this.groupPhieuBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripThem,
            this.toolStripXoa,
            this.toolStripSửa,
            this.toolStripTimkiem,
            this.toolStripButtonXem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(979, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripThem
            // 
            this.toolstripThem.Image = global::PresentationLayer.Properties.Resources.Custom_Icon_Design_Office_Add_1;
            this.toolstripThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripThem.Name = "toolstripThem";
            this.toolstripThem.Size = new System.Drawing.Size(58, 22);
            this.toolstripThem.Text = "Thêm";
            this.toolstripThem.Click += new System.EventHandler(this.toolstripThem_Click);
            // 
            // toolStripXoa
            // 
            this.toolStripXoa.Image = global::PresentationLayer.Properties.Resources.Delete_icon1;
            this.toolStripXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoa.Name = "toolStripXoa";
            this.toolStripXoa.Size = new System.Drawing.Size(50, 22);
            this.toolStripXoa.Text = "Xóa ";
            this.toolStripXoa.Click += new System.EventHandler(this.toolStripXoa_Click);
            // 
            // toolStripSửa
            // 
            this.toolStripSửa.Image = global::PresentationLayer.Properties.Resources.edit__1_;
            this.toolStripSửa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSửa.Name = "toolStripSửa";
            this.toolStripSửa.Size = new System.Drawing.Size(46, 22);
            this.toolStripSửa.Text = "Sửa";
            this.toolStripSửa.ToolTipText = "Sửa";
            this.toolStripSửa.Click += new System.EventHandler(this.toolStripSửa_Click);
            // 
            // toolStripTimkiem
            // 
            this.toolStripTimkiem.Image = global::PresentationLayer.Properties.Resources.tim;
            this.toolStripTimkiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTimkiem.Name = "toolStripTimkiem";
            this.toolStripTimkiem.Size = new System.Drawing.Size(77, 22);
            this.toolStripTimkiem.Text = "Tìm kiếm";
            this.toolStripTimkiem.ToolTipText = "Tìm kiếm";
            this.toolStripTimkiem.Click += new System.EventHandler(this.toolStripTimkiem_Click);
            // 
            // toolStripButtonXem
            // 
            this.toolStripButtonXem.Image = global::PresentationLayer.Properties.Resources.eye_512;
            this.toolStripButtonXem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXem.Name = "toolStripButtonXem";
            this.toolStripButtonXem.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonXem.Text = "Xem";
            this.toolStripButtonXem.Click += new System.EventHandler(this.toolStripButtonXem_Click);
            // 
            // datagridviewPhieuBan
            // 
            this.datagridviewPhieuBan.AllowDrop = true;
            this.datagridviewPhieuBan.AllowUserToAddRows = false;
            this.datagridviewPhieuBan.AllowUserToDeleteRows = false;
            this.datagridviewPhieuBan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.datagridviewPhieuBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewPhieuBan.Location = new System.Drawing.Point(9, 214);
            this.datagridviewPhieuBan.Name = "datagridviewPhieuBan";
            this.datagridviewPhieuBan.ReadOnly = true;
            this.datagridviewPhieuBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewPhieuBan.Size = new System.Drawing.Size(955, 281);
            this.datagridviewPhieuBan.TabIndex = 14;
            this.datagridviewPhieuBan.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagridviewPhieuBan_CellMouseClick);
            this.datagridviewPhieuBan.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagridviewPhieuBan_CellMouseDoubleClick);
            // 
            // groupPhieuBan
            // 
            this.groupPhieuBan.Controls.Add(this.label7);
            this.groupPhieuBan.Controls.Add(this.txtTenKhachHang);
            this.groupPhieuBan.Controls.Add(this.txtSoTienTraMax);
            this.groupPhieuBan.Controls.Add(this.label1);
            this.groupPhieuBan.Controls.Add(this.txtSoTienTraMin);
            this.groupPhieuBan.Controls.Add(this.txtTongTienMax);
            this.groupPhieuBan.Controls.Add(this.dateTimePickerNgayThanhToan);
            this.groupPhieuBan.Controls.Add(this.dateTimePickerNgayban);
            this.groupPhieuBan.Controls.Add(this.NgayT);
            this.groupPhieuBan.Controls.Add(this.txtSoPhieu);
            this.groupPhieuBan.Controls.Add(this.label4);
            this.groupPhieuBan.Controls.Add(this.txtTongTienMin);
            this.groupPhieuBan.Controls.Add(this.label5);
            this.groupPhieuBan.Controls.Add(this.txtMaKhachHang);
            this.groupPhieuBan.Controls.Add(this.label3);
            this.groupPhieuBan.Controls.Add(this.label2);
            this.groupPhieuBan.Location = new System.Drawing.Point(9, 28);
            this.groupPhieuBan.Name = "groupPhieuBan";
            this.groupPhieuBan.Size = new System.Drawing.Size(958, 117);
            this.groupPhieuBan.TabIndex = 13;
            this.groupPhieuBan.TabStop = false;
            this.groupPhieuBan.Text = "Thông tin phiếu bán hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tên khách hàng";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(94, 86);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(92, 20);
            this.txtTenKhachHang.TabIndex = 18;
            this.txtTenKhachHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenKhachHang_KeyPress);
            // 
            // txtSoTienTraMax
            // 
            this.txtSoTienTraMax.Location = new System.Drawing.Point(796, 62);
            this.txtSoTienTraMax.Name = "txtSoTienTraMax";
            this.txtSoTienTraMax.Size = new System.Drawing.Size(121, 20);
            this.txtSoTienTraMax.TabIndex = 17;
            this.txtSoTienTraMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTienTraMax_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(695, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = " ≤ Số tiền trả ≤";
            // 
            // txtSoTienTraMin
            // 
            this.txtSoTienTraMin.Location = new System.Drawing.Point(553, 60);
            this.txtSoTienTraMin.Name = "txtSoTienTraMin";
            this.txtSoTienTraMin.Size = new System.Drawing.Size(121, 20);
            this.txtSoTienTraMin.TabIndex = 15;
            this.txtSoTienTraMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTienTraMin_KeyPress);
            // 
            // txtTongTienMax
            // 
            this.txtTongTienMax.Location = new System.Drawing.Point(796, 33);
            this.txtTongTienMax.Name = "txtTongTienMax";
            this.txtTongTienMax.Size = new System.Drawing.Size(121, 20);
            this.txtTongTienMax.TabIndex = 14;
            this.txtTongTienMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongTienMax_KeyPress);
            // 
            // dateTimePickerNgayThanhToan
            // 
            this.dateTimePickerNgayThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayThanhToan.Location = new System.Drawing.Point(310, 65);
            this.dateTimePickerNgayThanhToan.Name = "dateTimePickerNgayThanhToan";
            this.dateTimePickerNgayThanhToan.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerNgayThanhToan.TabIndex = 13;
            // 
            // dateTimePickerNgayban
            // 
            this.dateTimePickerNgayban.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgayban.Location = new System.Drawing.Point(310, 36);
            this.dateTimePickerNgayban.Name = "dateTimePickerNgayban";
            this.dateTimePickerNgayban.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerNgayban.TabIndex = 11;
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(214, 65);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(86, 13);
            this.NgayT.TabIndex = 8;
            this.NgayT.Text = "Ngày thanh toán";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(94, 29);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(92, 20);
            this.txtSoPhieu.TabIndex = 3;
            this.txtSoPhieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoPhieu_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(691, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = " ≤ Tổng tiền  ≤";
            // 
            // txtTongTienMin
            // 
            this.txtTongTienMin.Location = new System.Drawing.Point(553, 31);
            this.txtTongTienMin.Name = "txtTongTienMin";
            this.txtTongTienMin.Size = new System.Drawing.Size(121, 20);
            this.txtTongTienMin.TabIndex = 5;
            this.txtTongTienMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTongTienMin_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã khách hàng";
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(94, 60);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(92, 20);
            this.txtMaKhachHang.TabIndex = 6;
            this.txtMaKhachHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaKhachHang_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Số phiếu ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(955, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Danh sách phiếu bán hàng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // M_PhieuBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 496);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datagridviewPhieuBan);
            this.Controls.Add(this.groupPhieuBan);
            this.Controls.Add(this.toolStrip1);
            this.Name = "M_PhieuBanHang";
            this.Text = "Phiếu bán hàng";
            this.Load += new System.EventHandler(this.M_PhieuBanHang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewPhieuBan)).EndInit();
            this.groupPhieuBan.ResumeLayout(false);
            this.groupPhieuBan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripThem;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripButton toolStripSửa;
        private System.Windows.Forms.ToolStripButton toolStripTimkiem;
        private System.Windows.Forms.DataGridView datagridviewPhieuBan;
        private System.Windows.Forms.GroupBox groupPhieuBan;
        private System.Windows.Forms.Label NgayT;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongTienMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayThanhToan;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayban;
        private System.Windows.Forms.ToolStripButton toolStripButtonXem;
        private System.Windows.Forms.TextBox txtTongTienMax;
        private System.Windows.Forms.TextBox txtSoTienTraMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoTienTraMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenKhachHang;
    }
}