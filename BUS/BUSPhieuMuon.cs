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
   public class BUSPhieuMuon
    {
        DALPhieuMuon da = new DALPhieuMuon();
        public DataTable GetDataProc()
        {
            return da.GetDataProc();
        }
        public int InsertData(PhieuMuonDao MA)
        {
            return da.InsertData(MA);
        }
        public int UpdateData(PhieuMuonDao BP)
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
