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
    internal class NotSpamUserRepository : BaseRepository<NotSpamUser>, INotSpamUserRepository
    {
        public NotSpamUserRepository(string tableName, string connectionString, IDbTransaction transaction = null) : base(tableName, connectionString, transaction)
        {
        }

        public void RemoveAll()
        {
            string sql = $@"DELETE  FROM {_tableName}";
            var result = Connection.Execute(sql, null, Transaction);
        }

        public void RemoveReps()
        {
            string sql = $@"DELETE n1 FROM {_tableName} n1, {_tableName} n2 WHERE n1.id != n2.id AND n1.Email = n2.Email";
            var result = Connection.Execute(sql, null, Transaction);
        }

        public List<NotSpamUser> FindByEmail(string email)
        {
            string sql = $@"Select * from { _tableName} Where Email = @Email ";
            var result = Connection.Query<NotSpamUser>(sql,
               new
               {
                   Email = email,
               }, Transaction);
            return result.ToList();
        }

        public List<NotSpamUser> FindByPhone(string phone)
        {
            string sql = $@"Select * from { _tableName} Where Phone = @Phone ";
            var result = Connection.Query<NotSpamUser>(sql,
               new
               {
                   Phone = phone,
               }, Transaction);
            return result.ToList();
        }

        public List<NotSpamUser> FindByName(string name)
        {
            string sql = $@"Select * from { _tableName} Where Name = @Name ";
            var result = Connection.Query<NotSpamUser>(sql,
               new
               {
                   Name = name,
               }, Transaction);
            return result.ToList();
        }

        public List<NotSpamUser> FindBySurname(string surname)
        {
            string sql = $@"Select * from { _tableName} Where Surname = @Surname ";
            var result = Connection.Query<NotSpamUser>(sql,
               new
               {
                   Surname = surname,
               }, Transaction);
            return result.ToList();
        }
    }
}
