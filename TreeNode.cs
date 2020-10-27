using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class TreeNode
    {
        public string kisiID, kisiAdiSoyadi, kisiAdresi, kisiTelefonu, kisiMail, kisiDogumTarihi, kisiYabanciDil, kisiEhliyet;
        public EgitimBilgileriListe kisiEgitimListesi;
        public IsyeriBilgileriListesi kisiIsyeriBilgileriListesi;


        public TreeNode sag;
        public TreeNode sol;

        public TreeNode(string kisiID_, string kisiAdiSoyadi_, string kisiAdresi_, string kisiTelefonu_, string kisiMail_, string kisiDogumTarihi_, string kisiYabanciDil_, string kisiEhliyet_, EgitimBilgileriListe kisiEgitimListesi_, IsyeriBilgileriListesi kisiIsyeriBilgileriListesi_)
        {
            kisiID = kisiID_;
            kisiAdiSoyadi = kisiAdiSoyadi_;
            kisiAdresi = kisiAdresi_;
            kisiTelefonu = kisiTelefonu_;
            kisiMail = kisiMail_;
            kisiDogumTarihi = kisiDogumTarihi_;
            kisiYabanciDil = kisiYabanciDil_;
            kisiEhliyet = kisiEhliyet_;
            kisiEgitimListesi = kisiEgitimListesi_;
            kisiIsyeriBilgileriListesi = kisiIsyeriBilgileriListesi_;
            sag = null;
            sol = null;

        }

    }
}
