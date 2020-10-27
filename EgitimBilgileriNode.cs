using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class EgitimBilgileriNode
    {
        public string okulID, okulAdi, okulturu, bolum, baslangicTarihi, bitisTarihi, notOrtalamasi;
        public EgitimBilgileriNode next;

        public EgitimBilgileriNode(string okulID_, string okulAdi_, string okulturu_, string bolum_, string baslangicTarihi_, string bitisTarihi_, string notOrtalamasi_)
        {
            okulID = okulID_;
            okulAdi = okulAdi_;
            okulturu = okulturu_;
            bolum = bolum_;
            baslangicTarihi = baslangicTarihi_;
            bitisTarihi = bitisTarihi_;
            notOrtalamasi = notOrtalamasi_;
            next = null;
        }
    }
}
