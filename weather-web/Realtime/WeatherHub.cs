using Microsoft.AspNetCore.SignalR;

public class WeatherHub : Hub
{
    public async Task SendWeatherUpdate(string location, object weatherData)
    {
        await Clients.All.SendAsync("ReceiveWeatherUpdate", location, weatherData);
    }

    }
