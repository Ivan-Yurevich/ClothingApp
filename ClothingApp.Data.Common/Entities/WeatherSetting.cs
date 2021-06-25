using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    class WeatherSetting : EntityBase<long>
    {
        /// <summary>
        /// Наименование настройки
        /// </summary>
        public string Name { get; set; }

        public enum TypeOfClothing
        {
            /// <summary>
            /// Головной убор
            /// </summary>
            Headdress = 1,

            /// <summary>
            /// Верхняя одежда
            /// </summary>
            Outerwear = 2,

            /// <summary>
            /// Нижняя одежда
            /// </summary>
            Underwear = 3,

            /// <summary>
            /// Обувь
            /// </summary>
            Footwear = 4,

            /// <summary>
            /// Аксессуар
            /// </summary>
            Accessory = 5
        }
    }
}
