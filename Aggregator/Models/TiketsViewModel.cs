using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class TiketsViewModel
    {
        public List<TiketViewModel> Tikets { get; set; }
        public string City { get; set; }
    }
}
