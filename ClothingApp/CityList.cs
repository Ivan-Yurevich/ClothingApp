using System.Linq;
using ClothingApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClothingApp.Models
{
    public class CityList
    {
        public static SelectList GetCities()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=aspnet-ClothingApp-5C7CFEF1-CF44-40CA-B47E-9F5A252F7CDF;Trusted_Connection=True;")
                    .Options;

            using (ApplicationDbContext db = new ApplicationDbContext(options))
            {
                return new SelectList(db.Cities.ToList(), "Name", "Name");
            }
        }
    }
}
