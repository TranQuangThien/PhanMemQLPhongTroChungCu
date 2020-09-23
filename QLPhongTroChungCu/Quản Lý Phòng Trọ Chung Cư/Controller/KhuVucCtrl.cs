using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using System.Data;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class KhuVucCtrl
    {

        KhuVucData khuvuc = new KhuVucData();

        

       

        public KhuVuc DuLieuKV(string makv)
        {
            DataSet ds = khuvuc.LayDLMotDong(makv);
            KhuVuc kv = new KhuVuc();
            kv.Makv = ds.Tables[0].Rows[0]["MaKV"].ToString();
            kv.Tenkv = ds.Tables[0].Rows[0]["TenKhuVuc"].ToString();
            kv.Diachi = ds.Tables[0].Rows[0]["DiaChi"].ToString();
            kv.Sophong = Convert.ToInt32(ds.Tables[0].Rows[0]["SoPhong"]);
            kv.Soday = Convert.ToInt32(ds.Tables[0].Rows[0]["SoDay"]);
            kv.Sotang = Convert.ToInt32(ds.Tables[0].Rows[0]["SoTang"]);
            kv.Matk = ds.Tables[0].Rows[0]["LoaiTaiKhoan"].ToString();
            kv.Matt = Convert.ToInt32(ds.Tables[0].Rows[0]["MaTrangThai"]);
            kv.Ghichu = ds.Tables[0].Rows[0]["GhiChu"].ToString();
            
            return kv;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.DataSource = khuvuc.LayDSKV().Tables[0];
        }

        public int Them(KhuVuc kv)
        {

              if (KiemTraTonTai(kv.Makv))
                return 0;
            return khuvuc.Them(kv);
        }

        public int Xoa(string makv)
        {
            return khuvuc.Xoa(makv);
        }

        public int Luu(KhuVuc kv)
        {
           
            return khuvuc.Luu(kv);
        }

        public bool KiemTraTonTai(string tk)
        {
            return khuvuc.KiemTra(tk);
        }

    }
}
