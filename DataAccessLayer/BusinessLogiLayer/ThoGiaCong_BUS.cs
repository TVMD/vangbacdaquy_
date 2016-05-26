using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class ThoGiaCong_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        //public IEnumerable<ThoGiaCong_DTO> LayTatCa()
        //{
        //    IEnumerable<ThoGiaCong_DTO> thogiacong = vbdq.THOGIACONGs.Where(o => o.MaTho == 1).AsEnumerable();
        //    return thogiacong;
        //}
        public List<ThoGiaCong_DTO> LayTatCa()
        {
            var MyQuery = (from pbh in vbdq.THOGIACONGs
                           select new ThoGiaCong_DTO
                           {
                               MaTho = pbh.MaTho,
                               TenTho = pbh.TenTho,
                               DiaChi = pbh.DiaChi,
                               SDT = pbh.SDT
                               
                           });
            return MyQuery.ToList(); 
        }

        public void ThoGiaCong_Upd(ThoGiaCong_DTO a)
        {
            var obj = vbdq.THOGIACONGs.Single(x => x.MaTho == a.MaTho);
            obj.TenTho = a.TenTho;
            obj.SDT = a.SDT;
            obj.DiaChi = a.DiaChi;

            vbdq.SubmitChanges();
        }
        public void ThoGiaCong_Add(ThoGiaCong_DTO a)
        {
            THOGIACONG b = new THOGIACONG();
            b.MaTho = a.MaTho;
            b.TenTho = a.TenTho;
            b.SDT = a.SDT;
            b.DiaChi = a.DiaChi;

            vbdq.THOGIACONGs.InsertOnSubmit(b);
            vbdq.SubmitChanges();
        }
        public void ThoGiaCong_Del(String matho)
        {
            THOGIACONG tho = (from thogiacong in vbdq.THOGIACONGs select thogiacong).Single(n => n.MaTho.CompareTo(matho)==0);
            vbdq.THOGIACONGs.DeleteOnSubmit(tho);
            vbdq.SubmitChanges();

        }
    }


}
