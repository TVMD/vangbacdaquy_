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
    public partial class FormLoaiDichVu_AddUpd : Form
    {
        LoaiDichVu_BUS loaidv_bus = new LoaiDichVu_BUS();
        public FormLoaiDichVu_AddUpd()
        {
            InitializeComponent();
            int khoamoi = Int16.Parse(loaidv_bus.LayKhoaMoi()) + 1;
            txtMaLoaidv.Text = khoamoi.ToString();

            btnCapNhat.Enabled = false;
        }
        public FormLoaiDichVu_AddUpd(LoaiDichVu_DTO loaidv)
        {
            InitializeComponent();
            txtMaLoaidv.Text = loaidv.MaLoaiDV.ToString();
            txtTenLoaidv.Text = loaidv.TenLoaiDV;
            txtDonGia.Text = loaidv.DonGia.ToString();

            btnThem.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiDichVu_DTO a = new LoaiDichVu_DTO();
            a.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            a.TenLoaiDV = txtTenLoaidv.Text;                       

            decimal number;
            if (Decimal.TryParse(txtDonGia.Text, out number) == true)
            {
                a.DonGia = Decimal.Parse(txtDonGia.Text);
                loaidv_bus.LoaiDichVu_Add(a);
                this.Close();
            }
            else MessageBox.Show("Nhập sai đơn giá - Chỉ nhập số!");

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoaiDichVu_DTO tho = new LoaiDichVu_DTO();
            tho.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            tho.TenLoaiDV = txtTenLoaidv.Text;     
                       

            decimal number;
            if (Decimal.TryParse(txtDonGia.Text, out number) == true)
            {
                tho.DonGia = Decimal.Parse(txtDonGia.Text);
                loaidv_bus.LoaiDichVu_Upd(tho);
                this.Close();
            }
            else MessageBox.Show("Nhập sai đơn giá - Chỉ nhập số!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }
    }
}
