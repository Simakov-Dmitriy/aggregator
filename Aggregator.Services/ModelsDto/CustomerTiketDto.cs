using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class CustomerTiketDto
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
