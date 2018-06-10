using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALNhanVien : ClassConnection
    {
        public DataTable GetData()
        {
            return (DataTable)ShowDataInGridView("select * from NhanVien");
        }
        public bool Them(NhanVien nv)
        {
            try
            {
                string query = @"INSERT INTO dbo.nhanvien(  MaNV ,TenNV ,NgaySinh ,GioiTinh ,Luong ,DiaChi)
                                VALUES  ( '" + nv.MaNV + "',N'" + nv.Ten + "','" + nv.NgaySinh + "', N'" + nv.GioiTinh + "','" + nv.Luong + "',N'" + nv.DiaChi + "')";
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
        public bool Sua(NhanVien nv)
        {
            try
            {
                string query = @"UPDATE dbo.NhanVien set TENNV=N'"+nv.Ten+"', NGAYSINH='"+nv.NgaySinh+"', GIOITINH=N'"+nv.GioiTinh+"',DIACHI=N'"+nv.DiaChi+"',LUONG="+nv.Luong+" WHERE MANV='"+nv.MaNV+"'";
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
                string query = @"Delete from NhanVien where manv='" + ma + "'";
                OpenConection();
                ExecuteQueries(@"DELETE FROM PhieuMuon WHERE manv = '" + ma + "'");
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
                string query = @"select * from NhanVien where (manv like '%" + chuoi + "%') or (tennv like N'%" + chuoi + "%') or (gioitinh like N'%" + chuoi + "%') or (diachi like N'%"+chuoi+"%')";
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
