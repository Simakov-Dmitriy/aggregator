using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Domain.Models
{
    public class BaseEntity
    {
        [ExplicitKey]
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
        }
    }
}
