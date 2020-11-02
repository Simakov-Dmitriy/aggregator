﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.ModelsToView
{
    public class BuyerTicket
    {
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string TiketId { get; set; }
        public string Cost { get; set; }
        public string Count { get; set; }
        public string Status { get; set; }
        public string AgeCategory { get; set; }
    }
}
