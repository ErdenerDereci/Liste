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
            isyeri.ekle("wtyeeyw", "yweewy", "wey", "wey");
            isyeri.ekle("asddas", "hgj", "ghj", "ghj");
            egitim.ekle("cvbncbv", "cvb", "bbbb", "bbb", "bbb", "2.bbb");
            egitim.ekle("asddsa", "xxx", "xx", "xx", "2024", "4");
            list.ekle("ali DERECI", "Uskuasddasddsasadar", "155", "erdener@gmail", "1994", "Almanca", "b1", egitim, isyeri);
            //list.yazdir();

            list.okut();
            list.listele();
            

            



            Console.ReadKey();
        }
    }
}
