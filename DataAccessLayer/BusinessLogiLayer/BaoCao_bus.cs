using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BusinessLogiLayer
{
    public class BaoCao_bus
    {
        VBDQDataContext vbdq = new VBDQDataContext();
        public List<CTBaoCao_DTO> LayTatCa()
        {
            var MyQuery = (from bc in vbdq.CTBAOCAOs
                           join tk in vbdq.BAOCAOTONKHOs on bc.MaBaoCao equals tk.MaBaoCao
                           select new CTBaoCao_DTO
                           {

                               MaBaoCao = bc.MaBaoCao,
                               MaSP = bc.MaSP,
                               TonDau = (int)bc.TonDau,
                               SLMua = (int)bc.SLMua,
                               SLBan = (int)bc.SLBan,
                               TonCuoi = (int)bc.TonCuoi,
                               NgayLap = tk.NgayLap.ToString()
                           });
            return MyQuery.ToList();
        }
        public List<BaoCaoTonKho_DTO> LayBaoCaoTonKho()
        {
            var MyQuery = (from bc in vbdq.BAOCAOTONKHOs
                           select new BaoCaoTonKho_DTO
                           {
                               MaBaoCao = bc.MaBaoCao,
                               NgayLap = bc.NgayLap.ToString()
                           });
            return MyQuery.ToList();
        }
        public int LayMaBaoCao()
        {
            int MyQuery = (from bc in vbdq.BAOCAOTONKHOs
                           select bc.MaBaoCao).ToList().Last();
            return MyQuery;
        }
        public void CapNhat(BaoCaoTonKho_DTO a)
        {
            BAOCAOTONKHO b = new BAOCAOTONKHO();
            b.MaBaoCao = a.MaBaoCao;
            b.NgayLap = DateTime.Parse(a.NgayLap);
            vbdq.BAOCAOTONKHOs.InsertOnSubmit(b);
            vbdq.SubmitChanges();
        }
        public List<CTBaoCao_DTO> LayCTBaoCao(int a)
        {
            vbdq = new VBDQDataContext();
            BAOCAOTONKHO bctk = new BAOCAOTONKHO();
            var MyQuery = (from bc in vbdq.CTBAOCAOs
                           join tk in vbdq.BAOCAOTONKHOs on bc.MaBaoCao equals tk.MaBaoCao
                           where bc.MaBaoCao == a
                           select new CTBaoCao_DTO
                           {

                               MaBaoCao = bc.MaBaoCao,
                               MaSP = bc.MaSP,
                               TonDau = (int)bc.TonDau,
                             SLMua = (int)bc.SLMua,
                               SLBan = (int)bc.SLBan,
                              TonCuoi = (int)bc.TonCuoi,
                               NgayLap = tk.NgayLap.ToString()
                           });
            return MyQuery.ToList();
        }
       
         public int TinhTongNhap(int t, DateTime a, DateTime b)
         {
             var MyQuery = (from pn in vbdq.PHIEUNHAPs
                            from ctpn in vbdq.CTPHIEUNHAPs
                            where pn.SoPhieuNhap == ctpn.SoPhieuNhap && ctpn.MaSP == t
                            select new
                    {
                        NgayLap = pn.NgayLap,
                        MaSP = ctpn.MaSP,
                        SlNhap = ctpn.SLNhap
                    
                  });
            
             int tongnhap = 0;
              string time1 = a.ToString();
              string time2 = b.ToString(); 
             foreach(var ctphieunhap in MyQuery)
                 {
                
                 
                     if (DateTime.Compare(DateTime.Parse(time1), DateTime.Parse(ctphieunhap.NgayLap.ToString())) <= 0 && DateTime.Compare(DateTime.Parse(time2), DateTime.Parse(ctphieunhap.NgayLap.ToString())) >= 0)
                         tongnhap = tongnhap + (int)ctphieunhap.SlNhap;
                         
                 }
                
                  return tongnhap;
             }
         public int TinhTongBan(int t, DateTime a, DateTime b)
         {
             var MyQuery = (from pb in vbdq.PHIEUBANHANGs
                            from ctpb in vbdq.CTPHIEUBANs
                            where pb.SoPhieuBan == ctpb.SoPhieuBan && ctpb.MaSP == t
                            select new
                            {
                                NgayBan = pb.NgayBan,
                                MaSP = ctpb.MaSP,
                                SLBan = ctpb.SoLuong

                            });

             int tongban = 0;
           //  string time1 = a.ToString();
           //  string time2 = b.ToString();
             foreach (var ctphieuban in MyQuery)
             {
                 if( a <= ctphieuban.NgayBan && ctphieuban.NgayBan <= b)
              //   if (DateTime.Compare(a, DateTime.Parse( ctphieuban.NgayBan)) < 0) //&& DateTime.Compare(DateTime.Parse(time2), DateTime.Parse(ctphieuban.NgayLap.ToString())) > 0)
                     tongban = tongban + (int)ctphieuban.SLBan;

             }

             return tongban;
         }
         

    
            
        public void InsertCTBaoCao( int t, DateTime a1, DateTime a2)
        {
           // SanPham_DTO s = new SanPham_DTO();
            foreach (var s in vbdq.SANPHAMs )
            {
                CTBAOCAO b = new CTBAOCAO();

                b.MaBaoCao = t;
                b.MaSP = s.MaSP;
                b.TonDau = s.SoLuongTon;
                b.SLMua = TinhTongNhap(s.MaSP, a1 , a2);
                b.SLBan = TinhTongBan(s.MaSP, a1, a2);
                b.TonCuoi = b.TonDau + b.SLMua - b.SLBan;
                vbdq.CTBAOCAOs.InsertOnSubmit(b);
                vbdq.SubmitChanges();

            }
        }
        public List<BaoCaoTonKho_DTO>  LayMaNgayBC(int m)
        {
           
            var MyQuery = (from bc in vbdq.BAOCAOTONKHOs
                           where bc.MaBaoCao == m
                           select new BaoCaoTonKho_DTO
                           {

                               MaBaoCao = m,
                               NgayLap = bc.NgayLap.ToString()
                           });
            return MyQuery.ToList();
        }
}
 }
        
  

