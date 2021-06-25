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
    [Route("[controller]")]
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
        /// <returns></returns>
        [HttpGet("fiveDays")]
        public IActionResult GetWeatherForWeek()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string city = _weatherService.GetCityName(""); // ip adress
            var respone = _weatherService.GetWeatherForFiveDays(city);

            return Ok(respone);

        }
        /// <summary>
        /// погода на сегодня
        /// </summary>
        /// <returns></returns>
        [HttpGet("today")]
        public ActionResult<Weather> GetWeatherToday()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string city = _weatherService.GetCityName(""); // ip adress
            var respone = _weatherService.GetWeatherForToDay(city);

            return Ok(respone);

        }
        /// <summary>
        /// погода на завтра
        /// </summary>
        /// <returns></returns>
        [HttpGet("tomorrow")]
        public ActionResult<Weather> GetWeatherTomorrow()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            string city = _weatherService.GetCityName(""); // ip adress
            var respone = _weatherService.GetWeatherForTomorrow(city);

            return Ok(respone);

        }
    }
}
