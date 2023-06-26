using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication1.Models;

namespace WebApplication1.EF
{
    public class FılmContext : DbContext
    {
        public DbSet<Fılmler> Fılmlers { get; set; }
        public DbSet<Kullanıcılar> Kullan { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=Test;User Id=sedat;Password=123123;TrustServerCertificate=true");
        }
    }
}
