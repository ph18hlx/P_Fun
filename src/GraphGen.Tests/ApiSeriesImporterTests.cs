using GraphGen.Services;

namespace GraphGen.Tests
{
    public class ApiSeriesImporterTests
    {
        [Fact]
        public void ParseRate_JsonValide_RetourneBonPoint()
        {
            var json = "{\"amount\":1.0,\"base\":\"EUR\",\"date\":\"2026-01-02\",\"rates\":{\"USD\":1.0876}}";
            var importer = new ApiSeriesImporter();

            var point = importer.ParseRate(json, "USD");

            Assert.Equal(new DateTime(2026, 1, 2), point.Date);
            Assert.Equal(1.0876, point.Value);
        }
    }
}