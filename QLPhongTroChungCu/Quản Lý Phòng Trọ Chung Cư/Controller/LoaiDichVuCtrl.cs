using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class LoaiDichVuCtrl
    {
        LoaiDichVuData Loaidichvu = new LoaiDichVuData();

        public void HienThiComboBoxLoaiDV(ComboBox cb)
        {
            cb.DataSource = Loaidichvu.LayDSLoaiDV().Tables[0];
            cb.DisplayMember = "TenLoaiDV";
            cb.ValueMember = "MaLoaiDV";
        }

    }
}
