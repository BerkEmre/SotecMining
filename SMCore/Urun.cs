using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCore
{
    class Urun
    {
        public int id { get; set; }
        public string urunIsmi { get; set; }
        public string urunKodu { get; set; }
        public string barkod { get; set; }

        public Urun(int id, string urunIsmi, string urunKodu, string barkod)
        {
            this.id = id;
            this.urunIsmi = urunIsmi;
            this.urunKodu = urunKodu;
            this.barkod = barkod;
        }
    }
}
