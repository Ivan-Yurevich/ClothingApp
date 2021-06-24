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

        [HttpGet("week")]
        public async Task<IActionResult> GetWeatherForWeek()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var city = await _weatherService.GetCity(""); // ip adress
            var respone = _weatherService.GetWeatherForWeek("", city);

            return Ok(respone);

        }

        [HttpGet("today")]
        public async Task<ActionResult<Weather>> GetWeatherToday()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var city = await _weatherService.GetCity(""); // ip adress
            var respone = _weatherService.GetWeatherForToDay("", city);

            return Ok(respone);

        }
    }
}
