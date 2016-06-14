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
        public string LayMaPhieuChi()
        {
            
                var MyQuery = vbdq.PHIEUCHIs.
                         OrderBy(o => o.SoPhieuChi).ToList().LastOrDefault();
            if(MyQuery != null)
                return MyQuery.SoPhieuChi.ToString();
            else
                return "0";
              
        }


        public List<PhieuChi_DTO> Search(PhieuChi_DTO phieu)
        {
            //DateTime t1 = phieugc.NgayLap;
            DateTime t1;
            DateTime.TryParse(phieu.NgayChi, out t1);
            var list = (from phieuchi in vbdq.PHIEUCHIs
                        where (phieuchi.SoPhieuChi == phieu.SoPhieuChi || phieu.SoPhieuChi == 0) &&
                             (phieu.NgayChi.Contains(" ") || phieuchi.NgayChi == t1) &&
                             (phieuchi.SoTienChi == phieu.SoTienChi || phieu.SoTienChi == 0) &&
                             (phieuchi.NoiDung == phieu.NoiDung || phieu.NoiDung == (" ") )
                        select new PhieuChi_DTO
                        {
                            SoPhieuChi = phieuchi.SoPhieuChi,
                            NgayChi = phieuchi.NgayChi.ToString(),
                            SoTienChi = Decimal.Parse(phieuchi.SoTienChi.ToString()),
                            NoiDung = phieuchi.NoiDung
                        });
            return list.ToList();

        }
        
    }
}
