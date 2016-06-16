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
//using DataAccessLayer;
using DTO;
namespace PresentationLayer
{
    public partial class FormThemPhieuMuaHang : Form
    {
        PhieuMuaHangDLL mh = new PhieuMuaHangDLL();
        public FormThemPhieuMuaHang()
        {
            InitializeComponent();
        }

        public FrmSoPhieuThu RefToMom { get; set; }

        private void FormThemPhieuBanHang_Load(object sender, EventArgs e)
        {
           
            cbbKH.DataSource = mh.LayKH();
            cbbKH.DisplayMember = "TenKh";
            cbbKH.ValueMember = "MaKh";
            dtNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtNgayThanhToan.CustomFormat = "dd-MM-yyyy";
            dtNgayMua.Format = DateTimePickerFormat.Custom;
            dtNgayMua.CustomFormat = "dd-MM-yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhieuMuaHang_DTO a = new PhieuMuaHang_DTO();
            //PHIEUMUAHANG a = new PHIEUMUAHANG();
            //a.SoPhieuMua = Int16.Parse(txtSoPhieuThu.Text);
            //a.TongTien = Int16.Parse(txtTongTien.Text);
            if(DateTime.Compare(dtNgayMua.Value.Date,dtNgayThanhToan.Value.Date)>0)
            {
                MessageBox.Show("Ngày mua phải sớm hơn ngày thanh toán");
                return;
            }
            if (DateTime.Compare(dtNgayMua.Value, DateTime.Now) > 0)
            {
                MessageBox.Show("Ngày mua phải sớm hơn ngày hiện tại");
                return;
            }
            a.MaKH = Int16.Parse(cbbKH.SelectedValue.ToString());
            a.NgayMua = dtNgayMua.Value.ToShortDateString();
            a.NgayThanhToan = dtNgayThanhToan.Value.ToShortDateString();
            //txtSoPhieuThu.Text = cbbKH.SelectedValue.ToString();
            mh.ThemPhieuMuaHang(a);
            MessageBox.Show("Thêm thành công");
            RefToMom.load();
            }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemPhieuBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            M_KhachHangEdit them=new M_KhachHangEdit();
            them.ShowDialog();
            if(them.DialogResult==DialogResult.OK)
            {
                cbbKH.DataSource = mh.LayKH();
                cbbKH.DisplayMember = "TenKh";
                cbbKH.ValueMember = "MaKh";
            }
        }
    }
}
