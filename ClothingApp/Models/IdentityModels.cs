using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothingApp.Models
{
    public enum UserGender
    {
        [Display(Name = "Женский")]
        Female = 1,
        [Display(Name = "Мужской")]
        Male = 2
    }

    public class CityList
    {
        public static SelectList GetCities() {
        List<SelectListItem> Genderitems = new List<SelectListItem>();
        
        Genderitems.Add(new SelectListItem() { Text = "Москва", Value = "Moscow" });
        Genderitems.Add(new SelectListItem() { Text = "Санкт-Петербург", Value = "Saint Petersburg" });
        return new SelectList(Genderitems, "Value", "Text");
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public UserGender Gender { get; set; }
        public string City { get; set; }
    }
}
