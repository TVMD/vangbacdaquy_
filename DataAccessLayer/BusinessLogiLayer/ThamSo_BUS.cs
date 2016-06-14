using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogiLayer
{
    public class ThamSo_BUS
    {
        VBDQDataContext vbdq = new VBDQDataContext();

        public String LayNoToiDa()
        {
            var MyQuery = (from thamso in vbdq.THAMSOs
                           where thamso.TEN.CompareTo("NoToiDa") == 0
                           select new ThamSo_DTO
                           {
                               TenTS = thamso.TEN,
                               GiaTri = thamso.GIATRI
                           }).ToList().First();
            return MyQuery.GiaTri;
        }
        public String LayQuen()
        {
            var MyQuery = (from thamso in vbdq.THAMSOs
                           where thamso.TEN.CompareTo("Quen") == 0
                           select new ThamSo_DTO
                           {
                               TenTS = thamso.TEN,
                               GiaTri = thamso.GIATRI
                           }).ToList().First();
            return MyQuery.GiaTri;
        }

        public void SaveThamSo(String NoToiDa, String Quen)
        {
            var obj = vbdq.THAMSOs.Single(x => x.TEN == "NoToiDa");
            obj.GIATRI = NoToiDa;

            obj = vbdq.THAMSOs.Single(x => x.TEN == "Quen");
            obj.GIATRI = Quen;

            vbdq.SubmitChanges();
        }
    }
}
