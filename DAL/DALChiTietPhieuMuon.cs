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
    public class DALChiTietPhieuMuon
    {
        Ketnoi_Duc conn = new Ketnoi_Duc();
        public DataTable DataCTYC(string strCTYC)
        {
            return conn.GetDataStr(strCTYC);
        }
        public int InsertDataCT(ChiTietPhieuMuon CTPYC)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@maphieu",CTPYC.MaPM),
                new SqlParameter("@masach",CTPYC.MaSach),
                new SqlParameter("@soluong",CTPYC.SoLuong),
            };
            return conn.ExcuteSQL("ThemCTPM", para);
        }
        public int UpdateDataCT(ChiTietPhieuMuon CTPYC)
        {
            SqlParameter[] para =
           {
                 new SqlParameter("@maphieu",CTPYC.MaPM),
                new SqlParameter("@masach",CTPYC.MaSach),
                new SqlParameter("@soluong",CTPYC.SoLuong),
            };
            return conn.ExcuteSQL("SuaCTPM", para);
        }
        public int DeleteDataCT(string IDMP, string IDMM)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@maphieu",IDMP),
                new SqlParameter("@masach",IDMM)

        };
            return conn.ExcuteSQL("XoaCTPM", para);
        }
    }
}
