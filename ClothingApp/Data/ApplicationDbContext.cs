using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClothingApp.Models;
using ClothingApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
    }
}
