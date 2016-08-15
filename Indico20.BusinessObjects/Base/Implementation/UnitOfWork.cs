using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Repositories.Core;
using Indico20.BusinessObjects.Repositories.Implementation;

namespace Indico20.BusinessObjects.Base.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public ICompanyRepository CompanyRepository { get; }
        public IUserStatusRepository UserStatusRepository { get; }

        public IMenuItemRepository MenuItemRepository { get; }

        public IUserRepository UserRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public UnitOfWork()
        {
            _context = new IndicoContext();
            CompanyRepository = new CompanyRepository(_context);
            UserStatusRepository = new UserStatusRepository(_context);
            MenuItemRepository = new MenuItemRepository(_context);
            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            OrderRepository = new OrderRepository(_context);
            OrderDetailRepository = new OrderDetailRepository(_context);
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
