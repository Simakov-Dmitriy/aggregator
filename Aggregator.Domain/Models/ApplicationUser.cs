using Microsoft.AspNetCore.Identity;
using System;

namespace Aggregator.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser():base()
        {
            
        }
        public string Role { get; set; }
        public bool IsBan { get; set; }
        public DateTime LastTouched { get; set; }
    }
}
