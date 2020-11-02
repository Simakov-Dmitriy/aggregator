using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class TiketViewModel
    {
        [Required]
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string City { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public double AdultCost { get; set; }
        [Required]
        public double ChildCost { get; set; }



        public double ChildSale { get; set; }
        public double AdultSale { get; set; }
        public double Discount { get; set; }
        [Required]
        public DateTime ClosingDate { get; set; }
        public string ImageId { get; set; }
        public string CouponId { get; set; }
    }
}
