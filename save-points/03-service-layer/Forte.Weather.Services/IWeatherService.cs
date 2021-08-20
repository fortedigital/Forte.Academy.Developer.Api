namespace Forte.Weather.Services
{
    public interface IWeatherService
    {
        public List<WeatherModel> WeatherForcast(int days);
    }
}
