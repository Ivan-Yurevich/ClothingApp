using System;

namespace ClothingApp.Data.Common.Entities
{
    public interface IEntityBase<TKey>
    { 
        TKey Id { get; set; }

        DateTime? Updated { get; set; }

        DateTime? Deleted { get; set; }
    }
}