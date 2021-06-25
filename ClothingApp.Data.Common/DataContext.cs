using ClothingApp.Data.Common.Models;
using ClothingApp.Data.Common.Models.WeatherModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common
{
    public class DataContext : DbContext
    {
        public DbSet<Clothes> Clothes { get; set; }

        public DbSet<WeaerSetting> WeatherSettings { get; set; }

        public DbSet<Rangerule> RangeRules { get; set; }

        public DbSet<Booleanruule> BooleanRules { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClothesApp;Trusted_Connection=True;");
        }
    }
}
