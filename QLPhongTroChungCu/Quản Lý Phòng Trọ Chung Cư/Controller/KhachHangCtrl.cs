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
    class KhachHangCtrl
    {

        KhachHangData khachhang = new KhachHangData();

        public void HienThiTK(DataGridView dgv, string tukhoa, string tieuchi)
        {
            dgv.DataSource = khachhang.LayDSTK(tukhoa, tieuchi).Tables[0];
        }

        public KhachHang DuLieuKhachHang(string ten)
        {
            DataSet ds = khachhang.LayDLMotDong(ten);
            KhachHang kh = new KhachHang();
            kh.MaKH = ds.Tables[0].Rows[0]["MaKH"].ToString();
            kh.TenKH = ds.Tables[0].Rows[0]["HoTenKH"].ToString();
            kh.GioiTinh = (bool)(ds.Tables[0].Rows[0]["GioiTinh"]);
            kh.SDT = ds.Tables[0].Rows[0]["SDT"].ToString();
            kh.NgaySinh = DateTime.Parse(ds.Tables[0].Rows[0]["NgaySinh"].ToString());
            kh.DiaChi = ds.Tables[0].Rows[0]["DiaChi"].ToString();
            kh.CMND = ds.Tables[0].Rows[0]["CMND"].ToString();
            kh.GhiChu = ds.Tables[0].Rows[0]["GhiChu"].ToString();
            return kh;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.DataSource = khachhang.LayDSKhachHang().Tables[0];
        }

        public int Them(KhachHang kh)
        {

            if (!KiemTraSDT(kh.SDT))
                return 0;
            if (KiemTraTonTai(kh.MaKH))
                return -1;
            return khachhang.Them(kh);
        }

        public int Xoa(string matk)
        {
            return khachhang.Xoa(matk);
        }

        public int Luu(KhachHang tk)
        {
            if (!KiemTraSDT(tk.SDT))
                return 0;
            return khachhang.Luu(tk);
        }

        private bool KiemTraSDT(string sdt)
        {
            long k = 0;
            if (!long.TryParse(sdt, out k))
                return false;
            if (sdt.Length > 11)
                return false;
            return true;
        }

        public bool KiemTraTonTai(string tk)
        {
            return khachhang.KiemTra(tk);
        }

    }
}
