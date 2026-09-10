using System.Globalization;
using GraphGen.Models;

namespace GraphGen.Services
{
    public class CsvSeriesImporter
    {
        public List<DataPoint> Import(string[] lignesCsv)
        {
            return lignesCsv
                .Skip(1)
                .Where(ligne => !string.IsNullOrWhiteSpace(ligne))
                .Select(ligne => ligne.Split(','))
                .Select(champs => new DataPoint(
                    DateTime.Parse(champs[0], CultureInfo.InvariantCulture),
                    double.Parse(champs[4], CultureInfo.InvariantCulture)
                ))
                .ToList();
        }
    }
}