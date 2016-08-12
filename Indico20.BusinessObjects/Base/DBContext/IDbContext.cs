using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Procedures;
using System;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Base.DBContext
{
    public interface IDbContext : IDisposable
    {
        void SaveChanges();
        T Get<T>(int id) where T : class, IEntity;
        IEnumerable<T> Get<T>() where T : class, IEntity;
        void Add(IEntity entity);
        void AddRange(IEnumerable<IEntity> entities);
        void Delete(IEntity entity);
        void DeleteRange(IEnumerable<IEntity> entities);
        IEnumerable<T> Find<T>(Func<T, bool> predicate) where T : class, IEntity;


        IEnumerable<GetMenuItemsForUserRoleResult> GetMenuItemsForUserRole(int userRole);

    }
}
