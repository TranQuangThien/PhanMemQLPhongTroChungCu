using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Data
{
    class TaiKhoanData
    {

        TaiKhoan taikhoan = new TaiKhoan();
        DataProvider cls = new DataProvider();

        public DataSet LayDLMotDong(string ten)
        {
            SqlCommand cmd = new SqlCommand("select * from TaiKhoan where UserName=@tendangnhap");

            cmd.Parameters.Add("tendangnhap", SqlDbType.VarChar).Value = ten;

            return cls.LayDuLieu(cmd);
        }

        public DataSet LayDSTaiKhoan()
        {
            SqlCommand sqlcmd = new SqlCommand("select MaTK, HoTenTK, NgaySinh, GioiTinh , SDT, DiaChi, CMND, MaQuyen, UserName from TaiKhoan ");
            return cls.LayDuLieu(sqlcmd);
        }

        public DataSet LayDSTK()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from TaiKhoan");
            return cls.LayDuLieu(sqlcmd);
        }

        public DataSet LayDSTK(string tukhoa, string tieuchi)
        {
            string sql = "select * from TaiKhoan where ";

            switch (tieuchi)
            {
                case "hoTen":
                    sql += "HoTenTK like N'%" + tukhoa + "%'";
                    break;
                case "cmnd":
                    sql += "CMND like '%" + tukhoa + "%'";
                    break;
                default:
                    sql += "SDT like '%" + tukhoa + "%'";
                    break;
            }
            SqlCommand sqlcmd = new SqlCommand(sql);
            return cls.LayDuLieu(sqlcmd);
        }

        public int Xoa(string matk)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from TaiKhoan where MaTK=@matk";
            cmd.Parameters.Add("matk", SqlDbType.VarChar).Value = matk;
            return cls.CapNhatDL(cmd);
        }

        public int Them(TaiKhoan tk)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into TaiKhoan ( MaTK, HoTenTK, NgaySinh, GioiTinh, SDT, DiaChi, CMND, MaQuyen, UserName, PassWord) values(@matk,@hoten,@ngsinh,@gioitinh,@sdt,@dchi,@cmnd,@maquyen,@username,@password)";

            cmd.Parameters.Add("matk", SqlDbType.NChar).Value = tk.MaTK;
            cmd.Parameters.Add("hoten", SqlDbType.NVarChar).Value = tk.HoTen;
            cmd.Parameters.Add("ngsinh", SqlDbType.Date).Value = tk.NgaySinh;
            cmd.Parameters.Add("gioitinh", SqlDbType.Bit).Value = tk.Gioitinh;
            cmd.Parameters.Add("sdt", SqlDbType.VarChar).Value = tk.SDT;
            cmd.Parameters.Add("dchi", SqlDbType.NVarChar).Value = tk.Diachi;
            cmd.Parameters.Add("cmnd", SqlDbType.NChar).Value = tk.Cmnd;
            cmd.Parameters.Add("maquyen", SqlDbType.Bit).Value = tk.Maquyen;
            cmd.Parameters.Add("username", SqlDbType.NVarChar).Value = tk.Username;
            cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = tk.Password;

            return cls.CapNhatDL(cmd);
        }

        public int Luu(TaiKhoan gv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update TaiKhoan set HoTenTK=@ten,GioiTinh=@gioitinh, SDT=@sdt, NgaySinh=@ngsinh, DiaChi=@diachi,CMND=@cmnd, MaQuyen=@maquyen where MaTK=@matk";

            cmd.Parameters.Add("ten", SqlDbType.NVarChar).Value = gv.HoTen;
            cmd.Parameters.Add("gioitinh", SqlDbType.Bit).Value = gv.Gioitinh;
            cmd.Parameters.Add("sdt", SqlDbType.NChar).Value = gv.SDT;
            cmd.Parameters.Add("ngsinh", SqlDbType.Date).Value = gv.NgaySinh;
            cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = gv.Diachi;
            cmd.Parameters.Add("cmnd", SqlDbType.VarChar).Value = gv.Cmnd;
            cmd.Parameters.Add("matk", SqlDbType.VarChar).Value = gv.MaTK;
            cmd.Parameters.Add("maquyen", SqlDbType.Bit).Value = gv.Maquyen;


            return cls.CapNhatDL(cmd);
        }

        public bool KiemTra(string tk)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from TaiKhoan where MaTK=@matk";

            cmd.Parameters.Add("matk", SqlDbType.VarChar).Value = tk;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
        public bool KiemTraUserName(string tk)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from TaiKhoan where UserName=@username";

            cmd.Parameters.Add("username", SqlDbType.VarChar).Value = tk;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }
    }
 }
