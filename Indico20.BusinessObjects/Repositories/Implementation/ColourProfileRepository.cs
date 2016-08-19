using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Implementation;
using Indico20.BusinessObjects.Repositories.Core;

namespace Indico20.BusinessObjects.Repositories.Implementation
{
    public class ColourProfileRepository : Repository<ColourProfile>, IColourProfileRepository
    {
        public ColourProfileRepository(IDbContext context) : base(context)
        {
        }
    }
}
