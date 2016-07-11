using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Objects
{
    public class MenuItem : IEntity
    {
        public int ID { get; set; }
        public int ControllerAction { get; set; }
        public int? Parent { get; set; }
        public int Position { get; set; }
        public bool IsAlignedLeft { get; set; }
        public bool IsSubNav { get; set; }
        public bool IsTopNav { get; set; }
        public bool IsVisible { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
