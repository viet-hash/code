using System;

namespace nopbai1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] nuoc_theo_thang = new int[12];
            double[] tien_nuoc_theo_thang = new double[12];

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("---------------------HOA DON TIEN NUOC---------------------");
                Console.WriteLine("Moi ban nhap Ho va Ten cua ban: ");
                string hoVaTen = Console.ReadLine();

                Console.WriteLine("Moi nhap ma khach hang cua ban:\n 1) Khach hang ho gia dinh \n 2) Co quan hanh chinh, dich vu cong \n 3) Don vi san xuat \n 4) Dich vu kinh doanh ");
                string khachHang = Console.ReadLine() ?? string.Empty;

                string khachHangLoai = check_khach(khachHang);
                if (khachHangLoai.Contains("khong dung"))
                {
                    Console.WriteLine(khachHangLoai);
                    continue; // Skip to next iteration if customer type is invalid
                }

                Console.WriteLine(khachHangLoai);

                Console.WriteLine("\nMoi ban nhap dia chi nha cua ban vao: ");
                string diaChi = Console.ReadLine();

                Console.WriteLine("\nMoi ban nhap so dien thoai cua ban vao: ");
                string soDienThoai = Console.ReadLine();

                Console.WriteLine("Moi ban nhap so m3 nuoc ban da su dung: ");
                if (!int.TryParse(Console.ReadLine(), out int som3))
                {
                    Console.WriteLine("Nhap khong hop le. Vui long nhap lai.");
                    i--;
                    continue;
                }

                double tienNuoc = TinhTienNuoc(khachHang, som3);
                tienNuoc = LamTronSoTien(tienNuoc, 2);
                Console.WriteLine($"\nTong so tien nuoc la {tienNuoc} VND");

                nuoc_theo_thang[i] = som3;
                tien_nuoc_theo_thang[i] = tienNuoc;

                Console.WriteLine("\nNhan phim bat ki de tiep tuc...");
                Console.ReadKey();
            }

            Console.WriteLine("\nThong ke so nuoc su dung theo thang:");
            foreach (int value in nuoc_theo_thang)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("\nThong ke tien nuoc theo thang:");
            foreach (double value in tien_nuoc_theo_thang)
            {
                Console.WriteLine(value);
            }
        }

        static double TinhTienNuoc(string khach_hang, double m3)
        {
            double money_water = 0;
            switch (khach_hang)
            {
                case "1":
                    if (m3 <= 10)
                    {
                        money_water = m3 * 5.973;
                    }
                    else if (m3 <= 20)
                    {
                        money_water = (10 * 5.973) + (m3 - 10) * 7.052;
                    }
                    else if (m3 <= 30)
                    {
                        money_water = (10 * 5.973) + (10 * 7.052) + (m3 - 20) * 8.699;
                    }
                    else
                    {
                        money_water = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + (m3 - 30) * 15.929;
                    }
                    break;

                case "2":
                    money_water = m3 * 9.955;
                    break;
                case "3":
                    money_water = m3 * 11.615;
                    break;
                case "4":
                    money_water = m3 * 22.068;
                    break;
                default:
                    money_water = 0;
                    break;
            }
            return money_water;
        }

        static double LamTronSoTien(double soTien, int soChuSoThapPhan)
        {
            return Math.Round(soTien, soChuSoThapPhan);
        }

        static string check_khach(string khach_hang)
        {
            switch (khach_hang)
            {
                case "1":
                    return "Ma khach hang cua ban la ho gia dinh";
                case "2":
                    return "Ma khach hang cua ban la co quan hanh chinh dich vu cong";
                case "3":
                    return "Ma khach hang cua ban la don vi san xuat";
                case "4":
                    return "Ma khach hang cua ban la dich vu kinh doanh";
                default:
                    return "Ma khach hang cua ban khong dung";
            }
        }
    }
}