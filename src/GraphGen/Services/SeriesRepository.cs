using System.Text.Json;
using GraphGen.Models;

namespace GraphGen.Services
{
    public class SeriesRepository
    {
        private readonly string _dossier;

        // TODO: la détection du lecteur externe se fait uniquement au démarrage.
        // Si le disque est débranché en cours d'exécution, Save()/LoadAll() échoueront
        // jusqu'au redémarrage de l'application.
        public SeriesRepository()
        {
            const string cheminExterne = @"D:\FPA2\P_Fun";
            var lecteurExterne = Path.GetPathRoot(cheminExterne)!; // "D:\"

            _dossier = Directory.Exists(lecteurExterne)
                ? cheminExterne
                : Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "GraphGen");

            Directory.CreateDirectory(_dossier);
        }

        public void Save(DataSeries series)
        {
            var chemin = Path.Combine(_dossier, $"{series.Name}.json");
            File.WriteAllText(chemin, JsonSerializer.Serialize(series));
        }

        public List<DataSeries> LoadAll()
        {
            return Directory.GetFiles(_dossier, "*.json")
                .Select(File.ReadAllText)
                .Select(json => JsonSerializer.Deserialize<DataSeries>(json))
                .Where(serie => serie != null)
                .Select(serie => serie!)
                .ToList();
        }
    }
}