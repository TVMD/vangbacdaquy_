using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogiLayer
{
    public class PhieuNhap_BUS
    {
        VBDQDataContext DB = new VBDQDataContext();
        public List<PhieuNhap_DTO> LayTatCa()
        {
            var MyQuery = (from pbh in DB.PHIEUNHAPs
                           select new PhieuNhap_DTO
                           {
                               SoPhieuNhap=pbh.SoPhieuNhap,
                               NgayLap=pbh.NgayLap.ToString(),
                               TongTien=pbh.TongTien??default(decimal)
                           });
            return MyQuery.ToList();
        }
        public void ThemPhieuNhap(PhieuNhap_DTO a)
        {
            PHIEUNHAP b = new PHIEUNHAP();
            b.NgayLap =DateTime.Parse( a.NgayLap);
            b.TongTien = a.TongTien;
            DB.PHIEUNHAPs.InsertOnSubmit(b);
            DB.SubmitChanges();
        }
        public void CapNhapPhieuNhap(PhieuNhap_DTO a)
        {
            var obj = DB.PHIEUNHAPs.Single(x => x.SoPhieuNhap == a.SoPhieuNhap);
            //obj.TongTien = a.TongTien;
            obj.NgayLap =DateTime.Parse( a.NgayLap);
            DB.SubmitChanges();
        }
        public PhieuNhap_DTO LayPhieuNhap(int sopn)
        {
            var MyQuery = (from pbh in DB.PHIEUNHAPs
                           where pbh.SoPhieuNhap == sopn
                           select new PhieuNhap_DTO
                           {
                               SoPhieuNhap = pbh.SoPhieuNhap,
                               NgayLap = pbh.NgayLap.ToString(),
                               TongTien = pbh.TongTien ?? default(decimal)
                           });
            return MyQuery.FirstOrDefault();
        }
        public void XoaPhieuNhap(int sopn)
        {
            var Myquery = (from p in DB.CTPHIEUNHAPs
                           where p.SoPhieuNhap == sopn
                           select p);
            DB.CTPHIEUNHAPs.DeleteAllOnSubmit(Myquery);
            var MyQuery = (from p in DB.PHIEUNHAPs
                           where p.SoPhieuNhap == sopn
                           select p);
            DB.PHIEUNHAPs.DeleteAllOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
        public List<PhieuNhap_DTO> Search(PhieuNhap_DTO a)
        {
            var pmh = DB.PhieuNhapSearch(a.SoPhieuNhap,a.NgayLap, a.TongTien);
            var MyQuery = (from mh in pmh
                           select new PhieuNhap_DTO
                           {
                               SoPhieuNhap = mh.SoPhieuNhap,
                               NgayLap = mh.NgayLap.ToString(),
                               TongTien = mh.TongTien ?? default(decimal)
                           });
            return MyQuery.ToList();
        }
    }
}
