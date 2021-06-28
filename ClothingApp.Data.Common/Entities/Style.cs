using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class Style : EntityBase<long>
    {
        /// <summary>
        /// Наименование образа
        /// </summary>
        public string Name { get; set; }

        public enum GenderType
        {
            /// <summary>
            /// Мужской пол
            /// </summary>
            Male = 1,

            /// <summary>
            /// Женский пол
            /// </summary>
            Female = 2
        }

        public ICollection<CompositionOfStyle> CompositionOfStyles { get; set; }

        public ICollection<MatchingStyleToWeather> MatchingStyleToWeathers { get; set; }
    }
}
