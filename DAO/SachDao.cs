using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SachDao
    {
        public string MaSach { set; get; }

        public string Tensach { set; get; }

        public string TenTG { set; get; }

        public int  Soluong { set; get; }

        public string Namxuatban { set; get; }

        public SachDao(string _Masach, string ten, string tentg,int soluong, string Namxuatban)
        {
            this.MaSach = _Masach;
            this.Tensach = ten;
            this.TenTG = tentg;
            this.Soluong = soluong;
            this.Namxuatban = Namxuatban;
        }
    }
}
