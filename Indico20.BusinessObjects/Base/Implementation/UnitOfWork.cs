using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Base.DBContext;
using Indico20.BusinessObjects.Repositories.Core;
using Indico20.BusinessObjects.Repositories.Implementation;

namespace Indico20.BusinessObjects.Base.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public ICompanyRepository Companies { get; private set; }
        public IUserStatusRepository UserStatus { get; private set; }

        public IMenuItemRepository MenuItems { get; private set; }

        public IUserRepository Users { get; private set; }

        public UnitOfWork()
        {
            _context = new IndicoContext();
            Companies = new CompanyRepository(_context);
            UserStatus = new UserStatusRepository(_context);
            MenuItems = new MenuItemRepository(_context);
            Users = new UserRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
