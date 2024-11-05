using EWeather.Helpers;
using EWeather.Services;
using Microsoft.AspNetCore.Mvc;

namespace EWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService, IHttpHelper httpHelper, IConfiguration configuration)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherDataAsync(string city, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await weatherService.GetWeatherDataAsync(city, cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Json(response);
        }
    }
}
