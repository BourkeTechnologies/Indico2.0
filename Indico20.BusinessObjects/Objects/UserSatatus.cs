using System;
using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Objects
{
    public class UserSatatus : IEntity
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
