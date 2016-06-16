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
        int Quyen;
        public FrmSoPhieuThu()
        {
            InitializeComponent();
            ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public FrmSoPhieuThu(int quyen)
        {
            InitializeComponent();
            ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Quyen = quyen;
        }

        private void FormPhieuBanHang_Load(object sender, EventArgs e)
        {
            
            load();
            
        }
        public Form RefToMainForm { set; get; }
        public void load()
        {
            if(Quyen==1)
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
            if (Quyen == 2)
            {
                btnThem.Visible = false;
            }
            dataGridView1.DataSource = mh.LayTatCa();
            dataGridView1.Columns["SoPhieuMua"].HeaderText = "Số Phiếu Mua";
            dataGridView1.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dataGridView1.Columns["NgayMua"].HeaderText = "Ngày Mua";
            dataGridView1.Columns["NgayThanhToan"].HeaderText = "Ngày Thanh Toán";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dataGridView1.Columns["TenKH"].HeaderText = "Khách hàng";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            //cbbKH.DataSource = mh.LayKH();
            //cbbKH.DisplayMember = "TenKh";
            //cbbKH.ValueMember = "MaKh";
            dtNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtNgayThanhToan.CustomFormat = "dd-MM-yyyy";
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd-MM-yyyy";
            
            //dataGridView1.Columns["KHACHHANG"].Visible = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mkh = Int16.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            txtSoPhieuThu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtKhachHang.Text = mh.Lay1KH(mkh).TenKh;
            txtTongTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtNgayMua.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dtNgayThanhToan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = mh.Lay1KH(mkh).DiaChi;
            
        }

        private void ThemClose(object sender, EventArgs e)
        {
            load();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormThemPhieuMuaHang them = new FormThemPhieuMuaHang();
            them.RefToMom = this;
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
            //them.FormClosed+=ThemClose(sender,e);
            //while(them.FormClosed)

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaPhieuMua sua;
            if(dataGridView1.SelectedRows.Count!=0)
            {
                int sopm=Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sua=new FormSuaPhieuMua(sopm);
            }
            else
            sua= new FormSuaPhieuMua();
            sua.RefToMom = this;
            sua.ShowDialog();
            if (sua.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PhieuMuaHang_DTO a = new PhieuMuaHang_DTO();
            string diachi;
            string tenkh;
            if (txtSoPhieuThu.Text != "")
                a.SoPhieuMua = Int16.Parse(txtSoPhieuThu.Text);
            else a.SoPhieuMua = -1;
            tenkh = txtKhachHang.Text;
            a.MaKH = -1;
            //string ngaymua = "";
            //string ngaythanhtoan = "";
           
            if (dtNgayThanhToan.Value.Date!=DateTime.Now.Date)
                a.NgayThanhToan = dtNgayThanhToan.Value.ToShortDateString();
            if (dtNgayMua.Value.Date!=DateTime.Now.Date)
                a.NgayMua = dtNgayMua.Value.ToShortDateString();
            if (txtTongTien.Text != "")
                a.TongTien = Decimal.Parse(txtTongTien.Text);
            else a.TongTien = -1;
            if (txtDiaChi.Text != "")
                diachi = txtDiaChi.Text;
            else diachi = "";
            mh.Search(a,diachi,tenkh);
            dataGridView1.DataSource = mh.Search(a,diachi,tenkh);
            dataGridView1.Columns["SoPhieuMua"].HeaderText = "Số Phiếu Mua";
            dataGridView1.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dataGridView1.Columns["NgayMua"].HeaderText = "Ngày Mua";
            dataGridView1.Columns["NgayThanhToan"].HeaderText = "Ngày Thanh Toán";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dataGridView1.Columns["TenKH"].HeaderText = "Khách hàng";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            //a.NgayMua
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int sopm = 0;
            int count = dataGridView1.SelectedRows.Count;
            if(count!=0)
            {
                if (Decimal.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString())!=0)
                {
                    DialogResult dr= MessageBox.Show("Số phiếu mua này đã được sử dụng bạn có muốn xóa tất cả chi tiết phiếu mua đi kèm không?","Cảnh Báo",MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        sopm = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        mh.XoaPhieuMuaHang(sopm);
                    }
                }
                
            }
            load();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Bạn cần chon một phiếu mua hàng để xem chi tiết");
                return;
            }
            FormChiTietMuaHang chitiet = new FormChiTietMuaHang(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            chitiet.ShowDialog();
            if (chitiet.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtKhachHang.Text = "";
            txtSoPhieuThu.Text = "";
            txtTongTien.Text = "";
            dtNgayMua.Value = DateTime.Now.Date;
            dtNgayThanhToan.Value = DateTime.Now.Date;
        }

        private void txtSoPhieuThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
