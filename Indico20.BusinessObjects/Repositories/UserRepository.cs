using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Objects;
using Indico20CodeBase.Extensions;
using Indico20CodeBase.Tools;

namespace Indico20.BusinessObjects.Repositories
{
    public class UserRepository :Repository, IRepository<User>
    {
        public string TableName => "User";

        public void Add(User entity)
        {
            Execute(QueryBuilder.Insert(TableName,GetColumnValueMapping(entity)));
        }

        public void AddRange(IEnumerable<User> entities)
        {
            var list = entities as List<User> ?? entities.ToList();
            if (list.Count < 1)
                return;
            var queryBuilder = new StringBuilder();
            foreach (var entity in list)
            {
                queryBuilder.Append(QueryBuilder.Insert(TableName,GetColumnValueMapping(entity)));
            }
            Execute(queryBuilder.ToString());
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return Find(TableName, predicate);
        }

        public User Get(int id)
        {
            return Get<User>(TableName, id);
        }

        public IEnumerable<User> GetAll()
        {
            return GetAll<User>(TableName);
        }

        public void Remove(User entity)
        {
            Remove(TableName,entity);
        }

        public void Removerange(IEnumerable<User> entities)
        {
            RemoveRange(TableName,entities);
        }

        public void Update(User entity)
        {
            Update(entity,QueryBuilder.Update(TableName,GetColumnValueMapping(entity), entity.ID ));
        }

        public Dictionary<string, object> GetColumnValueMapping(User entity)
        {
            return new Dictionary<string, object>()
            {
                {"Company", entity.Company},
                {"IsDistributor", entity.IsDistributor},
                {"Status", entity.Status},
                {"Username", entity.Username},
                {"Password", entity.Password},
                {"GivenName", entity.GivenName},
                {"FamilyName", entity.FamilyName},
                {"EmailAddress", entity.EmailAddress},
                {"PhotoPath", entity.PhotoPath},
                {"Creator", entity.Creator},
                {"CreatedDate", entity.CreatedDate},
                {"Modifier", entity.Modifier},
                {"ModifiedDate", entity.ModifiedDate},
                {"IsActive", entity.IsActive},
                {"IsDeleted", entity.IsDeleted},
                {"Guid", entity.Guid},
                {"OfficeTelephoneNumber", entity.OfficeTelephoneNumber},
                {"MobileTelephoneNumber", entity.MobileTelephoneNumber},
                {"HomeTelephoneNumber", entity.HomeTelephoneNumber},
                {"DateLastLogin", entity.DateLastLogin},
                {"HaveAccessForHTTPPost", entity.HaveAccessForHTTPPost},
                {"Designation", entity.Designation},
                {"IsDirectSalesPerson", entity.IsDirectSalesPerson}
            };
        }
    }
}
