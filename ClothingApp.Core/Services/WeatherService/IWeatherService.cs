using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ClothingApp.Data.Common.Models;

namespace ClothingApp.Core.Services.WeatherService
{
    public interface IWeatherService
    {
        List<Weather> GetWeatherForFiveDays(string address);

        Task<string> GetCity(string remoteIpAddress);
        
        List<Weather> GetWeatherForToDay(string address);
        
        string GetCityName(string remoteIpAddress);
        
        List<Weather> GetWeatherForTomorrow(string address);
    }
}
