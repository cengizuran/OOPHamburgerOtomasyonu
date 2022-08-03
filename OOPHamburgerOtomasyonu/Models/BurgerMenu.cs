using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHamburgerOtomasyonu.Models
{
    public class BurgerMenu:BaseEntity
    {
        public override string ToString()
        {
            return $"{Isim}, {Fiyat:C2}";
        }
        public string Aciklama { get; set; }

    }
}
