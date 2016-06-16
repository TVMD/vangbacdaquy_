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
        M_PhieuBanHangBLL PhieuBan = new M_PhieuBanHangBLL();
        public M_PhieuNo()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public Form RefToMainForm { set; get; }
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
            ControlBox = false;
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
            //reset các ô tìm kiếm
            txtSoPhieuno.Text = "";
            txtSoPhieuBan.Text = "";
            dateTimePickerNgayNo.Text = dateTimePickerNgayThanhToan.Text = DateTime.Now.ToShortDateString();
            txtSoTienTramin.Text = txtSoTienTramax.Text = "";
            txtConLaimin.Text = txtConLaimax.Text = "";
            txtTenKhachHang.Text = "";

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

        private void datagridviewPhieuNo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow r = datagridviewPhieuNo.SelectedRows[0];
            txtSoPhieuno.Text = r.Cells["SoPhieuNo"].Value.ToString();
            txtSoPhieuBan.Text = r.Cells["SoPhieuBan"].Value.ToString();
            dateTimePickerNgayNo.Text = r.Cells["NgayNo"].Value.ToString();
            dateTimePickerNgayThanhToan.Text = r.Cells["NgayThanhToan"].Value.ToString();
            txtSoTienTramin.Text = txtSoTienTramax.Text = r.Cells["SoTienTra"].Value.ToString();
            txtConLaimin.Text = txtConLaimax.Text = r.Cells["SoTienConLai"].Value.ToString();
            txtTenKhachHang.Text = PhieuBan.GetTenKH((int)r.Cells["SoPhieuNo"].Value);
        }

        private void txtSoPhieuno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSoPhieuBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSoTienTramin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtSoTienTramax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtConLaimin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
            if (e.KeyChar == (char)13)
            {
                toolStripTimkiem_Click(sender, e);
            }
        }

        private void txtConLaimax_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}
