using EWeather.Models;

namespace EWeather.Services
{
    public interface IWeatherService
    {
        public Task<WeatherForecastViewModel?> GetWeatherDataAsync(string city, CancellationToken cancellationToken);
    }
}