using lr8.Models;

namespace lr8.Services;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "api_key";  // API ключ

    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
    }

    public async Task<WeatherInfo> GetWeatherAsync(string city)
    {
        var response = await _httpClient.GetAsync($"weather?q={city}&appid={_apiKey}&units=metric");
        
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        
        var weatherData = JsonConvert.DeserializeObject<dynamic>(content);

        return new WeatherInfo
        {
            Description = weatherData.weather[0].description,
            Temperature = weatherData.main.temp,
            Humidity = weatherData.main.humidity
        };
    }
}
