using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhieuDichVu_DTO
    {
        public int SoPhieuDichVu { get; set; }
        public int STT { get; set; }
        public int MaLoaiDV { get; set; }
        public string TenLoaiDV { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public int TinhTrang { get; set; }
        public string NgayGiao { get; set; }
    }
}
