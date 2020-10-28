using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class EgitimBilgileriListe
    {
        EgitimBilgileriNode head;
        int id = 0;
        private string idDondur()
        {
            id++;
            return "egitim" + id;
        }
        public void ekle(string okulAdi_, string turu_, string bolumu_, string baslangicTarihi_, string bitisTarihi_, string notOrtalamasi_)
        {
            string id = idDondur();
            EgitimBilgileriNode eklenecek = new EgitimBilgileriNode(id,okulAdi_,turu_,bolumu_,baslangicTarihi_,bitisTarihi_,notOrtalamasi_);

            if (head == null)
            {
                head = eklenecek;
            }
            else
            {
                EgitimBilgileriNode temp = head;

                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eklenecek;
            }
        }
        public void listele()
        {
            EgitimBilgileriNode temp = head;
            Console.WriteLine("-----------------------------------------");
            while (temp != null)
            {
                
                Console.WriteLine(temp.okulAdi + "\n" + temp.okulturu + "\n" +temp.bolum + "\n" +temp.baslangicTarihi + "\n" +temp.bitisTarihi + "\n" +temp.notOrtalamasi + "\n");
                temp = temp.next;
            }
        }
        public void sil(string id)
        {
            if (head.okulID == id)
            {
                head = head.next;
            }
            else
            {
                EgitimBilgileriNode temp = head;
                EgitimBilgileriNode temp2 = temp.next;
                while (temp2.okulID != id)
                {
                    temp = temp.next;
                    temp2 = temp2.next;
                }
                temp.next = temp.next.next;
            }
        }
        public void guncelle(string id, string okulAdi_, string turu_, string bolumu_, string baslangicTarihi_, string bitisTarihi_, string notOrtalamasi_)
        {
            EgitimBilgileriNode temp = head;

            while (temp.okulID != id)
            {
                temp = temp.next;
            }
            temp.okulAdi = okulAdi_;
            temp.okulturu = turu_;
            temp.bolum = bolumu_;
            temp.baslangicTarihi = baslangicTarihi_;
            temp.bitisTarihi = bitisTarihi_;
            temp.notOrtalamasi = notOrtalamasi_;
        }
        public int count()
        {
            EgitimBilgileriNode temp = head;
            int sayac = 0;
            while (temp != null)
            {
                sayac++;
                temp = temp.next;
            }
            return sayac;
        }
        public EgitimBilgileriNode egitimListesi(int i)
        {
            EgitimBilgileriNode temp = head;
            int sayac = 0;
            if (count() < i)
            {
                Console.WriteLine("Hata: index out of range!");
                return null;
            }
            else
            {
                while (temp != null)
                {
                    if (sayac == i)
                    {
                        return temp;
                    }
                    sayac++;
                    temp = temp.next;
                }
            }
            return null;

        }
    }
}
