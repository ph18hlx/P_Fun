using GraphGen.Models;
using GraphGen.Services;
using ScottPlot.Statistics;
using System.Globalization;
using System.IO;

namespace GraphGen
{
   
    public partial class Form1 : Form
    {
        private readonly SeriesRepository _repository = new();
        private readonly Dictionary<string, DataSeries> _series;
        public Form1()
        {
            InitializeComponent();
            _series = _repository.LoadAll().ToDictionary(serie => serie.Name);
            RafraichirAffichage();
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Fichiers CSV (*.csv)|*.csv";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var lignes = File.ReadAllLines(dialog.FileName);
            var points = new CsvSeriesImporter().Import(lignes);

            AjouterOuMettreAJour("AAPL", points);
        }

        private async void btnImportApi_Click(object sender, EventArgs e)
        {
            var point = await new ApiSeriesImporter().GetLatestRateAsync("EUR", "USD");
            AjouterOuMettreAJour("EURUSD", new[] { point });
        }
        private void AjouterOuMettreAJour(string nom, IEnumerable<DataPoint> points)
        {
            if (!_series.TryGetValue(nom, out var series))
            {
                series = new DataSeries(nom);
                _series[nom] = series;
            }

            series.AddOrUpdate(points);
            _repository.Save(series);
            RafraichirAffichage();
        }

        private void RafraichirAffichage()
        {
            lstPoints.Items.Clear();
            if (_series.Count == 0) return;

            var derniere = _series.Values.Last(); // provisoire, avant la vraie liste de séries
            lstPoints.Items.AddRange(
                derniere.Points.Select(p => $"{p.Date:dd.MM.yyyy} : {p.Value}").ToArray()
            );
        }
    }
}