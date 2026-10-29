using GraphGen.Extensions;
using GraphGen.Models;

namespace GraphGen.Tests
{
    public class DataPointExtensionsTests
    {
        [Fact]
        public void Normalize_PremierPoint_VautZeroPourcent()
        {
            var points = new[]
            {
                new DataPoint(new DateTime(2026, 1, 1), 50),
                new DataPoint(new DateTime(2026, 1, 2), 60)
            };

            var resultat = points.Normalize().ToList();

            Assert.Equal(0, resultat[0].Value);
        }

        [Fact]
        public void Normalize_CoursQuiDouble_Donne100Pourcent()
        {
            var points = new[]
            {
                new DataPoint(new DateTime(2026, 1, 1), 100),
                new DataPoint(new DateTime(2026, 1, 2), 200)
            };

            var resultat = points.Normalize().ToList();

            Assert.Equal(100, resultat[1].Value, 5);
        }

        [Fact]
        public void Normalize_PremiereValeurZero_RetourneListeVide()
        {
            var points = new[]
            {
                new DataPoint(new DateTime(2026, 1, 1), 0),
                new DataPoint(new DateTime(2026, 1, 2), 5)
            };

            Assert.Empty(points.Normalize());
        }

        [Fact]
        public void InRange_GardeSeulementLesPointsDansLaPeriode()
        {
            var points = new[]
            {
                new DataPoint(new DateTime(2026, 1, 1), 1),
                new DataPoint(new DateTime(2026, 2, 1), 2),
                new DataPoint(new DateTime(2026, 3, 1), 3)
            };

            var resultat = points.InRange(new DateTime(2026, 1, 15), new DateTime(2026, 2, 15)).ToList();

            Assert.Single(resultat);
            Assert.Equal(2, resultat[0].Value);
        }
    }
}