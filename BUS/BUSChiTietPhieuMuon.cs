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
    public class BUSChiTietPhieuMuon
    {
        DALChiTietPhieuMuon da = new DALChiTietPhieuMuon();
        public DataTable GetDataProc(string sql)
        {
            return da.DataCTYC(sql);
        }
        public int InsertData(ChiTietPhieuMuon MA)
        {
            return da.InsertDataCT(MA);
        }
        public int UpdateData(ChiTietPhieuMuon BP)
        {
            return da.UpdateDataCT(BP);
        }
        public int DeleteData(string MaPhieu,string Masach )
        {
            return da.DeleteDataCT(MaPhieu,Masach);
        }
    }
}
