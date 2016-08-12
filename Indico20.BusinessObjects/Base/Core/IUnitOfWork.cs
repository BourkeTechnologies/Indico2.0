using Indico20.BusinessObjects.Repositories.Core;
using System;

namespace Indico20.BusinessObjects.Base.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
        ICompanyRepository Companies { get; }
        IUserStatusRepository UserStatus { get; }
        IMenuItemRepository MenuItems { get; }
        IUserRepository Users { get; }
    }
}
