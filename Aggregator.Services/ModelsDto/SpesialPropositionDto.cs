using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class SpesialPropositionDto
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
        public string ImageId { get; set; }
    }
}
