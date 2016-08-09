using System;
using System.Collections.Generic;
using System.Linq;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Ninject;

namespace Indico20.BusinessObjects.Repositories
{
    public class UserStatusRepository : Repository, IRepository<UserStatus>
    {

        public UserStatusRepository(IUnitOfWork unit)
        {
            TableName = "UserStatus";
            UnitOfWork = unit;
        }
        public void Add(UserStatus entity)
        {
            UnitOfWork.Add(TableName, GetColumnValueMapping(entity));
        }

        public void AddRange(IEnumerable<UserStatus> entities)
        {
            var list = entities as List<UserStatus> ?? entities.ToList();
            if (list.Count < 1)
                return;
            var items = list.Select(GetColumnValueMapping).ToList();
            UnitOfWork.AddRange(TableName, items);
        }

        public IEnumerable<UserStatus> Find(Func<UserStatus, bool> predicate)
        {
            var kernel = new StandardKernel();
            var items = Find(TableName, predicate).ToList();
            if (items.Count <= 0)
                return items;
            foreach (var item in items)
            {
                kernel.Inject(item);
            }
            return items;
        }

        public UserStatus Get(int id)
        {
            var kernel = new StandardKernel();
            var userSatatus = Get<UserStatus>(TableName, id);
            kernel.Inject(userSatatus);
            return userSatatus;
        }

        public IEnumerable<UserStatus> GetAll()
        {
            var list = GetAll<UserStatus>(TableName).ToList();
            var kernel = new StandardKernel();
            foreach (var status in list)
            {
                kernel.Inject(status);
            }
            return list;
        }

        public void Remove(int id)
        {
            UnitOfWork.Remove(TableName, id);
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            UnitOfWork.RemoveRange(TableName, ids);
        }

        public void Update(UserStatus entity)
        {
            UnitOfWork.Update(TableName, GetColumnValueMapping(entity),entity.ID);
        }

        public Dictionary<string, object> GetColumnValueMapping(UserStatus entity)
        {
            return new Dictionary<string, object>()
            {
                {"Key", entity.Key},
                {"Name", entity.Name}
            };
        }
    }
}
