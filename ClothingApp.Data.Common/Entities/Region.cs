using System.Collections.Generic;

namespace ClothingApp.Data.Common.Entities
{
    public class Region : EntityBase<long>
    {
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
