using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.models;
using weather_web.backend; // Add this line to import WeatherService
using Microsoft.AspNetCore.SignalR; // Add this line to import SignalR
using System.Threading.Tasks;
using weather_web.Realtime;

namespace weather_web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHubContext<WeatherHub> _hubContext;

        public HomeController(IHubContext<WeatherHub> hubContext)
        {
            _hubContext = hubContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetWeatherDetails(string location)
        {
            WeatherService weatherService = new WeatherService();
            // khoi tao Service
            if (string.IsNullOrEmpty(location))
            {
                location = "Ho Chi Minh City";
            }
            // set defaut location la Ho Chi Minh City
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

                    // Gửi dữ liệu thời tiết theo thời gian thực qua SignalR
                    await _hubContext.Clients.All.SendAsync("ReceiveWeatherUpdate", weatherData);
                    
                    
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
