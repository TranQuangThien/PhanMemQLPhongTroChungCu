using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_Lý_Phòng_Trọ_Chung_Cư.Class
{
    class User
    {

        //Khởi tạo biến giá trị.
        private string tenTK, tenUser;
        private int phanQuyen;

        //Hàm xử lý getter và setter
        public string UserName { get => tenTK; set => tenTK = value; }
        public string TenTK { get => tenUser; set => tenUser = value; }
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }

        //Khởi tạo mặc định của class.
        public User()
        {
            this.UserName = "tqthien";
            this.TenTK = "";
            this.PhanQuyen = 1;
        }

        public User(User user)
        {
            this.UserName = user.UserName;
            this.TenTK = user.TenTK;
            this.PhanQuyen = user.PhanQuyen;
        }

        //Hàm gán giá trị user sau khi đăng xuất.
        public void dangXuat()
        {
            this.UserName = "";
            this.TenTK = "";
            this.PhanQuyen = 0;
        }

    }
}
