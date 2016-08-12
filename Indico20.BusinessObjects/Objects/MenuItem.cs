using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Base.DBContext;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects
{
    public class MenuItem : IEntity
    {

        #region Fields

        private int _iD;
        private int _controllerAction;
        private int? _parent;
        private int _position;
        private bool _isAlignedLeft;
        private bool _isSubNav;
        private bool _isTopNav;
        private bool _isVisible;
        private string _key;
        private string _name;
        private string _title;

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

        public string TableName => "MenuItem";

        public IDbContext _Context { get; set; }

        public int ID { get { return _iD; } set { _iD = value; NotifyPropertyChanged("ID"); } }
        public int ControllerAction { get { return _controllerAction; } set { _controllerAction = value; NotifyPropertyChanged("ControllerAction"); } }
        public int? Parent { get { return _parent; } set { _parent = value; NotifyPropertyChanged("Parent"); } }
        public int Position { get { return _position; } set { _position = value; NotifyPropertyChanged("Position"); } }
        public bool IsAlignedLeft { get { return _isAlignedLeft; } set { _isAlignedLeft = value; NotifyPropertyChanged("IsAlignedLeft"); } }
        public bool IsSubNav { get { return _isSubNav; } set { _isSubNav = value; NotifyPropertyChanged("IsSubNav"); } }
        public bool IsTopNav { get { return _isTopNav; } set { _isTopNav = value; NotifyPropertyChanged("IsTopNav"); } }
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; NotifyPropertyChanged("IsVisible"); } }
        public string Key { get { return _key; } set { _key = value; NotifyPropertyChanged("Key"); } }
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }
        public string Title { get { return _title; } set { _title = value; NotifyPropertyChanged("Title"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
           {
                {"ControllerAction",ControllerAction},
                {"Parent",Parent},
                {"Position",Position},
                {"IsAlignedLeft",IsAlignedLeft},
                {"IsSubNav",IsSubNav},
                {"IsTopNav",IsTopNav},
                {"IsVisible",IsVisible},
                {"Key",Key},
                {"Name",Name},
                {"Title",Title},
           };
        }

        #endregion

    }
}
