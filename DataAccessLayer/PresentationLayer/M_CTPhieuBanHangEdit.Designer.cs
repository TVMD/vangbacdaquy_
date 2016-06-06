namespace PresentationLayer
{
    partial class M_CTPhieuBanHangEdit
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSLTon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxSanPham = new System.Windows.Forms.ComboBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDongGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLuu = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSLTon);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboBoxSanPham);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDongGia);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSL);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(16, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 217);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết phiếu bán";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Số lượng tồn";
            // 
            // txtSLTon
            // 
            this.txtSLTon.Enabled = false;
            this.txtSLTon.Location = new System.Drawing.Point(371, 64);
            this.txtSLTon.Name = "txtSLTon";
            this.txtSLTon.ReadOnly = true;
            this.txtSLTon.Size = new System.Drawing.Size(122, 20);
            this.txtSLTon.TabIndex = 30;
            this.txtSLTon.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Thành tiền";
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
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(114, 156);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(122, 20);
            this.txtThanhTien.TabIndex = 16;
            this.txtThanhTien.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Đơn giá";
            // 
            // txtDongGia
            // 
            this.txtDongGia.Enabled = false;
            this.txtDongGia.Location = new System.Drawing.Point(114, 114);
            this.txtDongGia.Name = "txtDongGia";
            this.txtDongGia.ReadOnly = true;
            this.txtDongGia.Size = new System.Drawing.Size(122, 20);
            this.txtDongGia.TabIndex = 14;
            this.txtDongGia.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Số lượng ";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(115, 64);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(122, 20);
            this.txtSL.TabIndex = 12;
            this.txtSL.Text = "0";
            this.txtSL.TextChanged += new System.EventHandler(this.txtSL_TextChanged);
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLuu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(570, 25);
            this.toolStrip1.TabIndex = 6;
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
            // M_CTPhieuBanHangEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 304);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Name = "M_CTPhieuBanHangEdit";
            this.Text = "Chi tiết phiếu bán hàng";
            this.Load += new System.EventHandler(this.M_CTPhieuBanHangEdit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxSanPham;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDongGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSLTon;
    }
}