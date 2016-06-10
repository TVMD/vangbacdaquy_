using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogiLayer;
using DTO;

namespace PresentationLayer
{
    public partial class FormDonViTinh : Form
    {
        DonViTinh_BUS dv = new DonViTinh_BUS();
        public FormDonViTinh()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public void load()
        {
            dataGridView1.DataSource = dv.LayDVTinh();
            dataGridView1.Columns["MaDonViTinh"].HeaderText = "Mã đơn vị tính";
            dataGridView1.Columns["TenDonViTinh"].HeaderText = "Tên đơn vị tính";
        }
        private void FormDonViTinh_Load(object sender, EventArgs e)
        {
            load();
            ControlBox = false;
        }
        public Form RefToMainForm { set; get; }
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemDVTinh them = new FormThemDVTinh();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng trươc khi xóa");
                return;
            }
            DialogResult dr = MessageBox.Show("Đơn vị tính này có thể đã được sử dụng, nếu xóa sẽ gây lỗi, bạn có chắc chắn muốn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                dv.XoaDVTinh(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                load();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng để sửa");
                return;
            }
            int madv = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FormThemDVTinh them = new FormThemDVTinh(madv);
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenDV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
