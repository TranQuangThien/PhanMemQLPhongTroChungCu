using Quản_Lý_Phòng_Trọ_Chung_Cư.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư
{
    public partial class frmDay : Form
    {
        public frmDay()
        {
            InitializeComponent();
        }


        //Khai báo biến
        string text;
        DayCtrl dayctrl = new DayCtrl();
        KhuVucCtrl kvctrl = new KhuVucCtrl();
        //Gắn Dữ liệu
        private void GanDuLieu(BUS.Day day)
        {
            day.Maday = dayctrl.GetID() + 1;
            day.Makv = cbKhuVuc.SelectedValue.ToString();
            day.Tenday = txtTenDay.Text;
            

        }

        //Hiển thị thông báo
        private void ThongBao(string text)
        {
            MessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Hàm xử lý kiểm tra dữ liệu.
        private bool KiemTra()
        {
            bool ktra = true;

            if (txtTenDay.Text == "")
            {
                text = "Vui lòng nhập Tên Dãy!";
                ThongBao(text);
                ktra = false;
            }
            return ktra;
        }

        //chức năng làm mới
        private void LamMoi()
        {
            txtMaDay.Clear();
            txtTenDay.Clear();
           
            dayctrl.HienThi(dgvDay);
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        //Chức năng hiển thị thông tin
        private void HienThiThongTin()
        {

            if (dgvDay.CurrentRow != null)
            {
                txtMaDay.Text = dgvDay.CurrentRow.Cells["MaDay"].Value.ToString();
                txtTenDay.Text = dgvDay.CurrentRow.Cells["TenDay"].Value.ToString();
                
                cbKhuVuc.SelectedValue = dgvDay.CurrentRow.Cells["MaKV"].Value.ToString();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (KiemTra())
            {
                BUS.Day dv = new BUS.Day();
                GanDuLieu(dv);
                switch (dayctrl.Them(dv))
                {
                    case -1:
                        text = "Tên Dãy Tồn Tại!";
                        ThongBao(text);
                        break;
                    case 1:
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LamMoi();
                        break;
                }
            }

        }

        private void frmDay_Load(object sender, EventArgs e)
        {

            kvctrl.HienThiComboBox(cbKhuVuc);
            dayctrl.HienThi(dgvDay);
            HienThiThongTin();
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDay.CurrentRow != null)
            {
                int maday = Convert.ToInt32(dgvDay.CurrentRow.Cells[0].Value.ToString());

                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    dayctrl.Xoa(maday);
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dayctrl.HienThi(dgvDay);
                    }
                }

            }
        }

        private void dgvDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiThongTin();
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BUS.Day dv = new BUS.Day();
            dv.Maday = Convert.ToInt32(txtMaDay.Text);
            dv.Tenday = txtTenDay.Text;
            dv.Makv = cbKhuVuc.SelectedValue.ToString();
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn đổi dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                dayctrl.Luu(dv);
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dayctrl.HienThi(dgvDay);
                HienThiThongTin();
            }
        }

        private int SoLuongDay()
        {



            return 1;
        }
    }
}
