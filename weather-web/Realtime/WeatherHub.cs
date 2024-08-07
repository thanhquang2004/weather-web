using Microsoft.AspNetCore.SignalR;

namespace weather_web.Realtime;

public class WeatherHub : Hub
{
    public async Task SendWeatherUpdate(Object weatherData)
    {
        await Clients.All.SendAsync("ReceiveWeatherUpdate", weatherData);
    }
}