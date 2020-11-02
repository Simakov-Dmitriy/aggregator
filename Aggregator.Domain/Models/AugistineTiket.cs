using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class AugistineTiket : BaseEntity
    {
        public string Text { get; set; }
        public DateTime ClosingDate { get; set; }
        public string ImageId { get; set; }
        public double AdultCost { get; set; }
        public double ChildCost { get; set; }
        public double Discount { get; set; }
        public string CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}
