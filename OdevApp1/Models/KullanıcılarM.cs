using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevApp1.Models
{

    public class Rootobject1
    {
        public KullanıcılarM[] Property1 { get; set; }
    }

    public class KullanıcılarM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Parola { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DoğumTarihi { get; set; }
    }

}
