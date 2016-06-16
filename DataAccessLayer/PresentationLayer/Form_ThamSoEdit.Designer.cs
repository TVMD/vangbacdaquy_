namespace PresentationLayer
{
    partial class Form_ThamSoEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoToiDa = new System.Windows.Forms.TextBox();
            this.txtQuen = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số nợ tối đa (đồng)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lần giao dịch \r\nđể thành khách quen\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNoToiDa
            // 
            this.txtNoToiDa.Location = new System.Drawing.Point(146, 27);
            this.txtNoToiDa.Name = "txtNoToiDa";
            this.txtNoToiDa.Size = new System.Drawing.Size(100, 20);
            this.txtNoToiDa.TabIndex = 2;
            this.txtNoToiDa.TextChanged += new System.EventHandler(this.txtNoToiDa_TextChanged);
            this.txtNoToiDa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoToiDa_KeyPress);
            // 
            // txtQuen
            // 
            this.txtQuen.Location = new System.Drawing.Point(146, 73);
            this.txtQuen.Name = "txtQuen";
            this.txtQuen.Size = new System.Drawing.Size(100, 20);
            this.txtQuen.TabIndex = 3;
            this.txtQuen.TextChanged += new System.EventHandler(this.txtQuen_TextChanged);
            this.txtQuen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoToiDa_KeyPress);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(55, 150);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(171, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form_ThamSoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 202);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtQuen);
            this.Controls.Add(this.txtNoToiDa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_ThamSoEdit";
            this.Text = "Bảng Tham Số";
            this.Load += new System.EventHandler(this.Form_ThamSoEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoToiDa;
        private System.Windows.Forms.TextBox txtQuen;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnClose;
    }
}