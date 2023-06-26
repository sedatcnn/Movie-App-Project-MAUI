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
            app.MapGet("/f�lmler", () =>
            {
                F�lmContext context = new F�lmContext();
                return context.F�lmlers.ToList();
            });
            app.MapGet("/kullan�c�", () =>
            {
                F�lmContext context = new F�lmContext();
                return context.Kullan.ToList();
            });

            app.MapPost("/kullan�c�", (Kullan�c�lar kullan�c�lar) =>
            {
                F�lmContext context = new F�lmContext();
                context.Kullan.Add(kullan�c�lar);
                context.SaveChanges();
            });
            
            app.MapPost("/kullan�c�/guncelle", (Kullan�c�lar kullan�c�lar) =>
            {
                F�lmContext context = new F�lmContext();
                var guncellenecek = context.Kullan.Find(kullan�c�lar.Id);
                guncellenecek.Parola = kullan�c�lar.Parola;
               context.SaveChanges();
            });



            app.MapDelete("/kullan�c�/{id}", (string id) =>
            {
                F�lmContext context = new F�lmContext();
                var silinecek = context.Kullan.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (silinecek != null)
                {
                    context.Kullan.Remove(silinecek);
                    context.SaveChanges();
                }
            });

            #region 
            //Yabanc�F�lmler yabanc�F�lmler = new Yabanc�F�lmler();
            //yabanc�F�lmler.Yabanc�();

            //YerliF�lmler yerliF�lmler = new YerliF�lmler();
            //yerliF�lmler.Turk();

            //Kullan�c� kullan�c�=new Kullan�c�();
            //kullan�c�.Kulan();

            //F�lmContext context = new F�lmContext();
            //var seciliF�lm = context.F�lmlers
            //.Where(x => x.Id == Guid.Parse("DEFD8FB9-DEA7-4134-BC49-F60783732BA3"))
            //.FirstOrDefault();

            //if (seciliF�lm is not null)
            //{
            //    //seciliDuyuru.Baslik = "G�ncellendi";
            //    //context.SaveChanges();

            //    context.F�lmlers.Remove(seciliF�lm);
            //    context.SaveChanges();
            //}
            //F�lmContext context = new F�lmContext();
            //Random random = new Random();

            //var filmler = context.F�lmlers.Where(x => x.�zlenmeSay�s� == 48588).ToList();

            //foreach (var film in filmler)
            //{
            //    int randomValue = random.Next(5000000, 100000000); // 500,000 ile 10,000,000 aras�nda rastgele bir de�er olu�turur

            //    film.�zlenmeSay�s� = randomValue;
            //    // Di�er film �zelliklerini burada g�ncelleyebilirsiniz
            //}
            //F�lmContext context = new F�lmContext();
            //var kullan�c� = context.Kullan.SingleOrDefault(k => k.Name == "�brahim");

            //if (kullan�c� != null)
            //{
            //    kullan�c�.Cinsiyet = true;
            //    kullan�c�.Do�umTarihi = new DateTime(2000, 1, 25);

            //    context.SaveChanges();
            //} 
            //F�lmContext context = new F�lmContext();
            //var f�lms = context.F�lmlers.SingleOrDefault(k => k.F�lmAd� == "Kurak G�nler" && k.FotoUrl== "kis_uykusu.jpg");

            //if (f�lms != null)
            //{

            //    f�lms.FotoUrl = "kurak_gunler.jpg";
            //    context.SaveChanges();
            //}
            //F�lmContext context = new F�lmContext();

            //var filmler = context.F�lmlers.Where(x => x.F�lmUzunlugu == " " && x.F�lmAd� == "�l�ml� D�nya");

            //foreach (var film in filmler)
            //{
            //    film.F�lmUzunlugu = "1s 47dk";

            //}

            //context.SaveChanges();
            #endregion


            app.Run();
        }
    }
}