using Aggregator.Domain.Models;
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
    internal class СustomersRepository : Base.BaseRepository<Сustomer>, IСustomersRepository
    {
        public СustomersRepository( string tableName, string connectionString, IDbTransaction transaction = null ) : base(tableName, connectionString, transaction)
        {
        }

        public override void Add( Сustomer item )
        {
            string sql = $@"INSERT INTO { _tableName} (Id, CreationDate, Email, Name, Phone, Surname)
                            VALUES (@Id, @CreationDate, @Email, @Name, @Phone, @Surname )";
            Connection.Execute(sql,
               new
               {
                   Id = item.Id,
                   CreationDate = item.CreationDate,
                   Email = item.Email,
                   Name = item.Name,
                   Phone = item.Phone,
                   Surname = item.Surname,
               }, Transaction);
        }

        public Сustomer GetByEmailOrPhone( string email, string phone )
        {
            string sql = $@"Select * from { _tableName} Where Email = @Email or Phone = @Phone";
            var customer = Connection.QueryFirstOrDefault< Сustomer>(sql,
               new
               {
                   Email = email,
                   Phone = phone,
               }, Transaction);
            return customer;
        }

        public Сustomer GetByEmail(string email)
        {
            string sql = $@"Select * from { _tableName} Where Email = @Email ";
            var customer = Connection.QueryFirstOrDefault<Сustomer>(sql,
               new
               {
                   Email = email,
               }, Transaction);
            return customer;
        }

        public List<Сustomer> FindByEmail(string email)
        {
            string sql = $@"Select * from { _tableName} Where Email = @Email ";
            var customers = Connection.Query<Сustomer>(sql,
               new
               {
                   Email = email,
               }, Transaction);
            return customers.ToList();
        }

        public List<Сustomer> FindByPhone(string phone)
        {
            string sql = $@"Select * from { _tableName} Where Phone = @Phone ";
            var customers = Connection.Query<Сustomer>(sql,
               new
               {
                   Phone = phone,
               }, Transaction);
            return customers.ToList();
        }

        public List<Сustomer> FindByName(string name)
        {
            string sql = $@"Select * from { _tableName} Where Name = @Name ";
            var customers = Connection.Query<Сustomer>(sql,
               new
               {
                   Name = name,
               }, Transaction);
            return customers.ToList();
        }

        public List<Сustomer> FindBySurname(string surname)
        {
            string sql = $@"Select * from { _tableName} Where Surname = @Surname ";
            var customers = Connection.Query<Сustomer>(sql,
               new
               {
                   Surname = surname,
               }, Transaction);
            return customers.ToList();
        }
    }
}
