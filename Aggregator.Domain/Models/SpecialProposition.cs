using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class SpecialProposition : BaseEntity
    {
        public string Text { get; set; }
        public string ImageId { get; set; }

        public ICollection<Coupon> Coupons { get; set; }
    }
}
