﻿using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects.Implementation
{
    public class Role : IEntity
    {
        #region Fields

        private string _key;
        private string _name;
        private string _displayName;
        private int _priority;

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
        public string Key { get { return _key; } set { _key = value; NotifyPropertyChanged("Key"); } }
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }
        public string DisplayName { get { return _displayName; } set { _displayName = value; NotifyPropertyChanged("DisplayName"); } }
        public int Priority { get { return _priority; } set { _priority = value; NotifyPropertyChanged("Priority"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
            {
                {"Key",Key},
                {"Name",Name},
                {"DisplayName",DisplayName},
                {"Priority",Priority},
            };
        }

        #endregion

    }
}
