using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Interfaces
{
    interface IWeather
    {
        /// <summary>
        /// получение текущей погоды
        /// </summary>
        void Current_Weather();
        /// <summary>
        /// получение погоды на сегодня, завтра, неделю
        /// </summary>
        void Future_Weather();
        /// <summary>
        /// выбор/определение региона
        /// </summary>
        void Current_Region();
    }
}
