using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RotaGeek.Services;
using RotaGeek.Services.Models;

namespace RotaGeek.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(WeatherRequest request)
        {
            var weather = await _weatherService.GetAsync(request.Location);
            return Json(weather);
        }
    }
}