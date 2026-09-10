using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using GraphGen.Models;

namespace GraphGen.Services
{
    public class ApiSeriesImporter
    {
        private readonly HttpClient _client = new();

        public async Task<DataPoint> GetLatestRateAsync(string devise1, string devise2)
        {
            var url = $"https://api.frankfurter.app/latest?from={devise1}&to={devise2}";
            var json = await _client.GetStringAsync(url);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ExchangeRateResponse>(json, options);

            var date = DateTime.Parse(data!.Date, CultureInfo.InvariantCulture);
            var valeur = data.Rates[devise2];

            return new DataPoint(date, valeur);
        }
    }
}