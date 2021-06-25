using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class BooleanRule
    {
        /// <summary>
        /// Существует правило или нет
        /// </summary>
        public bool IsExist { get; set; }

        public enum BoolType
        {
            /// <summary>
            /// Наличие дождя
            /// </summary>
            PresenceOfRain = 1,

            /// <summary>
            /// Наличие ветра
            /// </summary>
            PresenceOfWind = 2,

            /// <summary>
            /// Наличие снега
            /// </summary>
            PresenceOfSnow = 3
        }
    }
}
