using Microsoft.EntityFrameworkCore;

namespace ClothingApp.Data.Common
{
    public class СlothesDbContext:DbContext
    {
        public СlothesDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClothesApp;Trusted_Connection=True;");
        }
    }
}
