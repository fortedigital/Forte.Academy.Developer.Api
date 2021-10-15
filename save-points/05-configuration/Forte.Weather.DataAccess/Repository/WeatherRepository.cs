using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forte.Weather.DataAccess
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _context;

        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherEntity>> GetForecast(int quantity)
        {
            return await _context.Weather
                .OrderBy(entity => entity.Id)
                .Take(quantity)
                .ToListAsync();
        }
    }
}
