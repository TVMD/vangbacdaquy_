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
    public partial class FormPhieuGiaCong_AddUpd : Form
    {
        PhieuGiaCong_BUS phieugc_bus = new PhieuGiaCong_BUS();
        public FormPhieuGiaCong_AddUpd()
        {
            InitializeComponent();
            int khoamoi = Int16.Parse(phieugc_bus.LayKhoaMoi()) + 1;
            txtSoPhieuGiaCong.Text = khoamoi.ToString();

            btnCapNhat.Enabled = false;
        }
        public FormPhieuGiaCong_AddUpd(PhieuGiaCong_DTO phieugc)
        {
            InitializeComponent();
            txtSoPhieuGiaCong.Text = phieugc.SoPhieuGiaCong.ToString();
            dtPicker_NgayLap.Value = DateTime.Parse(phieugc.NgayLap.ToString());
            txtTongTien.Text = phieugc.TongTien.ToString();

            btnThem.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhieuGiaCong_DTO phieugc = new PhieuGiaCong_DTO();
            phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieuGiaCong.Text);
            phieugc.NgayLap = dtPicker_NgayLap.Value.ToShortDateString();
            phieugc.TongTien = 0;

            phieugc_bus.PhieuGiaCong_Add(phieugc);
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            PhieuGiaCong_DTO phieugc = new PhieuGiaCong_DTO();
            phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieuGiaCong.Text);
            phieugc.NgayLap = dtPicker_NgayLap.Value.ToShortDateString();
            phieugc.TongTien = Decimal.Parse(txtTongTien.Text);

            phieugc_bus.PhieuGiaCong_Upd(phieugc);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
