using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Data;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Controller
{
    class TrangThaiCtrl
    {
        TrangThaiData trangthai = new TrangThaiData();

        public void HienThiComboBoxTT(ComboBox cb)
        {
            cb.DataSource = trangthai.LayDSTrangThai().Tables[0];
            cb.DisplayMember = "TenTrangThai";
            cb.ValueMember = "MaTrangThai";
        }

    }
}
