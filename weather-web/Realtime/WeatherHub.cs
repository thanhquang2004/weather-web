using Microsoft.AspNetCore.SignalR;

namespace weather_web.Realtime
{
    public class WeatherHub : Hub
    {
        // Phương thức này có thể được gọi từ client để gửi dữ liệu thời tiết
        public async Task SendWeatherUpdate(string location, object weatherData)
        {
            await Clients.All.SendAsync("ReceiveWeatherUpdate", location, weatherData);
        }
    }
}
