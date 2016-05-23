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
    public partial class FrmSoPhieuThu : Form
    {
        PhieuMuaHangDLL mh = new PhieuMuaHangDLL();
        public FrmSoPhieuThu()
        {
            InitializeComponent();
        }

        private void FormPhieuBanHang_Load(object sender, EventArgs e)
        {

            load();
            
        }
        public void load()
        {
            dataGridView1.DataSource = mh.LayTatCa();
            dataGridView1.Columns["SoPhieuMua"].HeaderText = "Số Phiếu Mua";
            dataGridView1.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dataGridView1.Columns["NgayMua"].HeaderText = "Ngày Mua";
            dataGridView1.Columns["NgayThanhToan"].HeaderText = "Ngày Thanh Toán";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
            //dataGridView1.Columns["KHACHHANG"].Visible = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mkh=Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())  ;
            txtSoPhieuThu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtKhachHang.Text = mh.LayTenKH(mkh);
            txtTongTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtNgayMua.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNgayThanhToan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void ThemClose(object sender, EventArgs e)
        {
            load();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormThemPhieuBanHang them = new FormThemPhieuBanHang();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
            //them.FormClosed+=ThemClose(sender,e);
            //while(them.FormClosed)

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaPhieuMua sua = new FormSuaPhieuMua();
            sua.ShowDialog();
            if (sua.DialogResult == DialogResult.Cancel)
                load();
        }
    }
}
