using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogiLayer;
using System.ComponentModel;

namespace PresentationLayer
{
    public partial class M_PhieuBanHanhEdit : Form
    {
        int SoPhieuBan = 0;
        int Edit = 0; //edit = 1 la update 
        M_PhieuBanHangBLL PhieuBan = new M_PhieuBanHangBLL();
        M_CTPhieuBanBLL CTPhieuBan = new M_CTPhieuBanBLL();
        M_KhachHangBLL KhachHang = new M_KhachHangBLL();
        M_SanPhamBLL SanPham = new M_SanPhamBLL();
        public M_PhieuBanHanhEdit()
        {
            Edit = 0;
            InitializeComponent();
            SoPhieuBan = PhieuBan.GetSoPhieu();
        }
        public M_PhieuBanHanhEdit(int sophieu)
        {
            SoPhieuBan = sophieu;
            Edit = 1;
            InitializeComponent();
        }
     
        private void M_PhieuBanHanhEdit_Load(object sender, EventArgs e)
        {
            comboBoxKhachHang.DataSource = KhachHang.SelectTop(0);
            comboBoxKhachHang.ValueMember = "MaKH";
            comboBoxKhachHang.DisplayMember = "TenKh";

            comboBoxSanPham.DataSource = SanPham.SelectTop(0);
            comboBoxSanPham.ValueMember = "MaSP";
            comboBoxSanPham.DisplayMember = "MaSP";
            
            txtSPhieu.Text = SoPhieuBan.ToString();
            if (Edit == 1)
            {
                PhieuBanHang_DTO phieuban = new PhieuBanHang_DTO();
                phieuban = PhieuBan.SelectTop(SoPhieuBan, 0).FirstOrDefault();
                dateTimePickerNgayBan.Text = phieuban.NgayBan;
                dateTimePickerNgayThanhToan.Text = phieuban.NgayThanhToan;
                txtTongTien.Text = phieuban.TongTien.ToString();
                comboBoxKhachHang.SelectedValue = phieuban.MaKH;
                
                BindingList<CTPhieuBan_DTO> dschitiet = CTPhieuBan.SelectTop(0);
                this.dataGridViewCT.DataSource = dschitiet;
                dataGridViewCT.Columns["SoPhieuBan"].Visible = false;
                dataGridViewCT.Columns["MaSP"].HeaderText = "Mã sản phẩm";
                dataGridViewCT.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridViewCT.Columns["DonGia"].HeaderText = "Đơn giá";
                dataGridViewCT.Columns["ThanhTien"].HeaderText = "Thành tiền";
            }
            
        }

        private void buttonThemKH_Click(object sender, EventArgs e)
        {
            M_KhachHangEdit form = new M_KhachHangEdit();
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var x = KhachHang.SelectTop(0);
                comboBoxKhachHang.DataSource = x;
                comboBoxKhachHang.SelectedValue = x.Last().MaKH;
            }

        }

        private void comboBoxSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDongGia.Text = SanPham.GetGia(int.Parse(comboBoxSanPham.Text)).ToString();
                txtThanhTien.Text = (int.Parse(txtSL.Text) * decimal.Parse(txtDongGia.Text)).ToString();
            }
            catch (Exception a)
            {
                //MessageBox.Show(a.ToString());
                return;
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = (int.Parse(txtSL.Text) * decimal.Parse(txtDongGia.Text)).ToString();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
                return;
            }
        }
    }
}
