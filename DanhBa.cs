using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    [Serializable]
    class DanhBa : Nguoi
    {
        private string sdt1, sdt2, email, ghiChu;
        public DanhBa()
        {

        }

        public DanhBa(string ho, string tenDem, string ten, string namSinh, bool gioiTinh,string sdt1, string sdt2, string email, string ghiChu) : base(ho,tenDem,ten,namSinh,gioiTinh)
        {
            this.Sdt1 = sdt1;
            this.Sdt2 = sdt2;
            this.Email = email;
            this.GhiChu = ghiChu;
        }

        public string Sdt1 { get => sdt1; set => sdt1 = value; }
        public string Sdt2 { get => sdt2; set => sdt2 = value; }
        public string Email { get => email; set => email = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public override string ToString()
        {
            string str = String.Format($" Họ: {Ho} | Tên đệm: {TenDem} | Tên: {Ten} | Năm sinh: {NamSinh} | Giới tính: {(GioiTinh?"Nam":"Nữ")} | SDT1: {Sdt1} " +
                                      $"| SDT2: {Sdt2} | Emai: {Email} | Ghi chú: {GhiChu}");
            return str;
        }
        public override void print()
        {
            Console.WriteLine(ToString());
        }
    }
}
