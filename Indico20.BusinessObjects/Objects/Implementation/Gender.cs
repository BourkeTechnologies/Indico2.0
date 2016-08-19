using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects.Implementation
{
    public class Gender : IEntity
    {

        #region Fields

        private string _name;

        #endregion


        #region PropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region Properties

        public IDbContext _Context { get; set; }
        public int ID { get; set; }
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
            {
                {"Name",Name},
            };
        }

        #endregion

    }

}
