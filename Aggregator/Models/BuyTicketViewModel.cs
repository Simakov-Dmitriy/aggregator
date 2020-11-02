using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class BuyTicketViewModel
    {
        public CardViewModel Card { get; set; }
        public UserInfoViewModel UserInfo { get; set; }
        public string Tikets { get; set; }
        public string PromoCode { get; set; }
        public string AudioGuide { get; set; }
        public SpesialPropositionViewModel SpesialProposition { get; set; }

        public string SuperTiket { get; set; }
        public string Insurance { get; set; }
        public string City { get; set; }
        public bool Capcha { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
    public class AgeInfo
    {
        public int? adult { get; set; }
        public int? child { get; set; }
    }
}
