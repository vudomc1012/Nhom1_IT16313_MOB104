using System;
using System.Text;

namespace Assignment
{
    public delegate void dele();

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            string path = @"E:\College\College_C#2\VunmhPH16830_IT16313_NET102\Assignment\PhoneList.bin";
            DanhBaServices pl = new DanhBaServices();
            string user = null;
            bool saved = true;
            dele gate = null;
            do
            {
                try
                {
                    Console.WriteLine("******MENU******");
                    Console.WriteLine("1. Them Danh Ba");
                    Console.WriteLine("2. In Danh Ba");
                    Console.WriteLine("3. Xoa Danh Ba");
                    Console.WriteLine("4. Cap nhat Danh Ba");
                    Console.WriteLine("5. Sap Xep Danh Ba");
                    Console.WriteLine("6. Loc Danh Ba");
                    Console.WriteLine("7. Luu Danh Ba");
                    Console.WriteLine("8. Load Danh Ba");
                    Console.WriteLine("9. Tim Kiem Gan Dung");
                    Console.WriteLine("0. Thoat");
                    Console.WriteLine("Moi chon chuc nang: ");
                    user = Console.ReadLine();
                    switch (Convert.ToInt32(user))
                    {
                        case 1:
                            saved = false;
                            gate = pl.addReg;
                            gate();
                            break;

                        case 2:
                            gate = pl.printReg;
                            gate();
                            break;

                        case 3:
                            saved = false;
                            gate = pl.delReg;
                            gate();
                            break;

                        case 4:
                            saved = false;
                            gate = pl.updateReg;
                            gate();
                            break;

                        case 5:
                            gate = pl.sortByAlphabet;
                            gate();
                            break;

                        case 6:
                            Console.WriteLine("1. THEO BẢNG CHỮ CÁI ");
                            Console.WriteLine("2. THEO TÊN");
                            Console.WriteLine("3. THEO GIỚI TÍNH");
                            Console.WriteLine("4. THEO NHÀ MẠNG");
                            Console.WriteLine("0. Quay lai");
                            Console.WriteLine("Ban Chon: ");
                            user = Console.ReadLine();
                            switch (Convert.ToInt32(user))
                            {
                                case 1:
                                    gate = pl.filterByAlphabet;
                                    gate();
                                    break;

                                case 2:
                                    gate = pl.filterByName;
                                    gate();
                                    break;

                                case 3:
                                    gate = pl.filterByGender;
                                    gate();
                                    break;

                                case 4:
                                    gate = pl.filterByProvider;
                                    gate();
                                    break;

                                case 0:
                                    break;
                            }

                            break;

                        case 7:
                            saved = true;
                            pl.GhiFile(pl.getList(), path);
                            break;

                        case 8:
                            saved = true;
                            pl.DocFile(path);
                            break;

                        case 9:
                            Console.WriteLine("1. THEO SDT ");
                            Console.WriteLine("2. THEO TÊN");
                            Console.WriteLine("0. Quay lai");
                            Console.WriteLine("Ban Chon: ");
                            user = Console.ReadLine();
                            switch (Convert.ToInt32(user))
                            {
                                case 1:
                                    gate = pl.filterByPhoneClose;
                                    gate();
                                    break;

                                case 2:
                                    gate = pl.filterByNameClose;
                                    gate();
                                    break;

                                case 0:
                                    break;
                            }
                            break;

                        case 0:
                            if (!saved)
                            {
                                do
                                {
                                    Console.WriteLine("File da thay doi. Ban co muon luu?(y/n):");
                                    user = Console.ReadLine();
                                    if (user.ToLower() == "y") pl.GhiFile(pl.getList(), path);
                                } while (user.ToLower() != "y" && user.ToLower() != "n");
                            }
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
    }
}