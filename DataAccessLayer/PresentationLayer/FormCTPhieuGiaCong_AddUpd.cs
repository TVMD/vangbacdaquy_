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
    public partial class FormCTPhieuGiaCong_AddUpd : Form
    {
        String sophieugc;
        CTPhieuGiaCong_BUS ctphieugc_bus = new CTPhieuGiaCong_BUS();
        public FormCTPhieuGiaCong_AddUpd()
        {
            InitializeComponent();
        }
        public FormCTPhieuGiaCong_AddUpd(String sophieugc)
        {
            InitializeComponent();
            //
            comboBox_MaTho.DataSource = ctphieugc_bus.LayDSMaTho();
            comboBox_MaTho.ValueMember = "MaTho";
            comboBox_MaTho.DisplayMember = "MaTho";
            //
            this.sophieugc = sophieugc;

            btnCapNhat.Enabled = false;
            
        }
        public FormCTPhieuGiaCong_AddUpd(CTGiaCong_DTO pbh)
        {
            InitializeComponent();
            comboBox_MaTho.DataSource = ctphieugc_bus.LayDSMaTho();
            comboBox_MaTho.ValueMember = "MaTho";
            comboBox_MaTho.DisplayMember = "MaTho";
            //
            txtSoPhieugc.Text = pbh.SoPhieuGiaCong.ToString();
            txtSoPhieudv.Text = pbh.SoPhieuDV.ToString();
            txtSTT.Text = pbh.STT.ToString();
            txtSoLuong.Text = pbh.SoLuong.ToString();
            txtDonGia.Text = pbh.DonGia.ToString();
            txtThanhTien.Text = pbh.ThanhTien.ToString();
            comboBox_MaTho.SelectedValue = pbh.MaTho;

            btnThem.Enabled = false;
        }

        private void FormCTPhieuGiaCong_AddUpd_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ctphieugc_bus.LayDSDichVuChuaGiaCong();          
            //
            
        }
        private void dataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            txtSoPhieugc.Text = sophieugc;
            txtSoPhieudv.Text = dataGridView1.Rows[e.RowIndex].Cells["SoPhieuDichVu"].Value.ToString();
            txtSTT.Text = dataGridView1.Rows[e.RowIndex].Cells["STT"].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CTGiaCong_DTO phieugc = new CTGiaCong_DTO();
            phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieugc.Text);
            phieugc.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
            phieugc.STT = Int16.Parse(txtSTT.Text);
            phieugc.DonGia = Decimal.Parse(txtDonGia.Text);
            phieugc.SoLuong = Int16.Parse(txtSoLuong.Text);
            phieugc.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieugc.MaTho = Int16.Parse(comboBox_MaTho.SelectedValue.ToString());


            ctphieugc_bus.CTPhieuGiaCong_Add(phieugc);
            ctphieugc_bus.CapNhatTongTien(phieugc.SoPhieuGiaCong, phieugc.SoPhieuDV, phieugc.STT, 0, 1);
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Decimal tien;
            CTGiaCong_DTO phieugc = new CTGiaCong_DTO();
            phieugc.SoPhieuGiaCong = Int16.Parse(txtSoPhieugc.Text);
            phieugc.SoPhieuDV = Int16.Parse(txtSoPhieudv.Text);
            phieugc.STT = Int16.Parse(txtSTT.Text);
            phieugc.DonGia = Decimal.Parse(txtDonGia.Text);
            phieugc.SoLuong = Int16.Parse(txtSoLuong.Text);
            tien = phieugc.ThanhTien;
            phieugc.ThanhTien = Decimal.Parse(txtThanhTien.Text);
            phieugc.MaTho = Int16.Parse(comboBox_MaTho.SelectedValue.ToString());


            ctphieugc_bus.CTPhieuGiaCong_Upd(phieugc);
            ctphieugc_bus.CapNhatTongTien(phieugc.SoPhieuGiaCong, phieugc.SoPhieuDV, phieugc.STT, tien, 2);
            this.Close();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            int number;
            if (txtSoLuong.Text.CompareTo("") != 0)
                if (Int32.TryParse(txtSoLuong.Text, out number) == false)
                {
                    MessageBox.Show("Nhập sai Số lượng - Chỉ nhập số!");
                    return;
                }
            if (txtDonGia.Text.CompareTo("") != 0 && txtSoLuong.Text.CompareTo("") != 0)
                txtThanhTien.Text = (Int32.Parse(txtSoLuong.Text) * Decimal.Parse(txtDonGia.Text)).ToString();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            Decimal number;
            if (txtDonGia.Text.CompareTo("") != 0)
                if (Decimal.TryParse(txtDonGia.Text, out number) == false)
                {
                    MessageBox.Show("Nhập sai Đơn giá - Chỉ nhập số!");
                    return;
                }
            if (txtSoLuong.Text.CompareTo("") != 0 && txtDonGia.Text.CompareTo("") != 0)
                txtThanhTien.Text = (Int32.Parse(txtSoLuong.Text) * Decimal.Parse(txtDonGia.Text)).ToString();
        }

    }
}
