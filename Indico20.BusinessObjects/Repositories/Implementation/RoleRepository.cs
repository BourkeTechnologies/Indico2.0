using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Implementation;
using Indico20.BusinessObjects.Repositories.Core;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
