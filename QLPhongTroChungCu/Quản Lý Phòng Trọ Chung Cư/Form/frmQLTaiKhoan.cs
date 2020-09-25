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
    public partial class frmQLTaiKhoan : Form
    {
        string text;
        TaiKhoanCtrl tkctrl = new TaiKhoanCtrl();
        public frmQLTaiKhoan()
        {
            InitializeComponent();
        }


        //Gắn Dữ liệu
        private void GanDuLieu(TaiKhoan tk)
        {
            tk.Username = txtUserName.Text;
            tk.Gioitinh = (radNam.Checked) ? true : false;
            tk.SDT = txtSDT.Text;
            tk.NgaySinh = Convert.ToDateTime(dtNgaySinh.Value);
            tk.Diachi = txtDiaChi.Text;
            tk.Password = txtPassWord.Text;
            tk.Cmnd = txtCMND.Text;
            tk.HoTen = txtHoTen.Text;
            tk.Maquyen = Convert.ToInt32(cbQuyen.SelectedValue);
            tk.MaTK = txtMaTK.Text;
        }

        //Hiển thi radio Giới Tính

        private void checkRadio()
        {
            string gtri = dgvTaiKhoan.CurrentRow.Cells["GioiTinh"].Value.ToString();
            radNam.Checked = (gtri == "True") ? true : false;
            radNu.Checked = (gtri == "False") ? true : false;
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

            if (txtHoTen.Text == "")
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
            else if (dtNgaySinh.Text == "")
            {
                text = "Vui lòng nhập ngày sinh!";
                ThongBao(text);
                ktra = false;
            }
            else if (cbQuyen.Text == "")
            {
                text = "Vui lòng chọn loại TK!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtUserName.Text == "")
            {
                text = "Vui lòng nhập Tên đăng nhập!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtPassWord.Text == "")
            {
                text = "Vui lòng nhập mật khẩu!";
                ThongBao(text);
                ktra = false;
            }

            return ktra;
        }

        private void LamMoi()
        {
            txtHoTen.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtPassWord.Clear();
            txtDiaChi.Clear();
            txtUserName.Clear();
            txtMaTK.Clear();
            tkctrl.HienThi(dgvTaiKhoan);
            txtPassWord.Enabled = true;
            txtMaTK.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtUserName.Enabled = true;
        }

        private void HienThiThongTin()
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {
                txtMaTK.Text = dgvTaiKhoan.CurrentRow.Cells["MaTK"].Value.ToString();
                txtUserName.Text = dgvTaiKhoan.CurrentRow.Cells["UserName"].Value.ToString();
                txtHoTen.Text = dgvTaiKhoan.CurrentRow.Cells["HoTenTK"].Value.ToString();
                checkRadio();
                txtSDT.Text = dgvTaiKhoan.CurrentRow.Cells["SDT"].Value.ToString();
                txtCMND.Text = dgvTaiKhoan.CurrentRow.Cells["CMND"].Value.ToString();
                dtNgaySinh.Value = Convert.ToDateTime(dgvTaiKhoan.CurrentRow.Cells["NgaySinh"].Value);
                txtDiaChi.Text = dgvTaiKhoan.CurrentRow.Cells["DiaChi"].Value.ToString();
                cbQuyen.SelectedValue = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["MaQuyen"].Value);
                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                TaiKhoan tk = new TaiKhoan();
                GanDuLieu(tk);

                
                    switch (tkctrl.Them(tk))
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

        private void frmQLTaiKhoan_Load(object sender, EventArgs e)
        {
            txtPassWord.Enabled = false;
            txtMaTK.Enabled = false;
            btnThem.Enabled = false;
            Dictionary<int, string> test = new Dictionary<int, string>();
            test.Add(0, "User");
            test.Add(1, "Admin");
            cbQuyen.DataSource = new BindingSource(test, null);
            cbQuyen.DisplayMember = "Value";
            cbQuyen.ValueMember = "Key";
            tkctrl.HienThi(dgvTaiKhoan);
            HienThiThongTin();
            
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiThongTin();
            txtPassWord.Enabled = false;
            txtMaTK.Enabled = false;
            txtUserName.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtUserName.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {
                string matk = dgvTaiKhoan.CurrentRow.Cells[0].Value.ToString();

                    DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlg == System.Windows.Forms.DialogResult.Yes)
                    {
                        tkctrl.Xoa(matk);
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tkctrl.HienThi(dgvTaiKhoan);
                        }
                    }
                }
            }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            GanDuLieu(tk);

            string tendn = dgvTaiKhoan.CurrentRow.Cells[0].Value.ToString();

            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn đổi dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (tkctrl.Luu(tk) > 0)
                {
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tkctrl.HienThi(dgvTaiKhoan);
                    HienThiThongTin();
                }
            }
        }

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

                tkctrl.HienThiTK(dgvTaiKhoan, txtTimKiem.Text, tieuchi);
            }
        }
    }
    }
