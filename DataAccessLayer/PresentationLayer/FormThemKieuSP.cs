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
    public partial class FormThemKieuSP : Form
    {
        KieuSP_BUS k = new KieuSP_BUS();
        int MaKieuSP;
        public FormThemKieuSP()
        {
            InitializeComponent();
        }
        public FormThemKieuSP(int makieusp)
        {
            InitializeComponent();
            MaKieuSP = makieusp;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtTenKieuSP.Text=="")
            {
                MessageBox.Show("Bạn còn dữ liệu chưa nhập");
                return;
            }
            KieuSP_DTO a=new KieuSP_DTO();
            a.TenKieuSP=txtTenKieuSP.Text;
            k.ThemKieuSP(a);
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(txtMaKieuSP.Text!="")
            {
                KieuSP_DTO a = new KieuSP_DTO();
                a.MaKieuSP = MaKieuSP;
                a.TenKieuSP = txtTenKieuSP.Text;
                k.CapNhapKieuSP(a);
            }
        }

        private void txtTenKieuSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemKieuSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormThemKieuSP_Load(object sender, EventArgs e)
        {
            if(MaKieuSP!=0)
            {
                txtMaKieuSP.Text = MaKieuSP.ToString();
                txtTenKieuSP.Text = k.Lay1KSP(MaKieuSP).TenKieuSP;
            }
        }
    }
}
