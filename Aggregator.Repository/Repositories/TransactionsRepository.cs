using Aggregator.Domain.Models;
using Aggregator.Repository.Interfaces;
using Aggregator.Repository.Repositories.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Repositories
{
    internal class TransactionsRepository : BaseRepository<Transaction>, ITransactionsRepository
    {
        public TransactionsRepository( string tableName, string connectionString, IDbTransaction transaction = null ) : base(tableName, connectionString, transaction)
        {
        }

        public override void Add( Transaction item )
        {
            string sql = $@"INSERT INTO { _tableName} (Id, CreationDate, AuthCode, CustomerId, Description, 
                                    ErrorCode, ErrorMessage, HashCode, MessageCode, ResponseCode, TransactionId)
                            VALUES (@Id, @CreationDate, @AuthCode, @CustomerId, @Description, 
                                    @ErrorCode, @ErrorMessage, @HashCode, @MessageCode, @ResponseCode, @TransactionId)";
             Connection.Execute(sql,
                new
                {
                    Id = item.Id,
                    CreationDate = item.CreationDate,
                    AuthCode = item.AuthCode,
                    CustomerId = item.CustomerId,
                    Description = item.Description,
                    ErrorCode = item.ErrorCode,
                    ErrorMessage = item.ErrorMessage,
                    HashCode = item.HashCode,
                    MessageCode = item.MessageCode,
                    ResponseCode = item.ResponseCode,
                    TransactionId = item.TransactionId,
                }, Transaction);
        }
    }
}
