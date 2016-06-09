using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThoGiaCong_DTO
    {
        public int MaTho { get; set; }
        public string TenTho { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public ThoGiaCong_DTO()
        {
            MaTho = 0;
            TenTho = null;
            SDT = null;
            DiaChi = null;
        }
    }
}
