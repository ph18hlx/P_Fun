using GraphGen.Models;
using GraphGen.Services;
using System.Globalization;
using System.IO;

namespace GraphGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var series = new DataSeries("AAPL");
            series.Points.Add(new DataPoint(new DateTime(2026, 1, 2), 192.53));
            series.Points.Add(new DataPoint(new DateTime(2026, 1, 3), 193.15));
            series.Points.Add(new DataPoint(new DateTime(2026, 1, 4), 191.24));

            var lignes = series.Points
            .Select(point => $"{point.Date:dd.MM.yyyy} : {point.Value}")
            .ToArray();

            lstPoints.Items.AddRange(lignes);

        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Fichiers CSV (*.csv)|*.csv";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var lignes = File.ReadAllLines(dialog.FileName);

            var importer = new CsvSeriesImporter();
            var points = importer.Import(lignes);

            var series = new DataSeries("AAPL");
            series.Points.AddRange(points);

            lstPoints.Items.Clear();
            lstPoints.Items.AddRange(
                series.Points.Select(p => $"{p.Date:dd.MM.yyyy} : {p.Value}").ToArray()
            );

        }
    }
}