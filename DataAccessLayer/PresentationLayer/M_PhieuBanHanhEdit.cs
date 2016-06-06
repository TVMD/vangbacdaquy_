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
    public partial class M_PhieuBanHanhEdit : Form
    {
        int SoPhieuBan = 0;
        int Edit = 0; //edit = 1 la update 
        M_PhieuBanHangBLL PhieuBan = new M_PhieuBanHangBLL();
        M_CTPhieuBanBLL CTPhieuBan = new M_CTPhieuBanBLL();
        M_KhachHangBLL KhachHang = new M_KhachHangBLL();
        M_SanPhamBLL SanPham = new M_SanPhamBLL();
        
        public M_PhieuBanHanhEdit()
        {
            Edit = 0;
            InitializeComponent();
            SoPhieuBan = PhieuBan.GetSoPhieu();
            this.DialogResult = DialogResult.Cancel;
        }
        public M_PhieuBanHanhEdit(int sophieu)
        {
            SoPhieuBan = sophieu;
            Edit = 1;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void loadgridview(BindingList<CTPhieuBan_DTO> dschitiet)
        {
            
            this.dataGridViewCT.DataSource = dschitiet;
            dataGridViewCT.Columns["SoPhieuBan"].Visible = false;
            dataGridViewCT.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dataGridViewCT.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridViewCT.Columns["DonGia"].HeaderText = "Đơn giá";
            dataGridViewCT.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }
        private void M_PhieuBanHanhEdit_Load(object sender, EventArgs e)
        {
            
            comboBoxKhachHang.DataSource = KhachHang.SelectTop(0);
            comboBoxKhachHang.ValueMember = "MaKH";
            comboBoxKhachHang.DisplayMember = "TenKh";

            
            txtSPhieu.Text = SoPhieuBan.ToString();
            if (Edit == 1)
            {
                PhieuBanHang_DTO phieuban = new PhieuBanHang_DTO();
                phieuban = PhieuBan.SelectTop(SoPhieuBan, 0).FirstOrDefault();
                dateTimePickerNgayBan.Text = phieuban.NgayBan;
                dateTimePickerNgayThanhToan.Text = phieuban.NgayThanhToan;
                txtTongTien.Text = phieuban.TongTien.ToString();
                comboBoxKhachHang.SelectedValue = phieuban.MaKH;

                BindingList<CTPhieuBan_DTO> dschitiet = CTPhieuBan.SelectTop(int.Parse(txtSPhieu.Text),0);
                loadgridview(dschitiet);
            }
            else
            {
                PhieuBan.Insert(1, "1/1/1900", "1/1/1900", 0, 0); // them vo moi them chi tiet dc vi co rang buoc khoa ngoai
            }
            
        }

        private void buttonThemKH_Click(object sender, EventArgs e)
        {
            M_KhachHangEdit form = new M_KhachHangEdit();
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var x = KhachHang.SelectTop(0);
                comboBoxKhachHang.DataSource = x;
                comboBoxKhachHang.SelectedValue = x.Last().MaKH;
            }

        }


        private void toolStripTimkiem_Click(object sender, EventArgs e)
        {
            BindingList<CTPhieuBan_DTO> ctphieu;
            try
            {
                int masptk = txtMaSPTK.Text == "" ? 0 : int.Parse(txtMaSPTK.Text);

                int slmin = txtSlmin.Text == "" ? 0 : int.Parse(txtSlmin.Text);
                int slmax = txtSlmax.Text == "" ? 0 : int.Parse(txtSlmax.Text);

                decimal dongiamin = txtDonGiamin.Text == "" ? 0 : decimal.Parse(txtDonGiamin.Text);
                decimal dongiamax = txtDonGiamax.Text == "" ? 0 : decimal.Parse(txtDonGiamax.Text);

                decimal thanhtienmin = txtThanhTienmin.Text == "" ? 0 : decimal.Parse(txtThanhTienmin.Text);
                decimal thanhtienmax = txtThanhTienmin.Text == "" ? 0 : decimal.Parse(txtThanhTienmax.Text);

                ctphieu =   CTPhieuBan.Search(int.Parse(txtSPhieu.Text),
                                   masptk,
                                   slmin,slmax,
                                   dongiamin,dongiamax,
                                   thanhtienmin,thanhtienmax
                                   );
                loadgridview(ctphieu);
                txtTongTien.Text = PhieuBan.Search(int.Parse(txtSPhieu.Text)).FirstOrDefault().TongTien.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewCT.SelectedRows)
            {
                CTPhieuBan.Delete((int)item.Cells["SoPhieuBan"].Value,(int)item.Cells["MaSP"].Value);
                dataGridViewCT.Rows.Remove(item);
            }
            txtTongTien.Text = PhieuBan.Search(int.Parse(txtSPhieu.Text)).FirstOrDefault().TongTien.ToString();
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = this.dataGridViewCT.SelectedRows[0];
            CTPhieuBan_DTO ct = new CTPhieuBan_DTO()
            {
                SoPhieuBan = int.Parse(txtSPhieu.Text),
                MaSP = int.Parse(r.Cells["MaSP"].Value.ToString()),
                SoLuong = int.Parse(r.Cells["SoLuong"].Value.ToString()),
                DonGia = decimal.Parse(r.Cells["DonGia"].Value.ToString()),
                ThanhTien = decimal.Parse(r.Cells["ThanhTien"].Value.ToString())
            };
            M_CTPhieuBanHangEdit form = new M_CTPhieuBanHangEdit(ct, 1);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadgridview(this.CTPhieuBan.SelectTop(int.Parse(txtSPhieu.Text), 0));
                txtTongTien.Text = PhieuBan.Search(int.Parse(txtSPhieu.Text)).FirstOrDefault().TongTien.ToString();
            }
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            CTPhieuBan_DTO ct = new CTPhieuBan_DTO(){
                SoPhieuBan=int.Parse(txtSPhieu.Text),
                MaSP=0,
                SoLuong=0,
                DonGia=0,
                ThanhTien=0
            };
            M_CTPhieuBanHangEdit form = new M_CTPhieuBanHangEdit(ct, 0);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadgridview(this.CTPhieuBan.SelectTop(int.Parse(txtSPhieu.Text),0));
                txtTongTien.Text = PhieuBan.Search(int.Parse(txtSPhieu.Text)).FirstOrDefault().TongTien.ToString();
            }
        }
        private void dataGridViewCT_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripSửa_Click(sender, e);
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            decimal tong = 0;
            
            if (txtSoTienTra.Text != "") 
            if(decimal.Parse(txtSoTienTra.Text)>decimal.Parse(txtTongTien.Text)){
                MessageBox.Show("Số tiền trả làm sao lớn hơn tổng tiền được ?","Thông báo");
                return;
            }

            PhieuBan = new M_PhieuBanHangBLL();//de reset datacontext thu
            PhieuBan.Update(int.Parse(txtSPhieu.Text),
                int.Parse(comboBoxKhachHang.SelectedValue.ToString()),
                dateTimePickerNgayBan.Text,
                dateTimePickerNgayThanhToan.Text,
                decimal.Parse(txtTongTien.Text),
                decimal.Parse(txtSoTienTra.Text));

            if (txtSoTienTra.Text != txtTongTien.Text) // đã là khách quen, xem ở trên có 1 cái dk r. kiểm tra nợ cuối cùng
            {
                DialogResult dr = MessageBox.Show("Số tiền trả ít hơn tổng tiền, phải lập phiếu nợ nhé ? ","Thông báo",MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    M_PhieuNoEdit form = new M_PhieuNoEdit(int.Parse(txtSPhieu.Text));
                    form.Text = "THÊM PHIẾU NỢ";
                    DialogResult x = form.ShowDialog();
                    
                    if (x == DialogResult.OK)
                    {
                        MessageBox.Show("Đã tạo phiếu nợ.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else{
                        MessageBox.Show("Không tạo được phiếu nợ.Hãy thử lại");
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            txtSoTienTra.Text = txtTongTien.Text;
        }

        private void M_PhieuBanHanhEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && Edit==0)// k luu thi xoa cai moi tao di
            {
                PhieuBan.Delete(int.Parse(txtSPhieu.Text));
            }
        }

        private void comboBoxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KhachHang_DTO kh = KhachHang.GetById(int.Parse(comboBoxKhachHang.SelectedValue.ToString()));
                if (kh.Quen < 1)
                {
                    this.txtSoTienTra.Enabled = false;
                }
                else
                {
                    this.txtSoTienTra.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void txtSoTienTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void txtMaSPTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSlmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSlmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtDonGiamin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtDonGiamax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtThanhTienmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtThanhTienmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }
    }
}
