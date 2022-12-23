using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApiModels.Models;

namespace WebApiModels.Models
{
    public class InternetContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; } = null!;
        public DbSet<Tariff> Tariffs { get; set; } = null!;
        public DbSet<Region> Regions { get; set; } = null!;

        public InternetContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }
      
    }
}
