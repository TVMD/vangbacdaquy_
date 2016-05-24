namespace PresentationLayer
{
    partial class M_KhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M_KhachHang));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSửa = new System.Windows.Forms.ToolStripButton();
            this.toolStripLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripTimkiem = new System.Windows.Forms.ToolStripButton();
            this.groupKhachHang = new System.Windows.Forms.GroupBox();
            this.dateTimePickerNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.NgayT = new System.Windows.Forms.Label();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datagridviewKH = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.groupKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewKH)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripThem,
            this.toolStripXoa,
            this.toolStripSửa,
            this.toolStripLuu,
            this.toolStripTimkiem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(869, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripThem
            // 
            this.toolstripThem.Image = global::PresentationLayer.Properties.Resources.Custom_Icon_Design_Office_Add_1;
            this.toolstripThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripThem.Name = "toolstripThem";
            this.toolstripThem.Size = new System.Drawing.Size(58, 22);
            this.toolstripThem.Text = "Thêm";
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
            // groupKhachHang
            // 
            this.groupKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupKhachHang.Controls.Add(this.dateTimePickerNgaySinh);
            this.groupKhachHang.Controls.Add(this.label1);
            this.groupKhachHang.Controls.Add(this.txtLoai);
            this.groupKhachHang.Controls.Add(this.NgayT);
            this.groupKhachHang.Controls.Add(this.txtMaKhachHang);
            this.groupKhachHang.Controls.Add(this.label4);
            this.groupKhachHang.Controls.Add(this.txtSDT);
            this.groupKhachHang.Controls.Add(this.label5);
            this.groupKhachHang.Controls.Add(this.txtTenKhachHang);
            this.groupKhachHang.Controls.Add(this.label3);
            this.groupKhachHang.Controls.Add(this.txtDiaChi);
            this.groupKhachHang.Controls.Add(this.label2);
            this.groupKhachHang.Location = new System.Drawing.Point(0, 37);
            this.groupKhachHang.Name = "groupKhachHang";
            this.groupKhachHang.Size = new System.Drawing.Size(811, 91);
            this.groupKhachHang.TabIndex = 10;
            this.groupKhachHang.TabStop = false;
            this.groupKhachHang.Text = "Thông tin khách hàng";
            // 
            // dateTimePickerNgaySinh
            // 
            this.dateTimePickerNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgaySinh.Location = new System.Drawing.Point(385, 34);
            this.dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            this.dateTimePickerNgaySinh.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerNgaySinh.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loại";
            // 
            // txtLoai
            // 
            this.txtLoai.Location = new System.Drawing.Point(634, 56);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(114, 20);
            this.txtLoai.TabIndex = 9;
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(289, 63);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(40, 13);
            this.NgayT.TabIndex = 8;
            this.NgayT.Text = "Địa chỉ";
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(94, 29);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(153, 20);
            this.txtMaKhachHang.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số ĐT";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(634, 29);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(114, 20);
            this.txtSDT.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên khách hàng";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(94, 60);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(153, 20);
            this.txtTenKhachHang.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày sinh";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(385, 60);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(140, 20);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã khách hàng";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(811, 31);
            this.label6.TabIndex = 11;
            this.label6.Text = "Danh Sách Khách Hàng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // datagridviewKH
            // 
            this.datagridviewKH.AllowDrop = true;
            this.datagridviewKH.AllowUserToAddRows = false;
            this.datagridviewKH.AllowUserToDeleteRows = false;
            this.datagridviewKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewKH.Location = new System.Drawing.Point(12, 165);
            this.datagridviewKH.Name = "datagridviewKH";
            this.datagridviewKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewKH.Size = new System.Drawing.Size(799, 247);
            this.datagridviewKH.TabIndex = 12;
            // 
            // M_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 427);
            this.Controls.Add(this.datagridviewKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupKhachHang);
            this.Controls.Add(this.toolStrip1);
            this.Name = "M_KhachHang";
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.M_KhachHang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupKhachHang.ResumeLayout(false);
            this.groupKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripThem;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripButton toolStripSửa;
        private System.Windows.Forms.ToolStripButton toolStripLuu;
        private System.Windows.Forms.GroupBox groupKhachHang;
        private System.Windows.Forms.Label NgayT;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripTimkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView datagridviewKH;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgaySinh;
    }
}