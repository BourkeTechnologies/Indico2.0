﻿using Indico20.BusinessObjects.Objects.Procedures.Core;

namespace Indico20.BusinessObjects.Objects.Procedures.Implementation
{
    public class GetMenuItemsForUserRole : ISpResult
    {
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
