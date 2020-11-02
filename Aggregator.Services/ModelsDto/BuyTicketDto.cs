using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class BuyTicketsDto
    {
        public CardDto Card { get; set; }
        public bool AudioGuide { get; set; }
        public bool SuperPass { get; set; }
        public bool Insurance { get; set; }
        public List<TiketInfo> Tikets { get; set; }
        public decimal Amount { get;  set; }
        public decimal CityProcent { get;  set; }
    }

    public class TiketInfo
    {
        public string Id { get; set; }
        public AgeInfo Age { get; set; }
    }

    public class AgeInfo
    {
        public int Adult { get; set; }
        public int Child { get; set; }
    }
}
