using ClothingApp.Data.Common.Entities;
using ClothingApp.Data.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common
{
    public class DataContext : DbContext
    {
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<WeatherSetting> WeatherSettings { get; set; }
        public DbSet<RangeRule> RangeRules { get; set; }
        public DbSet<BooleanRule> BooleanRules { get; set; }
        public DbSet<MatchingStyleToWeather> MatchingStyleToWeathers { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<CompositionOfStyle> CompositionOfStyles { get; set; }


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
