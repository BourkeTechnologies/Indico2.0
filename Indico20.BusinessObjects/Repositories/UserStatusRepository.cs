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
            Add(entity,@"INSERT INTO UserStatus 
                (Key,
                 Name)
                VALUES('{0}','{1}')",entity.Key,entity.Name);
        }

        public void AddRange(IEnumerable<UserSatatus> entities)
        {
            var list = entities as List<UserSatatus> ?? entities.ToList();
            if(list.Count<1)
                return;
            var stringBuilder = new StringBuilder();
            foreach (var entity in list)
            {
                stringBuilder.Append(string.Format(@"INSERT INTO UserStatus 
                (Key,
                 Name)
                VALUES('{0}','{1}');", entity.Key, entity.Name));
            }
            using (var connection = Connection)
            {
                connection.Execute(stringBuilder.ToString());
            }
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

            Update(entity, QueryBuilder.Update(TableName, new Dictionary<string, object>()
            {
                { "Key",entity.Key},
                { "Name",entity.Name}

            },entity.ID));
        }
    }
}
