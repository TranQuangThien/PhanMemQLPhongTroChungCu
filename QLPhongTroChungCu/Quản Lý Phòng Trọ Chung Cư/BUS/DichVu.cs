using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.BUS
{
    class DichVu
    {

        private int _madv;
        private string _tendv;
        private int _dongia;

        public int Madv { get => _madv; set => _madv = value; }
        public string Tendv { get => _tendv; set => _tendv = value; }
        public int Dongia { get => _dongia; set => _dongia = value; }
    }
}
