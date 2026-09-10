using GraphGen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGen.Tests
{
    public class CsvSeriesImporterTests
    {
        [Fact]
        public void Import_LignesValidesFormatStooq_RetournePoints()
        {
            var lignes = new[]
            {
        "Date,Open,High,Low,Close,Volume",
        "2026-01-02,192.10,193.80,191.50,192.53,42000000",
        "2026-01-03,192.60,194.20,192.00,193.15,39500000"
    };
            var importer = new CsvSeriesImporter();

            var resultat = importer.Import(lignes);

            Assert.Equal(2, resultat.Count);
            Assert.Equal(192.53, resultat[0].Value); // on vérifie bien la colonne Close, pas Open
        }

        [Fact]
        public void Import_AucuneLigneDeDonnees_RetourneListeVide()
        {
            var lignes = new[] { "Date,Open,High,Low,Close,Volume" };
            var importer = new CsvSeriesImporter();

            var resultat = importer.Import(lignes);

            Assert.Empty(resultat);
        }

        [Fact]
        public void Import_LigneVideEnFinDeFichier_EstIgnoree()
        {
            var lignes = new[]
            {
        "Date,Open,High,Low,Close,Volume",
        "2026-03-15,99.0,101.0,98.5,100.5,1000000",
        ""
    };
            var importer = new CsvSeriesImporter();

            var resultat = importer.Import(lignes);

            Assert.Single(resultat);
            Assert.Equal(100.5, resultat[0].Value);
        }
    }
}
