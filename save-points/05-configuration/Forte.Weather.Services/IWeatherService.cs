using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forte.Weather.Services
{
    public interface IWeatherService
    {
        public Task<IEnumerable<WeatherModel>> WeatherForcast(int days);
    }
}
