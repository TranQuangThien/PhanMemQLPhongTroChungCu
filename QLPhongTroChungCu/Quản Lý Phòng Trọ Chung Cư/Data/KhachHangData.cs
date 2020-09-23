using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using System.Data;
using System.Data.SqlClient;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Data
{
    class KhachHangData
    {

        KhachHang khachhang = new KhachHang();
        DataProvider cls = new DataProvider();

        public DataSet LayDLMotDong(string makh)
        {
            SqlCommand cmd = new SqlCommand("select * from KhachHang where MaKH=@makh");

            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;

            return cls.LayDuLieu(cmd);
        }

        public DataSet LayDSKhachHang()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from KhachHang ");
            return cls.LayDuLieu(sqlcmd);
        }

        public DataSet LayDSTK(string tukhoa, string tieuchi)
        {
            string sql = "select * from KhachHang where ";

            switch (tieuchi)
            {
                case "hoTen":
                    sql += "HoTenKH like N'%" + tukhoa + "%'";
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

        public int Xoa(string makh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from KhachHang where MaKH=@makh";
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = makh;
            return cls.CapNhatDL(cmd);
        }

        public int Them(KhachHang kh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into KhachHang ( MaKH, HoTenKH, NgaySinh, GioiTinh, SDT, DiaChi, CMND, GhiChu) values(@matk,@hoten,@ngsinh,@gioitinh,@sdt,@dchi,@cmnd,@ghichu)";

            cmd.Parameters.Add("matk", SqlDbType.NChar).Value = kh.MaKH;
            cmd.Parameters.Add("hoten", SqlDbType.NVarChar).Value = kh.TenKH;
            cmd.Parameters.Add("ngsinh", SqlDbType.Date).Value = kh.NgaySinh;
            cmd.Parameters.Add("gioitinh", SqlDbType.Bit).Value = kh.GioiTinh;
            cmd.Parameters.Add("sdt", SqlDbType.VarChar).Value = kh.SDT;
            cmd.Parameters.Add("dchi", SqlDbType.NVarChar).Value = kh.DiaChi;
            cmd.Parameters.Add("cmnd", SqlDbType.NChar).Value = kh.CMND;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = kh.GhiChu;
            return cls.CapNhatDL(cmd);
        }

        public int Luu(KhachHang kh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update KhachHang set HoTenKH=@ten,GioiTinh=@gioitinh, SDT=@sdt, NgaySinh=@ngsinh, DiaChi=@diachi,CMND=@cmnd, GhiChu=@ghichu where MaKH=@makh";

            cmd.Parameters.Add("ten", SqlDbType.NVarChar).Value = kh.TenKH;
            cmd.Parameters.Add("gioitinh", SqlDbType.Bit).Value = kh.GioiTinh;
            cmd.Parameters.Add("sdt", SqlDbType.NChar).Value = kh.SDT;
            cmd.Parameters.Add("ngsinh", SqlDbType.Date).Value = kh.NgaySinh;
            cmd.Parameters.Add("diachi", SqlDbType.NVarChar).Value = kh.DiaChi;
            cmd.Parameters.Add("cmnd", SqlDbType.VarChar).Value = kh.CMND;
            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = kh.MaKH;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = kh.GhiChu;
            return cls.CapNhatDL(cmd);
        }

        public bool KiemTra(string kh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from KhachHang where MaKH=@makh";

            cmd.Parameters.Add("makh", SqlDbType.VarChar).Value = kh;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }

    }
}
