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
        }
        public FormThoGiaCong_AddUpd(ThoGiaCong_DTO tho)
        {
            InitializeComponent();
            txtMaTho.Text = tho.MaTho.ToString();
            txtTenTho.Text = tho.TenTho;
            txtDiaChi.Text = tho.DiaChi;
            txtSodt.Text = tho.SDT;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThoGiaCong_DTO a = new ThoGiaCong_DTO();
            a.MaTho = Int16.Parse(txtMaTho.Text);
            a.TenTho = txtTenTho.Text;
            a.SDT = txtSodt.Text;
            a.DiaChi = txtDiaChi.Text;

            ThoGiaCong_bus.ThoGiaCong_Add(a);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ThoGiaCong_DTO tho = new ThoGiaCong_DTO();
            tho.MaTho = Int16.Parse(txtMaTho.Text);
            tho.TenTho = txtTenTho.Text;
            tho.DiaChi = txtDiaChi.Text;
            tho.SDT = txtSodt.Text;
            ThoGiaCong_bus.ThoGiaCong_Upd(tho);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
