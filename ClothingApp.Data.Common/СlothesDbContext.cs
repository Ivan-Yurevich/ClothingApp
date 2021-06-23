using ClothingApp.Data.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common
{
    public class СlothesDbContext:DbContext
    {
        public DbSet<Clothes> Clothes { get; set; }

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
