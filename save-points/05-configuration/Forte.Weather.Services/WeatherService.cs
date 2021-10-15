using Forte.Weather.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forte.Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;

        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WeatherModel>> WeatherForcast(int days)
        {
            return (await _repository.GetForecast(days)).ToModel();
        }
    }
}
