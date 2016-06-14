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
    public partial class FormPhieuNhapHang : Form
    {
        PhieuNhap_BUS pn = new PhieuNhap_BUS();
        int Quyen;
        public FormPhieuNhapHang()
        {
            InitializeComponent();
            ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        public FormPhieuNhapHang(int quyen)
        {
            InitializeComponent();
            ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Quyen = quyen;
        }

        private void FormPhieuNhapHang_Load(object sender, EventArgs e)
        {
            load();
            
        }
        public Form RefToMainForm { set; get; }
        public void load()
        {
            if (Quyen == 1)
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
            if (Quyen == 2)
            {
                btnThem.Visible = false;
            }
            dataGridView1.DataSource = pn.LayTatCa();
            dataGridView1.Columns["SoPhieuNhap"].HeaderText = "Số phiếu nhập";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
            cbbSoPhieuNhap.DataSource = pn.LayTatCa();
            cbbSoPhieuNhap.DisplayMember = "SoPhieuNhap";
            cbbSoPhieuNhap.ValueMember = "SoPhieuNhap";
            dtNgayLAp.Format = DateTimePickerFormat.Custom;
            dtNgayLAp.CustomFormat = "dd-MM-yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThemPhieuNhap them = new FormThemPhieuNhap();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormSuaPhieuNhap sua;
            if (dataGridView1.SelectedRows.Count != 0)
                sua = new FormSuaPhieuNhap(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            else sua = new FormSuaPhieuNhap();
            sua.ShowDialog();
            if (sua.DialogResult == DialogResult.Cancel)
                load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbSoPhieuNhap.SelectedValue = dataGridView1.CurrentRow.Cells[0].Value;
            dtNgayLAp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTongTien.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Decimal.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) != 0)
            {
                DialogResult dr = MessageBox.Show("Số phiếu nhập này đã được sử dụng bạn có muốn xóa tất cả chi tiết phiếu nhập đi kèm không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    pn.XoaPhieuNhap(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    load();
                }
            }
            
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PhieuNhap_DTO a = new PhieuNhap_DTO();
            a.SoPhieuNhap = -1;
            if (cbbSoPhieuNhap.Text != "")
                a.SoPhieuNhap = Int16.Parse(cbbSoPhieuNhap.SelectedValue.ToString());
            if (dtNgayLAp.Value.Date != DateTime.Now.Date)
                a.NgayLap = dtNgayLAp.Value.ToShortDateString();
            else a.NgayLap = "";
            if (txtTongTien.Text == "")
                a.TongTien = -1;
            else
            a.TongTien = Decimal.Parse(txtTongTien.Text);
            dataGridView1.DataSource = pn.Search(a);
            dataGridView1.Columns["SoPhieuNhap"].HeaderText = "Số phiếu nhập";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            int sopn = Int16.Parse(cbbSoPhieuNhap.Text);
            FormChiTietPhieuNhap ct = new FormChiTietPhieuNhap(sopn);
            ct.ShowDialog();
            if (ct.DialogResult == DialogResult.Cancel)
                load();
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 46);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtNgayLAp.Value = DateTime.Now.Date;
            txtTongTien.Text = "";
            cbbSoPhieuNhap.SelectedValue = 0;
        }
    }
}
