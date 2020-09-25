using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Data
{
    class DayData
    {

        DataProvider cls = new DataProvider();

        public int GetID()
        {
            string select = "SELECT MaDay ",
                from = "FROM Day ",
                orderBy = "ORDER BY MaDay DESC";

            SqlCommand cmd = new SqlCommand(select + from + orderBy);

            return cls.GetID(cmd);
        }

        //Lấy danh sách Dãy trong một dòng
        public DataSet LayDLMotDong(int maday)
        {
            SqlCommand cmd = new SqlCommand("select * from Day where MaDay=@maday");
            cmd.Parameters.Add("maday", SqlDbType.Int).Value = maday;

            return cls.LayDuLieu(cmd);
        }


        //lấy danh sách Dãy
        public DataSet LayDSDay()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from Day");
            return cls.LayDuLieu(sqlcmd);
        }

        //Chức năng xóa
        public int Xoa(int maday)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from Day where MaDay=@maday";
            cmd.Parameters.Add("maday", SqlDbType.Int).Value = maday;
            return cls.CapNhatDL(cmd);
        }

        //Chức năng thêm
        public int Them(Day day)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Day(MaDay, MaKV, TenDay)values(@maday,@makv,@tenday)";
            cmd.Parameters.Add("maday", SqlDbType.Int).Value = day.Maday;
            cmd.Parameters.Add("makv", SqlDbType.NChar).Value = day.Makv;
            cmd.Parameters.Add("tenday", SqlDbType.NVarChar).Value = day.Tenday;
          

            return cls.CapNhatDL(cmd);
        }

        //Chức năng lưu
        public int Luu(Day day)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Day set MaKV=@makv,TenDay=@tenday where MaDay=@maday";
            
            cmd.Parameters.Add("makv", SqlDbType.NChar).Value = day.Makv;
            cmd.Parameters.Add("tenday", SqlDbType.NVarChar).Value = day.Tenday;
            cmd.Parameters.Add("maday", SqlDbType.Int).Value = day.Maday;
            return cls.CapNhatDL(cmd);
        }
        public bool KiemTra(string tk)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Day where TenDay=@tenday";

            cmd.Parameters.Add("tenday", SqlDbType.VarChar).Value = tk;

            return (cls.LayDuLieu(cmd).Tables[0].Rows.Count > 0);
        }

    }
}
