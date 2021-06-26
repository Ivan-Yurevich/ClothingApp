using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ClothingApp.Data.Common.Models;
using System.Threading.Tasks;

namespace ClothingApp.Core.Services.WeatherService
{
    public interface IWeatherService
    {
        string GetWeatherForWeek(string remoteIpAddress, string address);

        Task<string> GetCity(string remoteIpAddress);

        Weather GetWeatherForToDay(string remoteIpAddress, string address);
    }
}
