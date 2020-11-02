using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services.ModelsDto
{
    public class CreateTiketDto
    {
        public string Text { get; set; }
        public double AdultCost { get; set; }
        public double ChildCost { get; set; }
        public DateTime ClosingDate { get; set; }
        public string CouponId { get; set; }
        public string ImageId { get; set; }
    }
}
