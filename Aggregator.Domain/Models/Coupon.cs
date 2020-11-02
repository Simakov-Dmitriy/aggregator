using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class Coupon : BaseEntity
    {
        [ExplicitKey]
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public int Counter { get; set; }
        public string Link { get; set; }
        public double SaleProcent { get; set; }
        public string PromoCode { get; set; }
        public DateTime ClosingDate { get; set; }
        public string City { get; set; }

        public string SpecialPropositionId { get; set; }
        public SpecialProposition SpecialProposition { get; set; }

        public ICollection<ChicagoTiket> Tikets { get; set; }

    }
}
