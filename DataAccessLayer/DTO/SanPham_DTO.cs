using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        public int MaSP { get; set; }
        public int MaLoaiSP { get; set; }
        public int MaKieuSP { get; set; }
        public float TrongLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string TenLoaiSP { get; set; }
        public string TenKieuSP { get; set; }
        public string TenDonViTinh { get; set; }
    }
}
