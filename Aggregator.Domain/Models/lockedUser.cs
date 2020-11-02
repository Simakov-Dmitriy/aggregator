using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class lockedIp : BaseEntity
    {
        public string IpAddress { get; set; }
        public DateTime? LokedTime { get; set; }
        public int Counter { get; set; }
    }
}
