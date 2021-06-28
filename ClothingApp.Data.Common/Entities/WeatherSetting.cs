using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class WeatherSetting : EntityBase<long>
    {
        /// <summary>
        /// Наименование настройки
        /// </summary>
        public string Name { get; set; }

        public int BooleanRuleId { get; set; }
        public BooleanRule BooleanRule { get; set; }

        public int RangeRuleId { get; set; }
        public RangeRule RangeRule { get; set; }

        public ICollection<MatchingStyleToWeather> MatchingStyleToWeathers { get; set; }
    }

    public class TypeOfClothing : WeatherSetting
    {
        public enum TypeClothing
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
