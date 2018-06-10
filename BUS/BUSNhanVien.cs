using DAL;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUSNhanVien
    {
        DALNhanVien dal_nv = new DALNhanVien();
        public DataTable GetData()
        {
            return dal_nv.GetData();
        }
        public bool Them(NhanVien nv)
        {
            return dal_nv.Them(nv);
        }
        public bool Sua(NhanVien nv)
        {
            return dal_nv.Sua(nv);
        }
        public Exception GetEx()
        {
            return dal_nv.GetEx();
        }
        public void SetEx(Exception ex)
        {

        }
        public bool Xoa(string ma)
        {
            return dal_nv.Xoa(ma);
        }
        public DataTable GetDataTimKiem(string chuoi)
        {
            return dal_nv.GetDataTimKiem(chuoi);
        }

    }
}
