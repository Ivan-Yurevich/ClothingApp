using Dadata;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ClothingApp.Data.Common.Models;

namespace ClothingApp.Core.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private string _token;

        public WeatherService(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Получение погоды в виде JSON файла
        /// </summary>
        private string GetWeatherFromApi(string address)
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={address}&units=metric&appid=90b476eb5559e5ee382e6a79ac19c8d0&";
            string result = string.Empty;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = HttpMethod.Get.ToString();

            req.UserAgent = "SimpleHostClient";
            req.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Преобразуем JSON с сайта словарь в строку
        /// </summary>
        private string ConvertJSONtoString(string result)
        {
            JObject jObject = JObject.Parse(result);
            dynamic obj = jObject;
            string array = "";
            foreach (JProperty rate in obj)
            {
                if (rate.Name == "list")
                {
                    array = rate.Value.ToString();
                }
            }
            return array;
        }
        /// <summary>
        /// Получить всю погоду на пять дней с шагом в 3 часа в сутки
        /// </summary>
        public List<Weather> GetAllWeather(string address)
        {
            string result = GetWeatherFromApi(address);
            string array = ConvertJSONtoString(result);

            //вся погода на пять дней с шагом в 3 часа в сутки,которая пришла с сайта
            List<Weather> allWeather = new List<Weather>();

            string sky = string.Empty;// небо (ясно/облачно и тд)
            string descriptionSky = string.Empty;// комментарий (пасмурно,небольшой дождь и тд)
            double tempMax = 0; //температура
            double tempMin = 0; //температура
            double wind = 0; //скорость ветра
            DateTime dt;

            //преобразуем JSON словарь с сайта в список объектов погоды
            var massiv = JArray.Parse(array);

            for (int i = 0; i < massiv.Count; i++)
            {
                dynamic objMass = massiv[i];
                foreach (var item in objMass["weather"])
                {
                    sky = item.main;
                    descriptionSky = item.description;
                }

                dt = DateTime.Parse(objMass["dt_txt"].Value);

                foreach (JProperty rate in objMass["main"])
                {
                    if (rate.Name == "temp_max")
                    {
                        tempMax = Convert.ToDouble(rate.Value);
                    }
                    if (rate.Name == "temp_min")
                    {
                        tempMin = Convert.ToDouble(rate.Value);
                    }
                }

                foreach (JProperty rate in objMass["wind"])
                {
                    if (rate.Name == "speed")
                    {
                        wind = Convert.ToDouble(rate.Value);
                    }

                }
                Weather weather = new Weather(sky, descriptionSky, tempMax, tempMin, wind, dt);
                allWeather.Add(weather);
            }
            return allWeather;
        }
        /// <summary>
        /// Получение погоды на 5 дней (утро/день/вечер)
        /// </summary>
        /// <param name="remoteIpAddress"></param>
        public List<Weather> GetWeatherForFiveDays(string address)
        {
            //вся погода на пять дней с шагом в 3 часа в сутки,которая пришла с сайта
            List<Weather> allWeather = GetAllWeather(address);

            //вся погода на пять дней с шагом утро/день/вечер
            List<Weather> сurrentWeather = new List<Weather>();

            сurrentWeather = allWeather.Where(x => x.PartOfDay.HasValue)
                .GroupBy(x => new { x.PartOfDay.Value, x.DateTime.Date }, (y, z) => z.OrderBy(j => j.DateTime.Date).First())
                .Select(x => new Weather(x.Sky, x.DescriptionSky, x.TemperatureMax, x.TemperatureMin, x.WindSpeed, x.DateTime)).ToList();
            
            return сurrentWeather;
        }
        public List<Weather> GetWeatherForToday(string address)
        {
            List<Weather> toDayWeather = new List<Weather>();

            toDayWeather.AddRange(GetWeatherForFiveDays(address)
                        .Where(x => x.DateTime.ToUniversalTime().Date == DateTime.UtcNow.Date));

            return toDayWeather;
        }
        /// <summary>
        /// получение погоды на завтра (утро/день/вечер)
        /// </summary>
        public List<Weather> GetWeatherForTomorrow(string address)
        {
            List<Weather> tomorrow = new List<Weather>();

            tomorrow.AddRange(GetWeatherForFiveDays(address)
                    .Where(x => x.DateTime.ToUniversalTime().Date == DateTime.UtcNow.AddDays(1).Date));

            return tomorrow;

        }
        /// <summary>
        /// Определение города
        /// </summary>
        public async Task<string> GetCity(string remoteIpAddress)
        {
            var api = new SuggestClientAsync("978aa0c47b638d3f9bd479137116e19dcd68ed67");
            var result = await api.Iplocate(remoteIpAddress);

            return result.location.value;
        }
        /// <summary>
        /// получение названия города
        /// </summary>
        public string GetCityName(string remoteIpAddress)
        {
            string cityName = GetCity(remoteIpAddress).Result;
            cityName = cityName.Substring(2);

            return cityName;
        }
        /// <summary>
        /// получение погоды на сегодня (утро/день/вечер)
        /// </summary>
        
    }
}
