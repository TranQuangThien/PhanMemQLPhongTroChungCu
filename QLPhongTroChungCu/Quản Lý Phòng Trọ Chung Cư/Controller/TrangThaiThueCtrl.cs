using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class TrangThaiThueCtrl
    {

        TrangThaiThueData trangthai = new TrangThaiThueData();

        public void HienThiComboBoxTTThue(ComboBox cb)
        {
            cb.DataSource = trangthai.LayDSTrangThai().Tables[0];
            cb.DisplayMember = "TenTrangThaiThue";
            cb.ValueMember = "MaTTThue";
        }
       
    }
}
