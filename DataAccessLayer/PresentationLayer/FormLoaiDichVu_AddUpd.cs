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
        }
        public FormLoaiDichVu_AddUpd(LoaiDichVu_DTO loaidv)
        {
            InitializeComponent();
            txtMaLoaidv.Text = loaidv.MaLoaiDV.ToString();
            txtTenLoaidv.Text = loaidv.TenLoaiDV;
            txtDonGia.Text = loaidv.DonGia.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiDichVu_DTO a = new LoaiDichVu_DTO();
            a.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            a.TenLoaiDV = txtTenLoaidv.Text;
            a.DonGia = Decimal.Parse(txtDonGia.Text);


            loaidv_bus.LoaiDichVu_Add(a);
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoaiDichVu_DTO tho = new LoaiDichVu_DTO();
            tho.MaLoaiDV = Int16.Parse(txtMaLoaidv.Text);
            tho.TenLoaiDV = txtTenLoaidv.Text;
            tho.DonGia = Decimal.Parse(txtDonGia.Text);

            loaidv_bus.LoaiDichVu_Upd(tho);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
