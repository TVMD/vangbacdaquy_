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
    public partial class FormThoGiaCong_AddUpd : Form
    {
        ThoGiaCong_BUS ThoGiaCong_bus = new ThoGiaCong_BUS();
        public FormThoGiaCong_AddUpd()
        {
            InitializeComponent();
            int khoamoi = Int16.Parse(ThoGiaCong_bus.LayKhoaMoi()) +1 ;
            txtMaTho.Text = khoamoi.ToString();

            btnCapNhat.Enabled = false;
        }
        public FormThoGiaCong_AddUpd(ThoGiaCong_DTO tho)
        {
            InitializeComponent();
            txtMaTho.Text = tho.MaTho.ToString();
            txtTenTho.Text = tho.TenTho;
            txtDiaChi.Text = tho.DiaChi;
            txtSodt.Text = tho.SDT;

            btnThem.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThoGiaCong_DTO a = new ThoGiaCong_DTO();
            a.MaTho = Int16.Parse(txtMaTho.Text);
            a.TenTho = txtTenTho.Text;
            a.SDT = txtSodt.Text;
            a.DiaChi = txtDiaChi.Text;

            int number;
            if (Int32.TryParse(txtSodt.Text, out number) == true)
            {
                ThoGiaCong_bus.ThoGiaCong_Add(a);
                this.Close();
            }
            else MessageBox.Show("Nhập sai số điện thoại - Chỉ nhập số!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ThoGiaCong_DTO tho = new ThoGiaCong_DTO();
            tho.MaTho = Int16.Parse(txtMaTho.Text);
            tho.TenTho = null;
            tho.DiaChi = null;
            tho.SDT = null;

            int number;
            if (Int32.TryParse(txtSodt.Text, out number) == true)
            {
                tho.TenTho = txtTenTho.Text;
                tho.DiaChi = txtDiaChi.Text;
                tho.SDT = txtSodt.Text;
                ThoGiaCong_bus.ThoGiaCong_Upd(tho);
                this.Close();
            }
            else MessageBox.Show("Nhập sai số điện thoại - Chỉ nhập số!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSodt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }
    }
}
