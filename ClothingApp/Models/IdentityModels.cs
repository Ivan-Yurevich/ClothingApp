using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothingApp.Data.Common.Models;
using ClothingApp.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothingApp.Models
{
    public enum UserGender
    {
        [Display(Name = "Женский")]
        Female = 1,
        [Display(Name = "Мужской")]
        Male = 2
    }

    public class ApplicationUser : IdentityUser
    {
        public UserGender Gender { get; set; }
        public string City { get; set; }
    }
}
