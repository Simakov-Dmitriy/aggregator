using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aggregator.Domain.Models;

namespace Aggregator.Models
{
    public class TicketsToPDFViewModel
    {
        public List<TicketToPdfViewModel> Tickets { get; set; }

        public Transaction Transaction { get; set; }
    }
}
