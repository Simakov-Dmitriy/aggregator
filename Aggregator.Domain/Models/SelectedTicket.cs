namespace Aggregator.Domain.Models
{
    public class SelectedTicket : BaseEntity
    {
        public string UserId { get; set; }
        public string Tickets { get; set; }
    }
}
