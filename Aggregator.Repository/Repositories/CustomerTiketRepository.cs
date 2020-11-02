using Aggregator.Domain.Enums;
using Aggregator.Domain.Models;
using Aggregator.Domain.ModelsToView;
using Aggregator.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Repositories
{
    internal class CustomerTiketRepository : Base.BaseRepository<CustomerTiket>, ICustomerTiketRepository
    {
        public CustomerTiketRepository(string tableName, string connectionString, IDbTransaction transaction = null) : base(tableName, connectionString, transaction)
        {
        }

        public List<CustomerTiket> GetAllPurchased()
        {
            //string status = CustomerTiketStatus.Succes.ToString();
            string sql = $@"Select * from CustomerTikets ORDER BY CreationDate DESC ";
         //                  where Status = @Status";
            var resul = Connection.Query<CustomerTiket>(sql, null, Transaction);
            return resul.ToList();
        }

        public List<BuyerTicket> GetBuyerTikets()
        {
            string sql = $@"Select * from CustomerTikets 
                            left join [Сustomers]
                            on CustomerTikets.CustomerId = [Сustomers].Id";
            var resul = Connection.Query<BuyerTicket>(sql, null, Transaction);
            return resul.ToList();
        }

        public List<CustomerTiket> GetByUserId(string id)
        {
            string sql = $@"Select * from CustomerTikets 
                            where CustomerId = @CustomerId and Status='Succes'";
            var resul = Connection.Query<CustomerTiket>(sql, new { CustomerId = id }, Transaction);
            return resul.ToList();
        }
    }
}
