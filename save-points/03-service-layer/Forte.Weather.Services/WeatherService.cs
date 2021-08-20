namespace Forte.Weather.Services
{
    public class WeatherService : IWeatherService
    {
        public List<WeatherModel> WeatherForcast(int days)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherModel
            {
                Date = DateTime.Now.AddDays(index),
                Celcius = Random.Shared.Next(-20, 55),
                Summary = SummaryCreator.Summaries[Random.Shared.Next(SummaryCreator.Summaries.Length)]
            }).ToList();
        }
    }
}
