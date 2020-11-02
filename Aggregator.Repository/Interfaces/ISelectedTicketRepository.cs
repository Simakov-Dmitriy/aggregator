using Aggregator.Domain.Models;
using System.Collections.Generic;

namespace Aggregator.Repository.Interfaces
{
    public interface ISelectedTicketRepository : IBaseRepository<SelectedTicket>
    {
        List<SelectedTicket> GetByListIp(string userIP);
        void setTicketById(string userIP, string ticket, string Id);
        void DeleteByIp(string userIP);
    }
}
