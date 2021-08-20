namespace Forte.Weather.Services
{
    public interface IWeatherService
    {
        public Task<IEnumerable<WeatherModel>> WeatherForcast(int days);
    }
}
