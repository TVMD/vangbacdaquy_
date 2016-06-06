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

namespace PresentationLayer
{
    
    public partial class FormThemSP : Form
    {
        KieuSP_BUS k = new KieuSP_BUS();
        LoaiSP_BUS lo = new LoaiSP_BUS();
        M_SanPhamBLL sp = new M_SanPhamBLL();
        int MaSP;
        public FormThemSP()
        {
            InitializeComponent();
        }
        public FormThemSP(int masp)
        {
            InitializeComponent();
            MaSP = masp;
        }

        private void FormThemSP_Load(object sender, EventArgs e)
        {
            cbbKieuSP.DataSource = k.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = lo.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            if(MaSP!=0)
            {
                txtMaSP.Text = MaSP.ToString();
                cbbKieuSP.SelectedValue = sp.Lay1LSP(MaSP).MaKieuSP;
                cbbLoaiSP.SelectedValue = sp.Lay1LSP(MaSP).MaLoaiSP;
                txtDonGiaBan.Text = sp.Lay1LSP(MaSP).DonGiaBan.ToString();
                txtTrongLuong.Text = sp.Lay1LSP(MaSP).TrongLuong.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDonGiaBan.Text == "" || txtTrongLuong.Text == "")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            SanPham_DTO a = new SanPham_DTO();
            a.MaLoaiSP = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            a.MaKieuSP = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            if(sp.KiemTraSP(a.MaKieuSP,a.MaLoaiSP)!=-1)
            {
                MessageBox.Show("Không thể thêm một sản phẩm mới có cùng kiểu sản phẩm và loại sản phẩm với sản phẩm có sẵn");
                return;
            }
            a.TrongLuong = float.Parse(txtTrongLuong.Text);
            a.DonGiaBan = Decimal.Parse(txtDonGiaBan.Text);
            sp.ThemSP(a);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                SanPham_DTO a = new SanPham_DTO();
                a.MaSP = MaSP;
                a.MaLoaiSP = Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
                a.MaKieuSP = Int16.Parse(cbbKieuSP.SelectedValue.ToString());
                if (sp.KiemTraSP(a.MaKieuSP, a.MaLoaiSP) != -1)
                {
                    MessageBox.Show("Không thể thêm một sản phẩm mới có cùng kiểu sản phẩm và loại sản phẩm với sản phẩm có sẵn");
                    return;
                }
                a.TrongLuong = float.Parse(txtTrongLuong.Text);
                a.DonGiaBan = Decimal.Parse(txtDonGiaBan.Text);
                sp.CapNhapSP(a);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTrongLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

       
    }
}
