namespace Forte.Weather.DataAccess
{
    public interface IWeatherRepository
    {
        public Task<IEnumerable<WeatherEntity>> GetForecast(int quantity);
    }
}
