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
    public partial class FormSuaPhieuNhap : Form
    {
        int Sopn;
        PhieuNhap_BUS pn = new PhieuNhap_BUS();
        public FormSuaPhieuNhap()
        {
            InitializeComponent();
        }
        public FormSuaPhieuNhap(int sopn)
        {
            InitializeComponent();
            Sopn = sopn;
        }

        private void FormSuaPhieuNhap_Load(object sender, EventArgs e)
        {
            cbbSoPhieuNhap.DataSource = pn.LayTatCa();
            cbbSoPhieuNhap.DisplayMember = "SoPhieuNhap";
            cbbSoPhieuNhap.ValueMember = "SoPhieuNhap";
            if (Sopn != 0)
                cbbSoPhieuNhap.SelectedValue = Sopn;
            dtNgayLAp.Format = DateTimePickerFormat.Custom;
            dtNgayLAp.CustomFormat = "dd-MM-yyyy";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
            PhieuNhap_DTO a = new PhieuNhap_DTO();
            a.NgayLap = dtNgayLAp.Value.ToShortDateString();
            if (DateTime.Compare(dtNgayLAp.Value, DateTime.Now) > 0)
            {
                MessageBox.Show("Ngày lập phải sớm hơn ngày hiện tại");
                return;
            }
            //a.TongTien = Decimal.Parse(txtTongTien.Text);
            a.SoPhieuNhap=Int16.Parse(cbbSoPhieuNhap.SelectedValue.ToString());
            pn.CapNhapPhieuNhap(a);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSuaPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbbSoPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoPhieuNhap.Text != "" && cbbSoPhieuNhap.SelectedIndex != -1 && cbbSoPhieuNhap.SelectedIndex != 0 || cbbSoPhieuNhap.Text == "1")
            {
                int sopn = Int16.Parse(cbbSoPhieuNhap.Text);
                PhieuNhap_DTO a = new PhieuNhap_DTO();
                a = pn.LayPhieuNhap(sopn);
                dtNgayLAp.Value = DateTime.Parse(a.NgayLap);
                //txtTongTien.Text = a.TongTien.ToString();
            }
        }

        private void cbbSoPhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }
    }
}
