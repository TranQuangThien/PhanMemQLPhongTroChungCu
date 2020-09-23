using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Class
{
    class Login
    {

        //Khởi tạo các biến lưu trữ và kết nối.
        DataProvider cls = new DataProvider();

        //Hàm xử lý đăng nhập và lưu giá trị
        public bool DangNhap(string username, string password, User user)
        {
            SqlCommand cmd = new SqlCommand("select * from TaiKhoan where UserName=@username and PassWord=@password");

            cmd.Parameters.Add("username", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("password", SqlDbType.VarChar).Value = password;

            DataSet ds = cls.LayDuLieu(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                user.UserName = ds.Tables[0].Rows[0]["HoTenTK"].ToString();
                user.TenTK = ds.Tables[0].Rows[0]["UserName"].ToString();
                user.PhanQuyen = Convert.ToInt32(ds.Tables[0].Rows[0]["MaQuyen"]);
                return true;
            }

            return false;
        }

        public int DoiMatKhau(string matKhau, string taiKhoan)
        {
            SqlCommand cmd = new SqlCommand();
            string update = "UPDATE TaiKhoan SET PassWord = @maKhau ",
                where = "WHERE UserName = @taiKhoan";

            cmd.CommandText = update + where;

            cmd.Parameters.Add("maKhau", SqlDbType.VarChar).Value = matKhau;
            cmd.Parameters.Add("taiKhoan", SqlDbType.VarChar).Value = taiKhoan;

            return cls.CapNhatDL(cmd);
        }

        public bool XacThuc(string tenDangNhap, string sdt)
        {
            SqlCommand cmd = new SqlCommand();

            string select = "SELECT * ",
                from = "FROM TaiKhoan ",
                where = "WHERE UserName = @tenDangNhap AND SDT = @sdt";

            cmd.CommandText = select + from + where;

            cmd.Parameters.Add("sdt", SqlDbType.Int).Value = sdt;
            cmd.Parameters.Add("tenDangNhap", SqlDbType.VarChar).Value = tenDangNhap;

            return cls.KiemTra(cmd);
        }
    }

}
