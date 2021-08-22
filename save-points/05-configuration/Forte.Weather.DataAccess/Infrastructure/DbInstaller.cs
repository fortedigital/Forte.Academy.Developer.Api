using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forte.Weather.DataAccess.Infrastructure
{
    public static class DbInstaller
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<WeatherDbContext>(options => options.UseSqlite(GetConnectionString()));

            services.AddTransient<IWeatherRepository, WeatherRepository>();
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return builder.GetConnectionString("WeatherDb");
        }
    }
}
