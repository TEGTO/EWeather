namespace EWeather
{
    public static class Configuration
    {
        public static string WEATHER_API_URL { get; } = "WeatherApiUrl";
        public static string WEATHER_API_KEY { get; } = "WeatherApiKey";
        public static string HTTP_CLIENT_RESILIENCE_PIPELINE { get; } = "HttpClioentResiliencePipeline";
    }
}
