﻿using ClothingApp.Core.Services.WeatherService;
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

            var city = await _weatherService.GetCity(""); // токен
            var respone = _weatherService.GetWeatherForWeek("", city);

            return Ok(respone);

        }
    }
}
