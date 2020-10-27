using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeListe list = new TreeListe();
            EgitimBilgileriListe egitim = new EgitimBilgileriListe();
            IsyeriBilgileriListesi isyeri = new IsyeriBilgileriListesi();
            egitim.ekle("Kou","Lisans","Bilisim","2017","2021","2.90") ;
            egitim.ekle("Yildiz", "Yuksek", "ML", "2022", "2024", "4");
            list.ekle("Erdener DERECI","Uskudar","155","erdener@gmail","1994","Almanca","b1",egitim,isyeri);
            
            list.yazdir();

            Console.ReadKey();
        }
    }
}
