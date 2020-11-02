using Aggregator.Domain.Models;
using Aggregator.Repository.Repositories.Base;
using System.Collections.Generic;

namespace Aggregator.Services.Services
{
    public class SelectedTicketServices
    {
        private readonly DbRepository _db;

        public SelectedTicketServices()
        {
            _db = new DbRepository();
        }

        public void Add(SelectedTicket selectedTicket)
        {
            _db.SelectedTickets.setTicketById(selectedTicket.UserId, selectedTicket.Tickets, selectedTicket.Id);
        }

        public IEnumerable<SelectedTicket> GetByIP(string ip)
        {
            return _db.SelectedTickets.GetByListIp(ip);
        }

        public void DeleteByIp(string userIP)
        {
            _db.SelectedTickets.DeleteByIp(userIP);
        }
    }
}
