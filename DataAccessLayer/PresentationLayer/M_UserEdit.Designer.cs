namespace PresentationLayer
{
    partial class M_UserEdit
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
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.groupKhachHang = new System.Windows.Forms.GroupBox();
            this.comboBoxQuyen = new System.Windows.Forms.ComboBox();
            this.NgayT = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelnewpass = new System.Windows.Forms.Label();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.groupKhachHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonThoat
            // 
            this.buttonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThoat.Location = new System.Drawing.Point(232, 301);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(85, 23);
            this.buttonThoat.TabIndex = 28;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLuu.Location = new System.Drawing.Point(93, 301);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(85, 23);
            this.buttonLuu.TabIndex = 27;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // groupKhachHang
            // 
            this.groupKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupKhachHang.Controls.Add(this.labelnewpass);
            this.groupKhachHang.Controls.Add(this.txtnewpass);
            this.groupKhachHang.Controls.Add(this.comboBoxQuyen);
            this.groupKhachHang.Controls.Add(this.NgayT);
            this.groupKhachHang.Controls.Add(this.txtUser);
            this.groupKhachHang.Controls.Add(this.label5);
            this.groupKhachHang.Controls.Add(this.txtpass);
            this.groupKhachHang.Controls.Add(this.label2);
            this.groupKhachHang.Location = new System.Drawing.Point(28, 31);
            this.groupKhachHang.Name = "groupKhachHang";
            this.groupKhachHang.Size = new System.Drawing.Size(342, 229);
            this.groupKhachHang.TabIndex = 26;
            this.groupKhachHang.TabStop = false;
            this.groupKhachHang.Text = "Thông tin người dùng";
            // 
            // comboBoxQuyen
            // 
            this.comboBoxQuyen.FormattingEnabled = true;
            this.comboBoxQuyen.Location = new System.Drawing.Point(107, 97);
            this.comboBoxQuyen.Name = "comboBoxQuyen";
            this.comboBoxQuyen.Size = new System.Drawing.Size(153, 21);
            this.comboBoxQuyen.TabIndex = 9;
            // 
            // NgayT
            // 
            this.NgayT.AutoSize = true;
            this.NgayT.Location = new System.Drawing.Point(11, 105);
            this.NgayT.Name = "NgayT";
            this.NgayT.Size = new System.Drawing.Size(38, 13);
            this.NgayT.TabIndex = 8;
            this.NgayT.Text = "Quyền";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(107, 29);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(153, 20);
            this.txtUser.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mật khẩu";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(107, 60);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(153, 20);
            this.txtpass.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên người dùng";
            // 
            // labelnewpass
            // 
            this.labelnewpass.AutoSize = true;
            this.labelnewpass.Location = new System.Drawing.Point(11, 146);
            this.labelnewpass.Name = "labelnewpass";
            this.labelnewpass.Size = new System.Drawing.Size(71, 13);
            this.labelnewpass.TabIndex = 11;
            this.labelnewpass.Text = "Mật khẩu mới";
            // 
            // txtnewpass
            // 
            this.txtnewpass.Location = new System.Drawing.Point(107, 143);
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.Size = new System.Drawing.Size(153, 20);
            this.txtnewpass.TabIndex = 10;
            // 
            // M_UserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 344);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.groupKhachHang);
            this.Name = "M_UserEdit";
            this.Text = "M_UserEdit";
            this.Load += new System.EventHandler(this.M_UserEdit_Load);
            this.groupKhachHang.ResumeLayout(false);
            this.groupKhachHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.GroupBox groupKhachHang;
        private System.Windows.Forms.ComboBox comboBoxQuyen;
        private System.Windows.Forms.Label NgayT;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label labelnewpass;
        private System.Windows.Forms.TextBox txtnewpass;
    }
}