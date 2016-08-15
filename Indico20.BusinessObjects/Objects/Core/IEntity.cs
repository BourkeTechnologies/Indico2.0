using Indico20.BusinessObjects.Base.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Indico20.BusinessObjects.Objects.Core
{
    public interface IEntity : INotifyPropertyChanged
    {
        int ID { get; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        Dictionary<string, object> GetColumnValueMapping();

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        IDbContext _Context { get; set; }
    }
}
