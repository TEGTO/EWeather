using AutoMapper;
using EWeather.Dtos;
using EWeather.Models;

namespace EWeather
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OpenWeatherResponse, WeatherForecastViewModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.DateTime).DateTime))
                .ForMember(dest => dest.HighTemp, opt => opt.MapFrom(src => ConvertKelvinToCelsius(src.Main.TempMax)))
                .ForMember(dest => dest.LowTemp, opt => opt.MapFrom(src => ConvertKelvinToCelsius(src.Main.TempMin)))
                .ForMember(dest => dest.Precipitation, opt => opt.MapFrom(src => src.Weather.Any(w => w.Main.Contains("Rain")) ? 100 : 0))
                .ForMember(dest => dest.RainWarning, opt => opt.MapFrom(src => src.Weather.Any(w => w.Main.Contains("Rain"))));
        }

        private static int ConvertKelvinToCelsius(double kelvin)
        {
            return (int)(kelvin - 273.15);
        }
    }
}