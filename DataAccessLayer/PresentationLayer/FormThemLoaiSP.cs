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
    public partial class FormThemLoaiSP : Form
    {
        DonViTinh_BUS dv = new DonViTinh_BUS();
        LoaiSP_BUS lo = new LoaiSP_BUS();
        int MaLoaiSP;
        public FormThemLoaiSP()
        {
            InitializeComponent();
        }
        public FormThemLoaiSP(int maloaisp)
        {
            InitializeComponent();
            MaLoaiSP = maloaisp;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiSP.Text == ""||txtPhantramloinhuan.Text=="")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            LoaiSP_DTO a = new LoaiSP_DTO();
            a.TenLoaiSP = txtTenLoaiSP.Text;
            a.MaDonViTinh=Int16.Parse(cbbDV.SelectedValue.ToString());
            a.PhanTramLoiNhuan = (float) Double.Parse(txtPhantramloinhuan.Text);
            if(a.PhanTramLoiNhuan>1)
            {
                MessageBox.Show("Phần trăm lợi nhuận phải nhỏ hơn 1");
                return;
            }
            if (a.PhanTramLoiNhuan <=0)
            {
                MessageBox.Show("Phần trăm lợi nhuận phải lớn hơn 0");
                return;
            }
            if (lo.CheckTenLoaiSP(a.TenLoaiSP) == 0)
            {
                lo.ThemLoaiSP(a);
                this.Close(); 
                //MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Loại sản phẩm này đã trùng tên, bạn vui lòng chọn tên khác");
                return;
            }
            
        }
        
        private void FormThemLoaiSP_Load(object sender, EventArgs e)
        {
            cbbDV.DataSource = dv.LayDVTinh();
            cbbDV.DisplayMember = "TenDonViTinh";
            cbbDV.ValueMember = "MaDonViTinh";
            if(MaLoaiSP!=0)
            {
                txtMaLoaiSP.Text = MaLoaiSP.ToString();
                txtTenLoaiSP.Text = lo.Lay1LSP(MaLoaiSP).TenLoaiSP;
                cbbDV.SelectedValue = lo.Lay1LSP(MaLoaiSP).MaDonViTinh;
                txtPhantramloinhuan.Text = lo.Lay1LSP(MaLoaiSP).PhanTramLoiNhuan.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSP.Text != "")
            {
                LoaiSP_DTO a = new LoaiSP_DTO();
                a.TenLoaiSP = txtTenLoaiSP.Text;
                a.MaDonViTinh = Int16.Parse(cbbDV.SelectedValue.ToString());
                a.PhanTramLoiNhuan = float.Parse(txtPhantramloinhuan.Text);
                a.MaLoaiSP = MaLoaiSP;
                if (a.PhanTramLoiNhuan <= 0)
                {
                    MessageBox.Show("Phần trăm lợi nhuận phải lớn hơn 0");
                    return;
                }
                if (a.TenLoaiSP == lo.Lay1LSP(MaLoaiSP).TenLoaiSP)
                {
                    if (lo.CheckTenLoaiSP(a.TenLoaiSP) == 1)
                    {
                        lo.CapNhapLoaiSP(a);
                        this.Close(); 
                        //MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Loại sản phẩm này đã trùng tên, bạn vui lòng chọn tên khác");
                        return;
                    }
                }
                else
                {
                    if (lo.CheckTenLoaiSP(a.TenLoaiSP) == 0)
                    {
                        lo.CapNhapLoaiSP(a);
                        this.Close();
                        //MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Loại sản phẩm này đã trùng tên, bạn vui lòng chọn tên khác");
                        return;
                    }
                }
                
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemLoaiSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtPhantramloinhuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void btnAddKieuSP_Click(object sender, EventArgs e)
        {
            FormThemDVTinh them = new FormThemDVTinh();
            them.ShowDialog();
            if(them.DialogResult==DialogResult.Cancel)
            {
                cbbDV.DataSource = dv.LayDVTinh();
                cbbDV.DisplayMember = "TenDonViTinh";
                cbbDV.ValueMember = "MaDonViTinh";
            }
        }
    }
}
