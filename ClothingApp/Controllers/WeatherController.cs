using ClothingApp.Core.Services.WeatherService;
using ClothingApp.Data.Common.Models;
using ClothingApp.Models;
using Microsoft.AspNetCore.Identity;
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
        UserManager<ApplicationUser> _userManager;
        private string userCity;

        public WeatherController(IWeatherService weatherService, UserManager<ApplicationUser> userManager)
        {
            _weatherService = weatherService;
            _userManager = userManager;
        }

        private string GetCityByIP()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            return _weatherService.GetCityName("46.0.40.18"); // ip adress
        }

        private async void GetCityFromUser()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(this.User.Identity.Name);
                userCity =  user.City;
            }
            else userCity = "";

        }
        /// <summary>
        /// погода на 5 дней
        /// </summary>
        public List<Weather> GetWeatherForWeek()
        {
            string city = GetCityByIP();
            var respone = _weatherService.GetWeatherForFiveDays(city);

            return respone;

        }
        /// <summary>
        /// погода на сегодня
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetWeatherToday()
        {
            string city = GetCityByIP();
            var respone = _weatherService.GetWeatherForToday(city);

            ViewBag.GetWeatherToday = respone;
            return respone;

        }
        
        /// <summary>
        /// погода на завтра
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetWeatherTomorrow()
        {
            string city = GetCityByIP();
            var respone = _weatherService.GetWeatherForTomorrow(city);           

            return respone;

        }
        [HttpGet]
        public ActionResult Today()
        {
            GetCityFromUser();
            ViewBag.GetWeatherToday = GetWeatherToday();
            ViewBag.IsDifferentPlaces = false;
            if (GetCityByIP()!=userCity&&userCity!="")
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("Today");
        }
        public ActionResult Tomorrow()
        {
            GetCityFromUser();
            ViewBag.GetWeatherTomorrow = GetWeatherTomorrow();
            ViewBag.IsDifferentPlaces = false;
            if (GetCityByIP() != userCity && userCity != "")
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("Tomorrow");
        }
    }
}
