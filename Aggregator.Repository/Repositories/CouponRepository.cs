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
   
    internal class CouponRepository : Base.BaseRepository<Coupon>, ICouponRepository    
    {
        public CouponRepository( string tableName, string connectionString, IDbTransaction transaction = null ) : base(tableName, connectionString, transaction)
        {
        }

        public override void  Add( Coupon item )
        {
        string sql = $@"INSERT INTO {_tableName } (Id, CreationDate, Text, AuthorId, Counter, Link, ClosingDate, SaleProcent, PromoCode, SpecialPropositionId, City)
                            VALUES (@Id, @CreationDate, @Text, @AuthorId, @Counter, @Link, @ClosingDate, @SaleProcent , @PromoCode , @SpecialPropositionId , @City)";
            var queryResult =  Connection.Query<Coupon>(sql, new
            {
                Id = item.Id,
                CreationDate = item.CreationDate,
                Text = item.Text,
                AuthorId = item.AuthorId,
                Counter = item.Counter,
                SaleProcent = item.SaleProcent,
                PromoCode = item.PromoCode,
                Link = item.Link,
                City = item.City,
                ClosingDate = item.ClosingDate,
                SpecialPropositionId = item.SpecialPropositionId
            }, Transaction);
        }

       
        public override void Update(Coupon item)
        {
            string sql = $@"UPDATE {_tableName } 
            set  Text = @Text,  Link = @Link, ClosingDate = @ClosingDate, 
            SaleProcent = @SaleProcent, PromoCode = @PromoCode, SpecialPropositionId = @SpecialPropositionId,  City = @City
                       where Id = @Id";
            var queryResult = Connection.Query<Coupon>(sql, new
            {
                Id = item.Id,
                Text = item.Text,
                SaleProcent = item.SaleProcent,
                PromoCode = item.PromoCode,
                Link = item.Link,
                ClosingDate = item.ClosingDate,
                SpecialPropositionId = item.SpecialPropositionId,
                City = item.City
            }, Transaction);
        }

        public Coupon GetByPromoCode(string promoCode)
        {
            string sql = $"Select * from {_tableName} where PromoCode = @Promocode";
            var result = Connection.QueryFirstOrDefault<Coupon>(sql, new { Promocode = promoCode }, Transaction);
            return result;
        }

    }
}
