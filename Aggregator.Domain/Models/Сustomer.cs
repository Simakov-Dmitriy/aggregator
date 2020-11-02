using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aggregator.Domain.Models
{
    public class Сustomer : BaseEntity
    {
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
