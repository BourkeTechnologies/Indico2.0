using System;
using System.Collections.Generic;
using System.Linq;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Ninject;

namespace Indico20.BusinessObjects.Repositories
{
    public class UserRepository :Repository, IRepository<User>
    {
        [Inject]
        public new IUnitOfWork UnitOfWork;

        public UserRepository()
        {
            TableName = "User";
        }

        public void Add(User entity)
        {
            UnitOfWork.Add(TableName,GetColumnValueMapping(entity));
        }

        public void AddRange(IEnumerable<User> entities)
        {
            var list = entities as List<User> ?? entities.ToList();
            if (list.Count < 1)
                return;
            var items = list.Select(GetColumnValueMapping).ToList();
            UnitOfWork.AddRange(TableName,items);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
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

        public User Get(int id)
        {
            var kernel = new StandardKernel();
            var user = Get<User>(TableName, id);
            kernel.Inject(user);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users= GetAll<User>(TableName).ToList();
            var kernel = new StandardKernel();
            foreach (var user in users)
            {
                kernel.Inject(user);
            }
                
            return users;
        }

        public void Remove(int id)
        {
            UnitOfWork.Remove(TableName,id);
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            UnitOfWork.RemoveRange(TableName,ids);
        }

        public void Update(User entity)
        {
            UnitOfWork.Update(TableName, GetColumnValueMapping(entity), entity.ID);
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
