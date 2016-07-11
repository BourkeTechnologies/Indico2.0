using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Indico20.BusinessObjects.Base
{
    public interface IRepository<T> where T : class , IEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        string TableName { get; }
        Dictionary<string, object> GetColumnValueMapping(T entity);
    }
}
