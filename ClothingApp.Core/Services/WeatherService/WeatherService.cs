using ClothingApp.Data.Common.Models;
using Dadata;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        /// Получение погоды за неделю
        /// </summary>
        /// <param name="remoteIpAddress"></param>
        public string GetWeatherForWeek(string remoteIpAddress, string address)
        {
            return null;
            string url = $"https://pro.openweathermap.org/data/2.5/forecast/climate?id={address}&units=metric&appid=90b476eb5559e5ee382e6a79ac19c8d0&"; 

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent = "SimpleHostClient";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
            {
                response = streamReader.ReadToEnd().ToString();
            }

            return response;
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
        /// получение погоды на сегодня 
        /// </summary>
        public Weather GetWeatherForToDay(string remoteIpAddress, string address)
        {
            string site = "http://api.openweathermap.org/data/2.5/weather?q={address}&lang=ru&units=metric&appid=90b476eb5559e5ee382e6a79ac19c8d0& ";
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
            req.Method = "GET";
            req.UserAgent = "SimpleHostClient";
            req.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            JObject jObject = JObject.Parse(result);
            dynamic obj = jObject;
            string sky = "";
            string descriptionSky = "";
            foreach (var item in obj["weather"])
            {
                sky = item.main;
                descriptionSky = item.description;
            }
            double tempMax = 0;
            double tempMin = 0;
            foreach (JProperty rate in obj["main"])
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
            double wind = 0;
            foreach (JProperty rate in obj["wind"])
            {
                if (rate.Name == "speed")
                {
                    wind = Convert.ToDouble(rate.Value);
                }

            }
            Weather weather = new Weather(sky, descriptionSky, tempMax, tempMin, wind);
            return weather;
        }
    }
}
