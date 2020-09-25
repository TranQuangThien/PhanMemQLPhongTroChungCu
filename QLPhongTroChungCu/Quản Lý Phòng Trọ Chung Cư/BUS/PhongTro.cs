using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class PhongTro
    {

        private string _maphongtro;
        private string _makv;
        private string _maday;
        private string _matang;
        private string _tenphongtro;
        private int _matt;
        private int _mattThue;
        private string _ghichu;

        public string Maphongtro { get => _maphongtro; set => _maphongtro = value; }
        public string Makv { get => _makv; set => _makv = value; }
        public string Maday { get => _maday; set => _maday = value; }
        public string Matang { get => _matang; set => _matang = value; }
        public string Tenphongtro { get => _tenphongtro; set => _tenphongtro = value; }
        public int Matt { get => _matt; set => _matt = value; }
        public int MattThue { get => _mattThue; set => _mattThue = value; }
        public string Ghichu { get => _ghichu; set => _ghichu = value; }
    }
}
