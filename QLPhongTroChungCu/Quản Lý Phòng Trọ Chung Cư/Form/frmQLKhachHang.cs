using Quản_Lý_Phòng_Trọ_Chung_Cư.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Controller;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư
{
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
        {
            InitializeComponent();
        }

        KhachHangCtrl khctrl = new KhachHangCtrl();
        string text;

        //Load Form
        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            khctrl.HienThi(dgvKhachHang);
            txtMaKH.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            HienThiThongTin();
        }

        //Gắn Dữ liệu
        private void GanDuLieu(KhachHang kh)
        {

            kh.GioiTinh = (radNam.Checked) ? true : false;
            kh.SDT = txtSDT.Text;
            kh.NgaySinh = Convert.ToDateTime(dtNgaySinh.Value);
            kh.DiaChi = txtDiaChi.Text;
            kh.CMND = txtCMND.Text;
            kh.TenKH = txtHoTenKH.Text;
            kh.MaKH = txtMaKH.Text;
            kh.GhiChu = txtGhiChu.Text;
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
            if (txtMaKH.Text == "")
            {
                text = "Vui lòng nhập Mã Khách Hàng!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtHoTenKH.Text == "")
            {
                text = "Vui lòng nhập họ & tên!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtSDT.Text == "")
            {
                text = "Vui lòng nhập Số điện thoại!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtSDT.TextLength < 10)
            {
                text = "SĐT không hợp lệ!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtCMND.Text == "")
            {
                text = "Vui lòng nhập CMND!";
                ThongBao(text);
                ktra = false;
            }
            return ktra;
        }

        //Làm Mới Form
        private void LamMoi()
        {
            txtMaKH.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtHoTenKH.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            khctrl.HienThi(dgvKhachHang);
            txtMaKH.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        //Kiểm tra giới tính
        private void checkRadio()
        {
            string gtri = dgvKhachHang.CurrentRow.Cells["GioiTinh"].Value.ToString();
            radNam.Checked = (gtri == "True") ? true : false;
            radNu.Checked = (gtri == "False") ? true : false;
        }

        //Hiển thị thông tin lên DataGridView
        private void HienThiThongTin()
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
                txtHoTenKH.Text = dgvKhachHang.CurrentRow.Cells["HoTenKH"].Value.ToString();
                checkRadio();
                txtSDT.Text = dgvKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
                txtCMND.Text = dgvKhachHang.CurrentRow.Cells["CMND"].Value.ToString();
                dtNgaySinh.Value = Convert.ToDateTime(dgvKhachHang.CurrentRow.Cells["NgaySinh"].Value);
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtGhiChu.Text = dgvKhachHang.CurrentRow.Cells["GhiChu"].Value.ToString();
            }
        }

        //Chức năng thêm
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (KiemTra())
            {
                KhachHang kh = new KhachHang();
                GanDuLieu(kh);

                {
                    switch (khctrl.Them(kh))
                    {
                        case -1:
                            text = "Mã tài khoản đã tồn tại!";
                            ThongBao(text);
                            break;
                        case 0:
                            text = "Số điện thoại không hợp lệ!";
                            ThongBao(text);
                            break;
                        case 2:
                            text = "UserName đã tồn tại!";
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

        //Chức năng sửa thông tin khách hàng
        private void btnSua_Click(object sender, EventArgs e)
        {

            KhachHang kh = new KhachHang();
            GanDuLieu(kh);

            string tendn = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();

            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn đổi dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (khctrl.Luu(kh) > 0)
                {
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    khctrl.HienThi(dgvKhachHang);
                    HienThiThongTin();
                }
            }

        }

        //Chức năng xóa thông tin khách hàng
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvKhachHang.CurrentRow != null)
            {
                string matk = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();

                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    khctrl.Xoa(matk);
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        khctrl.HienThi(dgvKhachHang);
                        HienThiThongTin();
                    }
                }
            }

        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            HienThiThongTin();
           
            txtMaKH.Enabled = false;
            
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        //Chức năng tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tieuchi = "";
            if (radHoTen.Checked)
                tieuchi = "hoTen";
            else if (radSDT.Checked)
                tieuchi = "sdt";
            else if (radCMND.Checked)
                tieuchi = "cmnd";
            else
            {
                text = "Vui lòng chọn loại tìm kiếm!";
                ThongBao(text);
            }

            if (txtTimKiem.Text.Length != 0 && tieuchi != "")
            {

                khctrl.HienThiTK(dgvKhachHang, txtTimKiem.Text, tieuchi);
            }
        }

        

    }
}
