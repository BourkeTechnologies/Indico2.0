using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects;
using Indico20.BusinessObjects.Repositories.Core;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbContext context) : base(context)
        {
        }
    }
}
