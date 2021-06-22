using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Models
{
    public class Weather
    {
        public int Id { get; set; }
        /// <summary>
        /// температура
        /// </summary>
        public int Temperature { get; set; }
        /// <summary>
        /// скорость ветра
        /// </summary>
        public double Wind { get; set; }
        /// <summary>
        /// снег
        /// </summary>
        public bool Snow { get; set; }
        /// <summary>
        /// дождь
        /// </summary>
        public bool Rain { get; set; }
        /// <summary>
        /// ясно
        /// </summary>
        public bool Clear { get; set; }
        /// <summary>
        /// пасмурно
        /// </summary>
        public bool Сloudy { get; set; }
    }
}
