using Aggregator.Domain.Models;
using Aggregator.Repository.Interfaces;
using Aggregator.Repository.Repositories.Base;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Repositories
{
    internal class ProcessingRequestRepository : BaseRepository<ProcessingRequest>, IProcessingRequestRepository
    {
        public ProcessingRequestRepository(string tableName, string connectionString, IDbTransaction transaction = null) : base(tableName, connectionString, transaction)
        {
           
        }

        public void ImportRange(List<ProcessingRequest> requests)
        {
            Connection.Insert(requests, Transaction);
        }

        public List<ProcessingRequest> TakeNotMatchingUsers()
        {
            string sql = $@"SELECT pr.*
                        FROM {_tableName} pr 
                        LEFT OUTER JOIN Сustomers on Сustomers.Email = pr.Email
                        LEFT OUTER JOIN NotSpamUsers on NotSpamUsers.Email = pr.Email
                        WHERE Сustomers.Email is null and NotSpamUsers.Email is  null";
            var result = Connection.Query<ProcessingRequest>(sql, null, Transaction);
            return result.ToList();
        }
         public void RemoveReps()
        {
            string sql = $@"DELETE n1 FROM {_tableName} n1, {_tableName} n2 WHERE n1.id != n2.id AND n1.Email = n2.Email";
            var result = Connection.Execute(sql, null, Transaction);
        }

        public void RemoveAll()
        {
            string sql = $@"DELETE  FROM {_tableName}";
            var result = Connection.Execute(sql, null, Transaction);
        }


        public List<ProcessingRequest> FindByEmail(string email)
        {
            string sql = $@"Select * from { _tableName} Where Email = @Email ";
            var result = Connection.Query<ProcessingRequest>(sql,
               new
               {
                   Email = email,
               }, Transaction);
            return result.ToList();
        }

        public List<ProcessingRequest> FindByPhone(string phone)
        {
            string sql = $@"Select * from { _tableName} Where Phone = @Phone ";
            var result = Connection.Query<ProcessingRequest>(sql,
               new
               {
                   Phone = phone,
               }, Transaction);
            return result.ToList();
        }

        public List<ProcessingRequest> FindByName(string name)
        {
            string sql = $@"Select * from { _tableName} Where Name = @Name ";
            var result = Connection.Query<ProcessingRequest>(sql,
               new
               {
                   Name = name,
               }, Transaction);
            return result.ToList();
        }

        public List<ProcessingRequest> FindBySurname(string surname)
        {
            string sql = $@"Select * from { _tableName} Where Surname = @Surname ";
            var result = Connection.Query<ProcessingRequest>(sql,
               new
               {
                   Surname = surname,
               }, Transaction);
            return result.ToList();
        }
    }
}
