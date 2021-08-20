using Microsoft.Extensions.DependencyInjection;

namespace Forte.Weather.Services
{
    public static class ServiceInstaller
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IWeatherService, WeatherService>();
        }
    }
}
