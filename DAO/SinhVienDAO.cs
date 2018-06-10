using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SinhVienDAO
    {
        public string Masv { set; get; }

        public string Hoten { set; get; }

        public DateTime Ngaysinh { set; get; }

        public string Gioitinh { set; get; }

        public string Diachi { set; get; }

        public string Lop { set; get; }

        public SinhVienDAO(string _Masv,string Hoten,DateTime _Ngaysinh,string gioitinh, string _diachi,string _lop) 
        {
            this.Masv = _Masv;
            this.Hoten = Hoten;
            this.Ngaysinh = _Ngaysinh;
            this.Gioitinh = gioitinh;
            this.Diachi = _diachi;
            this.Lop = _lop;
        }
        public SinhVienDAO()
        {

        }
    }
}
