using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokoHPIntan
{
    public class Handphone
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Harga { get; set; }
        public int Stok { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //====3====== membuat hashSet berupa toko-toko yang berada di kota-kota tertentu
            HashSet<String> toko = new HashSet<String>();

            toko.Add("Jakarta");
            toko.Add("Bandung");
            toko.Add("Surabaya");
            toko.Add("Palembang");
            toko.Add("Makasar");

            //menampilkan daftar tempat toko-toko
            Console.WriteLine("------Selamat Datang di Toko Intan------\n\nCabang toko kami berada di\n-------------------------");

            for (int i = 0; i < toko.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + toko.ElementAt(i));
            }

            //membuat objek Handphones dengan list
            //===5===
            List<Handphone> Handphones = new List<Handphone>()
            {
                new Handphone {Name= "iphone", Color= "Red", Harga = 500, Stok = 10},
                new Handphone {Name= "samsung", Color= "White", Harga = 300, Stok = 30},
                new Handphone {Name= "oppo", Color= "Red", Harga = 250, Stok = 40 },
                new Handphone {Name= "vivo", Color= "White", Harga = 200, Stok = 25 }
            };
            Handphones.Add(new Handphone { Name = "luna", Color = "Black", Harga = 100, Stok = 30 });
            Handphones.Add(new Handphone { Name = "nokia", Color = "Green", Harga = 150, Stok = 50 });

            //menampilkan hp-hp dan detailnya
            Console.WriteLine("\nBerikut ini handphone-handphone yang tersedia di toko kami: \n----------------------------------");
            Console.WriteLine("Merk || Warna || Harga || Stok\n-------------------------");
            foreach (var hp in Handphones)
                Console.WriteLine(hp.Name + " " + hp.Color + " Rp." + hp.Harga + " " + hp.Stok);

            //===6=== dengan method & qury syntax
            //untuk menentukan hp dengan harga termurah
            Console.WriteLine("\n-------Penawaran Menarik--------\n");
            var hargaMin = Handphones.Min(hp => hp.Harga);
            var nameMin = from Handphone in Handphones where Handphone.Harga == hargaMin select Handphone;
            string resNameMin = nameMin.FirstOrDefault().Name;

            Console.WriteLine("Harga Termurah yaitu hp: " + resNameMin + " dengan harga Rp." + hargaMin + "\n");

            //untuk menentukan hp dengan stok paling sedikit
            var stokMin = Handphones.Min(hp => hp.Stok);
            var nameStokMin = from Handphone in Handphones where Handphone.Stok == stokMin select Handphone;
            string resNameStokMin = nameStokMin.FirstOrDefault().Name;

            Console.WriteLine("Limited Item: " + resNameStokMin + " dengan stok " + stokMin);

            String input = "";
            int total = 0;
            int jumlah = 0;
            var jumBeli = "";
            float totalBayar = 0;
            float totalDiskon = 0;

            //=====1=====
            while (true)
            {
                //====2====
                try
                {
                    //user menentukan hp yang akan dibeli
                    Console.WriteLine("=====================================\n\nPilih handphone yang akan dibeli: ");
                    input = Console.ReadLine();

                    //jika user ketik "quit" maka program berhenti
                    if (input.ToLower() == "quit")
                    {
                        break;
                    }

                    //===6=== dengan query syntax
                    //untuk mengecek apakan barang yang diinginkan user tersedia di daftar
                    var results = from Handphone in Handphones where Handphone.Name == input.ToLower() select Handphone;
                    string resName = results.FirstOrDefault().Name;
                    int resHarga = results.FirstOrDefault().Harga;
                    int stokHP = results.FirstOrDefault().Stok;

                    //user menentukan membeli berapa hp
                    Console.WriteLine("Beli berapa? ");
                    jumBeli = Console.ReadLine();

                    //jika user telah membeli lebih dari 3 kali (jumlah > 2 karena dimulai dari 0) maka mendapat diskon 30%
                    if (jumlah > 2)
                    {
                        //==4===
                        //mengurangi stokhp dengan jumlah yang akan dibeli user
                        stokHP = stokHP - int.Parse(jumBeli);

                        //menjumlahkan total yang harus dibayarkan -> total + (harga hp * jumlah beli)
                        total = total + (resHarga * int.Parse(jumBeli));

                        //memberikan informasi detail hp yang dibeli user
                        Console.WriteLine("\nPembelian ke " + (jumlah + 1) + " \n------Anda Membeli-----");
                        Console.WriteLine(resName + " dengan harga Rp." + resHarga + " Sebanyak " + jumBeli + " barang.\n Total yang harus kamu bayar: Rp." + total + "\nSisa Stok: " + stokHP);

                        //==4===
                        //menghitung diskon dan total bayar setelah diskon
                        totalDiskon = total * 0.3f;
                        totalBayar = total * 0.7f;
                        Console.WriteLine("Selamat kamu mendapat diskon Rp." + totalDiskon + " karena telah membeli lebih dari 3 kali\n Jadi total yang harus kamu bayar Rp." + totalBayar + " \n");
                        jumlah++;

                    }
                    //jika pembelian dibawah atau sama dengan 3 kali maka tidak mendapat diskon
                    else if (jumlah <= 3)
                    {
                        //===4====
                        //meghitung sisa stok setelah dikurangi jumlah beli
                        stokHP = stokHP - int.Parse(jumBeli);
                        //menghitung total bayar -> total + (harga * jumlah beli)
                        total = total + (resHarga * int.Parse(jumBeli));

                        //memberikan informasi detail hp yang dibeli
                        Console.WriteLine("\nPembelian ke " + (jumlah + 1) + " \n------Anda Membeli-----");
                        Console.WriteLine(resName + " dengan harga Rp." + resHarga + " Sebanyak " + jumBeli + " barang.\n Total yang harus kamu bayar: Rp." + total + "\nSisa Stok: " + stokHP);
                        jumlah++;

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Mohon input dengan benar");
                    continue; //ngulang dari atas while
                }
            }

        }
    }
}
