using System.Collections.Generic;
using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Procedures
{
    public class GetMenuItems : IndicoBO
    {
        public static IEnumerable<GetMenuItems> Get(int userRole)
        {
            return Query<GetMenuItems>("EXEC [dbo].[SPC_GetMenuItems] {0}",userRole);
        }

        public int ID { get; set; }
        public string MenuName { get; set; }
        public string Title { get; set; }
        public int Parent { get; set; }
        public int Position { get; set; }
        public bool IsAlignedLeft { get; set; }
        public bool IsVisible { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameters { get; set; }
    }
}
