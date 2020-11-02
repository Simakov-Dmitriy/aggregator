using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class ModeratorViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public DateTime LastTouched { get; set; }
    }
}
