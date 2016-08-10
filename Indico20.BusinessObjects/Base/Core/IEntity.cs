using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Base.Core
{
    public interface IEntity:INotifyPropertyChanged
    {
        int ID { get; }
        Dictionary<string, object> GetColumnValueMapping();
        string TableName { get; }
    }
}
