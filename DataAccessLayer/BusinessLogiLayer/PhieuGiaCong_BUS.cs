using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class PhieuGiaCong_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        public List<PhieuGiaCong_DTO> LayTatCa()
        {
            var MyQuery = (from pbh in vbdq.PHIEUGIACONGs
                           select new PhieuGiaCong_DTO
                           {
                               SoPhieuGiaCong = pbh.SoPhieuGiaCong,
                               NgayLap = pbh.NgayLap.ToString(),
                               TongTien = Decimal.Parse(pbh.TongTien.ToString())
                           });
            return MyQuery.ToList();
        }
        public String LayKhoaMoi()
        {
            var MyQuery = vbdq.PHIEUGIACONGs.
                         OrderBy(o => o.SoPhieuGiaCong).ToList().LastOrDefault();
            if (MyQuery != null)
                return MyQuery.SoPhieuGiaCong.ToString();
            else
                return "0";
        }
        public void PhieuGiaCong_Upd(PhieuGiaCong_DTO pbh)
        {
            var obj = vbdq.PHIEUGIACONGs.Single(x => x.SoPhieuGiaCong == pbh.SoPhieuGiaCong);

            obj.NgayLap = DateTime.Parse(pbh.NgayLap.ToString());
            obj.TongTien = Decimal.Parse(pbh.TongTien.ToString());

            vbdq.SubmitChanges();
        }
        public void PhieuGiaCong_Add(PhieuGiaCong_DTO pbh)
        {
            PHIEUGIACONG obj = new PHIEUGIACONG();
            obj.SoPhieuGiaCong = pbh.SoPhieuGiaCong;
            obj.NgayLap = DateTime.Parse(pbh.NgayLap.ToString());            
            obj.TongTien = Decimal.Parse(pbh.TongTien.ToString());

            vbdq.PHIEUGIACONGs.InsertOnSubmit(obj);
            vbdq.SubmitChanges();
        }
        public void PhieuGiaCong_Del(String sophieugc)
        {
            PHIEUGIACONG phieugc = (from phieu in vbdq.PHIEUGIACONGs select phieu).Single(n => n.SoPhieuGiaCong.CompareTo(sophieugc) == 0);
            vbdq.PHIEUGIACONGs.DeleteOnSubmit(phieugc);
            vbdq.SubmitChanges();

        }

        public List<PhieuGiaCong_DTO> Search(PhieuGiaCong_DTO phieu)
        {
            //DateTime t1 = phieugc.NgayLap;
            DateTime t1;
            DateTime.TryParse(phieu.NgayLap, out t1);
            var list = (from phieugc in vbdq.PHIEUGIACONGs
                        where (phieugc.SoPhieuGiaCong == phieu.SoPhieuGiaCong || phieu.SoPhieuGiaCong == 0) &&
                             (phieu.NgayLap.Contains(" ") || phieugc.NgayLap == t1) &&
                             (phieugc.TongTien == phieu.TongTien || phieu.TongTien == 0) 
                        select new PhieuGiaCong_DTO
                        {
                            SoPhieuGiaCong = phieugc.SoPhieuGiaCong,
                            NgayLap = phieugc.NgayLap.ToString(),
                            TongTien = Decimal.Parse(phieugc.TongTien.ToString())
                        });
            return list.ToList();

        }
    }
}
