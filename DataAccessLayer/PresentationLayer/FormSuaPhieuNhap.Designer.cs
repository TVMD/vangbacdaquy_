namespace PresentationLayer
{
    partial class FormSuaPhieuNhap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtNgayLAp = new System.Windows.Forms.DateTimePicker();
            this.cbbSoPhieuNhap = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtNgayLAp);
            this.groupBox1.Controls.Add(this.cbbSoPhieuNhap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // dtNgayLAp
            // 
            this.dtNgayLAp.Location = new System.Drawing.Point(302, 25);
            this.dtNgayLAp.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtNgayLAp.Name = "dtNgayLAp";
            this.dtNgayLAp.Size = new System.Drawing.Size(100, 20);
            this.dtNgayLAp.TabIndex = 3;
            // 
            // cbbSoPhieuNhap
            // 
            this.cbbSoPhieuNhap.FormattingEnabled = true;
            this.cbbSoPhieuNhap.Location = new System.Drawing.Point(115, 25);
            this.cbbSoPhieuNhap.Name = "cbbSoPhieuNhap";
            this.cbbSoPhieuNhap.Size = new System.Drawing.Size(103, 21);
            this.cbbSoPhieuNhap.TabIndex = 1;
            this.cbbSoPhieuNhap.SelectedIndexChanged += new System.EventHandler(this.cbbSoPhieuNhap_SelectedIndexChanged);
            this.cbbSoPhieuNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSoPhieuNhap_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày lập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu nhập";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(314, 138);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(76, 138);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // FormSuaPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 201);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSuaPhieuNhap";
            this.Text = "Sửa Phiếu Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSuaPhieuNhap_FormClosing);
            this.Load += new System.EventHandler(this.FormSuaPhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtNgayLAp;
        private System.Windows.Forms.ComboBox cbbSoPhieuNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnSua;
    }
}