using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class CreateSpecialPropositionViewModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }

        [Required]
        public string Text { get; set; }

        public IFormFileCollection uploads { get; set; }
    }
}
