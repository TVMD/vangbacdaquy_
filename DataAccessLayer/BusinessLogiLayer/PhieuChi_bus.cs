using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
namespace BusinessLogiLayer
{
    public class PhieuChi_bus
    {
        VBDQDataContext vbdq = new VBDQDataContext();
        public List<PhieuChi_DTO> LayTatCa()
        {
            var MyQuery = (from pc in vbdq.PHIEUCHIs
                           select new PhieuChi_DTO
                           {
                               SoPhieuChi = pc.SoPhieuChi,
                               NoiDung = pc.NoiDung,
                               SoTienChi = decimal.Parse( pc.SoTienChi.ToString()),
                               NgayChi = pc.NgayChi.ToString()


                           });
            return MyQuery.ToList();
        }
        public void PhieuChi_Upd(PhieuChi_DTO a)
        {
            PHIEUCHI b = new PHIEUCHI();
            var obj = vbdq.PHIEUCHIs.Single(x => x.SoPhieuChi == a.SoPhieuChi);
           // obj.SoPhieuChi = a.SoPhieuChi;
            obj.NoiDung = a.NoiDung;
            obj.NgayChi = DateTime.Parse(a.NgayChi);
            obj.SoTienChi = a.SoTienChi;

           // vbdq.PHIEUCHIs.InsertOnSubmit(b);
            vbdq.SubmitChanges();
        }
        public void PhieuChi_them(PhieuChi_DTO a)
        {
            PHIEUCHI b = new PHIEUCHI();
            b.SoPhieuChi = a.SoPhieuChi ;
            b.NoiDung = a.NoiDung ;
            b.SoTienChi = a.SoTienChi;
            b.NgayChi = DateTime.Parse(a.NgayChi);

            vbdq.PHIEUCHIs.InsertOnSubmit(b);
           vbdq.SubmitChanges();
        }
        public void PhieuChi_del(String sophieuchi)
        {
            PHIEUCHI chi = (from phieuchi in vbdq.PHIEUCHIs select phieuchi).Single(n => n.SoPhieuChi.CompareTo(sophieuchi) == 0);
            vbdq.PHIEUCHIs.DeleteOnSubmit(chi);
            vbdq.SubmitChanges();
        }
        public int LayMaPhieuChi()
        {
            int MyQuery = (from pc in vbdq.PHIEUCHIs
                           select pc.SoPhieuChi).ToList().Last();
            return MyQuery;
        }
    }
}
