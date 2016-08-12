using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Repositories.Core;
using Indico20.BusinessObjects.Repositories.Implementation;

namespace Indico20.BusinessObjects.Base.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public ICompanyRepository CompanyRepository { get; private set; }
        public IUserStatusRepository UserStatusRepository { get; private set; }

        public IMenuItemRepository MenuItemRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork()
        {
            _context = new IndicoContext();
            CompanyRepository = new CompanyRepository(_context);
            UserStatusRepository = new UserStatusRepository(_context);
            MenuItemRepository = new MenuItemRepository(_context);
            UserRepository = new UserRepository(_context);
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
