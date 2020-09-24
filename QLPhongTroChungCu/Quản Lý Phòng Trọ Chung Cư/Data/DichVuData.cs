using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Data
{
    class DichVuData
    {

        DataProvider cls = new DataProvider();

        public int GetID()
        {
            string select = "SELECT MaDichVu ",
                from = "FROM DichVu ",
                orderBy = "ORDER BY MaDichVu DESC";

            SqlCommand cmd = new SqlCommand(select + from + orderBy);

            return cls.GetID(cmd);
        }

        //Lấy danh sách khu vực trong một dòng
        public DataSet LayDLMotDong(string makv)
        {
            SqlCommand cmd = new SqlCommand("select * from DichVu where MaDichVu=@madv");
            cmd.Parameters.Add("madv", SqlDbType.Int).Value = makv;

            return cls.LayDuLieu(cmd);
        }


        //lấy danh sách khu vực
        public DataSet LayDSDV()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from DichVu");
            return cls.LayDuLieu(sqlcmd);
        }

        //Chức năng xóa
        public int Xoa(string madv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from DichVu where MaDichVu=@madv";
            cmd.Parameters.Add("madv", SqlDbType.Int).Value = madv;
            return cls.CapNhatDL(cmd);
        }

        //Chức năng thêm
        public int Them(DichVu dv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into DichVu(MaDichVu, TenDichVu, DonGia, MaLoaiDV )values(@madv,@tendv,@dongia,@maloaidv)";

            cmd.Parameters.Add("madv", SqlDbType.Int).Value = dv.Madv;
            cmd.Parameters.Add("tendv", SqlDbType.NVarChar).Value = dv.Tendv;
            cmd.Parameters.Add("dongia", SqlDbType.Int).Value = dv.Dongia;
            cmd.Parameters.Add("maloaidv", SqlDbType.NChar).Value = dv.Maloaidv;

            return cls.CapNhatDL(cmd);
        }

        //Chức năng lưu
        public int Luu(DichVu dv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update DichVu set TenDichVu=@tendv,DonGia=@dongia,MaLoaiDV=@maloaidv where MaDichVu=@madv";
            cmd.Parameters.Add("tendv", SqlDbType.NVarChar).Value = dv.Tendv;
            cmd.Parameters.Add("dongia", SqlDbType.Int).Value = dv.Dongia;
            cmd.Parameters.Add("madv", SqlDbType.Int).Value = dv.Madv;
            cmd.Parameters.Add("maloaidv", SqlDbType.NChar).Value = dv.Maloaidv;

            return cls.CapNhatDL(cmd);
        }

    }
}
