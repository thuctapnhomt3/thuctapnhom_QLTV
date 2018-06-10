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
    public class DALSinhVien : ClassConnection
    {
        Ketnoi_Duc conn = new Ketnoi_Duc();
        public DataTable GetDataProc()
        {
            return conn.GetDataProc("SinhVien_SelectAll", null);
        }
        public int InsertData(SinhVienDAO MA)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@masv",MA.Masv),
                new SqlParameter("@hoten",MA.Hoten),
                new SqlParameter("@gioitinh",MA.Gioitinh),
                new SqlParameter("@ngaysinh",MA.Ngaysinh),
                new SqlParameter("@diachi", MA.Diachi),
                new SqlParameter("@lop", MA.Lop),
            };
            return conn.ExcuteSQL("Insert_SinhVien", para);
        }
        public int UpdateData(SinhVienDAO MA)
        {
            SqlParameter[] para =
              {
              new SqlParameter("@masv",MA.Masv),
                new SqlParameter("@hoten",MA.Hoten),
                new SqlParameter("@gioitinh",MA.Gioitinh),
                new SqlParameter("@ngaysinh",MA.Ngaysinh),
                new SqlParameter("@diachi", MA.Diachi),
                new SqlParameter("@lop", MA.Lop),
            };
            return conn.ExcuteSQL("Update_SinhVien", para);
        }
        public int DeleteData(string Ma)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@masinh",Ma),
            };  
            return conn.ExcuteSQL("DELETE_SinhVien", para);
        }
        public string TangMa1()
        {
            return conn.TangMa("Select * From sinhvien", "SV");
        }
        public DataTable TimKiemPYC(string strTimKiem)
        {
            return conn.GetDataStr(strTimKiem);
        }
    }
}
