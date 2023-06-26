using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevApp1.Models
{
    public class Rootobject
    {
        public FılmlerM[] Property1 { get; set; }
    }

    public class FılmlerM
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string FılmAdı { get; set; }
        public string Yonetmen { get; set; }
        public string Senarist { get; set; }
        public string Oyuncular { get; set; }
        public string YayınTarihi { get; set; }
        public string FılmUzunlugu { get; set; }
        public int İzlenmeSayısı { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string FılmTur { get; set; }
        public double KullanıcıPuanı { get; set; }
        public string Acıklama { get; set; }
        public string FotoUrl { get; set; }
    }
}
