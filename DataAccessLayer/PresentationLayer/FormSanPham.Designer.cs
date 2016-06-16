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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSửa = new System.Windows.Forms.ToolStripButton();
            this.toolStripTimkiem = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbbKieuSP = new System.Windows.Forms.ComboBox();
            this.cbbLoaiSP = new System.Windows.Forms.ComboBox();
            this.txtSLTonMin = new System.Windows.Forms.TextBox();
            this.txtSLTonMax = new System.Windows.Forms.TextBox();
            this.txtDonGiaMin = new System.Windows.Forms.TextBox();
            this.txtDonGiaBanMax = new System.Windows.Forms.TextBox();
            this.txtTrongLuongMin = new System.Windows.Forms.TextBox();
            this.txtTrongLuongMax = new System.Windows.Forms.TextBox();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
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
            this.toolStripTimkiem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(736, 25);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.cbbKieuSP);
            this.groupBox1.Controls.Add(this.cbbLoaiSP);
            this.groupBox1.Controls.Add(this.txtSLTonMin);
            this.groupBox1.Controls.Add(this.txtSLTonMax);
            this.groupBox1.Controls.Add(this.txtDonGiaMin);
            this.groupBox1.Controls.Add(this.txtDonGiaBanMax);
            this.groupBox1.Controls.Add(this.txtTrongLuongMin);
            this.groupBox1.Controls.Add(this.txtTrongLuongMax);
            this.groupBox1.Controls.Add(this.txtTenDV);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 197);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kiểu sản phẩm";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(306, 168);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbbKieuSP
            // 
            this.cbbKieuSP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbKieuSP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbKieuSP.FormattingEnabled = true;
            this.cbbKieuSP.Location = new System.Drawing.Point(565, 20);
            this.cbbKieuSP.Name = "cbbKieuSP";
            this.cbbKieuSP.Size = new System.Drawing.Size(107, 21);
            this.cbbKieuSP.TabIndex = 6;
            // 
            // cbbLoaiSP
            // 
            this.cbbLoaiSP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbLoaiSP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbLoaiSP.FormattingEnabled = true;
            this.cbbLoaiSP.Location = new System.Drawing.Point(339, 20);
            this.cbbLoaiSP.Name = "cbbLoaiSP";
            this.cbbLoaiSP.Size = new System.Drawing.Size(107, 21);
            this.cbbLoaiSP.TabIndex = 6;
            // 
            // txtSLTonMin
            // 
            this.txtSLTonMin.Location = new System.Drawing.Point(9, 127);
            this.txtSLTonMin.Name = "txtSLTonMin";
            this.txtSLTonMin.Size = new System.Drawing.Size(100, 20);
            this.txtSLTonMin.TabIndex = 5;
            // 
            // txtSLTonMax
            // 
            this.txtSLTonMax.Location = new System.Drawing.Point(226, 127);
            this.txtSLTonMax.Name = "txtSLTonMax";
            this.txtSLTonMax.Size = new System.Drawing.Size(100, 20);
            this.txtSLTonMax.TabIndex = 5;
            // 
            // txtDonGiaMin
            // 
            this.txtDonGiaMin.Location = new System.Drawing.Point(339, 127);
            this.txtDonGiaMin.Name = "txtDonGiaMin";
            this.txtDonGiaMin.Size = new System.Drawing.Size(107, 20);
            this.txtDonGiaMin.TabIndex = 5;
            // 
            // txtDonGiaBanMax
            // 
            this.txtDonGiaBanMax.Location = new System.Drawing.Point(565, 127);
            this.txtDonGiaBanMax.Name = "txtDonGiaBanMax";
            this.txtDonGiaBanMax.Size = new System.Drawing.Size(107, 20);
            this.txtDonGiaBanMax.TabIndex = 5;
            // 
            // txtTrongLuongMin
            // 
            this.txtTrongLuongMin.Location = new System.Drawing.Point(339, 77);
            this.txtTrongLuongMin.Name = "txtTrongLuongMin";
            this.txtTrongLuongMin.Size = new System.Drawing.Size(107, 20);
            this.txtTrongLuongMin.TabIndex = 5;
            // 
            // txtTrongLuongMax
            // 
            this.txtTrongLuongMax.Location = new System.Drawing.Point(565, 77);
            this.txtTrongLuongMax.Name = "txtTrongLuongMax";
            this.txtTrongLuongMax.Size = new System.Drawing.Size(107, 20);
            this.txtTrongLuongMax.TabIndex = 5;
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(112, 77);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(104, 20);
            this.txtTenDV.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "≤ Số lượng tồn ≤ ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = " ≤ Đơn giá bán  ≤";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = " ≤ Trọng lượng  ≤";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kiểu sản phẩm";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(112, 24);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(104, 20);
            this.txtMaSP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại sản phẩm";
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 301);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(712, 274);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(595, 47);
            this.label8.TabIndex = 12;
            this.label8.Text = "Danh Sách Sản Phẩm";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 600);
            this.Controls.Add(this.label8);
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
        private System.Windows.Forms.ToolStripButton toolStripTimkiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTrongLuongMax;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSLTonMax;
        private System.Windows.Forms.TextBox txtDonGiaBanMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbKieuSP;
        private System.Windows.Forms.ComboBox cbbLoaiSP;
        private System.Windows.Forms.TextBox txtTrongLuongMin;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSLTonMin;
        private System.Windows.Forms.TextBox txtDonGiaMin;
    }
}