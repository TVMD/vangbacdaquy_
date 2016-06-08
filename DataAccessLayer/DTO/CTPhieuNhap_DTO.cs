using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhieuNhap_DTO
    {
        public int SoPhieuNhap { get; set; }
        public int MaSP { get; set; }
        public int SLNhap { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string TenKieuSP { get; set; }
        public string TenLoaiSP { get; set; }
        public int MaKieuSP { get; set; }
        public int MaLoaiSP { get; set; }
    }
}
