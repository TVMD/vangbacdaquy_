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
    public partial class FormLoaiSP : Form
    {
        LoaiSP_BUS lo = new LoaiSP_BUS();

        public FormLoaiSP()
        {
            InitializeComponent();
        }
        public void load()
        {
            dataGridView1.DataSource = lo.LayLoaiSP();
            dataGridView1.Columns["MaDonViTinh"].Visible=false;
            dataGridView1.Columns["TenDonVi"].HeaderText = "Đơn vị tính";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loai sản phẩm";
            dataGridView1.Columns["PhanTramLoiNhuan"].HeaderText = "Phần trăm lợi nhuận";
            dataGridView1.Columns["MaLoaiSP"].HeaderText = "Mã loại sản phẩm";
        }
        private void FormLoaiSP_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoaiSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenLoaiSP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPhanTram.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTenDV.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng trươc khi xóa");
                return;
            }
            DialogResult dr = MessageBox.Show("Loại sản phẩm này có thể đã được sử dụng, nếu xóa sẽ gây lỗi, bạn có chắc chắn muốn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                lo.XoaLoaiSP(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                load();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemLoaiSP them = new FormThemLoaiSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng để sửa");
                return;
            }
            int malsp = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FormThemLoaiSP them = new FormThemLoaiSP(malsp);
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }
    }
}
