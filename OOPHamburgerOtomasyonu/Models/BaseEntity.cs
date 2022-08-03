using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHamburgerOtomasyonu.Models
{
    public abstract class BaseEntity
    {
        public string Isim { get; set; }
        public virtual decimal Fiyat { get; set; }

        protected decimal _fiyat;
    }
}
