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

namespace Aggregator.Repository
{
    internal class lockedIpsRepository : BaseRepository<lockedIp>, IlockedIpsRepository
    {
        public lockedIpsRepository(string tableName, string connectionString, IDbTransaction transaction = null) : base(tableName, connectionString, transaction)
        {
        }

        public lockedIp FindByIp(string ip)
        {
           
            string sql = $@"select *  FROM {_tableName} where IpAddress= @Ip ";
            var result = Connection.QueryFirstOrDefault<lockedIp>(sql, new { Ip = ip}, Transaction);
            return result;
        }
    }
}
