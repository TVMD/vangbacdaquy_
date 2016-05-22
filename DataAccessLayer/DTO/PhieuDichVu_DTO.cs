using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDichVu_DTO
    {
        public int SoPhieuDV { get; set; }
        public int MaKH { get; set; }
        public string NgayDangKy { get; set; }
        public string NgayGiao { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public decimal TinhTrang { get; set; }
    }
}
