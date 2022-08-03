using OOPHamburgerOtomasyonu.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHamburgerOtomasyonu.Models
{
    public class Siparis:BaseEntity
    {
        public short Adet { get; set; }
        public BurgerMenu SecilenMenu { get; set; }
        public List<DipSos> SecilenSoslar { get; set; }
        public Boyut Boyut { get; set; }


        

        public Siparis()
        {
            SecilenSoslar = new List<DipSos>();
        }

        public void FiyatHesapla()
        {
            Fiyat = SecilenMenu.Fiyat;

            switch (Boyut)
            {
                case Boyut.Kucuk:
                    break;
                case Boyut.Orta:
                    Fiyat += 1;
                    break;
                case Boyut.Buyuk:
                    Fiyat += 2;
                    break;
            }

            foreach (DipSos item in SecilenSoslar)
            {
                Fiyat += item.Fiyat;
            }

            Fiyat *= Adet;
        }

        public override string ToString()
        {
            if (SecilenSoslar.Count==0)
            {
                return $"Müşteri: {Isim}, Menü: {SecilenMenu.Isim}, Boyut: {Boyut}, Adet: {Adet}, Fiyat: {Fiyat:C2}";
            }

            string soslar = null;

            foreach (DipSos item in SecilenSoslar)
            {
                soslar += $"{item.Isim},";
            }

            soslar = soslar.TrimEnd(',');

            return $"Müşteri: {Isim}, Menü: {SecilenMenu.Isim}, Boyut: {Boyut}, Soslar: {soslar} Adet: {Adet}, Fiyat: {Fiyat:C2}";
        }


    }
}
