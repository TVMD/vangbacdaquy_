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

                int sophieuno = txtSoPhieuno.Text == "" ? 0 : int.Parse(txtSoPhieuno.Text);
                int sophieuban = txtSoPhieuBan.Text == "" ? 0 : int.Parse(txtSoPhieuBan.Text);
                decimal tramin = txtSoTienTramin.Text == "" ? 0 : decimal.Parse(txtSoTienTramin.Text);
                decimal tramax = txtSoTienTramax.Text == "" ? 0 : decimal.Parse(txtSoTienTramax.Text);
                decimal conlaimin = txtConLaimin.Text == "" ? 0 : decimal.Parse(txtConLaimin.Text);
                decimal conlaimax = txtConLaimax.Text == "" ? 0 : decimal.Parse(txtConLaimin.Text);
                
                x = PhieuNo.Search(sophieuno,
                  sophieuban,
                  txtTenKhachHang.Text,
                  dateTimePickerNgayNo.Value.ToShortDateString(),
                  dateTimePickerNgayThanhToan.Value.ToShortDateString(),
                  tramin,
                  tramax,
                  conlaimin,
                  conlaimax);
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

        private void toolstripThem_Click(object sender, EventArgs e)
        {
            M_PhieuNoEdit form = new M_PhieuNoEdit();
            form.Text = "THÊM PHIẾU NỢ";

            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                loadgridview(this.PhieuNo.SelectTop(0));
            }
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow r = datagridviewPhieuNo.SelectedRows[0];
                PhieuNo_DTO p = new PhieuNo_DTO()
                {
                    SoPhieuNo = int.Parse(r.Cells["SoPhieuNo"].Value.ToString()),
                    SoPhieuBan = int.Parse(r.Cells["SoPhieuBan"].Value.ToString()),
                    NgayNo = r.Cells["NgayNo"].Value.ToString(),
                    NgayThanhToan = r.Cells["NgayThanhToan"].Value.ToString(),
                    SoTienTra = decimal.Parse(r.Cells["SoTienTra"].Value.ToString()),
                    SoTienConLai = decimal.Parse(r.Cells["SoTienConLai"].Value.ToString())
                };
                M_PhieuNoEdit form = new M_PhieuNoEdit(p);
                form.Text = "CHỈNH SỬA THÔNG TIN PHIẾU NỢ";

                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    loadgridview(this.PhieuNo.SelectTop(0));
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString() + "\nNếu chưa chọn dòng nào hãy chọn 1 dòng");
            }
        }

        private void datagridviewPhieuNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripSửa_Click(sender, e);
        }

    }
}
