using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Core;
using Indico20.BusinessObjects.Repositories.Core;
using System;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    /// <summary>
    /// the base class for all Repositories . this contains generic functionalities of all repositories
    /// like Get,Add etc..
    /// </summary>
    /// <typeparam name="T">the type of the Entity</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected IDbContext Context;

        protected Repository(IDbContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Get<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return Context.Get<T>();
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
            return Context.Find(predicate);
        }

        public IEnumerable<T> Where(IDictionary<string, object> propertyValues)
        {
            return Context.Where<T>(propertyValues);
        }
    }
}
