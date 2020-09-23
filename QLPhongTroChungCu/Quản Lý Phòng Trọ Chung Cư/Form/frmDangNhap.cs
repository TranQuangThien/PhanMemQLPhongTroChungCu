using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư
{
    public partial class frmDangNhap : Form
    {

        Login log = new Login();
        User user = new User();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            pnDangNhap.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmKiemTraTaiKhoan frm = new frmKiemTraTaiKhoan();
            frm.Show();
            this.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin đăng nhập.
            if (txtUserName.Text == "" || txtPassWord.Text == "")
            {
                MessageBox.Show("Vui lòng không bỏ trống thông tin đăng nhập!", "Đăng Nhập Thất Bại");
            }
            else if (log.DangNhap(txtUserName.Text, txtPassWord.Text, user))
            {
                //Nếu đăng nhập thành công thì ẩn frmDangNhap và mở frmTrangChu.

                /*frmTrangChu frm = new frmTrangChu(user);
                this.Hide();
                frm.Show();*/
                MessageBox.Show("xin chào " +user.UserName+ "" , "Đăng Nhập Thành Công");
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu.", "Đăng Nhập Thất Bại");
            }
        }
    }
}
