﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class CreateCouponDto
    {
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public double SaleProcent { get; set; }
        public string PromoCode { get; set; }
        public DateTime ClosingDate { get; set; }
        public string SpecialPropositionId { get; set; }
        public string Link { get; set; }
        public string City { get; set; }
    }
}
