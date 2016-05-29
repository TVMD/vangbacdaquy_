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
        }
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

        }
        private void toolstripThem_Click(object sender, EventArgs e)
        {

        }
        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.datagridviewPhieuBan.SelectedRows)
            {
                p.Delete((int)item.Cells["SoPhieuBan"].Value);
                datagridviewPhieuBan.Rows.Remove(item);
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
        }
    }
}
