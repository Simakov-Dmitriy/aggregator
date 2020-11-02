using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class SpecialPropositionViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string ImageId { get; set; }

        public IFormFileCollection uploads { get; set; }
    }
}
