using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using System.Windows.Forms;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class DayCtrl
    {

        DayData day = new DayData();
        DataProvider cls = new DataProvider();

        public int GetID()
        {
            return day.GetID();
        }

        public BUS.Day DuLieuKV(int maday)
        {
            DataSet ds = day.LayDLMotDong(maday);
            BUS.Day dv = new BUS.Day();
            dv.Maday = Convert.ToInt32(ds.Tables[0].Rows[0]["MaDay"]);
            dv.Makv = ds.Tables[0].Rows[0]["MaKV"].ToString();
            dv.Tenday = ds.Tables[0].Rows[0]["TenDay"].ToString();
            return dv;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.DataSource = day.LayDSDay().Tables[0];
        }

        public int Them(BUS.Day day)
        {
            if (KiemTraTonTai(day.Tenday))
                return -1;
            return this.day.Them(day);
        }

        public int Xoa(int maday)
        {
            return day.Xoa(maday);
        }

        public int Luu(BUS.Day dv)
        {
            return day.Luu(dv);
        }

        public bool KiemTraTonTai(string ten)
        {
            return day.KiemTra(ten);
        }
    }
}
