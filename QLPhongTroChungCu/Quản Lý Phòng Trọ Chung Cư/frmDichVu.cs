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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
        }

        //Khai báo biến
        string text;
        DichVuCtrl dvctrl = new DichVuCtrl();
        //Gắn Dữ liệu
        private void GanDuLieu(DichVu dv)
        {
            dv.Madv = dvctrl.GetID() + 1;
            dv.Tendv = txtTenDV.Text;
            dv.Dongia = Convert.ToInt32(txtDonGia.Text);
            
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

            if (txtTenDV.Text == "")
            {
                text = "Vui lòng nhập tên dịch vụ!";
                ThongBao(text);
                ktra = false;
            }
            else if (txtDonGia.Text == "")
            {
                text = "Vui lòng nhập Số Tiền!";
                ThongBao(text);
                ktra = false;
            }
            return ktra;
        }

        //chức năng làm mới
        private void LamMoi()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtDonGia.Clear();
            dvctrl.HienThi(dgvDichVu);
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

        }

        //Chức năng hiển thị thông tin
        private void HienThiThongTin()
        {

            if (dgvDichVu.CurrentRow != null)
            {
                txtMaDV.Text = dgvDichVu.CurrentRow.Cells["MaDichVu"].Value.ToString();
                txtTenDV.Text = dgvDichVu.CurrentRow.Cells["TenDichVu"].Value.ToString();
                txtDonGia.Text = dgvDichVu.CurrentRow.Cells["DonGia"].Value.ToString();
               
            }

        }

        //Chức năng thêm
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (KiemTra())
            {
                DichVu dv = new DichVu();
                GanDuLieu(dv);


                dvctrl.Them(dv);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
            }
        }

        //Chức năng load form
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            
            dvctrl.HienThi(dgvDichVu);
            HienThiThongTin();
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

        }


        //Chức năng làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        //chức năng click từng dịch vụ trong DataGridView
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            HienThiThongTin();
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            DichVu dv = new DichVu();
            dv.Madv = Convert.ToInt32(txtMaDV.Text) ;
            dv.Tendv = txtTenDV.Text;
            dv.Dongia = Convert.ToInt32(txtDonGia.Text);

            string madv = dgvDichVu.CurrentRow.Cells[0].Value.ToString();

            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn đổi dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                dvctrl.Luu(dv);
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvctrl.HienThi(dgvDichVu);
                    HienThiThongTin();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvDichVu.CurrentRow != null)
            {
                string makv = dgvDichVu.CurrentRow.Cells[0].Value.ToString();

                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    dvctrl.Xoa(makv);
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dvctrl.HienThi(dgvDichVu);
                    }
                }

            }
        }
    }
}
