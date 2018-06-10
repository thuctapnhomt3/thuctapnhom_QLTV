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
    public class BusSinhVien
    {
        DALSinhVien da = new DALSinhVien();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public int InsertData(SinhVienDAO MA)
        {
            return da.InsertData(MA);
        }
        public int UpdateData(SinhVienDAO BP)
        {
            return da.UpdateData(BP);
        }
        public int DeleteData(string Ma)
        {
            return da.DeleteData(Ma);
        }
        public string TangMa()
        {
            return da.TangMa1();
        }
        public DataTable TimKiemPYC(string strTimKiem)
        {
            return da.TimKiemPYC(strTimKiem);
        }

    }
}
