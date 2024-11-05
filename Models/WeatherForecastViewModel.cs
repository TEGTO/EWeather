namespace EWeather.Models
{
    public class WeatherForecastViewModel
    {
        public string City { get; set; } = default!;
        public DateTime Date { get; set; }
        public int Precipitation { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }
        public bool RainWarning { get; set; }
    }
}
