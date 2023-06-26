using Microsoft.EntityFrameworkCore;
using WebApplication1.EF;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapGet("/fýlmler", () =>
            {
                FýlmContext context = new FýlmContext();
                return context.Fýlmlers.ToList();
            });
            app.MapGet("/kullanýcý", () =>
            {
                FýlmContext context = new FýlmContext();
                return context.Kullan.ToList();
            });

            app.MapPost("/kullanýcý", (Kullanýcýlar kullanýcýlar) =>
            {
                FýlmContext context = new FýlmContext();
                context.Kullan.Add(kullanýcýlar);
                context.SaveChanges();
            });
            
            app.MapPost("/kullanýcý/guncelle", (Kullanýcýlar kullanýcýlar) =>
            {
                FýlmContext context = new FýlmContext();
                var guncellenecek = context.Kullan.Find(kullanýcýlar.Id);
                guncellenecek.Parola = kullanýcýlar.Parola;
               context.SaveChanges();
            });



            app.MapDelete("/kullanýcý/{id}", (string id) =>
            {
                FýlmContext context = new FýlmContext();
                var silinecek = context.Kullan.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (silinecek != null)
                {
                    context.Kullan.Remove(silinecek);
                    context.SaveChanges();
                }
            });

            #region 
            //YabancýFýlmler yabancýFýlmler = new YabancýFýlmler();
            //yabancýFýlmler.Yabancý();

            //YerliFýlmler yerliFýlmler = new YerliFýlmler();
            //yerliFýlmler.Turk();

            //Kullanýcý kullanýcý=new Kullanýcý();
            //kullanýcý.Kulan();

            //FýlmContext context = new FýlmContext();
            //var seciliFýlm = context.Fýlmlers
            //.Where(x => x.Id == Guid.Parse("DEFD8FB9-DEA7-4134-BC49-F60783732BA3"))
            //.FirstOrDefault();

            //if (seciliFýlm is not null)
            //{
            //    //seciliDuyuru.Baslik = "Güncellendi";
            //    //context.SaveChanges();

            //    context.Fýlmlers.Remove(seciliFýlm);
            //    context.SaveChanges();
            //}
            //FýlmContext context = new FýlmContext();
            //Random random = new Random();

            //var filmler = context.Fýlmlers.Where(x => x.ÝzlenmeSayýsý == 48588).ToList();

            //foreach (var film in filmler)
            //{
            //    int randomValue = random.Next(5000000, 100000000); // 500,000 ile 10,000,000 arasýnda rastgele bir deðer oluþturur

            //    film.ÝzlenmeSayýsý = randomValue;
            //    // Diðer film özelliklerini burada güncelleyebilirsiniz
            //}
            //FýlmContext context = new FýlmContext();
            //var kullanýcý = context.Kullan.SingleOrDefault(k => k.Name == "Ýbrahim");

            //if (kullanýcý != null)
            //{
            //    kullanýcý.Cinsiyet = true;
            //    kullanýcý.DoðumTarihi = new DateTime(2000, 1, 25);

            //    context.SaveChanges();
            //} 
            //FýlmContext context = new FýlmContext();
            //var fýlms = context.Fýlmlers.SingleOrDefault(k => k.FýlmAdý == "Kurak Günler" && k.FotoUrl== "kis_uykusu.jpg");

            //if (fýlms != null)
            //{

            //    fýlms.FotoUrl = "kurak_gunler.jpg";
            //    context.SaveChanges();
            //}
            //FýlmContext context = new FýlmContext();

            //var filmler = context.Fýlmlers.Where(x => x.FýlmUzunlugu == " " && x.FýlmAdý == "Ölümlü Dünya");

            //foreach (var film in filmler)
            //{
            //    film.FýlmUzunlugu = "1s 47dk";

            //}

            //context.SaveChanges();
            #endregion


            app.Run();
        }
    }
}