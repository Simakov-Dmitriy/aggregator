using System;

namespace Aggregator.Models
{
    public class CustomerTiketViewModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerId { get; set; }
        public string TiketId { get; set; }
        public string Cost { get; set; }
        public string Count { get; set; }
        public string Status { get; set; }
        public string AgeCategory { get; set; }
    }
}