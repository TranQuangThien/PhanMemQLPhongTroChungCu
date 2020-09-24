using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Data
{
    class LoaiDichVuData
    {

        DataProvider cls = new DataProvider();
        //lấy danh sách khu vực
        public DataSet LayDSLoaiDV()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from LoaiDichVu");
            return cls.LayDuLieu(sqlcmd);
        }

    }
}
