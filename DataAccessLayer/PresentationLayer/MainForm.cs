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
    public partial class MainForm : Form
    {
        private NguoiDung_DTO Taikhoan ;//= (new M_NguoiDungBLL()).Get("dichvu");//chua co form dang nhap
        static PhanQuyen_DTO Quyen;
        private Boolean isDangXuat = false;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(NguoiDung_DTO taikhoan)
        {
            Taikhoan = taikhoan;
            InitializeComponent();
        }
        #region [Config]
        private static MainForm _instance;
        public static MainForm Instance(NguoiDung_DTO taikhoan)
        {
            if (_instance == null)
                _instance = new MainForm(taikhoan);
            return _instance;
        }
        private static FrmSoPhieuThu phieumuahang = null;
        private static void ShowFormPhieuMuaHang(MainForm MF)
        {
            if (phieumuahang == null || phieumuahang.IsDisposed)
            {
                phieumuahang = new FrmSoPhieuThu(Quyen.PhieuMua);
                phieumuahang.RefToMainForm = MF;
                phieumuahang.MdiParent = MF;
                phieumuahang.StartPosition = FormStartPosition.WindowsDefaultLocation;
                
                phieumuahang.Show();
                phieumuahang.Location = new Point(0, 0);
            }
            else
                phieumuahang.Activate();
        }
        private static FormPhieuNhapHang phieunhaphang = null;
        private static void ShowFormPhieuNhapHang(MainForm MF)
        {
            if (phieunhaphang == null || phieunhaphang.IsDisposed)
            {
                phieunhaphang = new FormPhieuNhapHang(Quyen.ThuKho);
                phieunhaphang.RefToMainForm = MF;
                phieunhaphang.MdiParent = MF;
                phieunhaphang.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phieunhaphang.Show();
                phieunhaphang.Location = new Point(0, 0);
            }
            else
                phieunhaphang.Activate();
        }
        private static M_PhieuBanHang phieubanhang = null;
        private static void ShowFormPhieuBanHang(MainForm MF)
        {
            if (phieubanhang == null || phieubanhang.IsDisposed)
            {
                phieubanhang = new M_PhieuBanHang();
                phieubanhang.RefToMainForm = MF;
                phieubanhang.MdiParent = MF;
                phieubanhang.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phieubanhang.Show();
                phieubanhang.Location = new Point(0, 0);
            }
            else
                phieubanhang.Activate();
        }
        private static FormPhieuDichVu phieudichvu = null;
        private static void ShowFormDichVu(MainForm MF)
        {
            if (phieudichvu == null || phieudichvu.IsDisposed)
            {
                phieudichvu = new FormPhieuDichVu();
                //phieudichvu.RefToMainForm = MF;
                phieudichvu.MdiParent = MF;
                phieudichvu.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phieudichvu.Show();
                phieudichvu.Location = new Point(0, 0);
            }
            else
                phieudichvu.Activate();
        }
        private static FormPhieuGiaCong phieugiacong = null;
        private static void ShowFormGiaCong(MainForm MF)
        {
            if (phieugiacong == null || phieugiacong.IsDisposed)
            {
                phieugiacong = new FormPhieuGiaCong();
               // phieugiacong.RefToMainForm = MF;
                phieugiacong.MdiParent = MF;
                phieugiacong.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phieugiacong.Show();
                phieugiacong.Location = new Point(0, 0);
            }
            else
                phieudichvu.Activate();
        }
        private static M_PhieuNo phieuno = null;
        private static void ShowFormPhieuNo(MainForm MF)
        {
            if (phieuno == null || phieuno.IsDisposed)
            {
                phieuno = new M_PhieuNo();
                phieuno.RefToMainForm = MF;
                phieuno.MdiParent = MF;
                phieuno.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phieuno.Show();
                phieuno.Location = new Point(0, 0);
            }
            else
                phieuno.Activate();
        }
        private static FormSanPham sanpham = null;
        private static void ShowFormSanPham(MainForm MF)
        {
            if (sanpham == null || sanpham.IsDisposed)
            {
                sanpham = new FormSanPham();
                sanpham.RefToMainForm = MF;
                sanpham.MdiParent = MF;
                sanpham.StartPosition = FormStartPosition.WindowsDefaultLocation;
                sanpham.Show();
                sanpham.Location = new Point(0, 0);
            }
            else
                sanpham.Activate();
        }
        private static FormKieuSP kieusanpham = null;
        private static void ShowFormKieuSanPham(MainForm MF)
        {
            if (kieusanpham == null || kieusanpham.IsDisposed)
            {
                kieusanpham = new FormKieuSP();
                kieusanpham.RefToMainForm = MF;
                kieusanpham.MdiParent = MF;
                kieusanpham.StartPosition = FormStartPosition.WindowsDefaultLocation;
                kieusanpham.Show();
                kieusanpham.Location = new Point(0, 0);
            }
            else
                kieusanpham.Activate();
        }
        private static FormLoaiSP loaisanpham = null;
        private static void ShowFormLoaiSanPham(MainForm MF)
        {
            if (loaisanpham == null || loaisanpham.IsDisposed)
            {
                loaisanpham = new FormLoaiSP();
                loaisanpham.RefToMainForm = MF;
                loaisanpham.MdiParent = MF;
                loaisanpham.StartPosition = FormStartPosition.WindowsDefaultLocation;
                loaisanpham.Show();
                loaisanpham.Location = new Point(0, 0);
            }
            else
                loaisanpham.Activate();
        }

        private static FormDonViTinh dvtinh = null;
        private static void ShowFormDonViTinh(MainForm MF)
        {
            if (dvtinh == null || dvtinh.IsDisposed)
            {
                dvtinh = new FormDonViTinh();
                dvtinh.RefToMainForm = MF;
                dvtinh.MdiParent = MF;
                dvtinh.StartPosition = FormStartPosition.WindowsDefaultLocation;
                dvtinh.Show();
                dvtinh.Location = new Point(0, 0);
            }
            else
                dvtinh.Activate();
        }
        private static FormBaoCaoTonKho baocao = null;
        private static void ShowFormBaoCao(MainForm MF)
        {
            if (baocao == null || baocao.IsDisposed)
            {
                baocao = new FormBaoCaoTonKho();
                baocao.RefToMainForm = MF;
                baocao.StartPosition = FormStartPosition.WindowsDefaultLocation;
                baocao.MdiParent = MF;
                baocao.Show();
                baocao.Location = new Point(0, 0);
            }
            else
                baocao.Activate();
        }
        private static M_KhachHang khachhang = null;
        private static void ShowFormKhachHang(MainForm MF)
        {
            if (khachhang == null || khachhang.IsDisposed)
            {
                khachhang = new M_KhachHang();
                khachhang.RefToMainForm = MF;
                khachhang.StartPosition = FormStartPosition.WindowsDefaultLocation;
                khachhang.MdiParent = MF;
                khachhang.Show();
                khachhang.Location = new Point(0, 0);
            }
            else
                khachhang.Activate();
        }
        private static M_User user = null;
        private static void ShowFormUser(MainForm MF)
        {
            if (user == null || user.IsDisposed)
            {
                user = new M_User();
                //user.RefToMainForm = MF;
                user.StartPosition = FormStartPosition.WindowsDefaultLocation;
                user.MdiParent = MF;
                user.Show();
                user.Location = new Point(0, 0);
            }
            else
                user.Activate();
        }
        private static M_PhanQuyen phanquyen = null;
        private static void ShowFormPhanQuyen(MainForm MF)
        {
            if (phanquyen == null || user.IsDisposed)
            {
                phanquyen = new M_PhanQuyen();
                //user.RefToMainForm = MF;
                phanquyen.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phanquyen.MdiParent = MF;
                phanquyen.Show();
                phanquyen.Location = new Point(0, 0);
            }
            else
                user.Activate();
        }
        private static Form_ThamSoEdit thamso = null;
        private static void ShowFormThamSo(MainForm MF)
        {
            if (thamso == null || thamso.IsDisposed)
            {
                thamso = new Form_ThamSoEdit();
                //user.RefToMainForm = MF;
                thamso.StartPosition = FormStartPosition.WindowsDefaultLocation;
               thamso.MdiParent = MF;
                thamso.Show();
                thamso.Location = new Point(0, 0);
            }
            else
                thamso.Activate();
        }
        private static FormPhieuChi phieuchi = null;
        private static void ShowFormPhieuChi(MainForm MF)
        {
            if (phieuchi == null || phieuchi.IsDisposed)
            {
                phieuchi = new FormPhieuChi();
                //user.RefToMainForm = MF;
                phieuchi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                phieuchi.MdiParent = MF;
                phieuchi.Show();
                phieuchi.Location = new Point(0, 0);
            }
            else
                phieuchi.Activate();
        }
        private static FormThoGiaCong thogc = null;
        private static void ShowFormThoGiaCong(MainForm MF)
        {
            if (thogc == null || thogc.IsDisposed)
            {
                thogc = new FormThoGiaCong();
                //user.RefToMainForm = MF;
                thogc.StartPosition = FormStartPosition.WindowsDefaultLocation;
                thogc.MdiParent = MF;
                thogc.Show();
                thogc.Location = new Point(0, 0);
            }
            else
                thogc.Activate();
        }
        private static FormLoaiDichVu loaidv = null;
        private static void ShowFormLoaiDV(MainForm MF)
        {
            if (loaidv == null || thogc.IsDisposed)
            {
                loaidv = new FormLoaiDichVu();
                //user.RefToMainForm = MF;
                loaidv.StartPosition = FormStartPosition.WindowsDefaultLocation;
                loaidv.MdiParent = MF;
                loaidv.Show();
                loaidv.Location = new Point(0, 0);
            }
            else
                loaidv.Activate();
        }
        public bool CloseForm(Form F)
        {
            if (phieumuahang != F)
            {
                if ((phieumuahang != null) && (!phieumuahang.IsDisposed))
                {
                    phieumuahang.Close();
                }
            }
            if (phieunhaphang != F)
            {
                if ((phieunhaphang != null) && (!phieunhaphang.IsDisposed))
                {
                    phieunhaphang.Close(); ;
                }
            }
            if (phieubanhang != F)
            {
                if ((phieubanhang != null) && (!phieubanhang.IsDisposed))
                {
                    phieubanhang.Close(); ;
                }
            }

            if (phieudichvu != F)
            {
                if ((phieudichvu != null) && (!phieudichvu.IsDisposed))
                {
                    phieudichvu.Close(); ;
                    if (phieudichvu.DialogResult == DialogResult.Cancel)
                        return false;
                }
            }
            if (phieugiacong != F)
            {
                if ((phieugiacong != null) && (!phieugiacong.IsDisposed))
                {
                    phieugiacong.Close(); ;
                }
            }
            if (phieuno != F)
            {
                if ((phieuno != null) && (!phieuno.IsDisposed))
                {
                    phieuno.Close();
                }
            }
            if (sanpham != F)
            {
                if ((sanpham != null) && (!sanpham.IsDisposed))
                {
                    sanpham.Close();
                    if (sanpham.DialogResult == DialogResult.Cancel)
                        return false;
                }
            }
            if (kieusanpham != F)
            {
                if ((kieusanpham != null) && (!kieusanpham.IsDisposed))
                {
                    kieusanpham.Close();
                    if (kieusanpham.DialogResult == DialogResult.Cancel)
                        return false;
                }
            }
            if (loaisanpham != F)
            {
                if ((loaisanpham != null) && (!loaisanpham.IsDisposed))
                {
                    loaisanpham.Close(); ;
                }
            }
            if (dvtinh != F)
            {
                if ((dvtinh != null) && (!dvtinh.IsDisposed))
                {
                    dvtinh.Close(); ;
                }
            }
            if (baocao != F)
            {
                if ((baocao != null) && (!baocao.IsDisposed))
                {
                    baocao.Close(); ;
                }
            }
            if (khachhang != F)
            {
                if ((khachhang != null) && (!khachhang.IsDisposed))
                {
                    khachhang.Close(); ;
                }
            }
            if (phanquyen != F)
            {
                if ((phanquyen != null) && (!phanquyen.IsDisposed))
                {
                    phanquyen.Close(); ;
                }
            }
            if (user != F)
            {
                if ((user != null) && (!user.IsDisposed))
                {
                    user.Close(); ;
                }
            }
            if (thamso != F)
            {
                if ((thamso != null) && (!thamso.IsDisposed))
                {
                    thamso.Close(); ;
                }
            }
            if (phieuchi != F)
            {
                if ((phieuchi != null) && (!phieuchi.IsDisposed))
                {
                    phieuchi.Close(); ;
                }
            }
            if (thogc != F)
            {
                if ((thogc != null) && (!thogc.IsDisposed))
                {
                    thogc.Close(); ;
                }
            }
            if (loaidv != F)
            {
                if ((loaidv != null) && (!loaidv.IsDisposed))
                {
                    loaidv.Close(); ;
                }
            }
            return true;
        }

        #endregion

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;

            foreach (ToolStripItem x in menuStrip1.Items)
            {
                x.Visible = false;
            }

            string q = (new M_NguoiDungBLL()).Get(Taikhoan.UserName).Quyen;
            Quyen = (new M_PhanQuyenBLL()).Get(q);

            this.tệpToolStripMenuItem.Visible = true;
            if (Quyen.DichVu > 0)
            {
                this.dịchVụToolStripMenuItem.Visible = true;
            }
            if (Quyen.PhieuBan > 0)
            {
                this.btnPhieuBanHang.Visible = true;
            }
            if (Quyen.PhieuMua > 0)
            {
                this.muaHàngToolStripMenuItem.Visible = true;
            }
            if (Quyen.QuanLy > 0)
            {
                this.nợToolStripMenuItem.Visible = true;
                this.danhMụcToolStripMenuItem.Visible = true;
            }
            if (Quyen.ThuKho > 0)
            {
                this.nhâpHàngToolStripMenuItem.Visible = true;
                this.btnKeToan.Visible = true;
            }
            
            if (Quyen.PhieuMua==3 &&
                Quyen.PhieuBan==3 &&
                Quyen.DichVu==3 &&
                Quyen.QuanLy==3 &&
                Quyen.ThuKho==3) //super
            {
                this.quảnTrịToolStripMenuItem.Visible = true;
            }
        }

        private void btnPhieuMuaHang_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieumuahang))
            {
                ShowFormPhieuMuaHang(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Mua Hàng";
            }
        }

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieubanhang))
            {
                ShowFormPhieuBanHang(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Bán Hàng";
            }
        }

        private void btnPhieuDV_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieudichvu))
            {
                ShowFormDichVu(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Dịch Vụ";
            }
        }

        private void btnPhieuGiaCong_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieugiacong))
            {
                ShowFormGiaCong(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Gia Công";
            }
        }

        private void btnPhieuNhapHang_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieunhaphang))
            {
                ShowFormPhieuNhapHang(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Nhập Hàng";
            }
        }

        private void btnPhieuNo_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieuno))
            {
                ShowFormPhieuNo(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Nợ" ;
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            if (CloseForm(sanpham))
            {
                ShowFormSanPham(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Sản Phẩm";
            }
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (CloseForm(loaisanpham))
            {
                ShowFormLoaiSanPham(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Loại Sản Phẩm";
            }
        }

        private void btnKieuSP_Click(object sender, EventArgs e)
        {
            if (CloseForm(kieusanpham))
            {
                ShowFormKieuSanPham(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Kiểu Sản Phẩm";
            }
        }

        private void btnDonViTinh_Click(object sender, EventArgs e)
        {
            if (CloseForm(dvtinh))
            {
                ShowFormDonViTinh(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Đơn Vị Tính";
            }
        }

        private void báoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CloseForm(baocao))
            {
                ShowFormBaoCao(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Báo Cáo Tồn Kho";
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (CloseForm(khachhang))
            {
                ShowFormKhachHang(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Khách Hàng";
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            try
            {
                M_UserEdit form = new M_UserEdit(Taikhoan, 13);
                form.Text = "ĐỔI MẬT KHẨU";
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show("Đổi thành công");
                }
                else
                    MessageBox.Show("Đổi thất bại");
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            if (CloseForm(user))
            {
                ShowFormUser(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Người Dùng";
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất và thoát khỏi chương trình đang chạy ? ", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
                isDangXuat = true;
                this.Close();
            }
        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CloseForm(phanquyen))
            {
                ShowFormPhanQuyen(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phân Quyền";
            }
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            if (CloseForm(phieuchi))
            {
                ShowFormPhieuChi(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Phiếu Chi";
            }
        }

        private void btnThamSo_Click(object sender, EventArgs e)
        {
            if (CloseForm(thamso))
            {
                ShowFormThamSo(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Tham Số";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isDangXuat)
            if (MessageBox.Show("Bạn muốn thoát chương trình ?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnThoGiaCong_Click(object sender, EventArgs e)
        {
            if (CloseForm(thogc))
            {
                ShowFormThoGiaCong(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Thợ Gia Công";
            }
        }

        private void btnLoaiDV_Click(object sender, EventArgs e)
        {
            if (CloseForm(loaidv))
            {
                ShowFormLoaiDV(this);
                this.Text = "Quản Lý Vàng Bạc Đá Quý - " + "Loại Dịch Vụ";
            }
        }
    }
}
