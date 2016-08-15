using Indico20.BusinessObjects.Objects.Implementation;
using Indico20.BusinessObjects.Objects.Procedures.Implementation;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Repositories.Core
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        /// <summary>
        /// Get MenuItems for given user role
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        IEnumerable<GetMenuItemsForUserRole> GetUserRolesForThisMenuItem(int userRole);
    }
}
