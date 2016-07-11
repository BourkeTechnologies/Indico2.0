using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Indico20CodeBase.Tools;

namespace Indico20.BusinessObjects.Repositories
{
    class UserStatusRepository : Repository, IRepository<UserSatatus>
    {
        public string TableName => "UserStatus";

        public void Add(UserSatatus entity)
        {
            Execute(QueryBuilder.Insert(TableName,GetColumnValueMapping(entity)));
        }

        public void AddRange(IEnumerable<UserSatatus> entities)
        {
            var list = entities as List<UserSatatus> ?? entities.ToList();
            if(list.Count<1)
                return;
            var stringBuilder = new StringBuilder();
            foreach (var entity in list)
            {
                stringBuilder.Append(QueryBuilder.Insert(TableName, GetColumnValueMapping(entity)));
            }
            Execute(stringBuilder.ToString());
        }

        public IEnumerable<UserSatatus> Find(Expression<Func<UserSatatus, bool>> predicate)
        {
            return Find(TableName, predicate);
        }

        public UserSatatus Get(int id)
        {
            return Get<UserSatatus>(TableName, id);
        }

        public IEnumerable<UserSatatus> GetAll()
        {
            return GetAll<UserSatatus>(TableName);
        }

        public void Remove(UserSatatus entity)
        {
            Remove(TableName,entity);
        }

        public void Removerange(IEnumerable<UserSatatus> entities)
        {
            RemoveRange(TableName,entities);
        }

        public void Update(UserSatatus entity)
        {

            Update(entity, QueryBuilder.Update(TableName, GetColumnValueMapping(entity),entity.ID));
        }

        public Dictionary<string, object> GetColumnValueMapping(UserSatatus entity)
        {
            return new Dictionary<string, object>()
            {
                {"Key", entity.Key},
                {"Name", entity.Name}

            };
        }
    }
}
