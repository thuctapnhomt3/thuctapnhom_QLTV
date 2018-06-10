using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALSach : ClassConnection
    {
        public DataTable GetData()
        {
            return (DataTable)ShowDataInGridView("select * from Sach");
        }
        Ketnoi_Duc conn = new Ketnoi_Duc();

        public DataTable GetDataProc(string maphieu)
        {
            return conn.GetDataStr("SELECT * FROM Sach WHERE TENSACH NOT IN (SELECT CHITIETPHIEUMUON.MASACH FROM dbo.chitietphieumuon INNER JOIN dbo.Sach ON  sach.masach = chitietphieumuon.masach WHERE MaPM='"+maphieu+"')");
        }
        public bool Them(SachDao entity)
        {
            try
            {
                string query = @"INSERT INTO dbo.sach(  masach ,Tensach ,tentg ,soluong ,namxuatban)
                                VALUES  ( '" + entity.MaSach + "',N'" + entity.Tensach + "','" + entity.TenTG + "', N'" + entity.Soluong + "','" + entity.Namxuatban + "')";
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
        public bool Sua(SachDao entity)
        {
            try
            {
                string query = @"UPDATE dbo.Sach set Tensach=N'" + entity.Tensach + "', tentg=N'" + entity.TenTG + "', soluong=" +entity.Soluong + ",Namxuatban='" + entity.Namxuatban + "' WHERE Masach='" + entity.MaSach + "'";
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
                string query = @"DELETE dbo.CHITIETPHIEUMUON WHERE MASACH='" + ma + "'";
                OpenConection();
                ExecuteQueries(@"DELETE dbo.SACH WHERE MASACH ='" + ma + "'");
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
                string query = @"select * from sach where (masach like '%" + chuoi + "%') or (tensach like N'%" + chuoi + "%') or (namxuatban like '%" + chuoi + "%') or (tentg like N'%" + chuoi + "%')";
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
