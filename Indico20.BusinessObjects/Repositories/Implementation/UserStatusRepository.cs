using Indico20.BusinessObjects.Base.DBContext;
using Indico20.BusinessObjects.Objects;
using Indico20.BusinessObjects.Repositories.Core;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class UserStatusRepository : Repository<UserStatus>,IUserStatusRepository
    {
        public override string TableName => "UserStatus";
        public UserStatusRepository(IDbContext context) : base(context)
        {
        }
    }
}
