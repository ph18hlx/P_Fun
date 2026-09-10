using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphGen.Models
{
    public class ExchangeRateResponse
    {
        public string Base { get; set; } = "";
        public string Date { get; set; } = "";
        public Dictionary<string, double> Rates { get; set; } = new();
    }
}
