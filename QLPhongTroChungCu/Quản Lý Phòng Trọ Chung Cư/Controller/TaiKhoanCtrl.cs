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
    class TaiKhoanCtrl
    {

        TaiKhoanData taikhoan = new TaiKhoanData();

        public void HienThiComboBox(ComboBox cb)
        {
            cb.DataSource = taikhoan.LayDSTK().Tables[0];
            cb.DisplayMember = "HoTenTK";
            cb.ValueMember = "MaTK";
        }

        public void HienThiTK(DataGridView dgv, string tukhoa, string tieuchi)
        {
            dgv.DataSource = taikhoan.LayDSTK(tukhoa, tieuchi).Tables[0];
        }

        public TaiKhoan DuLieuGV(string ten)
        {
            DataSet ds = taikhoan.LayDLMotDong(ten);
            TaiKhoan tk = new TaiKhoan();
            tk.MaTK = ds.Tables[0].Rows[0]["MaTK"].ToString();
            tk.HoTen = ds.Tables[0].Rows[0]["HoTenTK"].ToString();
            tk.Gioitinh = (bool)(ds.Tables[0].Rows[0]["GioiTinh"]);
            tk.SDT = ds.Tables[0].Rows[0]["SDT"].ToString();
            tk.NgaySinh = DateTime.Parse(ds.Tables[0].Rows[0]["NgaySinh"].ToString());
            tk.Diachi = ds.Tables[0].Rows[0]["DiaChi"].ToString();
            tk.Maquyen = Convert.ToInt32(ds.Tables[0].Rows[0]["LoaiTaiKhoan"]);
            tk.Cmnd = ds.Tables[0].Rows[0]["CMND"].ToString();
            tk.Username = ds.Tables[0].Rows[0]["UserName"].ToString();
            tk.Password = ds.Tables[0].Rows[0]["PassWord"].ToString();
            return tk;
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.DataSource = taikhoan.LayDSTaiKhoan().Tables[0];
        }

        public int Them(TaiKhoan tk)
        {

            if (!KiemTraSDT(tk.SDT))
                return 0;
            if (KiemTraTonTai(tk.MaTK))
                return -1;
            if (KiemTrausername(tk.Username))
                return 2;
            return taikhoan.Them(tk);
        }

        public int Xoa(string matk)
        {
            return taikhoan.Xoa(matk);
        }

        public int Luu(TaiKhoan gv)
        {
            if (!KiemTraSDT(gv.SDT))
                return 0;
            return taikhoan.Luu(gv);
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
            return taikhoan.KiemTra(tk);
        }
        public bool KiemTrausername(string tk)
        {
            return taikhoan.KiemTraUserName(tk);
        }

    }
}
