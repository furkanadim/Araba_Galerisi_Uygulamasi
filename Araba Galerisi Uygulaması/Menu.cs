using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Araba_Galerisi_Uygulaması
{
    public static class Menu
    {
        static List<AracBilgileri> arabalar = new List<AracBilgileri>();

        public static void Islemler(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Ekle("Araba Ekle");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Listele("Araçları Listele");
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    AracAra("Araç Ara");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Sil("Araç Sil");
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ZamYap("Araçlara Zam Yap");
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    IndirimYap("Araçlara İndirim Yap");
                    break;
            }
        }

        private static void Sil(string v)
        {
            BaslikYazdir(v);
            if(arabalar.Count > 0)
            {
                for (int i = 0; i < arabalar.Count; i++)
                {
                    arabalar[i].Yazdir(i + 1);
                }
                Console.WriteLine();
                int siraNo = Metodlar.GetInt("Silmek istediğiniz aracın sıra numarasını giriniz.\nİşlemi iptal etmek için 0'a basınız: ", 0, arabalar.Count);
                if (siraNo == 0)
                {
                    AnaMenuyeDon("Silme işlemi İptal Edildi");
                }
                else
                {
                    int indexNo = siraNo - 1;
                    Console.WriteLine(arabalar[indexNo].Marka + " aracını silmek istediğinizden emin misiinz? (e)");
                    if(Console.ReadKey().Key == ConsoleKey.E)
                    {
                        string silinen = arabalar[indexNo].Marka;
                        arabalar.RemoveAt(indexNo);
                        AnaMenuyeDon(string.Format("{0} öğrencisi başarı ile silindi", silinen));
                    }
                }
            }
            else
            {
                AnaMenuyeDon("Listede öğrenci bulunmamaktadır");
            }
        }


        private static void AracAra(string v)
        {
            BaslikYazdir(v);
            Console.Write("Aranacak aracın adını giriniz: ");
            string arananArac = Console.ReadLine().ToLower(); 

            List<AracBilgileri> bulunanArabalar = arabalar.FindAll(x => x.Marka.ToLower().Contains(arananArac)); 

            if (bulunanArabalar.Count > 0)
            {
                BaslikYazdir("Bulunan Araçlar");
                for (int i = 0; i < bulunanArabalar.Count; i++)
                {
                    Console.WriteLine();
                    bulunanArabalar[i].Yazdir(i + 1);
                    Console.WriteLine("Model: " + bulunanArabalar[i].Model);
                    Console.WriteLine("Fiyat: " + bulunanArabalar[i].fiyat);
                    Console.WriteLine("Kilometre: " + bulunanArabalar[i].KM);
                }
                AnaMenuyeDon(string.Format("Toplam {0} araba listelenmiştir", bulunanArabalar.Count));
            }
            else
            {
                AnaMenuyeDon("Aranan araç bulunamadı.");
            }
        }

        private static void Listele(string v)
        {
            BaslikYazdir(v);
            if (arabalar.Count > 0)
            {
                for (int i = 0; i < arabalar.Count; i++)
                {
                    arabalar[i].Yazdir(i + 1);
                }
                AnaMenuyeDon(string.Format("Toplam {0} araba listelenmiştir", arabalar.Count));
            }
            else
            {
                AnaMenuyeDon("Listede araba bulunmamaktadır.");
            }
        }

        private static void ListeleGoster(string v)
        {
            if (arabalar.Count > 0)
            {
                for (int i = 0; i < arabalar.Count; i++)
                {
                    arabalar[i].Yazdir(i + 1);
                }
            }

        }
        private static void ZamYap(string v)
        {
            BaslikYazdir(v);

            if (arabalar.Count == 0)
            {
                Console.WriteLine("Listede araç bulunamadı.");
                AnaMenuyeDon("");
                return;
            }

            ListeleGoster("Mevcut Araçlar");
            Console.WriteLine();

            Console.Write("Zam yapmak istediğiniz aracın sıra numarasını girin: ");
            int aracIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Yüzdelik zam oranını girin (Örnek: 10 için 10, 25 için 25): ");
            double zamOrani = double.Parse(Console.ReadLine()) / 100;

            AracBilgileri arac = arabalar[aracIndex];

            if (arac.fiyat >= 100000)
            {
                arac.fiyat *= (1 + zamOrani);
                Console.WriteLine("Araca {0}% zam yapıldı. Güncel fiyatı: {1}", zamOrani * 100, arac.fiyat);
            }
            else
            {
                Console.WriteLine("Bu araca indirim yapılamaz. Fiyatı 100.000 ₺'den az.");
            }
            AnaMenuyeDon("İşlem tamamlandı. Ana menüye dönmek için bir tuşa basınız.");

        }

        private static void IndirimYap(string v)
        {
            BaslikYazdir(v);

            if (arabalar.Count == 0)
            {
                Console.WriteLine("Listede araç bulunamadı.");
                AnaMenuyeDon("");
                return;
            }

            ListeleGoster("Mevcut Araçlar");
            Console.WriteLine();

            Console.Write("İndirim yapmak istediğiniz aracın sıra numarasını girin: ");
            int aracIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Yüzdelik indirim oranını girin (Örnek: 10 için 10, 25 için 25): ");
            double indirimOrani = double.Parse(Console.ReadLine()) / 100;

            AracBilgileri arac = arabalar[aracIndex];

            if (arac.fiyat >= 100000)
            {
                arac.fiyat *= (1 - indirimOrani);
                Console.WriteLine("Araca {0}% indirim yapıldı. Güncel fiyatı: {1}", indirimOrani * 100, arac.fiyat);
            }
            else
            {
                Console.WriteLine("Bu araca indirim yapılamaz. Fiyatı 100.000 ₺'den az.");
            }

            AnaMenuyeDon("İşlem tamamlandı. Ana menüye dönmek için bir tuşa basınız.");
        }

        private static void Ekle(string v)
        {
            BaslikYazdir(v);
            AracBilgileri arb = new AracBilgileri();
            arb.Marka = Metodlar.GetString("Araç adı: ", 2, 20);
            arb.Model = Metodlar.GetString2("Araç modeli: ", 2, 20);
            arb.ModelYili = Metodlar.GetInt("Model Yılı: ");
            arb.fiyat = Metodlar.GetInt("Fiyat (TL cinsinden): ");
            arb.KM = Metodlar.GetInt("Aracın KM'si: ");
            arabalar.Add(arb);
            AnaMenuyeDon(string.Format("{0} arabası listeye başarıyla eklendi.", arb.Marka));
        }

        private static void BaslikYazdir(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
            Console.WriteLine("-------------------");
            Console.WriteLine();
        }

        private static void AnaMenuyeDon(string v)
        {
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine();
            Console.WriteLine("Ana menüye dönmek için Bir tuşa basınız");
            Console.ReadKey();
        }

        
    }
}
