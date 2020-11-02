namespace Aggregator.Domain.Models
{
    public class SelectedTickets : BaseEntity
    {
        public string UserIp { get; set; }
        public string Tickets { get; set; }
    }
}
