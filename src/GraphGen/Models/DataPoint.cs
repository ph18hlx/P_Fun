namespace GraphGen.Models
{
    public class DataPoint
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public DataPoint(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}