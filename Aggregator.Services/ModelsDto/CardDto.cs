using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class CardDto
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
    }
}
