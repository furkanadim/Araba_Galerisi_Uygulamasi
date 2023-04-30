using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Araba_Galerisi_Uygulaması
{
    // Marka, Model, Model Yılı, Fiyat, KM
    public class AracBilgileri
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public double ModelYili { get; set; }
        public double fiyat { get; set; }
        public double KM { get; set; }

        public void Yazdir(int sira)
        {
            Console.WriteLine(sira + "- " + Marka);
        }

    }
}
