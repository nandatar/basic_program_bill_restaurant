namespace basic_program
{
    public class Program
    {
        static string[,] arr = {};
        static string[] menu_cart =  { };
        static int[] harga_cart =  { };
        static int[] banyak_cart =  { };
        public static void Main(string[] args)
        {         
            MenuUtama();
        }


        static void PrintInvoice()
        {
            Console.WriteLine("INV/20221206/MPL/2876688425");
        }

        static void MenuUtama()
        {
            Console.Clear();
            Console.WriteLine("     SELAMAT DATANG DI RUMAH MAKAN ABCD    ");
            Console.WriteLine("");
            Console.WriteLine("1. PESAN MAKANAN                           ");
            Console.WriteLine("2. LIHAT KERANJANG                         ");
            Console.WriteLine("3. RESET KERANJANG                         ");
            Console.WriteLine("4. CHECKOUT                                ");
            Console.WriteLine("");
            Console.WriteLine("MASUKAN PILIHAN (1-4) ");
            int menu = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (menu)
                {
                    
                    case 1:
                        PrintMenu();
                        break;
                    case 2:
                        PrintKeranjang();
                        break;
                    case 3:
                        ResetCart();
                        break;
                    case 4:
                        CheckOut();
                        break;
                    default:
                        Console.WriteLine("ERROR : Input Not Valid");
                        Console.ReadKey();
                        MenuUtama();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                MenuUtama();
            }
     
        }
        static void PrintMenu()
        {
            Console.Clear();
            //kode untuk menampilkan informasi menu          
            Console.WriteLine("                 MENU MAKANAN                     ");
            Console.WriteLine("1. Ayam Geprek + Nasi              Rp.25.0000     ");
            Console.WriteLine("2. Ayam Bakar + Nasi               Rp.27.0000     ");
            Console.WriteLine("3. Nasi Goreng Komplit             Rp.33.0000     ");
            Console.WriteLine("4. Pecel Lele + Nasi               Rp.24.0000     ");
            Console.WriteLine("5. Bebek Goreng+ Nasi              Rp.30.0000     ");
            Console.WriteLine("");

            Console.WriteLine("Masukan Nomor Menu");
            int menu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Banyak Pesanan");
            int banyak = Convert.ToInt32(Console.ReadLine());

            string[] temp_nama = { };
            int[] temp_banyak = { };
            int[] temp_harga =  { };
            (temp_nama, temp_banyak, temp_harga) = SaveCart(menu, banyak);

            menu_cart = menu_cart.Append(temp_nama[0]).ToArray();
            banyak_cart = banyak_cart.Append(temp_banyak[0]).ToArray();
            harga_cart = harga_cart.Append(temp_harga[0]).ToArray();
            PrintKeranjang();
        }


        static void PrintKeranjang()
        {
            int sum = 0;
            sum = harga_cart.Sum();
            Console.Clear();
            Console.WriteLine("         KERANJANG         ");
            Console.WriteLine("");
            Console.WriteLine("Nama Menu" + "\t" +"\t" + "|Banyak" + "\t" + "|Harga");

            for (int i=0; i<menu_cart.Length; i++) 
            {
                Console.Write(menu_cart[i] + "\t|");
                Console.Write(banyak_cart[i] +"x"+"\t|"+"Rp.");
                Console.WriteLine(harga_cart[i]); 
            }
            Console.WriteLine("\t" + "TOTAL" + "\t" + "\t" + "\t|Rp." + sum);
            Console.WriteLine(" ");
            Console.WriteLine("1. Kembali Ke Menu Utama");
            Console.WriteLine("2. Pesan Lagi");
            Console.WriteLine("3. CheckOut");
            Console.WriteLine("MASUKAN PILIHAN (1-3) ");
            int menu = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (menu)
                {
                    case 1:
                        MenuUtama();
                        break;
                    case 2:
                        PrintMenu();
                        break;
                    case 3:
                        CheckOut();
                        break;
                    default:
                        Console.WriteLine("ERROR : Input Not Valid");
                        Console.ReadKey();
                        PrintKeranjang();
                        break;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                PrintKeranjang();
            }
            

        }

        static (string[], int[], int[]) SaveCart(int menu, int banyak)
        {
            string[] list_menu = { "Ayam Geprek + Nasi", "Ayam Bakar + Nasi ", "Nasi Goreng Komplit", "Pecel Lele + Nasi", "Pecel Lele + Nasi", "Bebek Goreng+ Nasi" };
            int[] list_harga = { 25000, 27000, 33000, 24000, 30000 };
            string[] menu_cart = new string[]{};
            int[] banyak_cart = new int []{};
            int[] harga_cart = new int[] {};
            menu_cart = menu_cart.Append(list_menu[menu - 1]).ToArray();
            banyak_cart = banyak_cart.Append(banyak).ToArray();


            //menjumlahkan harga berdasarkan jumlah dari 'banyak'
            int y = list_harga[menu-1];
            int x = 0;
            for (int i = 0; i < banyak; i++) 
            {
                x += y;
            }
            y = x;
            harga_cart = harga_cart.Append(y).ToArray();

            return (menu_cart, banyak_cart, harga_cart);
        }

        static void ResetCart()
        {
            menu_cart = new string[] { };
            banyak_cart = new int[] { };
            harga_cart = new int[] { };
            Console.WriteLine("Keranjang Telah Di Reset");
            Console.ReadKey();
            MenuUtama();
        }

        static void CheckOut()
        {
            Console.Clear();
            Console.WriteLine("===============CHECKOUT==============");
            int sum = 0;
            sum = harga_cart.Sum();
            Console.WriteLine("");
            Console.WriteLine("Nama Menu" + "\t" + "\t" + "|Banyak" + "\t" + "|Harga");

            for (int i = 0; i < menu_cart.Length; i++)
            {
                Console.Write(menu_cart[i] + "\t|");
                Console.Write(banyak_cart[i] + "x" + "\t|" + "Rp.");
                Console.WriteLine(harga_cart[i]);
            }
            Console.WriteLine("\t" + "TOTAL" + "\t" + "\t" + "\t|Rp." + sum);
            Console.WriteLine(" ");
            Console.Write("Masukkan Jumlah Uang : ");
            int bayar = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (bayar >= sum)
                {
                    Console.WriteLine("===========Pembayaran===========");
                    Console.WriteLine("| Total Belanja\t:" + sum + "\t |");
                    Console.WriteLine("| Bayar   \t: " + bayar + "\t |");
                    Console.WriteLine("| Kembalian  \t: " + (bayar - sum) + "\t |");
                    PrintInvoice();
                    ResetCart();
                    Console.ReadKey();
                    MenuUtama();
                }
                else
                {
                    Console.WriteLine("Uang Anda Kurang/Input Salah");
                    Console.ReadKey();
                    CheckOut();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Uang Anda Kurang/Input Salah");
                Console.ReadKey();
                CheckOut();
            }
        }   
    }
}