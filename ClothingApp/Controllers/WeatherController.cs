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
        public async Task<IActionResult> GetWeatherForWeek()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var city = await _weatherService.GetCity(""); // ip adress
            var respone = _weatherService.GetWeatherForFiveDays("", city);

            return Ok(respone);

        }
        /// <summary>
        /// погода на сегодня
        /// </summary>
        /// <returns></returns>
        [HttpGet("today")]
        public async Task<ActionResult<Weather>> GetWeatherToday()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var city = await _weatherService.GetCity(""); // ip adress
            var respone = _weatherService.GetWeatherForToDay("", city);

            return Ok(respone);

        }
        /// <summary>
        /// погода на завтра
        /// </summary>
        /// <returns></returns>
        [HttpGet("tomorrow")]
        public async Task<ActionResult<Weather>> GetWeatherTomorrow()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var city = await _weatherService.GetCity(""); // ip adress
            var respone = _weatherService.GetWeatherForTomorrow("", city);

            return Ok(respone);

        }
    }
}
