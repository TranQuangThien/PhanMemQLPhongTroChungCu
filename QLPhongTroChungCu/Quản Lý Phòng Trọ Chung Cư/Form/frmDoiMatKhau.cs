using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_Lý_Phòng_Trọ_Chung_Cư.Class;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư
{
    public partial class frmDoiMatKhau : Form
    {

        Login log = new Login();
        string taiKhoan;
        public frmDoiMatKhau(string username)
        {
            InitializeComponent();
            taiKhoan = username;
        }

        private void doiMatKhau()
        {
            log.DoiMatKhau(txtPassWord.Text, taiKhoan);
            MessageBox.Show("Thay đổi mật khẩu thành công.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {

            if (txtPassWord.Text == "" || txtRePass.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống mật khẩu.");
            }
            else if (txtPassWord.Text != txtRePass.Text)
            {
                MessageBox.Show("Mật Khẩu Không Trùng Khớp.", "Không Trùng Khớp");
            }
            else
            {
                doiMatKhau();
                frmDangNhap frm = new frmDangNhap();
                this.Hide();
                frm.Show();
            }

        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            pnKiemTra.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
