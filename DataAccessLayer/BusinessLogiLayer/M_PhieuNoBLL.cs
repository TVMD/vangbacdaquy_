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
    public class M_PhieuNoBLL
    {
        VBDQDataContext datacontext = new VBDQDataContext();
        public PhieuNo_DTO GetById(int sophieu)
        {
            var myquery = (from x in datacontext.PHIEUNOs.Where(p=>p.SoPhieuNo==sophieu)
                           select new PhieuNo_DTO
                           {
                               SoPhieuNo=x.SoPhieuNo,
                               SoPhieuBan=x.SoPhieuBan.Value,
                               NgayNo=x.NgayNo.ToString(),
                               NgayThanhToan=x.NgayThanhToan.ToString(),
                               SoTienTra=x.SoTienTra.Value,
                               SoTienConLai=x.SoTienConLai.Value

                           });
            return myquery.FirstOrDefault();
        }

        public BindingList<PhieuNo_DTO> SelectTop(int top)
        {

            var MyQuery = (from x in datacontext.PHIEUNOs
                           select new PhieuNo_DTO
                           {
                               SoPhieuNo=x.SoPhieuNo,
                               SoPhieuBan=x.SoPhieuBan.Value,
                               NgayNo=x.NgayNo.ToString(),
                               NgayThanhToan=x.NgayThanhToan.ToString(),
                               SoTienTra=x.SoTienTra.Value,
                               SoTienConLai=x.SoTienConLai.Value
                           });
            if (top != 0)
            {
                var r = new BindingList<PhieuNo_DTO>(MyQuery.Take(top).ToList());
                return r;
            }
            else
            {
                var r = new BindingList<PhieuNo_DTO>(MyQuery.ToList());
                return r;
            }
            
        }

        public BindingList<PhieuNo_DTO> Search(int sophieuno,int sophieuban, string tenkh,string ngayno,string ngaythanhtoan,
            decimal sotientramin,decimal sotientramax,decimal conlaimin,decimal conlaimax)
        {
            IEnumerable<MPhieuNo_SearchResult> phieuno;
            phieuno = datacontext.MPhieuNo_Search(sophieuno,sophieuban,
                                 tenkh,
                                 DateTime.Parse(ngayno), DateTime.Parse(ngaythanhtoan),
                                 sotientramin,sotientramax,
                                 conlaimin,conlaimax
                                 );
            var myquery = (from x in phieuno
                           select new PhieuNo_DTO
                               {
                                   SoPhieuNo = x.SoPhieuNo.Value,
                                   SoPhieuBan = x.SoPhieuBan.Value,
                                   NgayNo = x.NgayNo.ToString(),
                                   NgayThanhToan = x.NgayThanhToan.ToString(),
                                   SoTienTra = x.SoTienTra.Value,
                                   SoTienConLai = x.SoTienConLai.Value
                               });
            var r = new BindingList<PhieuNo_DTO>(myquery.ToList());
            return r;
        }

        public void Insert(PhieuNo_DTO x)
        {
            PHIEUNO phieuno = new PHIEUNO(){
                               SoPhieuNo=x.SoPhieuNo,
                               SoPhieuBan=x.SoPhieuBan,
                               NgayNo=DateTime.Parse(x.NgayNo),
                               NgayThanhToan=DateTime.Parse(x.NgayThanhToan),
                               SoTienTra=x.SoTienTra,
                               SoTienConLai=x.SoTienConLai
            };
            datacontext.PHIEUNOs.InsertOnSubmit(phieuno);     
            
            datacontext.SubmitChanges();
        }

        public void Update(PhieuNo_DTO x)
        {
            PHIEUNO phieuno = datacontext.PHIEUNOs.Where(p => p.SoPhieuNo == x.SoPhieuNo).FirstOrDefault();
            if (phieuno != null)
            {
                phieuno.SoPhieuNo=x.SoPhieuNo; 
                phieuno.SoPhieuBan=x.SoPhieuBan;
                phieuno.NgayNo=DateTime.Parse(x.NgayNo);
                phieuno.NgayThanhToan=DateTime.Parse(x.NgayThanhToan);
                phieuno.SoTienTra=x.SoTienTra;
                phieuno.SoTienConLai=x.SoTienConLai;  
            }

            datacontext.SubmitChanges();
        }

        public void Delete(int sophieuno)
        {
            PHIEUNO x = datacontext.PHIEUNOs.Where(p => p.SoPhieuNo == sophieuno).FirstOrDefault();
            if (x != null)
            {
                datacontext.PHIEUNOs.DeleteOnSubmit(x);
            }
            datacontext.SubmitChanges();
        }
        public void Save()
        {
            try
            {
                datacontext.SubmitChanges();
            }
            catch (Exception e)
            {
                
            }
        }
        public int GetSoPhieuNo()
        {
            int result = 0;
            var x = (from row in datacontext.PHIEUNOs
                     group row by true into r
                     select new
                     {
                         max = r.Max(z => z.SoPhieuNo)
                     }
                      );
            result = 1;
            try
            {
                result = x.ToArray()[0].max + 1;
            }
            catch (Exception) { }
            return result;
        }
    }
}
