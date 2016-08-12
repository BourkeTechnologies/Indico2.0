using Indico20.BusinessObjects.Base.DBContext;
using Indico20.BusinessObjects.Objects;
using Indico20.BusinessObjects.Procedures;
using Indico20.BusinessObjects.Repositories.Core;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(IDbContext context) : base(context)
        {
        }

        public IEnumerable<GetMenuItemsForUserRoleResult> ForUserRole(int userRole)
        {
            return Context.GetMenuItemsForUserRole(userRole);
        }
    }
}
