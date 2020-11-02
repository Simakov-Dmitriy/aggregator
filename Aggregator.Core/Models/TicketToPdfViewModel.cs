using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class TicketToPdfViewModel
    {
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string TiketId { get; set; }
        public string Cost { get; set; }
        public string Count { get; set; }
        public bool HaveAudioGuide { get; set; }
        public string Status { get; set; }
        public string AgeCategory { get; set; }
        public string City { get; set; }

        public byte[] ImageQr { get; set; }
        public string TicketName { get; set; }
        public string TicketImgUrl { get; set; }
    }
}
