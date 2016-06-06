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
    public partial class FormSanPham : Form
    {
        M_SanPhamBLL sp=new M_SanPhamBLL();
        public FormSanPham()
        {
            InitializeComponent();
        }
        void load()
        {
            dataGridView1.DataSource = sp.LaySP();
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            dataGridView1.Columns["TrongLuong"].HeaderText = "Trọng lượng";
            dataGridView1.Columns["DonGiaBan"].HeaderText = "Đơn giá bán";
            dataGridView1.Columns["SoLuongTon"].HeaderText = "Số lượng tổn";
            dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenDonViTinh"].HeaderText = "Dơn vị tính";
        }
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTrongLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaBan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSLTon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtTenLoaiSP.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtTenKieuSP.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTenDV.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng trươc khi xóa");
                return;
            }
            DialogResult dr = MessageBox.Show("Sản phẩm này có thể đã được sử dụng, nếu xóa sẽ gây lỗi, bạn có chắc chắn muốn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                sp.XoaSP(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                load();
            }
        }

        private void toolstripThem_Click(object sender, EventArgs e)
        {
            FormThemSP them = new FormThemSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng để sửa");
                return;
            }
            int malsp = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FormThemSP them = new FormThemSP(malsp);
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }
    }
}
