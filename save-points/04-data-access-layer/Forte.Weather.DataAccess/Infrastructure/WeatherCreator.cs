using Forte.Weather.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Forte.Weather.Services
{
    public static class WeatherCreator
    {
        private static readonly Random Random = new();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<WeatherEntity>().HasData(Create());
        }

        private static IEnumerable<WeatherEntity> Create()
        {
            return Enumerable.Range(1, 20)
                .Select(index => new WeatherEntity
                {
                    Id = index,
                    Date = DateTime.Now.AddDays(index),
                    Temperature = Random.Next(-20, 55),
                    Summary = Summaries[Random.Next(Summaries.Length)]
                });
        }
    }
}
