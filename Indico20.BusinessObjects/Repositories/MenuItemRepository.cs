using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Indico20CodeBase.Tools;

namespace Indico20.BusinessObjects.Repositories
{
    public class MenuItemRepository : Repository, IRepository<MenuItem>
    {
        public string TableName => "MenuItem";

        public void Add(MenuItem entity)
        {
            if(entity==null)
                return;
            Execute(QueryBuilder.Insert(TableName,GetColumnValueMapping(entity)));
        }

        public void AddRange(IEnumerable<MenuItem> entities)
        {
            if(entities==null)
                return;
            var listOfEntities = entities as IList<MenuItem> ?? entities.ToList();
            if (!(listOfEntities.Count > 0))
                return;
            var stringBuilder = new StringBuilder();
            foreach (var entity in listOfEntities)
            {
                stringBuilder.Append(QueryBuilder.Insert(TableName, GetColumnValueMapping(entity)));
            }
        }

        public IEnumerable<MenuItem> Find(Expression<Func<MenuItem, bool>> predicate)
        {
            return Find(TableName, predicate);
        }

        public MenuItem Get(int id)
        {
            return Get<MenuItem>(TableName, id);
        }

        public IEnumerable<MenuItem> GetAll()
        {
            return GetAll<MenuItem>(TableName);
        }

        public void Remove(MenuItem entity)
        {
            if(entity==null)
                return;
            Remove(TableName,entity);
        }

        public void RemoveRange(IEnumerable<MenuItem> entities)
        {
            if(entities==null)
                return;
            RemoveRange(TableName,entities);
        }

        public void Update(MenuItem entity)
        {
            Execute(QueryBuilder.Update(TableName,GetColumnValueMapping(entity),entity.ID));
        }

        public Dictionary<string, object> GetColumnValueMapping(MenuItem entity)
        {
           return new Dictionary<string, object>()
           {
                { "ControllerAction", entity.ControllerAction},
                { "Parent", entity.Parent},
                { "Position", entity.Position},
                { "IsAlignedLeft", entity.IsAlignedLeft},
                { "IsSubNav", entity.IsSubNav},
                { "IsTopNav", entity.IsTopNav},
                { "IsVisible", entity.IsVisible},
                { "Key", entity.Key},
                { "Name", entity.Name},
                { "Title", entity.Title}
           };
        }
    }
}
