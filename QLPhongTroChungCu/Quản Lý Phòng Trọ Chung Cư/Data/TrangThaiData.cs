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
    class TrangThaiData
    {

        DataProvider cls = new DataProvider();

        public DataSet LayDSTrangThai()
        {
            SqlCommand sqlcmd = new SqlCommand("select * from TrangThai ");
            return cls.LayDuLieu(sqlcmd);
        }

    }
}
