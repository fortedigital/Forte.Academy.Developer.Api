using Microsoft.Extensions.Configuration;

namespace Forte.Weather.DataAccess.Infrastructure
{
    static class ConfigManager
    {
        public static IConfiguration AppSetting { get; }

        static ConfigManager()
        {
            AppSetting = new ConfigurationBuilder().Build();
                
        }
    }
}
