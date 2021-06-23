using ClothingApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Interfaces
{
    public interface IWeather:IBaseRepository<Weather>
    {
        /// <summary>
        /// получение текущей погоды
        /// </summary>
        void CurrentWeather();

        /// <summary>
        /// получение погоды на сегодня, завтра, неделю
        /// </summary>
        void FutureWeather();

        /// <summary>
        /// выбор/определение региона
        /// </summary>
        void CurrentRegion();
    }
}
