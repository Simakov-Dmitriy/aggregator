using Aggregator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Interfaces
{
    public interface IBaseRepository<T> : IBasePaggination<T> where T : BaseEntity
    {
        void Add( T item );
        void AddRange( List<T> item );
        void Update( T item );
        void UpdateRange( List<T> items );
        void DeleteList( List<string> idToDelete );
        void Remove( T item );
        void RemoveById( string id );
        List<T> GetAll();
        T FindById( string id );
    }
}
