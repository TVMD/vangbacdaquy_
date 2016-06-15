using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogiLayer
{
    public class LoaiSP_BUS
    {
        VBDQDataContext DB = new VBDQDataContext();
        public List<LoaiSP_DTO> LayLoaiSP()
        {

            var MyQuery = (from pm in DB.LOAISPs
                           join dv in DB.DONVITINHs
                           on pm.MaDonViTinh equals dv.MaDonViTinh
                           select new LoaiSP_DTO
                           {
                               MaLoaiSP = pm.MaLoaiSP,
                               TenLoaiSP = pm.TenLoaiSP,
                               MaDonViTinh=pm.MaDonViTinh.Value,
                               PhanTramLoiNhuan=(float)pm.PhanTramLoiNhuan.Value,
                               TenDonVi=dv.TenDonViTinh
                           });

            return MyQuery.ToList();
        }
        public void XoaLoaiSP(int maloaisp)
        {
            var MyQuery = (from p in DB.LOAISPs
                           where p.MaLoaiSP == maloaisp
                           select p).FirstOrDefault();
            DB.LOAISPs.DeleteOnSubmit(MyQuery);
            DB.SubmitChanges();
        }
        public LoaiSP_DTO Lay1LSP(int maloaisp)
        {

            var MyQuery = (from pm in DB.LOAISPs
                           where pm.MaLoaiSP == maloaisp
                           select new LoaiSP_DTO
                           {
                               MaLoaiSP = pm.MaLoaiSP,
                               TenLoaiSP = pm.TenLoaiSP,
                               MaDonViTinh = pm.MaDonViTinh.Value,
                               PhanTramLoiNhuan = (float)pm.PhanTramLoiNhuan.Value
                           }).FirstOrDefault();

            return MyQuery;
        }
        public void ThemLoaiSP(LoaiSP_DTO a)
        {
            LOAISP b = new LOAISP();
            b.TenLoaiSP = a.TenLoaiSP;
            b.MaDonViTinh = a.MaDonViTinh;
            b.PhanTramLoiNhuan = a.PhanTramLoiNhuan;
            DB.LOAISPs.InsertOnSubmit(b);
            DB.SubmitChanges();
        }
        public void CapNhapLoaiSP(LoaiSP_DTO a)
        {
            var b = DB.LOAISPs.Single(x => x.MaLoaiSP == a.MaLoaiSP);
            //b.TenKieuSP = a.TenKieuSP;
            b.TenLoaiSP = a.TenLoaiSP;
            b.MaDonViTinh = a.MaDonViTinh;
            b.PhanTramLoiNhuan = a.PhanTramLoiNhuan;
            DB.SubmitChanges();
        }
        public int CheckTenLoaiSP(string name)
        {
            var MyQuery = DB.LOAISPs.Where(x => x.TenLoaiSP == name);
            int count = MyQuery.Count();
            return count;
        }
    }
}
