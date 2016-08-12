using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects;
using Indico20.BusinessObjects.Procedures;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Repositories.Core
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        IEnumerable<GetMenuItemsForUserRoleResult> ForUserRole(int userRole);
    }
}
