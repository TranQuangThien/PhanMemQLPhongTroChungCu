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
using Quản_Lý_Phòng_Trọ_Chung_Cư.Controller;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư
{
    public partial class frmQLKhuVuc : Form
    {
        public frmQLKhuVuc()
        {
            InitializeComponent();
        }

        KhuVucCtrl kvctrl = new KhuVucCtrl();
        TrangThaiCtrl ttctrl = new TrangThaiCtrl();
        TaiKhoanCtrl tkctrl = new TaiKhoanCtrl();
        string text;

        private void frmQLKhuVuc_Load(object sender, EventArgs e)
        {
            tkctrl.HienThiComboBox(cbTaiKhoan);
            ttctrl.HienThiComboBoxTT(cbTrangThai);
            kvctrl.HienThi(dgvKhuVuc);
            HienThiThongTin();
            txtMaKV.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        //Gắn liệu nhập từ textbox
        private void GanDuLieu(KhuVuc kv)
        {
            kv.Makv = txtMaKV.Text;
            kv.Tenkv = txtTenKV.Text;
            kv.Diachi = txtDiaChi.Text;
            kv.Soday = Convert.ToInt32(txtSoDay.Text);
            kv.Sophong = Convert.ToInt32(txtSoPhong.Text);
            kv.Sotang = Convert.ToInt32(txtSoTang.Text);
            kv.Matk = cbTaiKhoan.SelectedValue.ToString();
            kv.Matt = Convert.ToInt32(cbTrangThai.SelectedValue);
            kv.Ghichu = txtGhiChu.Text;
        }

        private void ThongBao(string text)
        {
            MessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Hàm xử lý kiểm tra dữ liệu.
        private bool KiemTra()
        {
            bool ktra = true;

            if (txtMaKV.Text == "")
            {
                text = "Vui lòng nhập Mã Khu Vực!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtTenKV.Text == "")
            {
                text = "Vui lòng nhập Tên Khu Vực!";
                ThongBao(text);
                ktra = false;
            }

            else if (txtDiaChi.Text == "")
            {
                text = "Vui lòng nhập Địa Chỉ!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtSoDay.Text == "")
            {
                text = "Vui lòng nhập Số Dãy!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtSoPhong.Text == "")
            {
                text = "Vui lòng Nhập Số Phòng!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtSoTang.Text == "")
            {
                text = "Vui lòng nhập Số Tầng!";
                ThongBao(text);
                ktra = false;
            }


            return ktra;
        }

        //làm mới các textbox
        private void LamMoi()
        {
            txtMaKV.Clear();
            txtTenKV.Clear();
            txtDiaChi.Clear();
            txtSoDay.Clear();
            txtSoPhong.Clear();
            txtSoTang.Clear();
            txtGhiChu.Clear();
            kvctrl.HienThi(dgvKhuVuc);
            txtMaKV.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        //Hiển thị thông tin lên các textbox
        private void HienThiThongTin()
        {
            if (dgvKhuVuc.CurrentRow != null)
            {
                txtMaKV.Text = dgvKhuVuc.CurrentRow.Cells["MaKV"].Value.ToString();
                txtTenKV.Text = dgvKhuVuc.CurrentRow.Cells["TenKhuVuc"].Value.ToString();
                txtDiaChi.Text = dgvKhuVuc.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtSoPhong.Text = dgvKhuVuc.CurrentRow.Cells["SoPhong"].Value.ToString();
                txtSoTang.Text = dgvKhuVuc.CurrentRow.Cells["SoTang"].Value.ToString();
                txtSoDay.Text = dgvKhuVuc.CurrentRow.Cells["SoDay"].Value.ToString();
                txtGhiChu.Text = dgvKhuVuc.CurrentRow.Cells["GhiChu"].Value.ToString();
                cbTaiKhoan.SelectedValue = dgvKhuVuc.CurrentRow.Cells["MaTK"].Value.ToString();
                cbTrangThai.SelectedValue = Convert.ToInt32(dgvKhuVuc.CurrentRow.Cells["MaTrangThai"].Value);
            }
        }

        private void dgvKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiThongTin();
            txtMaKV.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (KiemTra())
            {
                KhuVuc kv = new KhuVuc();
                GanDuLieu(kv);

                {
                    switch (kvctrl.Them(kv))
                    {

                        case 0:
                            text = "Mã Khu Vực Tồn Tại!";
                            ThongBao(text);
                            break;
                        case 1:
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoi();
                            break;
                    }

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            KhuVuc kv = new KhuVuc();
            GanDuLieu(kv);

            string makv = dgvKhuVuc.CurrentRow.Cells[0].Value.ToString();

            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn đổi dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (kvctrl.Luu(kv) > 0)
                { 
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kvctrl.HienThi(dgvKhuVuc);
                    HienThiThongTin();
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvKhuVuc.CurrentRow != null)
            {
                string makv = dgvKhuVuc.CurrentRow.Cells[0].Value.ToString();

                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    kvctrl.Xoa(makv);
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kvctrl.HienThi(dgvKhuVuc);
                    }
                }
            }

        }
    }
}
