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
    public partial class M_PhieuBanHang : Form
    {
        int mod = 0;
        M_PhieuBanHangBLL p = new M_PhieuBanHangBLL();
        
        public M_PhieuBanHang()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public Form RefToMainForm { set; get; }
        private void loadgridview(BindingList<PhieuBanHang_DTO> pbh)
        {
            datagridviewPhieuBan.DataSource = pbh;
            datagridviewPhieuBan.Columns["MaKH"].HeaderText = "Mã khách hàng";
            datagridviewPhieuBan.Columns["TenKh"].HeaderText = "Tên khách hàng";
            datagridviewPhieuBan.Columns["SoPhieuBan"].HeaderText = "Số phiếu";
            datagridviewPhieuBan.Columns["NgayBan"].HeaderText = "Ngày bán";
            datagridviewPhieuBan.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
            datagridviewPhieuBan.Columns["TongTien"].HeaderText = "Tổng tiền";
            datagridviewPhieuBan.Columns["SoTienTra"].HeaderText = "Số tiền trả";

            if (mod == 0)
            {
                datagridviewPhieuBan.Columns["TenKh"].Width *= 2;
                datagridviewPhieuBan.Columns["NgayBan"].Width *= 2;
                datagridviewPhieuBan.Columns["NgayBan"].Width -= datagridviewPhieuBan.Columns["NgayBan"].Width / 3;
                datagridviewPhieuBan.Columns["NgayThanhToan"].Width *= 2;
                datagridviewPhieuBan.Columns["NgayThanhToan"].Width -= datagridviewPhieuBan.Columns["NgayThanhToan"].Width / 3;
                mod++;
            }
           
        }

        private void M_PhieuBanHang_Load(object sender, EventArgs e)
        {
            var pbh = p.SelectTop(0);
            loadgridview(pbh);
            ControlBox = false;
        }
        
        private void toolstripThem_Click(object sender, EventArgs e)
        {
            M_PhieuBanHanhEdit form = new M_PhieuBanHanhEdit();
            form.Text = "CHI TIẾT PHIẾU BÁN";

            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadgridview(this.p.SelectTop(0));
            }
        }
        
        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            M_PhieuNoBLL phieuno = new M_PhieuNoBLL();
            foreach (DataGridViewRow item in this.datagridviewPhieuBan.SelectedRows)
            {
                int x = phieuno.GetSLPhieuNo((int)item.Cells["SoPhieuBan"].Value);
                if (x > 1) //k cho xoa
                {
                    MessageBox.Show("Không thể xóa phiếu bán này. Đã tồn tại nhiều phiếu nợ. Kiểm tra và xóa phiếu nợ rồi thử lại");
                    return;
                }
                else // cho xoa
                {
                    if (x == 1) // nếu có phiếu nợ thì cần xóa chứ
                    {
                        if (MessageBox.Show("Có 1 phiếu nợ của phiếu bán này, Vẫn xóa ?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            phieuno.DeletebyPhieuBan((int)item.Cells["SoPhieuBan"].Value);
                        }
                        else
                            return;
                    }
                    p.Delete((int)item.Cells["SoPhieuBan"].Value);
                    datagridviewPhieuBan.Rows.Remove(item);
                }
            }    
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            p.Save();
        }

        private void toolStripTimkiem_Click(object sender, EventArgs e)
        {
            BindingList<PhieuBanHang_DTO> phieu;
            try
            {
                this.dateTimePickerNgayban.CustomFormat = "yyyy/mm/dd";
                this.dateTimePickerNgayThanhToan.CustomFormat = "yyyy/mm/dd";
                int makh = txtMaKhachHang.Text == "" ? 0 : int.Parse(txtMaKhachHang.Text);
                int sophieu = txtSoPhieu.Text == "" ? 0 : int.Parse(txtSoPhieu.Text);

                decimal sotientramin = txtSoTienTraMin.Text == "" ? 0 : decimal.Parse(txtSoTienTraMin.Text);
                decimal sotientramax = txtSoTienTraMax.Text == "" ? 0 : decimal.Parse(txtSoTienTraMax.Text);
                decimal tongtienmin = txtTongTienMin.Text == "" ? 0 : decimal.Parse(txtTongTienMin.Text);
                decimal tongtienmax = txtTongTienMax.Text == "" ? 0 : decimal.Parse(txtTongTienMax.Text);
                
                phieu = p.Search( sophieu,
                                   makh,
                                   txtTenKhachHang.Text,
                                   dateTimePickerNgayban.Value.ToShortDateString(),
                                   dateTimePickerNgayThanhToan.Value.ToShortDateString(),
                                   tongtienmin,tongtienmax,
                                   sotientramin,sotientramax
                                   );
                loadgridview(phieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // reset cac o tim kiem
            txtSoPhieu.Text = "";
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            dateTimePickerNgayban.Text = dateTimePickerNgayThanhToan.Text = DateTime.Now.ToShortDateString();
            txtTongTienMin.Text = txtTongTienMax.Text = "";
            txtSoTienTraMin.Text = txtSoTienTraMax.Text = "";

        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            M_PhieuNoBLL phieuno = new M_PhieuNoBLL();
            var item = datagridviewPhieuBan.SelectedRows[0];
            int x = phieuno.GetSLPhieuNo((int)item.Cells["SoPhieuBan"].Value);
            if (x >= 1) //k cho cap nhat
            {
                MessageBox.Show("Không thể sửa trên phiếu bán này. Đã tồn tại nhiều phiếu nợ. Kiểm tra và xóa phiếu nợ rồi thử lại");
                return;
            }
            else // cho cập nhật
            {
                DataGridViewRow r = datagridviewPhieuBan.SelectedRows[0];
                int sophieu = (int)r.Cells["SoPhieuBan"].Value;
                M_PhieuBanHanhEdit form = new M_PhieuBanHanhEdit(sophieu);
                form.Text = "CHI TIẾT PHIẾU BÁN";

                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    loadgridview(this.p.SelectTop(0));
                }
            }
           
        }

        private void toolStripButtonXem_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = datagridviewPhieuBan.SelectedRows[0];
            int sophieu = (int)r.Cells["SoPhieuBan"].Value;
            M_PhieuBanHanhEdit form = new M_PhieuBanHanhEdit(sophieu);
            form.Text = "CHI TIẾT PHIẾU BÁN";

            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadgridview(this.p.SelectTop(0));
            }
        }

        private void datagridviewPhieuBan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow r = datagridviewPhieuBan.SelectedRows[0];
            int sophieu = (int)r.Cells["SoPhieuBan"].Value;
            M_PhieuBanHanhEdit form = new M_PhieuBanHanhEdit(sophieu);
            form.Text = "CHI TIẾT PHIẾU BÁN";

            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadgridview(this.p.SelectTop(0));
            }
        }

        private void datagridviewPhieuBan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow r = datagridviewPhieuBan.SelectedRows[0];
            txtSoPhieu.Text = r.Cells["SoPhieuBan"].Value.ToString();
            txtMaKhachHang.Text = r.Cells["MaKH"].Value.ToString();
            txtTenKhachHang.Text = r.Cells["TenKh"].Value.ToString();
            dateTimePickerNgayban.Text = r.Cells["NgayBan"].Value.ToString();
            dateTimePickerNgayThanhToan.Text = r.Cells["NgayThanhToan"].Value.ToString();
            txtTongTienMin.Text = txtTongTienMax.Text = r.Cells["TongTien"].Value.ToString();
            txtSoTienTraMin.Text = txtSoTienTraMax.Text = r.Cells["SoTienTra"].Value.ToString();
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtMaKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtTenKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtTongTienMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtTongTienMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSoTienTraMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSoTienTraMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
