using GraphGen.Extensions;
using GraphGen.Models;
using GraphGen.Services;
using System.Text.Json;

namespace GraphGen
{
    /// <summary>
    /// Fenêtre principale de PTL : import des séries, sélection et affichage graphique.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly SeriesRepository _repository = new();
        private readonly Dictionary<string, DataSeries> _series;

        public Form1()
        {
            InitializeComponent();
            _series = _repository.LoadAll().ToDictionary(serie => serie.Name);

            // Période affichée par défaut : les 2 dernières années
            dtpFin.Value = DateTime.Today;
            dtpDebut.Value = DateTime.Today.AddYears(-2);

            RafraichirAffichage();
        }

        // TODO: le nom de la série vient du nom du fichier CSV, on pourrait demander un nom à l'utilisateur.
        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Fichiers CSV (*.csv)|*.csv";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var nom = Path.GetFileNameWithoutExtension(dialog.FileName).ToUpperInvariant();
                var points = new CsvSeriesImporter().Import(File.ReadAllLines(dialog.FileName));
                AjouterOuMettreAJour(nom, points);
            }
            catch (Exception ex) when (ex is FormatException or IndexOutOfRangeException or IOException)
            {
                AfficherErreur($"Fichier CSV invalide : {ex.Message}");
            }
        }

        private void btnImportJson_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Fichiers JSON (*.json)|*.json";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var json = File.ReadAllText(dialog.FileName);
                var serie = new JsonSeriesImporter().Import(json);
                AjouterOuMettreAJour(serie.Name.ToUpperInvariant(), serie.Points);
            }
            catch (Exception ex) when (ex is JsonException or FormatException or IOException)
            {
                AfficherErreur($"Fichier JSON invalide : {ex.Message}");
            }
        }

        // TODO: seule la paire EUR/USD est branchée dans l'interface.
        private async void btnImportApi_Click(object sender, EventArgs e)
        {
            // try/catch ici : une exception qui s'échappe d'un "async void" ferait planter l'appli.
            try
            {
                var point = await new ApiSeriesImporter().GetLatestRateAsync("EUR", "USD");
                AjouterOuMettreAJour("EURUSD", new[] { point });
            }
            catch (Exception ex) when (ex is HttpRequestException or JsonException or KeyNotFoundException or FormatException)
            {
                AfficherErreur($"Impossible de récupérer le taux EUR/USD : {ex.Message}");
            }
        }

        private static void AfficherErreur(string message)
        {
            MessageBox.Show(message, "Erreur d'import", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Fusionne les points dans la série du même nom (ou la crée), la sauvegarde et rafraîchit l'affichage.
        /// </summary>
        // TODO: le graphique est redessiné à chaque import, on pourrait le faire une seule fois.
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

        /// <summary>
        /// Reconstruit la liste des séries en conservant les cases déjà cochées, puis redessine le graphique.
        /// </summary>
        private void RafraichirAffichage()
        {
            var nomsCoches = clbSeries.CheckedItems.Cast<string>().ToHashSet();
            var noms = _series.Keys.OrderBy(n => n).ToArray();

            clbSeries.Items.Clear();
            clbSeries.Items.AddRange(noms);

            noms.Select((nom, index) => (nom, index))
                .Where(t => nomsCoches.Contains(t.nom))
                .ToList()
                .ForEach(t => clbSeries.SetItemChecked(t.index, true));

            RafraichirGraphique();
        }

        /// <summary>
        /// Redessine une courbe par série cochée, filtrée sur la période choisie (et normalisée si demandé).
        /// </summary>
        // TODO: aucune vérification que la date de début est avant la date de fin.
        private void RafraichirGraphique()
        {
            formsPlot1.Plot.Clear();

            clbSeries.CheckedItems
                .Cast<string>()
                .Select(nom => _series[nom])
                .ToList()
                .ForEach(TracerCourbe);

            formsPlot1.Plot.Axes.DateTimeTicksBottom();
            formsPlot1.Plot.Axes.Left.Label.Text = chkNormaliser.Checked ? "Variation (%)" : "Valeur";
            formsPlot1.Plot.Legend.IsVisible = true;
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
        }

        private void TracerCourbe(DataSeries series)
        {
            var points = series.Points.InRange(dtpDebut.Value, dtpFin.Value);

            if (chkNormaliser.Checked)
                points = points.Normalize();

            var pointsListe = points.ToList();
            if (pointsListe.Count == 0) return; // rien à tracer sur cette période

            var dates = pointsListe.Select(p => p.Date.ToOADate()).ToArray();
            var valeurs = pointsListe.Select(p => p.Value).ToArray();

            var courbe = formsPlot1.Plot.Add.Scatter(dates, valeurs);
            courbe.LegendText = series.Name;
        }

        private void clbSeries_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // La case n'est cochée "pour de vrai" qu'après l'événement : on reporte le redessin.
            BeginInvoke((MethodInvoker)RafraichirGraphique);
        }

        private void chkNormaliser_CheckedChanged(object sender, EventArgs e)
        {
            RafraichirGraphique();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            RafraichirGraphique();
        }
    }
}