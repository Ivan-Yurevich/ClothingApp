using ClothingApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClothingApp.Core.Services.WeatherService;
using ClothingApp.Data;
using System.Collections.Generic;
using ClothingApp.Data.Common.Models;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ClothingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService, ApplicationDbContext context)
        {
            _logger = logger;
            _weatherService = weatherService;
            _db = context;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public async Task<IActionResult> Index()
        {

            await LoaderDBData.Load(_db);
            return View();
        }


        [HttpGet]
        public string GetName()
        {
            return "Иван";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
