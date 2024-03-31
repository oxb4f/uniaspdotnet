using lr8.Services;
using Microsoft.AspNetCore.Mvc;

namespace lr8.Components;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class WeatherViewComponent : ViewComponent
{
    private readonly WeatherService _weatherService;

    public WeatherViewComponent(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string city)
    {
        var weatherInfo = await _weatherService.GetWeatherAsync(city);
        return View(weatherInfo);
    }
}
