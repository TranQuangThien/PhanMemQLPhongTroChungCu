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
    public partial class frmKiemTraTaiKhoan : Form
    {

        Login log = new Login();

        public frmKiemTraTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmKiemTraTaiKhoan_Load(object sender, EventArgs e)
        {
            pnKiemTra.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
        }

        private bool kiemTra()
        {
            if (log.XacThuc(txtUserName.Text, txtPhone.Text))
            { 
                return true;
            }

            MessageBox.Show("Thông tin tài khoản không khớp.");
            return false;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPhone.Text == "" )
            {
                MessageBox.Show("Vui lòng không bỏ trống thông tin kiểm tra tài khoản!");
            }
            else if (kiemTra())
            {
                frmDoiMatKhau frm = new frmDoiMatKhau(txtUserName.Text);
                this.Hide();
                frm.Show();
            }
        }

    }
}
