using System;

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

        public PartOfDay? PartOfDay { get; set; }

        public DateTime DateTime { get; set; }

        public Weather(string sky, string descriptionSky, double tempMax, double tempMin, double wind, DateTime dateTime)
        {
            Sky = sky;
            DescriptionSky = descriptionSky;
            TemperatureMax = tempMax;
            TemperatureMin = tempMin;
            WindSpeed = wind;
            if (dateTime != DateTime.MinValue)
            {
                DateTime = dateTime;
                SetPartOfDay();
            }
        }

        private void SetPartOfDay()
        {
            if (DateTime.Hour > 3 && DateTime.Hour < 12) PartOfDay = Models.PartOfDay.Morning;
            else if (DateTime.Hour > 11 && DateTime.Hour < 16) PartOfDay = Models.PartOfDay.Daytime;
            else if (DateTime.Hour > 15 && DateTime.Hour < 23) PartOfDay = Models.PartOfDay.Evening;            
        }
    }
}
