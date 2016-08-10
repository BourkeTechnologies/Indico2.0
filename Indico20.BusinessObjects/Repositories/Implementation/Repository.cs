using System;
using System.Collections.Generic;
using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Base.DBContext;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class , IEntity
    {
        protected IDbContext Context;
        public virtual string TableName { get; set; }

        public Repository(IDbContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Get<T>(TableName, id);
        }

        public IEnumerable<T> Get()
        {
            return Context.Get<T>(TableName);
        }

        public void Add(T entity)
        {
            Context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.AddRange(entities);
        }

        public void Delete(T entity)
        {
            Context.Delete(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Context.DeleteRange(entities);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Context.Find(TableName, predicate);
        }
    }
}
