using System;

namespace ClothingApp.Data.Common.Entities
{
    public class EntityBase<TKey> : IEntityBase<TKey>
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime? Deleted { get; set; }
    }
}