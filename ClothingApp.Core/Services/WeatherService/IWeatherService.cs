using ClothingApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Core.Services.WeatherService
{
    public interface IWeatherService
    {
        List<Weather> GetWeatherForFiveDays(string remoteIpAddress, string address);
        Task<string> GetCity(string remoteIpAddress);
        List<Weather> GetWeatherForToDay(string remoteIpAddress, string address);
        List<Weather> GetWeatherForTomorrow(string remoteIpAddress, string address);
    }
}
