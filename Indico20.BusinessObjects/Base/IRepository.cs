using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        void Removerange(IEnumerable<T> entities);
        string TableName { get; }
    }
}
