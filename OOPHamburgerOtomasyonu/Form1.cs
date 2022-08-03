using OOPHamburgerOtomasyonu.Enums;
using OOPHamburgerOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPHamburgerOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form Load event'ı ile birlikte bir List<BurgerMenu> oluşturulup combobox içerisinde listelenecek ürünler içerisine eklenir

            List<BurgerMenu> menuler = new List<BurgerMenu>
            {
                new BurgerMenu{Isim="Whopper", Aciklama="Whopper menü", Fiyat=20},
                new BurgerMenu{Isim="Chicken Royale", Aciklama="Chicken Royale menü", Fiyat=25},
                new BurgerMenu{Isim="SteakHouse", Aciklama="SteakHouse menü", Fiyat=30},
                new BurgerMenu{Isim="SmokeHouse", Aciklama="Texas SmokeHouse menü", Fiyat=35},
                new BurgerMenu{Isim="Big King",Aciklama="Big King menü", Fiyat=40}
            };

            cmbMenuler.DataSource = menuler;
        }

        private void cmbMenuler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Combobox'ta seçilen ürün BurgerMenu'ye cast edilir, açıklaması label üzerine yazdırılır. Seçim yapılmamış ise "Lütfen menü seçiniz" ibaresi yazdırılacaktır.

            if (cmbMenuler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen menü seçiniz");
                return;
            }
            lblAciklama.Text = (cmbMenuler.SelectedItem as BurgerMenu).Aciklama;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            

            Siparis s = new Siparis(); //Sipariş için instance

            s.Isim = txtIsim.Text; //müşteri ismi textbox'tan alınır
            if (cmbMenuler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen menü seçiniz");
                return;
            }
            s.SecilenMenu = (cmbMenuler.SelectedItem as BurgerMenu); //seçilen menü combobox'tan alınır (BurgerMenu'ye cast edilerek)

            if (rdbBuyuk.Checked) s.Boyut = Boyut.Buyuk;
            else if (rdbOrta.Checked) s.Boyut = Boyut.Orta;
            else s.Boyut = Boyut.Kucuk; //Boyut seçim kontrolü

            foreach (CheckBox item in groupBox1.Controls) //groupbox içerisinde yapılan tüm sos seçimleri için isim ve fiyat değerleri siparişe eklenir
            {
                DipSos ds = new DipSos();
                if (item.Checked)
                {
                    ds.Isim = item.Text;
                    ds.Fiyat = Convert.ToDecimal(item.Tag);
                    s.SecilenSoslar.Add(ds);
                }
            } 

            s.Adet = Convert.ToInt16(nmrAdet.Value); //numericupdown üzerinden sipariş adedi alınır

            s.FiyatHesapla(); //sipariş için fiyathesapla metodu çalıştırılır

            lstSiparis.Items.Add(s); //lstSiparis isimli listbox'a ilgili sipariş eklenir
        }

        

        private void btnCiro_Click(object sender, EventArgs e)
        {
            //girilmiş siparişler üzerinden ciro hesaplanır
            decimal ciro = 0;

            foreach (Siparis item in lstSiparis.Items)
            {
                ciro += item.Fiyat;
            }
            MessageBox.Show(ciro.ToString());
        }

        
    }
}
