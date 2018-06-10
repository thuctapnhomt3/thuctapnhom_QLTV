using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALPhieuTra:ClassConnection
    {
        public DataTable GetData()
        {
            return (DataTable)ShowDataInGridView("SELECT  MAPT,TENSV, PHIEUTRA.MASV, NGAYTRA,GHICHU FROM dbo.PHIEUTRA, dbo.SINHVIEN WHERE SINHVIEN.MASV=PHIEUTRA.MASV");
        }
        public bool Them(PhieuTraDao entity)
        {
            try
            {
                string query = @"INSERT INTO dbo.phieutra(  MAPT,MaSV, NGAYTRA,GHICHU )
                                VALUES  ( '" + entity.MaPhieu + "','" + entity.Masv + "','" + entity.NgayTra + "', N'" + entity.Ghichu + "')";
                OpenConection();
                ExecuteQueries(query);
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                SetEx(ex);
                return false;
            }
        }
        public bool Sua(PhieuTraDao entity)
        {
            try
            {
                string query = @"UPDATE dbo.phieutra set manv='" + entity.Masv + "', ngaytra=N'" + entity.NgayTra + "',Ghichu=N'" + entity.Ghichu + "' WHERE MaPT='" + entity.MaPhieu + "'";
                OpenConection();
                ExecuteQueries(query);
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                SetEx(ex);
                return false;
            }
        }
        public bool Xoa(String ma)
        {
            try
            {
              
                OpenConection();
                ExecuteQueries(@"DELETE dbo.phieutra WHERE mapt ='" + ma + "'");
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                SetEx(ex);
                return false;
            }
        }
        public DataTable GetDataTimKiem(string chuoi)
        {
            //try
            //{
            //    int luong = int.Parse(chuoi);
            //    string query = @"select * from NhanVien where luong like '%" + luong + "%'";
            //    return (DataTable)ShowDataInGridView(query);
            //}
            //catch
            //{
            //try
            //{
            //    DateTime dt = DateTime.Parse(chuoi);
            //    string query = @"select * from NhanVien where ngaysinh like '%" + dt + "%'";
            //    return (DataTable)ShowDataInGridView(query);
            //}
            //    catch
            //{
            try
            {
                //string query = @"select * from NhanVien where (manv like '%" + chuoi + "%' or ten like N'%" + chuoi + "%' or maphong like '%" + chuoi + "%' or gioitinh like N'%" + chuoi + "%' or luong like '%" + chuoi + "%'or diachi like N'%" + chuoi+ "% or ngaysinh like '%" + DateTime.Parse(chuoi) +"')";
                string query = @"select * from phieutra where (mapt like '%" + chuoi + "%') or (masv like N'%" + chuoi + "%') or (ghichu like N'%" + chuoi + "%')";
                return (DataTable)ShowDataInGridView(query);
            }
            catch (Exception ex)
            {
                SetEx(ex);
                return null;
            }
            // }

        }
    }
}
