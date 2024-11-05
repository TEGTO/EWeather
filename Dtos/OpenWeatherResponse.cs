using Newtonsoft.Json;

namespace EWeather.Dtos
{
    public class OpenWeatherResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("main")]
        public MainData Main { get; set; } = default!;

        [JsonProperty("weather")]
        public List<WeatherInfo> Weather { get; set; } = default!;

        [JsonProperty("dt")]
        public long DateTime { get; set; }
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }

    public class WeatherInfo
    {
        [JsonProperty("main")]
        public string Main { get; set; } = default!;

        [JsonProperty("description")]
        public string Description { get; set; } = default!;
    }
}
