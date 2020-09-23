using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Class
{
    class DataProvider
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-MVAMU7J\SQLEXPRESS;Initial Catalog=QLPhongTroChungCu;Integrated Security=True");

        public DataProvider()
        {
            KetNoi();
        }

        void KetNoi()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public DataSet LayDuLieu(SqlCommand sqlcmd)
        {
            DataSet ds = new DataSet();
            sqlcmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);

            da.Fill(ds);

            return ds;
        }

        public int CapNhatDL(SqlCommand sqlcmd)
        {
            SqlCommand cmd = sqlcmd;
            cmd.Connection = conn;
            int kq = cmd.ExecuteNonQuery();

            return kq;
        }

        public int GetID(SqlCommand sqlcmd)
        {
            int id = 1;
            SqlCommand cmd = sqlcmd;
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                id = Convert.ToInt32(dr[0]);
            }
            dr.Close();

            return id;
        }

        public bool KiemTra(SqlCommand sqlcmd)
        {
            bool kTra = false;
            SqlCommand cmd = sqlcmd;
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                kTra = true;
            }
            dr.Close();

            return kTra;
        }
    }
}
