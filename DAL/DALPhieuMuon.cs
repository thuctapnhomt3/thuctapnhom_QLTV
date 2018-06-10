using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALPhieuMuon
    {
        Ketnoi_Duc conn = new Ketnoi_Duc();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("PhieuMuon_All", null);
        }
        public int InsertData(PhieuMuonDao MA)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@maphieu",MA.MaPM),
                new SqlParameter("@manv",MA.MaNV),
                new SqlParameter("@masv",MA.MaSV),
                new SqlParameter("@ngaytao",MA.NgayMuon),
                new SqlParameter("@ngaytra", MA.NgayTra),
                new SqlParameter("@ghichu", MA.Ghichu),
            };
            return conn.ExcuteSQL("Insert_Phieumuon", para);
        }
        public int UpdateData(PhieuMuonDao MA)
        {
            SqlParameter[] para =
              {
               new SqlParameter("@maphieu",MA.MaPM),
                new SqlParameter("@manv",MA.MaNV),
                new SqlParameter("@masv",MA.MaSV),
                new SqlParameter("@ngaytao",MA.NgayMuon),
                new SqlParameter("@ngaytra", MA.NgayTra),
                new SqlParameter("@ghichu", MA.Ghichu),
            };
            return conn.ExcuteSQL("Update_Phieumuon", para);
        }
        public int DeleteData(string Ma)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaPhieu",Ma)
        };
            return conn.ExcuteSQL("DELETE_PhieuMuon", para);
        }
        public string TangMa1()
        {
            return conn.TangMa("Select * From Phieumuon", "PN");
        }
        public DataTable TimKiemPYC(string strTimKiem)
        {
            return conn.GetDataStr(strTimKiem);
        }
    }
}
