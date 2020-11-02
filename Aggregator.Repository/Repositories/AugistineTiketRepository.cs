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
  
    internal class AugistineTiketRepository : BaseRepository<AugistineTiket>, IAugistineTiketRepository
    {
        public AugistineTiketRepository(string tableName, string connectionString, IDbTransaction transaction = null) : base(tableName, connectionString, transaction)
        {
        }

       
        public override void Update(AugistineTiket item)
        {
            string sql = $@"UPDATE { _tableName} 
                    SET  CreationDate = @CreationDate, Text = @Text, AdultCost = @AdultCost, 
                    ChildCost = @ChildCost, ImageId = @ImageId, CouponId = @CouponId, Discount = @Discount
                    WHERE  Id = @Id";
            var queryResult = Connection.Query<AugistineTiket>(sql,
                new
                {
                    Id = item.Id,
                    CreationDate = item.CreationDate,
                    Text = item.Text,
                    AdultCost = item.AdultCost,
                    ChildCost = item.ChildCost,
                    ImageId = item.ImageId,
                    CouponId = item.CouponId,
                    Discount = item.Discount
                }, Transaction);
        }
        public List<AugistineTiket> GetByListIds(List<string> ids)
        {
            string sql = $@"Select * from {_tableName} where  Id in  @Ids ";
            var result = Connection.Query<AugistineTiket>(sql, new { Ids = ids }, Transaction);
            return result.ToList();
        }
    }
}
