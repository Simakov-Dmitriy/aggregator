using Aggregator.Domain.Models;
using Aggregator.Repository.Interfaces;
using Aggregator.Repository.Repositories.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Aggregator.Repository.Repositories
{
     class SelectedTicketRepository : BaseRepository<SelectedTicket>, ISelectedTicketRepository
    {

        public SelectedTicketRepository(string tableName, string connectionString, IDbTransaction transaction = null) : base(tableName, connectionString, transaction)
        {
        }

        public void DeleteByIp(string userIP)
        {
            string sql = $"Delete from {_tableName} where UserId = @ip";
            Connection.Query<SelectedTicket>(sql, new
            {
                ip = userIP
            }, Transaction);
        }

        public List<SelectedTicket> GetByListIp(string userIP)
        {
            string sql = $@"Select * from {_tableName} where  UserId =  @Ids ";
            var result = Connection.Query<SelectedTicket>(sql, new { Ids = userIP }, Transaction);
            return result.ToList();
        }

        public void setTicketById(string userIP, string ticket, string Id)
        {
            string sql = $"INSERT INTO {_tableName} (Id,UserId, Tickets, CreationDate) VALUES (@id, @ip, @tickets, @Date)";
            Connection.Query<SelectedTicket>(sql, new
            {
                id = Id,
                ip = userIP,
                tickets = ticket,
                Date = DateTime.Now
            }, Transaction);
        }
    }
}
