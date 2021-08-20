namespace Forte.Weather.Services
{
    public record WeatherModel
    {
        public DateTime Date { get; set; }

        public int Celcius { get; set; }

        public int Farenheit { get; set;}

        public string? Summary { get; set; }
    }
}
