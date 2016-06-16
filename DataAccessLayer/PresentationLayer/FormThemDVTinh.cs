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
    public partial class FormThemDVTinh : Form
    {
        DonViTinh_BUS dv = new DonViTinh_BUS();
        int MaDV;
        public FormThemDVTinh()
        {
            InitializeComponent();
        }
        public FormThemDVTinh(int madv)
        {
            InitializeComponent();
            MaDV = madv;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDV.Text == "")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            DonViTinh_DTO a = new DonViTinh_DTO();
            a.TenDonViTinh = txtTenDV.Text;
            if (dv.CheckDonViTinh(a.TenDonViTinh) == 0)
            {
                dv.ThemDVTinh(a);   
               // MessageBox.Show("Thêm thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đơn vị tính này đã trùng tên, bạn vui lòng chọn tên khác");
                return;
            }
                     
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemDVTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(txtMaDV.Text!="")
            {
                DonViTinh_DTO a = new DonViTinh_DTO();
                a.MaDonViTinh = MaDV;
                a.TenDonViTinh = txtTenDV.Text;
                if (a.TenDonViTinh == dv.Lay1DV(MaDV).TenDonViTinh)
                {
                    if (dv.CheckDonViTinh(a.TenDonViTinh) == 1)
                    {
                        dv.CapNhapDVTinh(a);
                        this.Close();
                        //MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Đơn vị tính này đã trùng tên, bạn vui lòng chọn tên khác");
                        return;
                    }
                }
                else
                {
                    if (dv.CheckDonViTinh(a.TenDonViTinh) == 0)
                    {
                        dv.CapNhapDVTinh(a);     
                        //MessageBox.Show("Cập nhật thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đơn vị tính này đã trùng tên, bạn vui lòng chọn tên khác");
                        return;
                    }
                }
                
            }
        }

        private void FormThemDVTinh_Load(object sender, EventArgs e)
        {
            if (MaDV != 0)
            {
                txtMaDV.Text = MaDV.ToString();
                txtTenDV.Text = dv.Lay1DV(MaDV).TenDonViTinh;
            }
        }
    }
}
