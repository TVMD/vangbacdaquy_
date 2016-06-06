namespace PresentationLayer
{
    partial class FormSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSanPham));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTrongLuong = new System.Windows.Forms.TextBox();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.txtTenLoaiSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenKieuSP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSLTon = new System.Windows.Forms.TextBox();
            this.toolstripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSửa = new System.Windows.Forms.ToolStripButton();
            this.toolStripLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripTimkiem = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(736, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSLTon);
            this.groupBox1.Controls.Add(this.txtDonGiaBan);
            this.groupBox1.Controls.Add(this.txtTrongLuong);
            this.groupBox1.Controls.Add(this.txtTenDV);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTenKieuSP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTenLoaiSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 168);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kiểu sản phẩm";
            // 
            // txtTrongLuong
            // 
            this.txtTrongLuong.Location = new System.Drawing.Point(339, 77);
            this.txtTrongLuong.Name = "txtTrongLuong";
            this.txtTrongLuong.ReadOnly = true;
            this.txtTrongLuong.Size = new System.Drawing.Size(107, 20);
            this.txtTrongLuong.TabIndex = 5;
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(112, 77);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.ReadOnly = true;
            this.txtTenDV.Size = new System.Drawing.Size(104, 20);
            this.txtTenDV.TabIndex = 5;
            // 
            // txtTenLoaiSP
            // 
            this.txtTenLoaiSP.Location = new System.Drawing.Point(339, 24);
            this.txtTenLoaiSP.Name = "txtTenLoaiSP";
            this.txtTenLoaiSP.ReadOnly = true;
            this.txtTenLoaiSP.Size = new System.Drawing.Size(104, 20);
            this.txtTenLoaiSP.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Trọng lượng";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(112, 24);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(104, 20);
            this.txtMaSP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên loại sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đơn vị tính";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(696, 246);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên kiểu sản phẩm";
            // 
            // txtTenKieuSP
            // 
            this.txtTenKieuSP.Location = new System.Drawing.Point(565, 25);
            this.txtTenKieuSP.Name = "txtTenKieuSP";
            this.txtTenKieuSP.ReadOnly = true;
            this.txtTenKieuSP.Size = new System.Drawing.Size(104, 20);
            this.txtTenKieuSP.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Đơn giá bán";
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Location = new System.Drawing.Point(565, 77);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.ReadOnly = true;
            this.txtDonGiaBan.Size = new System.Drawing.Size(107, 20);
            this.txtDonGiaBan.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số lượng tồn";
            // 
            // txtSLTon
            // 
            this.txtSLTon.Location = new System.Drawing.Point(112, 124);
            this.txtSLTon.Name = "txtSLTon";
            this.txtSLTon.ReadOnly = true;
            this.txtSLTon.Size = new System.Drawing.Size(107, 20);
            this.txtSLTon.TabIndex = 5;
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
            // toolStripLuu
            // 
            this.toolStripLuu.Image = global::PresentationLayer.Properties.Resources.Save_icon;
            this.toolStripLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLuu.Name = "toolStripLuu";
            this.toolStripLuu.Size = new System.Drawing.Size(116, 22);
            this.toolStripLuu.Text = "Lưu Xuống CSDL";
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
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 533);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormSanPham";
            this.Text = "FormSanPham";
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripThem;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripButton toolStripSửa;
        private System.Windows.Forms.ToolStripButton toolStripLuu;
        private System.Windows.Forms.ToolStripButton toolStripTimkiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTrongLuong;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.TextBox txtTenLoaiSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTenKieuSP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSLTon;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}