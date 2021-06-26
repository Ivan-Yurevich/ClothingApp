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
        /// Получение погоды на 5 дней (утро/день/вечер)
        /// </summary>
        /// <param name="remoteIpAddress"></param>
        public List<Weather> GetWeatherForFiveDays(string address)
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
            //преобразуем JSON с сайта словарь в строку
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

            string sky = string.Empty;// небо (ясно/облачно и тд)
            string descriptionSky = string.Empty;// комментарий (пасмурно,небольшой дождь и тд)
            double tempMax = 0; //температура
            double tempMin = 0; //температура
            double wind = 0; //скорость ветра

            //вся погода на пять дней с шагом в 3 часа в сутки,которая пришла с сайта
            List<Weather> allWeather = new List<Weather>();

            //вся погода на пять дней с шагом утро/день/вечер
            List<Weather> сurrentWeather = new List<Weather>();

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
                Weather weather = new Weather(sky, descriptionSky, tempMax, tempMin, wind);
                allWeather.Add(weather);
            }

            сurrentWeather.Add(allWeather.ElementAt(2));
            сurrentWeather.Add(allWeather.ElementAt(4));
            сurrentWeather.Add(allWeather.ElementAt(6));
            сurrentWeather.Add(allWeather.ElementAt(10));
            сurrentWeather.Add(allWeather.ElementAt(12));
            сurrentWeather.Add(allWeather.ElementAt(14));
            сurrentWeather.Add(allWeather.ElementAt(18));
            сurrentWeather.Add(allWeather.ElementAt(20));
            сurrentWeather.Add(allWeather.ElementAt(22));
            сurrentWeather.Add(allWeather.ElementAt(26));
            сurrentWeather.Add(allWeather.ElementAt(28));
            сurrentWeather.Add(allWeather.ElementAt(30));
            сurrentWeather.Add(allWeather.ElementAt(34));
            сurrentWeather.Add(allWeather.ElementAt(36));
            сurrentWeather.Add(allWeather.ElementAt(38));

            return сurrentWeather;
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
        public List<Weather> GetWeatherForToDay(string address)
        {
            List<Weather> toDayWeather = new List<Weather>();

            toDayWeather.Add(GetWeatherForFiveDays(address).ElementAt(0));
            toDayWeather.Add(GetWeatherForFiveDays(address).ElementAt(1));
            toDayWeather.Add(GetWeatherForFiveDays(address).ElementAt(2));

            return toDayWeather;

        }
        /// <summary>
        /// получение погоды на завтра (утро/день/вечер)
        /// </summary>
        public List<Weather> GetWeatherForTomorrow(string address)
        {
            List<Weather> tomorrow = new List<Weather>();

            tomorrow.Add(GetWeatherForFiveDays(address).ElementAt(3));
            tomorrow.Add(GetWeatherForFiveDays(address).ElementAt(4));
            tomorrow.Add(GetWeatherForFiveDays(address).ElementAt(5));

            return tomorrow;

        }
    }
}
