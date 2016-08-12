using System;
using System.Collections.Generic;
using Indico20.BusinessObjects.Objects.Core;

namespace Indico20.BusinessObjects.Repositories.Core
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Find(Func<T, bool> predicate);
        void AddRange(IEnumerable<T> entities);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> ids);

    }
}
