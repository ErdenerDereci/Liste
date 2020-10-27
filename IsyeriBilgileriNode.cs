using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class IsyeriBilgileriNode
    {
        public string isyeriID, isyeriAdi, isyeriAdresi, gorevi, suresi;
        public IsyeriBilgileriNode next;

        public IsyeriBilgileriNode(string id, string isyeriAdi_,string isyeriAdresi_ ,string gorevi_,string suresi_)
        {
            isyeriID = id;
            isyeriAdi = isyeriAdi_;
            isyeriAdresi = isyeriAdresi_;
            gorevi = gorevi_;
            suresi = suresi_;
            next = null;
        }
        
    }
}
