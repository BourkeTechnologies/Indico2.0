using Indico20.BusinessObjects.Repositories.Core;
using System;

namespace Indico20.BusinessObjects.Base.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
        ICompanyRepository CompanyRepository { get; }
        IUserStatusRepository UserStatusRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
