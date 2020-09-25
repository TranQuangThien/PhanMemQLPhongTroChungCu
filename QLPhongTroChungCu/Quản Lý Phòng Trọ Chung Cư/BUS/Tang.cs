using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class Tang
    {

        private string _matang;
        private string _makv;
        private string _tentang;

        public string Matang { get => _matang; set => _matang = value; }
        public string Makv { get => _makv; set => _makv = value; }
        public string Tentang { get => _tentang; set => _tentang = value; }
    }
}
