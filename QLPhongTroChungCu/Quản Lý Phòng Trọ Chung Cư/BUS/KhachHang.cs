using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class KhachHang
    {

        private string _makh;
        private string _tenkh;
        private DateTime _ngaysinh;
        private bool _gioitinh;
        private string _diachi;
        private string _sdt;
        private string _cmnd;
        private string _ghichu;

        public string MaKH { get => _makh; set => _makh = value; }
        public string TenKH { get => _tenkh; set => _tenkh = value; }
        public DateTime NgaySinh { get => _ngaysinh; set => _ngaysinh = value; }
        public bool GioiTinh { get => _gioitinh; set => _gioitinh = value; }
        public string DiaChi { get => _diachi; set => _diachi = value; }
        public string SDT { get => _sdt; set => _sdt = value; }
        public string CMND { get => _cmnd; set => _cmnd = value; }
        public string GhiChu { get => _ghichu; set => _ghichu = value; }
    }
}
