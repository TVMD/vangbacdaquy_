namespace PresentationLayer
{
    partial class FormThemLoaiSP
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
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaLoaiSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenLoaiSP = new System.Windows.Forms.TextBox();
            this.txtPhantramloinhuan = new System.Windows.Forms.TextBox();
            this.cbbDV = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(103, 151);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(358, 151);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaLoaiSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenLoaiSP);
            this.groupBox1.Controls.Add(this.txtPhantramloinhuan);
            this.groupBox1.Controls.Add(this.cbbDV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết phiếu nhập";
            // 
            // txtMaLoaiSP
            // 
            this.txtMaLoaiSP.Location = new System.Drawing.Point(129, 25);
            this.txtMaLoaiSP.Name = "txtMaLoaiSP";
            this.txtMaLoaiSP.ReadOnly = true;
            this.txtMaLoaiSP.Size = new System.Drawing.Size(97, 20);
            this.txtMaLoaiSP.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã loại sản phẩm";
            // 
            // txtTenLoaiSP
            // 
            this.txtTenLoaiSP.Location = new System.Drawing.Point(126, 70);
            this.txtTenLoaiSP.Name = "txtTenLoaiSP";
            this.txtTenLoaiSP.Size = new System.Drawing.Size(100, 20);
            this.txtTenLoaiSP.TabIndex = 9;
            // 
            // txtPhantramloinhuan
            // 
            this.txtPhantramloinhuan.Location = new System.Drawing.Point(360, 70);
            this.txtPhantramloinhuan.Name = "txtPhantramloinhuan";
            this.txtPhantramloinhuan.Size = new System.Drawing.Size(100, 20);
            this.txtPhantramloinhuan.TabIndex = 9;
            this.txtPhantramloinhuan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhantramloinhuan_KeyPress);
            // 
            // cbbDV
            // 
            this.cbbDV.FormattingEnabled = true;
            this.cbbDV.Location = new System.Drawing.Point(360, 24);
            this.cbbDV.Name = "cbbDV";
            this.cbbDV.Size = new System.Drawing.Size(100, 21);
            this.cbbDV.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phần trăm lợi nhuận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đơn vị tính";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên loại sản phẩm";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(229, 151);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // FormThemLoaiSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 206);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormThemLoaiSP";
            this.Text = "FormThemLoaiSP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormThemLoaiSP_FormClosing);
            this.Load += new System.EventHandler(this.FormThemLoaiSP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaLoaiSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenLoaiSP;
        private System.Windows.Forms.TextBox txtPhantramloinhuan;
        private System.Windows.Forms.ComboBox cbbDV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCapNhat;
    }
}