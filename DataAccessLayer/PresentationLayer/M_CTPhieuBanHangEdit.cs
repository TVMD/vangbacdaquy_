using System;
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
        
    public partial class M_CTPhieuBanHangEdit : Form
    {
        int SoPhieuBan = 0;
        int Edit = 0; //edit = 1 la update 
        M_CTPhieuBanBLL CTPhieuBan = new M_CTPhieuBanBLL();
        M_SanPhamBLL SanPham = new M_SanPhamBLL();
        private CTPhieuBan_DTO ct = new CTPhieuBan_DTO();
       
        public M_CTPhieuBanHangEdit()
        {
            InitializeComponent();
            Edit = 0;
        }

        public M_CTPhieuBanHangEdit(CTPhieuBan_DTO p,int edit){
            ct = p;
            InitializeComponent();
            Edit = edit;
            if(edit==1)// edit
                comboBoxSanPham.Enabled = false;
        }

        private void M_CTPhieuBanHangEdit_Load(object sender, EventArgs e)
        {
            comboBoxSanPham.DataSource = SanPham.SelectTop(0);
            comboBoxSanPham.ValueMember = "MaSP";
            comboBoxSanPham.DisplayMember = "MaSP";

            if (Edit==1) //edit
            {
                comboBoxSanPham.Text = ct.MaSP.ToString();
                txtSL.Text = ct.SoLuong.ToString();
                txtDongGia.Text = ct.DonGia.ToString();
                txtThanhTien.Text = ct.ThanhTien.ToString();
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (txtSL.Text == "") txtSL.Text = "0";// k so bi null

            if (int.Parse(txtSLTon.Text) < int.Parse(txtSL.Text))
            {
                MessageBox.Show("Số lượng tồn không đủ", "Thông báo");
                txtSL.Text = txtSLTon.Text;
                return;
            }

           
            if (Edit == 1) //edit
            {
                 CTPhieuBan.Update(ct.SoPhieuBan,ct.MaSP,
                     int.Parse(txtSL.Text),
                     decimal.Parse(txtDongGia.Text),
                     decimal.Parse(txtThanhTien.Text));
            }
            if (Edit==0) // add
            {
                CTPhieuBan.Insert(ct.SoPhieuBan,
                    int.Parse(comboBoxSanPham.Text),
                    int.Parse(txtSL.Text),
                    decimal.Parse(txtDongGia.Text),
                    decimal.Parse(txtThanhTien.Text));
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            int sl = txtSL.Text == "" ? 0 : int.Parse(txtSL.Text);
            {
                txtThanhTien.Text = (sl * decimal.Parse(txtDongGia.Text)).ToString();
            }
        }

        private void comboBoxSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDongGia.Text = SanPham.GetGia(int.Parse(comboBoxSanPham.Text)).ToString();
                txtSLTon.Text = SanPham.GetSLTon(int.Parse(comboBoxSanPham.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripLuu_Click(sender, e);
            }
        }

        private void buttonLuu_Click(object sender, System.EventArgs e)
        {
            if (txtSL.Text == "") txtSL.Text = "0";// k so bi null

            if (int.Parse(txtSLTon.Text) < int.Parse(txtSL.Text))
            {
                MessageBox.Show("Số lượng tồn không đủ", "Thông báo");
                txtSL.Text = txtSLTon.Text;
                return;
            }


            if (Edit == 1) //edit
            {
                CTPhieuBan.Update(ct.SoPhieuBan, ct.MaSP,
                    int.Parse(txtSL.Text),
                    decimal.Parse(txtDongGia.Text),
                    decimal.Parse(txtThanhTien.Text));
            }
            if (Edit == 0) // add
            {
                CTPhieuBan.Insert(ct.SoPhieuBan,
                    int.Parse(comboBoxSanPham.Text),
                    int.Parse(txtSL.Text),
                    decimal.Parse(txtDongGia.Text),
                    decimal.Parse(txtThanhTien.Text));
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
