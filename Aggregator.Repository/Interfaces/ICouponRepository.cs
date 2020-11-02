using Aggregator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Interfaces
{
    public interface ICouponRepository : IBaseRepository<Coupon>
    {
        Coupon GetByPromoCode(string promoCode);
    }
}
