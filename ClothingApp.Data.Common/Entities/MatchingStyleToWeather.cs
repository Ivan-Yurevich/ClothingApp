using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class MatchingStyleToWeather : EntityBase<long>
    {
        public int WeatherSettingId { get; set; }
        public WeatherSetting WeatherSetting { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}
