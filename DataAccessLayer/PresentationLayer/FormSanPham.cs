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
using DTO;

namespace PresentationLayer
{
    public partial class FormSanPham : Form
    {
        M_SanPhamBLL sp=new M_SanPhamBLL();
        KieuSP_BUS k = new KieuSP_BUS();
        LoaiSP_BUS lo = new LoaiSP_BUS();
        public FormSanPham()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        void load()
        {
            dataGridView1.DataSource = sp.LaySP();
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            cbbKieuSP.DataSource = k.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = lo.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            dataGridView1.Columns["TrongLuong"].HeaderText = "Trọng lượng";
            dataGridView1.Columns["DonGiaBan"].HeaderText = "Đơn giá bán";
            dataGridView1.Columns["SoLuongTon"].HeaderText = "Số lượng tổn";
            dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenDonViTinh"].HeaderText = "Dơn vị tính";
        }
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            load();
            ControlBox = false;
        }
        public Form RefToMainForm { set; get; }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTrongLuongMax.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTrongLuongMin.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaBanMax.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDonGiaMin.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSLTonMax.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSLTonMin.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbbKieuSP.SelectedValue= dataGridView1.CurrentRow.Cells[2].Value;
            cbbLoaiSP.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            txtTenDV.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng trươc khi xóa");
                return;
            }
            DialogResult dr = MessageBox.Show("Sản phẩm này có thể đã được sử dụng, nếu xóa sẽ gây lỗi, bạn có chắc chắn muốn xóa không?", "Cảnh Báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                sp.XoaSP(Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                load();
            }
        }

        private void toolstripThem_Click(object sender, EventArgs e)
        {
            FormThemSP them = new FormThemSP();
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void toolStripSửa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một dòng để sửa");
                return;
            }
            int malsp = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FormThemSP them = new FormThemSP(malsp);
            them.ShowDialog();
            if (them.DialogResult == DialogResult.Cancel)
                load();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaSP.Text ="";
            txtTrongLuongMax.Text = "";
            txtTrongLuongMin.Text = "";
            txtDonGiaBanMax.Text = "";
            txtDonGiaMin.Text = "";
            txtSLTonMax.Text = "";
            txtSLTonMin.Text = "";
            cbbKieuSP.SelectedValue =0;
            cbbLoaiSP.SelectedValue = 0;
            txtTenDV.Text = "";
        }

        private void toolStripTimkiem_Click(object sender, EventArgs e)
        {
            int slmin= txtSLTonMin.Text==""?0:Int16.Parse(txtSLTonMin.Text);
            int slmax= txtSLTonMax.Text==""?0:Int16.Parse(txtSLTonMax.Text);
            int dongiamin= txtDonGiaMin.Text==""?0:Int16.Parse(txtDonGiaMin.Text);
            int dongiamax= txtDonGiaBanMax.Text==""?0:Int16.Parse(txtDonGiaBanMax.Text);
            int trongluongmin=txtTrongLuongMin.Text==""?0:Int16.Parse(txtTrongLuongMin.Text);
            int trongluongmax = txtTrongLuongMax.Text == "" ? 0 : Int16.Parse(txtTrongLuongMax.Text);
            SanPham_DTO a = new SanPham_DTO();
            a.MaSP = txtMaSP.Text == "" ? 0 : Int16.Parse(txtMaSP.Text);
            a.MaKieuSP = cbbKieuSP.Text == "" ? 0 : Int16.Parse(cbbKieuSP.SelectedValue.ToString());
            a.MaLoaiSP = cbbLoaiSP.Text == "" ? 0 : Int16.Parse(cbbLoaiSP.SelectedValue.ToString());
            dataGridView1.DataSource = sp.Search(a, slmin, slmax, dongiamin, dongiamax, trongluongmin, trongluongmax);
            dataGridView1.Columns["MaLoaiSP"].Visible = false;
            dataGridView1.Columns["MaKieuSP"].Visible = false;
            cbbKieuSP.DataSource = k.LayKieuSP();
            cbbKieuSP.DisplayMember = "TenKieuSP";
            cbbKieuSP.ValueMember = "MaKieuSP";
            cbbLoaiSP.DataSource = lo.LayLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            dataGridView1.Columns["TrongLuong"].HeaderText = "Trọng lượng";
            dataGridView1.Columns["DonGiaBan"].HeaderText = "Đơn giá bán";
            dataGridView1.Columns["SoLuongTon"].HeaderText = "Số lượng tổn";
            dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["TenLoaiSP"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["TenKieuSP"].HeaderText = "Kiểu sản phẩm";
            dataGridView1.Columns["TenDonViTinh"].HeaderText = "Dơn vị tính";
        }
    }
}
