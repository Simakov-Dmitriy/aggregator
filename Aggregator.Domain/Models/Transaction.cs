using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public string TransactionId { get; set; }
        public string ResponseCode { get; set; }
        public string MessageCode { get; set; }
        public string Description { get; set; }
        public string HashCode { get; set; }
        public string AuthCode { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public string CustomerId { get; set; }
        public virtual Сustomer Customer { get; set; }
    }
}
