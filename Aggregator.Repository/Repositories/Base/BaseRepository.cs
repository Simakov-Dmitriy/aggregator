using Aggregator.Domain.Models;
using Aggregator.Repository.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Aggregator.Repository.Repositories.Base
{
    internal class BaseRepository<T> : IBasePaggination<T>, IBaseRepository<T> where T : BaseEntity
    {
        private string _connectionString;
        protected readonly string _tableName;
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction == null ? new SqlConnection(_connectionString) : Transaction.Connection; } }

        public BaseRepository( string tableName, string connectionString, IDbTransaction transaction = null )
        {
            _connectionString = connectionString;
            _tableName = tableName;
            Transaction = transaction;
        }

        public virtual void Add( T item )
        {
            DapperHack();
             Connection.Insert<T>(item, Transaction);
        }
        public virtual void AddRange( List<T> item )
        {
             Connection.Insert(item, Transaction);
        }

        public virtual void UpdateRange( List<T> items )
        {
             Connection.Update(items, Transaction);
        }

        public virtual void Update( T item )
        {
             Connection.Update(item, Transaction);
        }

        public virtual void DeleteList( List<string> idToDelete )
        {
            if( idToDelete == null || idToDelete.Count < 1 )
            {
                return;
            }

            var IdsForDelete = new List<T>();

            foreach( var id in idToDelete )
            {
                var itemForDelete = (T)Activator.CreateInstance(typeof(T), new object[] { });
                itemForDelete.Id = id;
                IdsForDelete.Add(itemForDelete);
            }
             Connection.Delete(IdsForDelete, Transaction);
        }

        public virtual void Remove( T item )
        {
             Connection.Execute("DELETE FROM " + _tableName + " WHERE Id=@Id", new { Id = item.Id }, Transaction);
        }

        public virtual void RemoveById( string id )
        {
            Connection.Execute("DELETE FROM " + _tableName + " WHERE Id=@Id", new { Id = id }, Transaction);
        }

        public virtual T FindById( string id )
        {
            var result = Connection.QueryFirstOrDefault<T>("SELECT TOP(1) * FROM " + _tableName + " WHERE Id=@Id", new { Id = id }, Transaction);
            return result;
        }

        public virtual List<T> GetAll()
        {
            IEnumerable<T> elements = Connection.Query<T>("SELECT  * FROM " + _tableName , Transaction);
            return elements.ToList();
        }

        protected static void DapperHack()
        {
            var cache = typeof(SqlMapperExtensions).GetField("KeyProperties", BindingFlags.NonPublic | BindingFlags.Static)?.GetValue(null)
                as ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>;

            cache?.Clear();
        }

        public virtual List<T> GetPagination( int start, int step )
        {
            var sql = $"  SELECT * from " + _tableName + " "
                        + "ORDER BY CreationDate DESC "
                        + "OFFSET     @Start ROWS "
                        + "FETCH NEXT @Step ROWS ONLY;";
            var queryResult =  Connection.Query<T>(sql, new { Start = start, Step = step }, Transaction);
            return queryResult.ToList();
        }

        public int GetCount()
        {
            var queryResult =  Connection.Query<int>("SELECT COUNT(Id) FROM  " + _tableName, Transaction);
            return queryResult.First();
        }
    }
}
