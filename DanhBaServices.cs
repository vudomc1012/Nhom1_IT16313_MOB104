using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class DanhBaServices
    {
        private List<DanhBa> lstDanhBa;
        FileStream fs;
        BinaryFormatter bf;
        string input = "", input2, user;
        private DanhBa regis;

        public DanhBaServices()
        {
            lstDanhBa = new List<DanhBa>();
            regis = new DanhBa("Nguyen", "Van", "Anh", "2000", true, "0987654321", "0123456789", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Nguyen", "Thi", "Binh", "2000", false, "0135792468", "0975318642", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Dao", "Minh", "Chien", "2000", true, "0998877665", "01223344556", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Pham", "Thi Ngoc", "Diep", "2000", false, "0192837465", "0918273645", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Tran", "Thu", "Ha", "2000", false, "0987987987", "0123123123", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Nguyen", "Van", "Khanh", "2000", true, "0987876765", "0123234345", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Vu", "Khanh", "Linh", "2000", false, "0321123321", "0876678876", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Nguyen", "Van", "Minh", "2000", true, "0191191919", "08282828828", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Nguyen", "Van", "Nguyen", "2000", true, "0101010101", "0011000010", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
            regis = new DanhBa("Le", "Ngpc", "Phuong", "2000", false, "0111111111", "0546732891", "NotAnEmail@NotASyte.com", "Test");
            lstDanhBa.Add(regis);
        }

        private string getInput(string mess)
        {
            Console.WriteLine("Nhap " + mess);
            return Console.ReadLine();
        }
        private int getIndex(string sdt)
        {
            try
            {
                for (int i = 0; i < lstDanhBa.Count; i++)
                {
                    if (lstDanhBa[i].Sdt1 == sdt || lstDanhBa[i].Sdt2 == sdt)
                    {
                        return i;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong Tim Thay SDT Ban Muon Tim");

            }
            return -1;
        }


        public void addReg()
        {
            try
            {
                do
                {
                    input = getInput("So Luong: ");
                    for (int i = 0; i < Convert.ToInt32(input); i++)
                    {
                        regis = new DanhBa();
                        do
                        {
                            regis.Ho = getInput("Ho: ");
                        } while (regis.Ho.Any(char.IsDigit));
                        do
                        {
                            regis.TenDem = getInput("Ten Dem: ");
                        } while (regis.TenDem.Any(char.IsDigit));
                        do
                        {
                            regis.Ten = getInput("Ten: ");
                        } while (regis.Ten.Any(char.IsDigit));
                        do
                        {
                            regis.NamSinh = (getInput("Nam Sinh: "));
                        } while (!regis.NamSinh.All(char.IsDigit) || Convert.ToInt32(regis.NamSinh) < 1980 || Convert.ToInt32(regis.NamSinh) > 2022);

                        do
                        {
                            input2 = getInput("Gioi Tinh (Nam - 1 | Nu = 2): ");
                            if (input2 == "1")
                            {
                                regis.GioiTinh = true;
                            }
                            else { regis.GioiTinh = false; }
                        } while (input2 != "1" && input2 != "2");
                        do
                        {
                            regis.Sdt1 = getInput("So Dien Thoai 1: ");
                        } while (regis.Sdt1.Length > 11);
                        do
                        {
                            regis.Sdt2 = getInput("So Dien Thoai 2: ");
                        } while (regis.Sdt2.Length > 11);
                        regis.Email = getInput("Email");
                        regis.GhiChu = getInput("Ghi chu");
                        lstDanhBa.Add(regis);
                    }
                    Console.WriteLine("Ban co muon nhap tiep?(y/n)");
                    input = Console.ReadLine();
                } while (input == "y");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Thong Tin Khong Dung!");
            }

        }

        public void updateReg()
        {
            int i;
            do
            {
                i = getIndex(getInput("So Dien Thoai Muon Sua: ")); 
            } while (i == -1) ;


            do
            {
                try
                {
                    Console.WriteLine("******MENU******");
                    Console.WriteLine("1. Ten");
                    Console.WriteLine("2. SDT1");
                    Console.WriteLine("3. SDT2");
                    Console.WriteLine("4. Email");
                    Console.WriteLine("5. Thong tin ca nhan");
                    Console.WriteLine("6. Ghi chu");
                    Console.WriteLine("0. Hoan thanh");
                    user = Console.ReadLine();
                    switch (Convert.ToInt32(user))
                    {
                        case 1:
                            lstDanhBa[i].Ho = getInput("Ho: ");
                            lstDanhBa[i].TenDem = getInput("Ten Dem: ");
                            lstDanhBa[i].Ten = getInput("Ten: ");
                            break;

                        case 2:
                            lstDanhBa[i].Sdt1 = getInput("So Dien Thoai 1: ");
                            break;

                        case 3:
                            lstDanhBa[i].Sdt1 = getInput("So Dien Thoai 2: ");
                            break;

                        case 4:
                            lstDanhBa[i].Email = getInput("Email");
                            break;

                        case 5:
                            lstDanhBa[i].Ten = getInput("Ten: ");
                            lstDanhBa[i].NamSinh = getInput("Nam Sinh: ");
                            do
                            {
                                input = getInput("Gioi Tinh (Nam - m | Nu = f): ");
                                if (input == "m")
                                {
                                    lstDanhBa[i].GioiTinh = true;
                                }
                                else { lstDanhBa[i].GioiTinh = false; }
                            } while (input != "m" && input != "f");
                            break;

                        case 6:
                            lstDanhBa[i].GhiChu = getInput("Ghi chu");
                            break;



                        case 0:
                            Console.WriteLine("Sua thanh cong");
                            return;

                        default:
                            Console.WriteLine("Khong co chuc nang nay");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Khong ton tai");
                }
            }
            while (true);
        }

       



        public void delReg()
        {
            int i;
            do
            {
                i = getIndex(getInput("So Dien Thoai Muon Xoa: ")); 
            } while (i == -1);
            lstDanhBa.RemoveAt(i);
            Console.WriteLine("Xoa Thanh Cong!");
        }

        public void printReg()
        {
            foreach(var x in lstDanhBa)
            {
                x.print();
            }
        }

        public void sortByAlphabet()
        {
            input = "0";
            do
            {
                Console.WriteLine("1. Tang dan");
                Console.WriteLine("2. Giam dan");
                Console.WriteLine("Ban Chon: ");
                input = Console.ReadLine(); 
            } while (Convert.ToInt32(input) != 1 && Convert.ToInt32(input) != 2);
            if (Convert.ToInt32(input) == 1)
            {
                var query = lstDanhBa.OrderBy(regis => regis.Ten).ThenBy(regis => regis.TenDem).ThenBy(regis => regis.Ho);
                foreach (DanhBa regis in query)
                {
                    regis.print();
                } 
            } else
            {
                var query = lstDanhBa.OrderByDescending(regis => regis.Ten).ThenByDescending(regis => regis.TenDem).ThenByDescending(regis => regis.Ho);
                foreach (DanhBa regis in query)
                {
                    regis.print();
                }
            }
        }

        public void filterByProvider()
        {
            do
            {
                Console.WriteLine("Chọn nhà mạng:");
                Console.WriteLine("1. Viettel");
                Console.WriteLine("2. Vina");
                Console.WriteLine("3. Mobifone");
                Console.WriteLine("4. Vietnamoble");
                Console.WriteLine("0. Quay lại");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt1.StartsWith("09")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt1.StartsWith("03")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt1.StartsWith("01")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt2.StartsWith("09")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt2.StartsWith("03")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt2.StartsWith("01")))
                        {
                            x.print();
                        }

                        break;
                    case "2":
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt1.StartsWith("08")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt2.StartsWith("08")))
                        {
                            x.print();
                        }
                        break;
                    case "3":
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt1.StartsWith("07")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt2.StartsWith("07")))
                        {
                            x.print();
                        }
                        break;
                    case "4":
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt1.StartsWith("05")))
                        {
                            x.print();
                        }
                        foreach (var x in lstDanhBa.Where(regis => regis.Sdt2.StartsWith("05")))
                        {
                            x.print();
                        }
                        break;
                    case "0":
                        break;
                }
            } while (!(input == "0"));

        }

        public void filterByAlphabet()
        {
            do
            {
                input = getInput("Chu cai dau cua ten: "); 
            } while (input.Length != 1);
            var query = from regis in lstDanhBa
                        where regis.Ten.ToLower().StartsWith(input.ToLower())
                        select regis;
            foreach (DanhBa regis in query)
            {
                regis.print();
            }
        }

        public void filterByName()
        {
            input = getInput("Ten ban muon tim");
            var quer = from regis in lstDanhBa
                       where regis.Ten.ToLower().Equals(input.ToLower())
                       select regis;
            foreach(DanhBa regis in quer)
            {
                regis.print();
            }
        }

        public void filterByGender()
        {
            input = "";
            bool gender;
            do
            {
                input = getInput("Gioi Tinh (Nam - m | Nu - f): "); 
            } while (input != "m" && input != "f");
            if(input == "m")
            {
                gender = true;
            } else
            {
                gender = false;
            }
            var queey = from regis in lstDanhBa
                        where regis.GioiTinh.Equals(gender)
                        select regis;
        }
        public void GhiFile(List<DanhBa> lsStudents, string path)
        {
            fs = new FileStream(path, FileMode.Create);
            bf = new BinaryFormatter();
            bf.Serialize(fs, lstDanhBa);//Serialize Tuần tự hóa hoặc tuần tự hóa là quá trình dịch cấu trúc dữ liệu hoặc trạng thái đối tượng sang định dạng có thể được lưu trữ hoặc truyền và tái tạo lại sau này.
            fs.Close();
            Console.WriteLine("Ghi file thành công");
        }

        public List<DanhBa> getList()
        {
            return lstDanhBa;
        }

        public void DocFile(string path)
        {
            lstDanhBa = new List<DanhBa>();
            fs = new FileStream(path, FileMode.Open);
            bf = new BinaryFormatter();
            var data = bf.Deserialize(fs);//Đọc đối tượng lên
            lstDanhBa = (List<DanhBa>)data;//Gán lại List object cho List Student
            fs.Close();
        }

        public void filterByNameClose()
        {
            input = getInput("Ten ban muon tim");
            var quer = from regis in lstDanhBa
                       where regis.Ten.ToLower().Contains(input.ToLower())
                       select regis;
            foreach (DanhBa regis in quer)
            {
                regis.print();
            }
        }

        public void filterByPhoneClose()
        {
            input = getInput("SDT ban muon tim");
            var quer = from regis in lstDanhBa
                       where regis.Sdt1.Contains(input) || regis.Sdt2.Contains(input)
                       select regis;
            foreach (DanhBa regis in quer)
            {
                regis.print();
            }
        }
    }
}
