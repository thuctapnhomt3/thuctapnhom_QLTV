using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhieuMuonDao
    {
        public string MaPM { set; get; }

        public string MaNV { set; get; }

        public string MaSV { set; get; }

        public DateTime NgayMuon { set; get; }

        public DateTime NgayTra { set; get; }
        
        public string Ghichu { set; get; }

        public string TENSV { set; get; }

        public PhieuMuonDao()
        {
            MaPM = "";
            MaNV = "";
            MaSV = "";
            NgayMuon = DateTime.Parse("01/01/2017");
            NgayTra = DateTime.Parse("01/01/2017");
            TENSV = "";
            Ghichu = "";
        }
        public PhieuMuonDao( string maphieu,string masv,string manv,DateTime ngaymuon,DateTime ngaytra,string ghichu, string tensv)
        {
            this.MaPM = maphieu;
            this.MaNV = manv;
            this.MaSV = masv;
            this.NgayMuon = ngaymuon;
            this.NgayTra = ngaytra;
            this.Ghichu = ghichu;
            this.TENSV = tensv;
        }
             
    }
}
