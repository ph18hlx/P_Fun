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
    }
}