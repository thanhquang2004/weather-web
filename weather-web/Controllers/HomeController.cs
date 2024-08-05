using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.models;
using weather_web.backend; // Add this line to import WeatherService

namespace weather_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetWeatherDetails(string location)
        {
            WeatherService weatherService = new WeatherService();
            // khoi tao Service
            var response = await weatherService.GetWeatherData(location);
            // fetch data voi location duoc nhap
            if (response.IsSuccess)
            {
                WeatherModel weatherData = response.JsonData as WeatherModel;
                // truyen data vao WeatherModel neu thanh cong

                if (weatherData != null && weatherData.Forecast != null && weatherData.Forecast.forecastday.Count > 0)
                {
                    // Hien thi du bao cac gio ke ( thử dữ liệu )
                    ViewData["HourlyForecast"] = weatherData.Forecast.forecastday[0].hour;
                }
                return View("Index", weatherData);
            }
            else
            {
                ViewData["Error"] = response.ErrorMessage;
                return View("Index");
            }
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
