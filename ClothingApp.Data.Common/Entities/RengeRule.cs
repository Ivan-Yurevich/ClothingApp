using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class RengeRule : EntityBase<long>
    {
        /// <summary>
        /// Минимальное значение температуры
        /// </summary>
        public double MinTemperature { get; set; }

        /// <summary>
        /// Максимальное значение температуры
        /// </summary>
        public double MaxTemperarure { get; set; }

        public enum RuleType
        {
            /// <summary>
            /// Темппература
            /// </summary>
            Temperature = 1
        }
    }
}
