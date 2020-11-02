using Aggregator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class ByTicketResult
    {
        public List<CustomerTiket> CustomerTikets { get; set; }
        public Transaction Transaction { get; set; }
    }
}
