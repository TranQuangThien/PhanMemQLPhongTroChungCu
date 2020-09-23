using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class KhuVuc
    {

        private string _makv;
        private string _tenkv;
        private string _diachi;
        private int _sophong;
        private int _sotang;
        private int _soday;
        private string _matk;
        private int _matt;
        private string _ghichu;

        public string Makv { get => _makv; set => _makv = value; }
        public string Tenkv { get => _tenkv; set => _tenkv = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public int Sophong { get => _sophong; set => _sophong = value; }
        public int Sotang { get => _sotang; set => _sotang = value; }
        public int Soday { get => _soday; set => _soday = value; }
        public string Matk { get => _matk; set => _matk = value; }
        public int Matt { get => _matt; set => _matt = value; }
        public string Ghichu { get => _ghichu; set => _ghichu = value; }
    }
}
