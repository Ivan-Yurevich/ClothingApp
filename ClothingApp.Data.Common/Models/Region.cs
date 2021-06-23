using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
