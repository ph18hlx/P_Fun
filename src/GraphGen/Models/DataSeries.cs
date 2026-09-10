namespace GraphGen.Models
{
    public class DataSeries
    {
        public string Name { get; set; }
        public List<DataPoint> Points { get; set; }

        public DataSeries(string name)
        {
            Name = name;
            Points = new List<DataPoint>();
        }

        public void AddOrUpdate(IEnumerable<DataPoint> nouveauxPoints)
        {
            Points = Points
                .Concat(nouveauxPoints)
                .GroupBy(point => point.Date)
                .Select(groupe => groupe.Last())
                .OrderBy(point => point.Date)
                .ToList();
        }
    }
}