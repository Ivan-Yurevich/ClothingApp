using System.ComponentModel.DataAnnotations;

namespace ClothingApp.Data.Common.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
