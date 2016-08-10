using Indico20.BusinessObjects.Base.DBContext;
using Indico20.BusinessObjects.Objects;
using Indico20.BusinessObjects.Repositories.Core;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public override string TableName => "User";
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}
