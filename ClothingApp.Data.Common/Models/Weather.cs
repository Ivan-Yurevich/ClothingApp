using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Models
{
    public class Weather
    {
        public int Id { get; set; }

        /// <summary>
        /// небо
        /// </summary>
        public string Sky { get; set; }
        /// <summary>
        /// комментарий к небу
        /// </summary>
        public string DescriptionSky { get; set; }
        /// <summary>
        /// температура максимальная
        /// </summary>
        public double TemperatureMax { get; set; }
        /// <summary>
        /// температура минимальная
        /// </summary>
        public double TemperatureMin { get; set; }
        /// <summary>
        /// скорость ветра
        /// </summary>
        public double WindSpeed { get; set; }

        public Weather(string sky, string descriptionSky, double tempMax, double tempMin, double wind)
        {
            Sky = sky;
            DescriptionSky = descriptionSky;
            TemperatureMax = tempMax;
            TemperatureMin = tempMin;
            WindSpeed = wind;
        }
    }
}
