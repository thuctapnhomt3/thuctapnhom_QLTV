using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietPhieuMuon
    {
        public string MaPM { set; get; }

        public string MaSach { set; get; }

        public int SoLuong { set; get; }

        public ChiTietPhieuMuon(string maphieu,string masach,int soluong)
        {
            this.MaPM = maphieu;
            this.MaSach = masach;
            this.SoLuong = soluong;
        }
        public ChiTietPhieuMuon()
        {

        }
    }
}
