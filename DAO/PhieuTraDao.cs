using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhieuTraDao
    {
        public string MaPhieu { set; get; }

        public string Masv { set; get; }

        public DateTime NgayTra { set; get; }

        public string Tinhtrangsach { set; get; }

        public string Ghichu { set; get; }

        public PhieuTraDao(string maphieu,string masv,DateTime ngaytra,string ghichu)
        {
            this.MaPhieu = maphieu;
            this.Masv = masv;
            this.NgayTra = ngaytra;  
            this.Ghichu = ghichu;
        }
    }
}
