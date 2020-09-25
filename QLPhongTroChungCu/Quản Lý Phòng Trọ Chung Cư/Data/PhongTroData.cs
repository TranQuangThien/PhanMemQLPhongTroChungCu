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
    class PhongTroData
    {

        PhongTro phongtro = new PhongTro();
        DataProvider cls = new DataProvider();

        public DataSet LayDLMotDong(string ten)
        {
            SqlCommand cmd = new SqlCommand("select * from PhongTro where MaPhongTro=@maphongtro");

            cmd.Parameters.Add("maphongtro", SqlDbType.NChar).Value = ten;

            return cls.LayDuLieu(cmd);
        }

        public DataSet LayDSPhongTro()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from PhongTro ");
            return cls.LayDuLieu(sqlcmd);
        }

        public DataSet LayDSTK()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from PhongTro");
            return cls.LayDuLieu(sqlcmd);
        }

        public DataSet LayDSTK(string tukhoa, string tieuchi)
        {
            string sql = "select * from PhongTro where ";

            switch (tieuchi)
            {
                case "makhuvuc":
                    sql += "MaKV like '%" + tukhoa + "%'";
                    break;
                case "chuathue":
                    sql += "MaTTThue = 1" ;
                    break;
                default:
                    sql += "MaTTThue = 2";
                    break;
            }
            SqlCommand sqlcmd = new SqlCommand(sql);
            return cls.LayDuLieu(sqlcmd);
        }

        public int Xoa(string matk)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from PhongTro where MaPhongTro=@maphongtro";
            cmd.Parameters.Add("maphongtro", SqlDbType.VarChar).Value = matk;
            return cls.CapNhatDL(cmd);
        }

        public int Them(PhongTro tro)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into PhongTro (MaPhongTro, MaKV, MaDay, MaTang, MaTrangThai, TenPhongTro, GhiChu, MaTTThue ) values(@maphong, @makv, @maday, @matang, @matt, @tenphong, @ghichu, @mattthue)";

            cmd.Parameters.Add("maphong", SqlDbType.NChar).Value = tro.Maphongtro;
            cmd.Parameters.Add("makv", SqlDbType.NChar).Value = tro.Makv;
            cmd.Parameters.Add("maday", SqlDbType.NChar).Value = tro.Maday;
            cmd.Parameters.Add("matang", SqlDbType.NChar).Value = tro.Matang;
            cmd.Parameters.Add("matt", SqlDbType.Int).Value = tro.Matt;
            cmd.Parameters.Add("tenphong", SqlDbType.NVarChar).Value = tro.Tenphongtro;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = tro.Ghichu;
            cmd.Parameters.Add("mattthue", SqlDbType.Int).Value = tro.MattThue;
            

            return cls.CapNhatDL(cmd);
        }

        public int Luu(PhongTro tro)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update PhongTro set MaPhongTro=@maphong, MaKV=@makv, MaDay=@maday, MaTang=@matang, MaTrangThai=@matt, TenPhongTro=@tenphong, GhiChu=@ghichu, MaTTThue=@mattthue";

            cmd.Parameters.Add("maphong", SqlDbType.NChar).Value = tro.Maphongtro;
            cmd.Parameters.Add("makv", SqlDbType.NChar).Value = tro.Makv;
            cmd.Parameters.Add("maday", SqlDbType.NChar).Value = tro.Maday;
            cmd.Parameters.Add("matang", SqlDbType.NChar).Value = tro.Matang;
            cmd.Parameters.Add("matt", SqlDbType.Int).Value = tro.Matt;
            cmd.Parameters.Add("tenphong", SqlDbType.NVarChar).Value = tro.Tenphongtro;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = tro.Ghichu;
            cmd.Parameters.Add("mattthue", SqlDbType.Int).Value = tro.MattThue;


            return cls.CapNhatDL(cmd);
        }

        public bool KiemTra(string tro)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from PhongTro where TenPhongTro=@tenphongtro";

            cmd.Parameters.Add("tenphongtro", SqlDbType.NVarChar).Value = tro;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }

    }
}
