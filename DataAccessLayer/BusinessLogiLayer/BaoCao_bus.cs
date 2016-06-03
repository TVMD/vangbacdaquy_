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
            var MyQuery = (from bc in vbdq.CTBAOCAOs join tk in vbdq.BAOCAOTONKHOs on bc.MaBaoCao equals tk.MaBaoCao
                           select new CTBaoCao_DTO
                           {
                              
                               MaBaoCao =bc.MaBaoCao,
                               MaSP = bc.MaSP,
                               TonDau =(int) bc.TonDau,
                               SLMua = (int) bc.SLMua,
                               SLBan = (int) bc.SLBan,
                               TonCuoi = (int) bc.TonCuoi,
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
            b.NgayLap = DateTime.Parse( a.NgayLap);
            vbdq.BAOCAOTONKHOs.InsertOnSubmit(b);
            vbdq.SubmitChanges();
        }
       
    }
}
