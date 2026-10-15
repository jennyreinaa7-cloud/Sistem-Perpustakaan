using System;
using System.Collections.Generic; 

namespace DataPerpustakaan
{
    public class Item
    {
        public string Judul {get; set;}
        public int Tahun {get; set;}

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual void Deskripsi()
        {
            Console.WriteLine ($"Koleksi Umum: {Judul}");
            Console.WriteLine($"Tahun        : {Tahun}");
        }

        public void InfoItem()
        {
            Console.WriteLine($" Data Item       : {Judul}");
            Console.WriteLine($" Rilis pada tahun: {Tahun}");
        }
    }

    public class Buku : Item
    {
        public string Penulis {get; set;}

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis dari karya {Judul} adalah {Penulis}.");
        }
        public override void Deskripsi()
        {
            Console.WriteLine($"Kategori Buku Judul: {Judul}");
            Console.WriteLine($"Rilis              : {Tahun}");
            Console.WriteLine($"Penulis            : {Penulis}");
        }
    }

    public class Majalah : Item
    {
        public int Edisi {get; set;}
        public Majalah (string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine($"Majalah {Judul} edisi nomor {Edisi}.");
        }
        public override void Deskripsi()
        {
            Console.WriteLine($"Judul       :{Judul}");
            Console.WriteLine($"Edisi       :Ke-{Edisi}");
            Console.WriteLine($"Tahun       :{Tahun}");
        }
    }

    public class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void BacaSinopsis()
        {
            Console.WriteLine($"Sinopsis Novel {Judul} adalah sebuah cerita perjalanan karya {Penulis}.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Buku Novel  :{Judul}");
            Console.WriteLine($"Karya       :{Penulis}");
            Console.WriteLine($"Tahun       :{Tahun}");
        }
    }
    public class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine($"Membuka lembar ilustrasi visual untuk serial komik {Judul}.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Buku Komik {Judul} karangan {Penulis} pada {Tahun}");
        }
    }
    public class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void KategoriAnak()
        {
            Console.WriteLine($"Edisi Majalah {Judul} memuat konten kreatif untuk segmentasi anak.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Anak  : {Judul}");
            Console.WriteLine($"Edisi         : #{Edisi}");
            Console.WriteLine($"Tahun         : {Tahun}");
        }
    }

    public class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void TopikTeknologi()
        {
            Console.WriteLine($"Majalah {Judul} menampilkan pembahasan intensif mengenai bahasa pemograman klasik seperti pascal dan C++.");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"\nMajalah Teknologi :{Judul}");
            Console.WriteLine($"Tahun               :{Tahun}");
            Console.WriteLine($"Edisi               :#{Edisi}");
        }
    }

    public class Perpustakaan
    {
        private readonly List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item) => daftarItem.Add(item);

        public void DaftarItem()
        {
            foreach (var item in daftarItem)
            {
                item.Deskripsi();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan();

            Novel novel = new Novel("Doraemon", 1967, "Fujiko F");
            Komik komik = new Komik("Si Juki", 2010 , "Faza Meonk");
            Majalah majalahanak = new Majalah("Majalah Anak Islam AZKA", 2022, 90);
            MajalahTeknologi majalahteknologi = new MajalahTeknologi("Mikrodata", 1997, 1);

            perpustakaan.TambahItem(novel);
            perpustakaan.TambahItem(komik);
            perpustakaan.TambahItem(majalahanak);
            perpustakaan.TambahItem(majalahteknologi);

           
            perpustakaan.DaftarItem();

            Console.WriteLine("\nSoal 1");
            novel.Deskripsi();
            majalahanak.Deskripsi();

            Console.WriteLine("\nSoal 2");
            novel.BacaSinopsis();

            Console.WriteLine("\nSoal 3");
            Console.WriteLine($"Detail Judul:{novel.Judul}");
            Console.WriteLine($"Tahun       :{novel.Tahun}");
            Console.WriteLine($"Penulis     :{novel.Penulis}");

            Console.WriteLine("\nSoal 4");
            majalahteknologi.TopikTeknologi();

            Console.WriteLine("\nSoal 5");
            Item itemSebagaiKomik = new Komik ("Si Juki", 2010, "Faza Meonk");
            itemSebagaiKomik.Deskripsi();
        }
    }
}