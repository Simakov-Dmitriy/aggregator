using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class CustomerTiket : BaseEntity
    {
        public string CustomerId { get; set; }
        public string TiketId { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public double Sale { get; set; }
        public string SpesialPropositionId { get; set; }
        public string Status { get; set; }
        public bool IsAudioGuide { get; set; }
        public bool SuperPass { get; set; }
        public bool Insurance { get; set; }
        public string AgeCategory { get; set; }
        public bool IsUsed { get; set; }
    }
}
