using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
