using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class CompositionOfStyle : EntityBase<long>
    {
        public int StyleId { get; set; }
        public Style Style { get; set; }

        public int ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }
    }
}
