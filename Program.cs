using System.Linq;
using System.Transactions;

namespace basic_program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] arr= new string[3, 3];
            string[] menu_cart = new string[] {};
            int[] harga_cart = new int[] {};
            int[] banyak_cart = new int[] {};
            MenuUtama(menu_cart,banyak_cart, harga_cart);
           
        }


        /*
        * Penerapan If Else dengan menggunakan method CheckDiscount
        * 
        */

        static float CheckDiscount(float checkdiscount)
        {
            float x = 0;
            if ((checkdiscount > 50000) && (checkdiscount <= 100000))
            {
                x = checkdiscount * 0.05F;
            }
            else if (checkdiscount > 100000)
            {
                x = checkdiscount * 0.1F;
            }
            else
            {
                x = 0;
            }
            checkdiscount = x;
            return checkdiscount;
        }

        static void PrintInvoice()
        {
            Console.Clear();
            Console.WriteLine("INV/20221206/MPL/2876688425");
        }

        static (string[], int[], int[]) MenuUtama(string[] menu_cart,int[] banyak_cart, int[] harga_cart )
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
            switch (menu)
            {
                case 1:
                    PrintMenu(menu_cart,banyak_cart, harga_cart);
                    break;
                case 2:
                    PrintKeranjang(menu_cart,banyak_cart, harga_cart);
                    break;
                case 3:
                    Console.WriteLine("Keranjang Telah Dibersihkan");
                    break;
                case 4:
                    PrintInvoice();
                    break;
            }
            return (menu_cart, banyak_cart, harga_cart);
        }
        static (string[], int[]) PrintMenu(string[] menu_cart,int[] banyak_cart, int[] harga_cart)
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
            string[] temp_nama = new string[] { };
            int[] temp_banyak = new int[] { };
            int[] temp_harga = new int[] { };
            (temp_nama, temp_banyak, temp_harga) = SaveCart(menu, banyak);

            menu_cart = menu_cart.Append(temp_nama[0]).ToArray();
            banyak_cart = banyak_cart.Append(temp_banyak[0]).ToArray();
            harga_cart = harga_cart.Append(temp_harga[0]).ToArray();

            PrintKeranjang(menu_cart,banyak_cart, harga_cart);

            return (menu_cart, harga_cart);
        }


        static void PrintKeranjang(string[] menu_cart, int[] banyak_cart, int[] harga_cart)
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
            switch (menu)
            {
                case 1:
                    MenuUtama(menu_cart, banyak_cart, harga_cart);
                    break;
                case 2:
                    PrintMenu(menu_cart, banyak_cart, harga_cart);
                    break;
                case 3:
                    PrintInvoice();
                    break;
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

    }
}