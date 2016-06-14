namespace PresentationLayer
{
    partial class M_User
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
            this.label6 = new System.Windows.Forms.Label();
            this.datagridviewPQ = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewPQ)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripThem,
            this.toolStripXoa,
            this.toolStripSửa});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(426, 25);
            this.toolStrip1.TabIndex = 2;
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
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(402, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Danh Sách Người Dùng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // datagridviewPQ
            // 
            this.datagridviewPQ.AllowDrop = true;
            this.datagridviewPQ.AllowUserToAddRows = false;
            this.datagridviewPQ.AllowUserToDeleteRows = false;
            this.datagridviewPQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewPQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridviewPQ.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datagridviewPQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewPQ.Location = new System.Drawing.Point(12, 98);
            this.datagridviewPQ.Name = "datagridviewPQ";
            this.datagridviewPQ.ReadOnly = true;
            this.datagridviewPQ.RowHeadersVisible = false;
            this.datagridviewPQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewPQ.Size = new System.Drawing.Size(402, 285);
            this.datagridviewPQ.TabIndex = 14;
            this.datagridviewPQ.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagridviewPQ_CellMouseDoubleClick);
            // 
            // M_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 395);
            this.Controls.Add(this.datagridviewPQ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip1);
            this.Name = "M_User";
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.M_User_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewPQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripThem;
        private System.Windows.Forms.ToolStripButton toolStripXoa;
        private System.Windows.Forms.ToolStripButton toolStripSửa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView datagridviewPQ;
    }
}