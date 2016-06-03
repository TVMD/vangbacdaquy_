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
    public partial class FormKieuSP : Form
    {
        KieuSP_BUS ct = new KieuSP_BUS();
        public FormKieuSP()
        {
            InitializeComponent();
        }
        public void load()
        {
            dataGridView1.DataSource = ct.LayKieuSP();
            dataGridView1.Columns["MaKieuSP"].HeaderText = "Mã kiểu sản phẩm";
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Tên kiểu sản phẩm";
        }
        private void FormKieuSP_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKieuSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenKieuSP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow==null)
            {
                MessageBox.Show("Bạn phải chọn một dòng trươc khi xóa");
                return;
            }
            DialogResult dr = MessageBox.Show("Kiểu sản phẩm này có thể đã được sử dụng, nếu xóa sẽ gây lỗi, bạn có chắc chắn muốn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                ct.XoaKieuSP(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                load();
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemKieuSP them = new FormThemKieuSP();
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
            int maksp = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FormThemKieuSP them = new FormThemKieuSP(maksp);
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }
    }
}
