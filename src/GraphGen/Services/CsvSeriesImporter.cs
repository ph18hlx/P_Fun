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
                .Select(ligne => ligne.Split(';'))
                .Select(champs => new DataPoint(
                    DateTime.Parse(champs[0], CultureInfo.InvariantCulture),
                    double.Parse(champs[1], CultureInfo.InvariantCulture)
                ))
                .ToList();
        }
    }
}