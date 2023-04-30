using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba_Galerisi_Uygulaması
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bir araba galerisi uygulaması yapılacak
            // Araç propertyleri: Marka, Model, Model Yılı, Fiyat, KM
            // 1- Araç Ekle 
            // 2- Araçları Listele 
            // 3- Araç Ara 
            // 4- Araç Sil 
            // 5- Araçlara Zam Yap 
            // 6- Araçlara İndirim Yap 
            // Not: 5 ve 6 numaralı menülerde bize yüzde kaçlık zam-indirim yapılacağı sorulacak.
            // Zam ve indirim yüzdeleri %20 den fazla olamayacak.
            // Fiyatı 100bin₺ den az olan araçlara indirim uygulanmayacak.
            // Onun dışında girilen miktar kadar tüm araçlara zam-indirim uygulanacak.

            ConsoleKey cevap;
            do
            {
                Console.Clear();
                Console.WriteLine("Araba Galerisi Uygulaması");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1- Araç Ekle");
                Console.WriteLine("2- Araçları Listele");
                Console.WriteLine("3- Araç Ara");
                Console.WriteLine("4- Araç Sil");
                Console.WriteLine("5- Araçlara Zam Yap");
                Console.WriteLine("6- Araçlara İndirim Yap");
                cevap = Console.ReadKey().Key;
                Menu.Islemler(cevap);
            } while (cevap != ConsoleKey.D0 && cevap != ConsoleKey.NumPad0);

            Console.Clear();
            Console.WriteLine("Araç Galerisini kullandığınız için teşekkürler");
            Console.WriteLine("Programı kapatmak için bir tuşa basınız...");


            Console.ReadKey();
        }
    }
}
