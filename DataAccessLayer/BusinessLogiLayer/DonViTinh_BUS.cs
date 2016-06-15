using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogiLayer
{
    public class DonViTinh_BUS
    {
        VBDQDataContext DB = new VBDQDataContext();
        public List<DonViTinh_DTO> LayDVTinh()
        {

            var MyQuery = (from pm in DB.DONVITINHs
                           select new DonViTinh_DTO
                           {
                               MaDonViTinh = pm.MaDonViTinh,
                               TenDonViTinh = pm.TenDonViTinh
                           });

            return MyQuery.ToList();
        }
        public void XoaDVTinh(int madvtinh)
        {
            var MyQuery = (from p in DB.DONVITINHs
                           where p.MaDonViTinh == madvtinh
                           select p).FirstOrDefault();
            DB.DONVITINHs.DeleteOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
        public DonViTinh_DTO Lay1DV(int madvtinh)
        {

            var MyQuery = (from pm in DB.DONVITINHs
                           where pm.MaDonViTinh == madvtinh
                           select new DonViTinh_DTO
                           {
                               MaDonViTinh = pm.MaDonViTinh,
                               TenDonViTinh = pm.TenDonViTinh
                           }).FirstOrDefault();

            return MyQuery;
        }
        public void ThemDVTinh(DonViTinh_DTO a)
        {
            DONVITINH b = new DONVITINH();
            b.TenDonViTinh = a.TenDonViTinh;
            DB.DONVITINHs.InsertOnSubmit(b);
            DB.SubmitChanges();
        }
        public void CapNhapDVTinh(DonViTinh_DTO a)
        {
            var b = DB.DONVITINHs.Single(x => x.MaDonViTinh == a.MaDonViTinh);
            b.TenDonViTinh = a.TenDonViTinh;
            DB.SubmitChanges();
        }
        public int CheckDonViTinh(string name)
        {
            var MyQuery = DB.DONVITINHs.Where(x => x.TenDonViTinh == name);
            int count = MyQuery.Count();
            return count;
        }
    }
}
