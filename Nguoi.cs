using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Nguoi
    {
        private string ho, tenDem, ten;
        private string namSinh;
        private bool gioiTinh;

        public Nguoi()
        {

        }

        public Nguoi(string ho, string tenDem, string ten, string namSinh, bool gioiTinh)
        {
            this.Ho = ho;
            this.TenDem = tenDem;
            this.Ten = ten;
            this.NamSinh = namSinh;
            this.GioiTinh = gioiTinh;
        }

        public string Ho { get => ho; set => ho = value; }
        public string TenDem { get => tenDem; set => tenDem = value; }
        public string Ten { get => ten; set => ten = value; }
        public string NamSinh { get => namSinh; set => namSinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        public virtual void print()
        {
            Console.WriteLine("Ho va ten: {0} | Nam sinh: {1} | Gioi Tinh: {2}",Ho + " " + TenDem + " " + Ten,NamSinh,GioiTinh?"Nam":"Nu");
        }
    }
}
