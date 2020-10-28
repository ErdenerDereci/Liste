using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Liste
{
    class TreeListe
    {
        string dosya_yolu = @"C:\ikveriTabani.txt";
        TreeNode root;
        int id = 0;
        public void ekle(string kisiAdiSoyadi_, string kisiAdresi_, string kisiTelefonu_, string kisiMail_, string kisiDogumTarihi_, string kisiYabanciDil_, string kisiEhliyet_, EgitimBilgileriListe kisiEgitimListesi_, IsyeriBilgileriListesi kisiIsyeriBilgileriListesi_)
        {
            string id = idDondur();
            TreeNode eklenecek = new TreeNode( id, kisiAdiSoyadi_,  kisiAdresi_,  kisiTelefonu_,  kisiMail_,  kisiDogumTarihi_,  kisiYabanciDil_,  kisiEhliyet_,kisiEgitimListesi_,kisiIsyeriBilgileriListesi_);
            if (root == null)
            {
                root = eklenecek;
            }
            else
            {
                TreeNode temp = root;
                TreeNode temp2;
                while (true)
                {
                    temp2 = temp;
                    if (string.Compare(temp.kisiAdiSoyadi, kisiAdiSoyadi_) == -1)
                    {
                        temp = temp.sag;
                        if (temp == null)
                        {
                            temp2.sag = eklenecek;
                            break;
                        }
                    }
                    else
                    {
                        temp = temp.sol;
                        if (temp == null)
                        {
                            temp2.sol = eklenecek;
                            break;
                        }
                    }
                }
            }
        }

        private void print(TreeNode node)
        {
            
            if (node != null)
            {
                print(node.sol);
                Console.WriteLine(node.kisiAdiSoyadi +"\n"+ node.kisiAdresi + "\n" + node.kisiTelefonu + "\n" + node.kisiMail+ "\n"+
                    node.kisiDogumTarihi+ "\n"+node.kisiYabanciDil+ "\n"+ node.kisiEhliyet + "\n");
                node.kisiEgitimListesi.listele();
                node.kisiIsyeriBilgileriListesi.listele();
                print(node.sag);
            }
        }
        public void listele()
        {
            print(root);
        }

        private string idDondur()
        {
            id++;
            return "kisi" + id;
        }

        private TreeNode minVal(TreeNode node)
        {
            while (node.sol != null)
            {
                node = node.sol;
            }
            return node;
        }

        private TreeNode sil(TreeNode node,string kisiAdiSoyadi_)
        {

            if (node == null) ///node null ise geriye null değer döndürecek yani root
            {
                return node;
            }
            if (string.Compare(node.kisiAdiSoyadi, kisiAdiSoyadi_) == 1)  ////silinecek veri node daki değerden küçükse ife girecek
            {
                node.sol = sil(node.sol, kisiAdiSoyadi_); ////node un solundaki değer için fonksiyonu tekrar döndürüyor
            }
            else if (string.Compare(node.kisiAdiSoyadi, kisiAdiSoyadi_) == -1)  ////silinecek veri node daki değerden büyükse ife girecek
            {
                node.sag = sil(node.sag, kisiAdiSoyadi_); ////node un sağındaki değer için fonksiyonu tekrar döndürüyor
            }
            else  //// silinecek veri node daki değere eşitse else e giriyor
            {
                if (node.sol == null) ///solunda çocuk yoksa sağdaki değeri döndürür oda boşsa fonku bitirir. Buradaki işlem hiç çocuğu yoksa da uygulanır
                {
                    return node.sag;
                }
                else if (node.sag == null)
                {
                    return node.sol;
                }

                kopyala(node, minVal(node.sag)); /// düğümde iki tane çocuk varsa sağındaki ağaçtan minimum değeri kendine eşitler (düğümü değil değeri)
                node.sag = sil(node.sag, node.kisiAdiSoyadi);  ///
            }
            return node;

        }
        private void kopyala(TreeNode kopyalanan, TreeNode minvalue)
        {
            kopyalanan.kisiAdiSoyadi = minvalue.kisiAdiSoyadi;
            kopyalanan.kisiAdresi = minvalue.kisiAdresi;
            kopyalanan.kisiTelefonu = minvalue.kisiTelefonu;
            kopyalanan.kisiMail = minvalue.kisiMail;
            kopyalanan.kisiDogumTarihi = minvalue.kisiDogumTarihi;
            kopyalanan.kisiYabanciDil = minvalue.kisiYabanciDil;
            kopyalanan.kisiEhliyet = minvalue.kisiEhliyet;


        }
        
        public void delete(string kisiAdi)
        {
           root= sil(root,kisiAdi);
            
        }

        private void Write(TreeNode node)
        {
            

            if (node != null)
            {
                Write(node.sol);
                
                string dosya_yolu = @"C:\ikveriTabani.txt";

                FileStream fs = new FileStream(dosya_yolu, FileMode.Append, FileAccess.Write) ;

                StreamWriter sw = new StreamWriter(fs) ;

                sw.WriteLine("*********KISI BILGILERI*********");
                sw.WriteLine(" ");
                sw.WriteLine("Kisi Adi Soyadi: " + node.kisiAdiSoyadi);
                sw.WriteLine("Kisi Adresi: " + node.kisiAdresi);
                sw.WriteLine("Kisi Telefonu: " + node.kisiTelefonu);
                sw.WriteLine("Kisi Mail: " + node.kisiMail);
                sw.WriteLine("Kisi DogumTarihi: " + node.kisiDogumTarihi);
                sw.WriteLine("Kisi Yabanci Dil: " + node.kisiYabanciDil);
                sw.WriteLine("Kisi Ehliyet: " + node.kisiEhliyet);
                sw.WriteLine(" ");
                sw.WriteLine("--------Egitim Bilgileri--------");
                for (int i = 0; i<node.kisiEgitimListesi.count(); i++)
                {
                    sw.WriteLine(" ");
                    sw.WriteLine("Okul Adi: "+node.kisiEgitimListesi.egitimListesi(i).okulAdi);
                    sw.WriteLine("Okul Turu: "+ node.kisiEgitimListesi.egitimListesi(i).okulturu);
                    sw.WriteLine("Bolumu: " + node.kisiEgitimListesi.egitimListesi(i).bolum);
                    sw.WriteLine("Baslangic Tarihi: " + node.kisiEgitimListesi.egitimListesi(i).baslangicTarihi);
                    sw.WriteLine("Bitis Tarihi: " + node.kisiEgitimListesi.egitimListesi(i).bitisTarihi);
                    sw.WriteLine("Not Ortalamasi: " + node.kisiEgitimListesi.egitimListesi(i).notOrtalamasi);
                    sw.WriteLine("......");
                }
                sw.WriteLine("+++++++++Isyeri Bilgileri+++++++++");
                for (int i =0; i<node.kisiIsyeriBilgileriListesi.count(); i++)
                {
                    sw.WriteLine(" ");
                    sw.WriteLine("Isyeri Adi: " + node.kisiIsyeriBilgileriListesi.isyeribilgileri(i).isyeriAdi);
                    sw.WriteLine("Isyeri Adresi: " + node.kisiIsyeriBilgileriListesi.isyeribilgileri(i).isyeriAdresi);
                    sw.WriteLine("Gorevi: " + node.kisiIsyeriBilgileriListesi.isyeribilgileri(i).gorevi);
                    sw.WriteLine("Calisma suresi: " + node.kisiIsyeriBilgileriListesi.isyeribilgileri(i).suresi);
                    sw.WriteLine("......");
                }


                sw.WriteLine("_____________________________________________________________________");

                Write(node.sag);
                sw.Flush();

                sw.Close();
                fs.Close();
            }
           
        }

        private void Read(TreeNode node)
        {
            
            string kisiAdi = " ",adresi = " ", telefonu = " ", mail = " ", dogumtarihi = " ", yabancidil = " ", ehliyet = " ";
            string isyeriadi = " ", isyeriAdresi = " ", gorevi = " ", calisma = " ";
            string okuladi = " ", okulturu = " ", bolumu = " ", baslangic = " ", bitis = " ", notortalamasi = " ";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Read);
          
            StreamReader sw = new StreamReader(fs);
            
            string satir = sw.ReadLine();
            while (satir != null)
            {
                
               
                if (satir[0] == '*')
                {
                    
                    

                    for (int i = 0; i < 8; i++)
                    {
                        satir = sw.ReadLine();
                        if (satir.Contains("Kisi Adi"))
                        {
                            kisiAdi = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Adresi"))
                        {
                            adresi = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Telefonu"))
                        {
                            telefonu = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Mail"))
                        {
                            mail = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi DogumTarihi"))
                        {
                            dogumtarihi = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Yabanci Dil"))
                        {
                            yabancidil = stringAyikla(satir);
                        }
                        else if (satir.Contains("Kisi Ehliyet"))
                        {
                            ehliyet = stringAyikla(satir);
                        }
                    }
                }
                else if (satir[0] == '-')
                {
                    satir = sw.ReadLine();
                    EgitimBilgileriListe egitimliste = new EgitimBilgileriListe();

                    while (true)
                    {

                        satir = sw.ReadLine();
                        if (satir.Contains("Okul Adi"))
                        {
                            okuladi = stringAyikla(satir);
                        }
                        else if (satir.Contains("Okul Turu"))
                        {
                            okulturu = stringAyikla(satir);
                        }
                        else if (satir.Contains("Bolumu"))
                        {
                            bolumu = stringAyikla(satir);
                        }
                        else if (satir.Contains("Baslangic"))
                        {
                            baslangic = stringAyikla(satir);
                        }
                        else if (satir.Contains("Bitis"))
                        {
                            bitis = stringAyikla(satir);
                        }
                        else if (satir.Contains("Not"))
                        {
                            notortalamasi = stringAyikla(satir);
                        }
                        else if (satir[0] == '.')
                        {

                            egitimliste.ekle(okuladi, okulturu, bolumu, baslangic, bitis, notortalamasi);
                        }
                        else if (satir[0] == '+')
                        {
                            satir = sw.ReadLine();
                            IsyeriBilgileriListesi isyeriliste = new IsyeriBilgileriListesi();

                            while (true)
                            {
                                satir = sw.ReadLine();
                                if (satir.Contains("Isyeri Adi"))
                                {
                                    isyeriadi = stringAyikla(satir);
                                }
                                else if (satir.Contains("Isyeri Adresi"))
                                {
                                    isyeriAdresi = stringAyikla(satir);
                                }
                                else if (satir.Contains("Gorevi"))
                                {
                                    gorevi = stringAyikla(satir);
                                }
                                else if (satir.Contains("Calisma suresi"))
                                {
                                    calisma = stringAyikla(satir);
                                }

                                else if (satir[0] == '.')
                                {

                                    isyeriliste.ekle(isyeriadi, isyeriAdresi, gorevi, calisma);
                                }
                                else if (satir[0] == '_')
                                {
                                    ekle(kisiAdi, adresi, telefonu, mail, dogumtarihi, yabancidil, ehliyet, egitimliste, isyeriliste);
                                    
                                    break;
                                }

                            }
                            break;
                        }
                    }
                   

                }

                satir = sw.ReadLine();
            }
            
            
            sw.Close();
            fs.Close();
        }
        public void okut()
        {
            Read(root);
        }
        
        public void yazdir()
        {
            Write(root);
        }
        private string stringAyikla(string deger)
        {
            string donecek = "";
            int i;
            for (i = 0; i < deger.Length; i++)
            {
                if (deger[i] == ':')
                {
                    break;
                }
            }
            i++;
            i++;
            for (int j=i; j < deger.Length; j++)
            {
                donecek = donecek + deger[j];
            }
            return donecek;

        }
    }

   

}
