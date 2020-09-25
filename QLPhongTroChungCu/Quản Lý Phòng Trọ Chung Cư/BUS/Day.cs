using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class Day
    {

        private int _maday;
        private string _makv;
        private string _tenday;

        public int Maday { get => _maday; set => _maday = value; }
        public string Makv { get => _makv; set => _makv = value; }
        public string Tenday { get => _tenday; set => _tenday = value; }
    }
}
