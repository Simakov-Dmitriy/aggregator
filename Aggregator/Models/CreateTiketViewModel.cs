using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class CreateTiketViewModel
    {
        public string Text { get; set; }
        public double AdultCost { get; set; }
        public double ChildCost { get; set; }
        public DateTime ClosingDate { get; set; }
        public IFormFileCollection uploads { get; set; }
        public string CouponId { get; set; }
        public List<SelectListItem> Coupons { get; set; }
    }
}
