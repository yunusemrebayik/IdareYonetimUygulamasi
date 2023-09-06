using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimUygulamasiV01
{
    class Ogrenci
    {
        public string Ad;
        public string Soyad;
        public string Sube;
        public int No;
        public int DogumYili;
        public int Yas;
        public string Cinsiyet;
        public int MatematikNotu;
        public int TurkceNotu;
        public int FenNotu;
        public int SosyalNotu;

        public Ogrenci(int no, string sube, string ad, string soyad, string cinsiyet)
        {

            this.No = no;
            this.Sube = sube;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Cinsiyet = cinsiyet;

            if (this.Cinsiyet == "Erkek")
            {
                Console.WriteLine(this.Ad + " Bey isimli ogrenci olusturuldu.");


            }
            else
            {

                Console.WriteLine(this.Ad + " Hanim isimli ogrenci olusturuldu.");

            }


        }

        public Ogrenci()
        {

            Console.WriteLine("Ogrenci olusturuldu..");


        }


        public float OrtalamaGetir()
        {

            int toplam = MatematikNotu + TurkceNotu + FenNotu + SosyalNotu;
            float ortalama = (float)toplam / 4;
            return ortalama;
        }

        public int YasHesapla(int yil)
        {

            return 2023 - yil;


        }

        public void OrtalamaYazdir()
        {
            int toplam = MatematikNotu + TurkceNotu + FenNotu + SosyalNotu;
            float ortalama = (float)toplam / 4;

            Console.WriteLine(No + " nolu ogrencinin not ortalamasi; " + ortalama);

        }

        public void YasHesapla()
        {

            Yas = 2023 - DogumYili;

        }

    }
}
