using GraphGen.Models;

namespace GraphGen.Extensions
{
    /// <summary>
    /// Méthodes d'extension pour manipuler des collections de DataPoint avec LINQ.
    /// </summary>
    public static class DataPointExtensions
    {
        /// <summary>
        /// Convertit chaque valeur en variation (%) par rapport à la première valeur de la collection.
        /// </summary>
        // TODO: si la 1re valeur est 0, on pourrait partir de la première valeur non nulle.
        public static IEnumerable<DataPoint> Normalize(this IEnumerable<DataPoint> points)
        {
            var liste = points.ToList();

            // Collection vide ou valeur de départ nulle (division par zéro impossible)
            if (liste.Count == 0 || liste[0].Value == 0)
                return Enumerable.Empty<DataPoint>();

            var valeurDepart = liste[0].Value;

            return liste.Select(p => new DataPoint(p.Date, (p.Value / valeurDepart - 1) * 100));
        }

        /// <summary>
        /// Ne garde que les points dont la date est comprise entre début et fin (inclus).
        /// </summary>
        public static IEnumerable<DataPoint> InRange(this IEnumerable<DataPoint> points, DateTime debut, DateTime fin)
        {
            return points.Where(p => p.Date >= debut && p.Date <= fin);
        }
    }
}