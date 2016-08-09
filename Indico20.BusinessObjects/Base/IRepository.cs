using System;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Base
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
        void Add(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<int> ids);
        string TableName { get; }
        Dictionary<string, object> GetColumnValueMapping(T entity);
    }
}
