using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class DichVuCtrl
    {
        
        DichVuData dichvu = new DichVuData();
        DataProvider cls = new DataProvider();

        public int GetID()
        {
            return dichvu.GetID();
        }

        public DichVu DuLieuKV(string makv)
        {
            DataSet ds = dichvu.LayDLMotDong(makv);
            DichVu dv = new DichVu();
            dv.Madv = Convert.ToInt32(ds.Tables[0].Rows[0]["MaDichVu"]);
            dv.Tendv = ds.Tables[0].Rows[0]["TenDichVu"].ToString();
            dv.Dongia = Convert.ToInt32(ds.Tables[0].Rows[0]["DonGia"]);
            return dv;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.DataSource = dichvu.LayDSDV().Tables[0];
        }

        public int Them(DichVu dv)
        {

            return dichvu.Them(dv);
        }

        public int Xoa(string madv)
        {
            return dichvu.Xoa(madv);
        }

        public int Luu(DichVu dv)
        {
            return dichvu.Luu(dv);
        }

    }
}
