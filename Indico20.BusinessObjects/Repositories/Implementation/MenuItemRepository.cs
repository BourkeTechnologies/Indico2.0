using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Implementation;
using Indico20.BusinessObjects.Procedures.Implementation;
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
