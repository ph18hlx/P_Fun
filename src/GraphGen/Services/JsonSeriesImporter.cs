using System.Text.Json;
using GraphGen.Models;

namespace GraphGen.Services
{
    public class JsonSeriesImporter
    {
        private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true };

        public DataSeries Import(string json)
        {
            var serie = JsonSerializer.Deserialize<DataSeries>(json, Options);

            if (serie == null || string.IsNullOrWhiteSpace(serie.Name))
                throw new FormatException("Le JSON ne contient pas de nom de série.");

            return serie;
        }
    }
}