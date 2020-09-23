using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Data
{
    class KhuVucData
    {

        
        DataProvider cls = new DataProvider();

        //Lấy danh sách khu vực trong một dòng
        public DataSet LayDLMotDong(string makv)
        {
            SqlCommand cmd = new SqlCommand("select * from KhuVuc where MaKV=@makv");
            cmd.Parameters.Add("makv", SqlDbType.VarChar).Value = makv;

            return cls.LayDuLieu(cmd);
        }

       
        //lấy danh sách khu vực
        public DataSet LayDSKV()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from KhuVuc");
            return cls.LayDuLieu(sqlcmd);
        }

        //Chức năng xóa
        public int Xoa(string makv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from KhuVuc where MaKV=@makv";
            cmd.Parameters.Add("makv", SqlDbType.VarChar).Value = makv;
            return cls.CapNhatDL(cmd);
        }

        //Chức năng thêm
        public int Them(KhuVuc kv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into KhuVuc(MaKV, TenKhuVuc, DiaChi, SoPhong, SoDay, SoTang, MaTK, MaTrangThai, GhiChu)values(@makv,@tenkv,@dchi,@sophong,@soday,@sotang,@matk,@matt,@ghichu)";

            cmd.Parameters.Add("makv", SqlDbType.NChar).Value = kv.Makv;
            cmd.Parameters.Add("tenkv", SqlDbType.NVarChar).Value = kv.Tenkv;
            cmd.Parameters.Add("dchi", SqlDbType.NVarChar).Value = kv.Diachi;
            cmd.Parameters.Add("sophong", SqlDbType.Int).Value = kv.Sophong;
            cmd.Parameters.Add("soday", SqlDbType.Int).Value = kv.Soday;
            cmd.Parameters.Add("sotang", SqlDbType.Int).Value = kv.Sotang;
            cmd.Parameters.Add("matk", SqlDbType.NChar).Value = kv.Matk;
            cmd.Parameters.Add("matt", SqlDbType.Int).Value = kv.Matt;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = kv.Ghichu;
            

            return cls.CapNhatDL(cmd);
        }

        //Chức năng lưu
        public int Luu(KhuVuc kv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update KhuVuc set TenKhuVuc=@tenkv,SoPhong=@sophong,DiaChi=@dchi,SoDay=@soday, SoTang=@sotang, MaTK=@matk,MaTrangThai=@matt,GhiChu=@ghichu where MaKV=@makv";

            cmd.Parameters.Add("tenkv", SqlDbType.NVarChar).Value = kv.Tenkv;
            cmd.Parameters.Add("dchi", SqlDbType.NVarChar).Value = kv.Diachi;
            cmd.Parameters.Add("sophong", SqlDbType.Int).Value = kv.Sophong;
            cmd.Parameters.Add("soday", SqlDbType.Int).Value = kv.Soday;
            cmd.Parameters.Add("sotang", SqlDbType.Int).Value = kv.Sotang;
            cmd.Parameters.Add("matk", SqlDbType.NChar).Value = kv.Matk;
            cmd.Parameters.Add("matt", SqlDbType.Int).Value = kv.Matt;
            cmd.Parameters.Add("ghichu", SqlDbType.NVarChar).Value = kv.Ghichu;
            cmd.Parameters.Add("makv", SqlDbType.NChar).Value = kv.Makv;
            return cls.CapNhatDL(cmd);
        }

        //Chức năng kiểm tra tồn tại mã khu vực
        public bool KiemTra(string kv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from KhuVuc where MaKV=@makv";

            cmd.Parameters.Add("makv", SqlDbType.VarChar).Value = kv;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }

    }
}
