using System;
using System.Collections.Generic;
using System.Linq;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Indico20.BusinessObjects.Procedures;
using Indico20CodeBase.Tools;
using Ninject;

namespace Indico20.BusinessObjects.Repositories
{
    public class MenuItemRepository : Repository, IRepository<MenuItem>
    {

        public MenuItemRepository()
        {
            TableName = "MenuItem";
        }

        public void Add(MenuItem entity)
        {
            UnitOfWork.Add(TableName, GetColumnValueMapping(entity));
        }

        public void AddRange(IEnumerable<MenuItem> entities)
        {
            var list = entities as List<MenuItem> ?? entities.ToList();
            if (list.Count < 1)
                return;
            var items = list.Select(GetColumnValueMapping).ToList();
            UnitOfWork.AddRange(TableName, items);
        }

        public IEnumerable<MenuItem> Find(Func<MenuItem, bool> predicate)
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

        public MenuItem Get(int id)
        {
            var kernel = new StandardKernel();
            var menuItem = Get<MenuItem>(TableName, id);
            kernel.Inject(menuItem);
            return menuItem;
        }

        public IEnumerable<MenuItem> GetAll()
        {
            var menuItems = GetAll<MenuItem>(TableName).ToList();
            var kernel = new StandardKernel();
            foreach (var menuItem in menuItems)
            {
                kernel.Inject(menuItem);
            }
            return menuItems;
        }

        public void Remove(int id)
        {
            UnitOfWork.Remove(TableName, id);
        }

        public void RemoveRange(IEnumerable<int> entities)
        {
            UnitOfWork.RemoveRange(TableName, entities);
        }

        public void Update(MenuItem entity)
        {
            UnitOfWork.Update(TableName, GetColumnValueMapping(entity), entity.ID);
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

        public IEnumerable<GetMenuItemsForUserRoleResult> GetMenuItemsForUserRole(int userRole)
        {
            return Query<GetMenuItemsForUserRoleResult>(QueryBuilder.ExecuteStoredProcedure("SPC_GetMenuItemsForUserRole", userRole));
        }
    }
}
