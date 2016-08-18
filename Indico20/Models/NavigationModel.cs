using System.Collections.Generic;

namespace Indico20.Models
{
    public class NavigationModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public List<NavigationModel> SubMenus { get; set; }
        public bool IsLeftAligned { get; set; }
        public int Position { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameters { get; set; }
        public int ID { get; set; }
        public int Parent { get; set; }
    }
}