namespace WebApplication1.Models
{
    public class Fılmler
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
