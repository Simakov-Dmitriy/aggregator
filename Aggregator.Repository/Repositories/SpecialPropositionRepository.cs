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
    internal class SpecialPropositionRepository : Base.BaseRepository<SpecialProposition>, ISpecialPropositionRepository
    {
        public SpecialPropositionRepository( string tableName, string connectionString, IDbTransaction transaction = null ) : base(tableName, connectionString, transaction)
        {
        }

        public override void  Add( SpecialProposition item )
        {
             string sql =$@"INSERT INTO SpecialPropositions (Id, CreationDate, Text, ImageId)
                            VALUES (@Id, @CreationDate, @Text, @ImageId )";
            var queryResult =  Connection.Query<SpecialProposition>(sql, new { Id = item.Id, CreationDate = item.CreationDate, Text = item.Text , ImageId = item.ImageId}, Transaction);
        }

        public override void Update(SpecialProposition item)
        {
            string sql = $@"UPDATE {_tableName } 
            set  Text = @Text,  ImageId = @ImageId
                       where Id = @Id";
            var queryResult = Connection.Query<SpecialProposition>(sql, new { Id = item.Id,  Text = item.Text, ImageId = item.ImageId }, Transaction);
        }
        
    }
}
