using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogiLayer
{
    public class KieuSP_BUS
    {
        VBDQDataContext DB = new VBDQDataContext();
        public List<KieuSP_DTO> LayKieuSP()
        {

            var MyQuery = (from pm in DB.KIEUSPs
                           select new KieuSP_DTO
                           {
                               MaKieuSP = pm.MaKieuSP,
                               TenKieuSP = pm.TenKieuSP
                           });

            return MyQuery.ToList();
        }
        public void XoaKieuSP(int makieusp)
        {
            var MyQuery = (from p in DB.KIEUSPs
                           where p.MaKieuSP == makieusp
                           select p).FirstOrDefault();
            DB.KIEUSPs.DeleteOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
        public KieuSP_DTO Lay1KSP(int makieusp)
        {

            var MyQuery = (from pm in DB.KIEUSPs
                           where pm.MaKieuSP==makieusp
                           select new KieuSP_DTO
                           {
                               MaKieuSP = pm.MaKieuSP,
                               TenKieuSP = pm.TenKieuSP
                           }).FirstOrDefault();

            return MyQuery;
        }
        public void ThemKieuSP(KieuSP_DTO a)
        {
            KIEUSP b = new KIEUSP();
            b.TenKieuSP = a.TenKieuSP;
            DB.KIEUSPs.InsertOnSubmit(b);
            DB.SubmitChanges();
        }
        public int CheckTenKieuSP(string name)
        {
            var MyQuery = DB.KIEUSPs.Where(x => x.TenKieuSP == name);
            int count = MyQuery.Count();
            return count;
        }
        public void CapNhapKieuSP(KieuSP_DTO a)
        {
            var b = DB.KIEUSPs.Single(x => x.MaKieuSP==a.MaKieuSP);
            b.TenKieuSP = a.TenKieuSP;
            DB.SubmitChanges();
        }
    }
}
