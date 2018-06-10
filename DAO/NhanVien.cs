using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVien
    {
        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private DateTime ngaysinh;

        public DateTime NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        private string gioitinh;

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private int luong;

        public int Luong
        {
            get { return luong; }
            set { luong = value; }
        }
        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public NhanVien(string ma, string ten, DateTime ngaysinh,string gioitinh, int luong, string diadiem)
        {
            this.manv = ma;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.luong = luong;
            this.diachi = diadiem;
        }
    }
}
