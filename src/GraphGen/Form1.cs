using GraphGen.Extensions;
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
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var nom = Path.GetFileNameWithoutExtension(dialog.FileName).ToUpperInvariant();

            var lignes = File.ReadAllLines(dialog.FileName);
            var points = new CsvSeriesImporter().Import(lignes);

            AjouterOuMettreAJour(nom, points);
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
            var nomsCoches = clbSeries.CheckedItems.Cast<string>().ToHashSet();

            clbSeries.Items.Clear();
            foreach (var nom in _series.Keys.OrderBy(n => n))
            {
                clbSeries.Items.Add(nom, nomsCoches.Contains(nom));
            }

            RafraichirGraphique();
        }

        private void RafraichirGraphique()
        {
            formsPlot1.Plot.Clear();

            var seriesAffichees = clbSeries.CheckedItems
                .Cast<string>()
                .Select(nom => _series[nom]);

            foreach (var series in seriesAffichees)
            {
                var points = chkNormaliser.Checked
                    ? series.Points.Normalize()
                    : series.Points;

                var dates = points.Select(p => p.Date.ToOADate()).ToArray();
                var valeurs = points.Select(p => p.Value).ToArray();

                var courbe = formsPlot1.Plot.Add.Scatter(dates, valeurs);
                courbe.LegendText = series.Name;
            }

            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.Axes.Left.Label.Text = chkNormaliser.Checked ? "Variation (%)" : "Valeur";
            formsPlot1.Plot.Legend.IsVisible = true;
            formsPlot1.Refresh();
        }

        private void clbSeries_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((MethodInvoker)RafraichirGraphique);
        }

        private void chkNormaliser_CheckedChanged(object sender, EventArgs e)
        {
            RafraichirGraphique();
        }
    }
}