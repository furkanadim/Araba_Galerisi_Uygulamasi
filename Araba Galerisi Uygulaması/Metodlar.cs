using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba_Galerisi_Uygulaması
{
    public static class Metodlar
    {
        public static string GetString(string metin, int min = 1, int max = 500)
        {
            string txt = string.Empty;
            bool hata = false;

            do
            {
                Console.WriteLine(metin);
                txt = Console.ReadLine();
                if(string.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Boş bir değer giremezsiniz!");
                    hata = true;
                }
                else
                {
                    if(txt.Length < min || txt.Length > max)
                    {
                        Console.WriteLine("Lütfen min. {0} max. {1} karakter uzunluğunda metin giriniz.", min, max);
                        hata = true;
                    }
                    else
                    {
                        int sayac = 0;
                        foreach (var item in txt)
                        {
                            try
                            {
                                Convert.ToInt32(char.ToString(item));
                                sayac++;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        if (sayac > 0)
                        {
                            Console.WriteLine("Lütfen sayısal değer kullanmayın..");
                            hata = true;
                        }
                        else
                        {
                            hata = false;
                        }
                    }
                }
            } while(hata);
            return txt;
        }

        public static int GetInt(string metin, int min = int.MinValue, int max = int.MaxValue)
        {
            int sayi = 0;
            bool hata = false;
            do
            {
                Console.WriteLine(metin);
                try
                {
                    sayi = int.Parse(Console.ReadLine());
                    if(sayi >= min && sayi <= max)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0}, max {1} arasında bir değer girin.", min, max);
                        hata = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hata = true;
                }
            }while(hata);
            return sayi;
        }

        public static string GetString2(string metin, int min=1, int max = 500)
        {
            string txt = string.Empty;
            bool hata = false;
            do
            {
                Console.WriteLine(metin);
                txt = Console.ReadLine();
                if(string.IsNullOrEmpty(txt))
                {
                    Console.WriteLine("Boş bir değer giremezsiniz");
                    hata = true;
                }
            }while (hata);
            return txt;
        }

    }

}
