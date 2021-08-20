using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Forte.Weather.DataAccess.Infrastructure
{
    public static class DbInstaller
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<WeatherDbContext>(options => options.UseSqlite("Data source=weather.db"));

            services.AddTransient<IWeatherRepository, WeatherRepository>();
        }
    }
}
