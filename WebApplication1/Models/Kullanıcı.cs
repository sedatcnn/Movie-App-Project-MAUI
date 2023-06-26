using WebApplication1.EF;

namespace WebApplication1.Models
{
    public class Kullanıcı
    {
        public void Kulan()
        {
            FılmContext context = new FılmContext();
            context.Kullan.Update(new Models.Kullanıcılar
            {
                Id=Guid.NewGuid(),
                Name="Sedat",
                Parola="123123"
            });

            context.SaveChanges();
        }
    }
}
