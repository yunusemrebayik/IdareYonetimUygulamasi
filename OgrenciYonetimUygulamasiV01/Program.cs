using System;
using System.Collections.Generic;
using System.Drawing;

namespace OgrenciYonetimUygulamasiV01
{
    class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>(); //Tüm metotlardan ulaşabilmemiz için bu listeyi sınıfın en üstünden yarattık. 
        static bool durum = true;

        static void Main(string[] args)
        {
            Ornekler();
            Uygulama(); // Main metodunun boş olmasını istiyoruz. 
        }

        static void Ornekler()
        {

            Ogrenci ogr = new Ogrenci();
            ogr.Ad = "Ali";
            ogr.Soyad = "Veli";
            ogr.No = 568;
            ogr.Sube = "A";
            ogr.DogumYili = 1995;
            ogrenciler.Add(ogr);
            ogr.YasHesapla();

            Console.WriteLine("Alinin yasi; " + ogr.Yas);

            Ogrenci ogr2 = new Ogrenci();
            ogr2.Ad = "Feyza";
            ogr2.Soyad = "Kiranlioglu";
            ogr2.Sube = "B";
            ogr2.DogumYili = 1923;
            ogr2.No = 56;
            ogr2.Yas = ogr2.YasHesapla(ogr2.DogumYili);

            ///Console.WriteLine(ogr2.Yas);

            ogr2.MatematikNotu = 75;
            ogr2.FenNotu = 40;
            ogr2.SosyalNotu = 60;
            ogr2.TurkceNotu = 89;

            ogr2.OrtalamaYazdir();

        }
        static void Uygulama()
        {
            SahteVeriEkle(); // Program başlarken sahte veri dolduruyoruz. 
            Menu();

            
            while (durum)
            {

                
                string giris = SecimAl();

                switch (giris)
                {

                    case "E":
                    case "1":
                        OgrenciEkle();
                        break;
                    case "L":
                    case "2":
                        OgrenciListele();
                        break;
                    case "S":
                    case "3":
                        OgrenciSil();
                        break;
                    case "X":
                    case "4":
                        //return da olur ama eger mainde baska bir sey varsa cikmaz
                        // Environment.Exit(0);
                        durum = false;                     
                        break;
                    default:
                        
                        Console.WriteLine("Hatalı giriş yaptınız, tekrar deneyin.");
                        break;
                }
                Console.WriteLine();
            }
        
        }

        static void Menu()
        {
            
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1- Öğrenci Ekle (E)");
            Console.WriteLine("2- Öğrenci Listele (L)");
            Console.WriteLine("3- Öğrenci Sil (S)");
            Console.WriteLine("4- Çıkış (X)");
            Console.WriteLine();
        
        }

        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();

            Console.WriteLine("1- Öğrenci Ekle ----------");
            Console.WriteLine((ogrenciler.Count+1) + ". Öğrencinin");
            int no;
            do
            {

                Console.Write("No: ");
                no = int.Parse(Console.ReadLine());

            } while (OgrenciVarMi(no) == true);

            o.No = no; 
            Console.Write("Adı: ");
            o.Ad = IlkHarfBuyut(Console.ReadLine());
            Console.Write("Soyadı: ");
            o.Soyad = IlkHarfBuyut(Console.ReadLine());
            Console.Write("Şubesi: ");
            o.Sube = IlkHarfBuyut(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)");
            string secim = Console.ReadLine().ToUpper();

            if (secim == "E")
            {

                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci Eklendi.");

            }
            else 
            {

                Console.WriteLine("Öğrenci Eklenmedi.");
            
            }

            Console.WriteLine();

        }

        static void OgrenciListele()
        {

            Console.WriteLine("2- Öğrenci Listele ----------");
            Console.WriteLine();
            
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");
                return;
            }
            
            
            Console.WriteLine("Şube".PadRight(8) + "No".PadRight(6) + "Ad Soyad");
            Console.WriteLine("----------------------------------");
            foreach (Ogrenci item in ogrenciler)
            {

                Console.WriteLine(item.Sube.PadRight(8) + item.No.ToString().PadRight(6) + item.Ad + " " + item.Soyad);
            
            }
        
        }

        static void OgrenciSil()
        {

            Console.WriteLine("3- Öğrenci Sil ----------");

            if (ogrenciler.Count == 0)
            {

                Console.WriteLine("Listede silinecek öğrenci yok.");
                return; /// bunu gordugu an metodtan cikar.

            }

            Console.WriteLine("Silmek istediğiniz öğrencinin");
            Console.Write("No: ");
            int no = int.Parse(Console.ReadLine());

            Ogrenci ogr = null;

            foreach (Ogrenci item in ogrenciler)
            {

                if (item.No == no)
                {

                    ogr = item;
                    break;
                
                }
            
            }


            if (ogr != null)
            {
                Console.WriteLine("Adı: " + ogr.Ad);
                Console.WriteLine("Soyadı: " + ogr.Soyad);
                Console.WriteLine("Şubesi: " + ogr.Sube);
                Console.WriteLine();
                Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H)");
                string secim = Console.ReadLine().ToUpper();

                if (secim == "E")
                {

                    ogrenciler.Remove(ogr);
                    Console.WriteLine("Öğrenci Silindi.");

                }
                else 
                {

                    Console.WriteLine("Öğrenci Silinemedi.");

                }

            }
            else 
            {

                Console.WriteLine("Böyle bir öğrenci bulunamadı.");


            }

        }

        static void SahteVeriEkle()
        {

            Ogrenci o1 = new Ogrenci();
            o1.Ad = "Yunus Emre";
            o1.Soyad = "Bayık";
            o1.No = 1;
            o1.Sube = "A";
            ogrenciler.Add(o1);

            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Meltem";
            o2.Soyad = "Gökce";
            o2.No = 2;
            o2.Sube = "B";
            ogrenciler.Add(o2);

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Ahmet";
            o3.Soyad = "Koci";
            o3.No = 3;
            o3.Sube = "C";
            ogrenciler.Add(o3);


            Ogrenci o4 = new Ogrenci(45, "a" , "Hilal", "Milal", "kadin");
            ogrenciler.Add(o4);

        }

        static string SecimAl()
        {
            string karakterler = "ELSX1234";
            int sayac = 0;

            while (true)
            {
                
                
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine().ToUpper();

                int gecersiz = karakterler.IndexOf(giris);
                
                Console.WriteLine();

                if (giris.Length == 1 && gecersiz >= 0 )
                {
                    sayac = 0; 
                    return giris;
                   

                }
                else
                {

                    sayac++;
                    if (sayac == 10)
                    {
                        
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum.Program sonlandırılıyor.");
                        return "4";
                       // or // Environment.Exit(0);

                    }
                   
                    Console.WriteLine("Hatalı giriş yapıldı.");
                    
                }



            }

        }

        static string IlkHarfBuyut(string metin)
        {

            return metin.Substring(0, 1).ToUpper() + metin.Substring(1).ToLower();

        }

        static bool OgrenciVarMi(int no)
        {

            foreach (Ogrenci item in ogrenciler)
            {
                if (item.No == no)
                {
                    Console.WriteLine("Bu numaraya sahip ogrenci var...");
                    return true;

                }

            }
            return false;
        }

    }
}
