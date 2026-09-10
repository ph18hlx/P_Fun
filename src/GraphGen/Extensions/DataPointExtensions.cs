using GraphGen.Models;

namespace GraphGen.Extensions
{
    public static class DataPointExtensions
    {
        public static IEnumerable<DataPoint> Normalize(this IEnumerable<DataPoint> points)
        {
            var liste = points.ToList();
            if (liste.Count == 0) yield break;

            var valeurDepart = liste[0].Value;

            foreach (var point in liste)
            {
                var variation = (point.Value / valeurDepart - 1) * 100;
                yield return new DataPoint(point.Date, variation);
            }
        }
        public static IEnumerable<DataPoint> InRange(this IEnumerable<DataPoint> points, DateTime debut, DateTime fin)
        {
            return points.Where(p => p.Date >= debut && p.Date <= fin);
        }
    }
}