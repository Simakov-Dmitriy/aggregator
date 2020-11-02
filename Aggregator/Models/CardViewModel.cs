using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class CardViewModel
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiresEnd { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
    }
}
