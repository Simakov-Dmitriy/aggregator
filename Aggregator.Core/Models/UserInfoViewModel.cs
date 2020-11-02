using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class UserInfoViewModel
    {
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

       
    }
}
