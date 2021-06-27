using ClothingApp.Core.Services.WeatherService;
using ClothingApp.Data.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        /// <summary>
        /// погода на 5 дней
        /// </summary>
        public List<Weather> GetWeatherForWeek()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string city = _weatherService.GetCityName("46.0.40.18"); // ip adress
            var respone = _weatherService.GetWeatherForFiveDays(city);

            return respone;

        }
        /// <summary>
        /// погода на сегодня
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetWeatherToday()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string city = _weatherService.GetCityName("46.0.40.18"); // ip adress
            var respone = _weatherService.GetWeatherForToDay(city);

            ViewBag.GetWeatherToday = respone;
            return respone;

        }
        
        /// <summary>
        /// погода на завтра
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetWeatherTomorrow()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string city = _weatherService.GetCityName("46.0.40.18"); // ip adress
            var respone = _weatherService.GetWeatherForTomorrow(city);           

            return respone;

        }
        [HttpGet]
        public ActionResult Today()
        {           
            ViewBag.GetWeatherToday = GetWeatherToday();
            return View("Today");
        }
        public ActionResult Tomorrow()
        {
            ViewBag.GetWeatherTomorrow = GetWeatherTomorrow();
            return View("Tomorrow");
        }
    }
}
