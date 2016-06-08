using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
using System.ComponentModel;

namespace BusinessLogiLayer
{
    public class M_ThamSoBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        
        public string Get(string tenthamso)
        {
            THAMSO ts = datacontext.THAMSOs.Where(p => p.TEN== tenthamso).FirstOrDefault();
            if (ts != null)
            {
                return ts.GIATRI;
            }
            else
                return "";
        }

        public int Set(string tenthamso,string giatri)
        {
            THAMSO ts = datacontext.THAMSOs.Where(p => p.TEN == tenthamso).FirstOrDefault();
            if (ts != null)
            {
                ts.GIATRI = giatri;
                datacontext.SubmitChanges();
                return 0; // tìm thấy
            }
            else
            {
                return 1; // k tìm thấy tham số
            }
        }

        public void Insert(string tenthamso, string kieu,string giatri)
        {
            THAMSO ts = new THAMSO()
            {
                TEN = tenthamso,
                KIEU = kieu,
                GIATRI = giatri
            };
            datacontext.THAMSOs.InsertOnSubmit(ts);
            datacontext.SubmitChanges();
        }

        public void Delete(string tenthamso, string giatri)
        {
            THAMSO ts = datacontext.THAMSOs.Where(p => p.TEN == tenthamso).FirstOrDefault();
            if (ts != null)
            {
                datacontext.THAMSOs.DeleteOnSubmit(ts);
                datacontext.SubmitChanges();
            }
        }

    }
}
