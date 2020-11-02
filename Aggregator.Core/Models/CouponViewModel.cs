using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class CouponViewModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public int Counter { get; set; }
        public string Link { get; set; }
        public double SaleProcent { get; set; }
        public string PromoCode { get; set; }
        public DateTime ClosingDate { get; set; }
        public string SpecialPropositionId { get; set; }

        public List<SelectListItem> SpecialPropositions { get; set; }

        public string CityCoise { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }

}

