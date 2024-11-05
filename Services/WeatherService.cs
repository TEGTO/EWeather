using AutoMapper;
using EWeather.Dtos;
using EWeather.Helpers;
using EWeather.Models;

namespace EWeather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpHelper httpHelper;
        private readonly IMapper mapper;
        private readonly string weatherApiUrl;
        private readonly string weatherApiKey;

        public WeatherService(IMapper mapper, IHttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            weatherApiUrl = configuration[Configuration.WEATHER_API_URL]!;
            weatherApiKey = configuration[Configuration.WEATHER_API_KEY]!;
            this.mapper = mapper;
        }

        public async Task<WeatherForecastViewModel?> GetWeatherDataAsync(string city, CancellationToken cancellationToken)
        {
            var response = await httpHelper.SendGetRequestAsync<OpenWeatherResponse>(
                  weatherApiUrl,
                  new Dictionary<string, string> { { "q", city }, { "appid", weatherApiKey } },
                  cancellationToken: cancellationToken
                  );

            return mapper.Map<WeatherForecastViewModel>(response);
        }
    }
}
