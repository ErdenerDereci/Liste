using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class IsyeriBilgileriListesi
    {
        IsyeriBilgileriNode head;

        int id = 0;
        public void ekle(string isyeriAdi_, string isyeriAdresi_, string gorevi_, string suresi_)
        {
            string id = idDondur();
            IsyeriBilgileriNode eklenecek = new IsyeriBilgileriNode(id,isyeriAdi_,isyeriAdresi_,gorevi_,suresi_);

            if(head == null)
            {
                head = eklenecek;
            }
            else
            {
                IsyeriBilgileriNode temp = head;

                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eklenecek;
            }
        }
        public void listele()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            IsyeriBilgileriNode temp = head;

            while (temp != null)
            {
                Console.WriteLine(temp.isyeriAdi + "\n" + temp.isyeriAdresi + "\n" + temp.gorevi + "\n" + temp.suresi + "\n");
                temp = temp.next;
            }
            Console.WriteLine("____________________________________________________________________");
        }
        public void sil(string id)
        {
            if (head.isyeriID == id)
            {
                head = head.next;
            }
            else
            {
                IsyeriBilgileriNode temp = head;
                IsyeriBilgileriNode temp2 = temp.next;
                while (temp2.isyeriID != id)
                {
                    temp = temp.next;
                    temp2 = temp2.next;
                }
                temp.next = temp.next.next;
            }
        }

        private string idDondur()
        {
            id++;
            return "isyeri" + id;
        }
        public void guncelle(string id, string isyeriAdi_, string isyeriAdresi_, string gorevi_, string suresi_)
        {
            IsyeriBilgileriNode temp = head;

            while (temp.isyeriID != id)
            {
                temp = temp.next;
            }
            temp.isyeriAdi = isyeriAdi_;
            temp.isyeriAdresi = isyeriAdresi_;
            temp.gorevi = gorevi_;
            temp.suresi = suresi_;
        }
        public int count()
        {
            IsyeriBilgileriNode temp = head;
            int sayac = 0;
            while (temp != null)
            {
                sayac++;
                temp = temp.next;
            }
            return sayac;
        }
        public IsyeriBilgileriNode isyeribilgileri(int i)
        {
            IsyeriBilgileriNode temp = head;
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
        public void clear()
        {
            head = null;
        }
    }
}
