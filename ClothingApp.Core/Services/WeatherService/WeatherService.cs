using Dadata;
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
        public WeatherService()
        {
            // Подгрузить токен
        }

        /// <summary>
        /// Получение погоды за неделю
        /// </summary>
        /// <param name="remoteIpAddress"></param>
        public string GetWeatherForWeek(string remoteIpAddress, string address)
        {
            string url = $"https://pro.openweathermap.org/data/2.5/forecast/climate?id={address}&units=metric&appid="; // Вставить токен

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
            var api = new SuggestClientAsync(""); // вставить токен
            var result = await api.Iplocate(remoteIpAddress);

            return result.location.value;
        }
    }
}
