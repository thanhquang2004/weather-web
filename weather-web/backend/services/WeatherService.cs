using Flurl.Http;
using backend.models;

namespace weather_web.backend
{
	public class WeatherService
	{
		// URL of the weather API
		private static readonly string WeatherApiUrl = "http://api.weatherapi.com/v1/forecast.json";

		// API key for the weather service, valid for 14 days
		private static readonly string WeatherApiKey = "f75c25d367144bb08af24259242008 ";

		public async Task<ResponseModel> GetWeatherData(string location)
		{
			// Construct the API URL with the provided location
			string apiUrl = $"{WeatherApiUrl}?key={WeatherApiKey}&q={location}&days=7&aqi=no&alerts=no";

			try
			{
				// Fetch data from the API
				var response = await apiUrl.GetAsync();

				// If the request is successful, parse the data into WeatherModel
				if (response.StatusCode == 200)
				{
					var responseData = await response.GetJsonAsync<WeatherModel>();
					return ResponseModel.Success(responseData);
				}

				// If there's an error, return an error response with the response message
				return ResponseModel.Error(response.ResponseMessage.ToString());
			}
			catch (FlurlHttpException ex)
			{
				// If an exception occurs, get the error response and return it
				var errorResponse = await ex.GetResponseStringAsync();
				return ResponseModel.Error(errorResponse);
			}
		}
	}
}
