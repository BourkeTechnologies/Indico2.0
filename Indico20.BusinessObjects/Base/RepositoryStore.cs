using Indico20.BusinessObjects.Repositories;

namespace Indico20.BusinessObjects.Base
{
    public class RepositoryStore
    {
        public static  UserRepository Users { get; private set; }
        public static CompanyRepository Companies { get; private set; }
        public static MenuItemRepository MenuItems { get; private set; }

        static RepositoryStore()
        {
            Users=new UserRepository();
            Companies=new CompanyRepository();
            MenuItems=new MenuItemRepository();
        }
    }
}
