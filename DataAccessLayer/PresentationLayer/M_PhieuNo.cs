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
    public partial class M_PhieuNo : Form
    {
        M_PhieuNoBLL PhieuNo = new M_PhieuNoBLL();
        public M_PhieuNo()
        {
            InitializeComponent();
        }

        private void loadgridview(BindingList<PhieuNo_DTO> p)
        {
            datagridviewPhieuNo.DataSource = p;
            datagridviewPhieuNo.Columns["SoPhieuNo"].HeaderText = "Số phiếu nợ";
            datagridviewPhieuNo.Columns["SoPhieuBan"].HeaderText = "Số phiếu bán";
            datagridviewPhieuNo.Columns["NgayNo"].HeaderText = "Ngày nợ";
            datagridviewPhieuNo.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
            datagridviewPhieuNo.Columns["SoTienTra"].HeaderText = "Số tiền trả";
            datagridviewPhieuNo.Columns["SoTienConLai"].HeaderText = "Số tiền còn lại";

        }

        private void M_PhieuNo_Load(object sender, EventArgs e)
        {
            var x = PhieuNo.SelectTop(0);
            loadgridview(x);

        }

        private void toolStripTimkiem_Click(object sender, EventArgs e)
        {
            BindingList<PhieuNo_DTO> x;
            try
            {
                this.dateTimePickerNgayNo.CustomFormat = "yyyy/mm/dd";
                this.dateTimePickerNgayThanhToan.CustomFormat = "yyyy/mm/dd";

                x = PhieuNo.Search(int.Parse(txtSoPhieuno.Text),
                    int.Parse(txtSoPhieuBan.Text),
                    txtTenKhachHang.Text,
                    dateTimePickerNgayNo.Value.ToShortDateString(),
                    dateTimePickerNgayThanhToan.Value.ToShortDateString(),
                    decimal.Parse(txtSoTienTramin.Text),
                    decimal.Parse(txtSoTienTramax.Text),
                    decimal.Parse(txtConLaimin.Text),
                    decimal.Parse(txtConLaimax.Text)
                    );
                loadgridview(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in datagridviewPhieuNo.SelectedRows)
            {
                PhieuNo.Delete(int.Parse(r.Cells["SoPhieuNo"].Value.ToString()));
                datagridviewPhieuNo.Rows.Remove(r);
            }
        }

    }
}
