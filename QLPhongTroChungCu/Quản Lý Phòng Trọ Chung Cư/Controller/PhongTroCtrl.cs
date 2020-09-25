using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;


namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class PhongTroCtrl
    {


        PhongTroData phongtro = new PhongTroData();

        public void HienThiComboBox(ComboBox cb)
        {
            cb.DataSource = phongtro.LayDSPhongTro().Tables[0];
            cb.DisplayMember = "TenPhongTro";
            cb.ValueMember = "MaPhongTro";
        }

        public void HienThiTK(DataGridView dgv, string tukhoa, string tieuchi)
        {
            dgv.DataSource = phongtro.LayDSTK(tukhoa, tieuchi).Tables[0];
        }

        public PhongTro DuLieuPhongTro(string tr)
        {
            DataSet ds = phongtro.LayDLMotDong(tr);
            PhongTro tro = new PhongTro();
            tro.Maphongtro = ds.Tables[0].Rows[0]["MaPhongTro"].ToString();
            tro.Makv = ds.Tables[0].Rows[0]["MaKV"].ToString();
            tro.Maday = ds.Tables[0].Rows[0]["MaDay"].ToString();
            tro.Matang = ds.Tables[0].Rows[0]["MaTang"].ToString();
            tro.Matt = Convert.ToInt32(ds.Tables[0].Rows[0]["MaTrangThai"].ToString());
            tro.Tenphongtro = ds.Tables[0].Rows[0]["TenPhongTro"].ToString();
            tro.MattThue = Convert.ToInt32(ds.Tables[0].Rows[0]["MaTTThue"]);
            tro.Ghichu = ds.Tables[0].Rows[0]["GhiChu"].ToString();
            return tro;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.DataSource = phongtro.LayDSPhongTro().Tables[0];
        }

        public int Them(PhongTro tro)
        {

            if (KiemTraTonTai(tro.Tenphongtro))
                return 1;
            return phongtro.Them(tro);
        }

        public int Xoa(string matk)
        {
            return phongtro.Xoa(matk);
        }

        public int Luu(PhongTro tro)
        {
            if (KiemTraTonTai(tro.Tenphongtro))
                return 1;
            return phongtro.Luu(tro);
        }

       
        public bool KiemTraTonTai(string tk)
        {
            return phongtro.KiemTra(tk);
        }

    }
}
