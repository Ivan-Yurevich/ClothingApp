using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    /// <summary>
    /// Объект одежды
    /// </summary>
    public class ClothingItem : EntityBase<long>
    {
        /// <summary>
        /// Наименование одежды
        /// </summary>
        public string Name { get; set; }
    }
}
