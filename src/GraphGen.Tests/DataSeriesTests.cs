using GraphGen.Models;

namespace GraphGen.Tests
{
    public class DataSeriesTests
    {
        [Fact]
        public void AddOrUpdate_DateExistante_RemplaceLaValeurSansDoublon()
        {
            var serie = new DataSeries("TEST");
            serie.Points.Add(new DataPoint(new DateTime(2026, 1, 1), 10));

            serie.AddOrUpdate(new[] { new DataPoint(new DateTime(2026, 1, 1), 99) });

            Assert.Single(serie.Points);
            Assert.Equal(99, serie.Points[0].Value);
        }

        [Fact]
        public void AddOrUpdate_NouvellesDates_SontAjouteesEtTriees()
        {
            var serie = new DataSeries("TEST");
            serie.Points.Add(new DataPoint(new DateTime(2026, 1, 3), 30));

            serie.AddOrUpdate(new[] { new DataPoint(new DateTime(2026, 1, 1), 10) });

            Assert.Equal(2, serie.Points.Count);
            Assert.Equal(new DateTime(2026, 1, 1), serie.Points[0].Date);
        }
    }
}