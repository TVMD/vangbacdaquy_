using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhieuMua_DTO
    {
        public int SoPhieuMua { get; set; }
        public int STT { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string TenKieuSP { get; set; }
        public string TenLoaiSP { get; set; }
        public int MaKieuSP { get; set; }
        public int MaLoaiSP { get; set; }
    }
}
