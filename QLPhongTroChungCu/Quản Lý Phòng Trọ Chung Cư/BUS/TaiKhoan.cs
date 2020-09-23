using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class TaiKhoan
    {
        private string _matk;
        private string _hoten;
        private DateTime _ngaysinh;
        private bool _gioitinh;
        private string _sdt;
        private string _diachi;
        private string _cmnd;
        private int _maquyen;
        private string _username;
        private string _password;

        public string MaTK { get => _matk; set => _matk = value; }
        public string HoTen { get => _hoten; set => _hoten = value; }
        public DateTime NgaySinh { get => _ngaysinh; set => _ngaysinh = value; }
        public bool Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public string SDT { get => _sdt; set => _sdt = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Cmnd { get => _cmnd; set => _cmnd = value; }
        public int Maquyen { get => _maquyen; set => _maquyen = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
