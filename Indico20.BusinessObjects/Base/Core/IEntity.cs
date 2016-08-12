using Indico20.BusinessObjects.Base.DBContext;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Indico20.BusinessObjects.Base.Core
{
    public interface IEntity : INotifyPropertyChanged
    {
        int ID { get; }
        Dictionary<string, object> GetColumnValueMapping();

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        IDbContext _Context { get; set; }
    }
}
