using Indico20.BusinessObjects.Base.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects
{
    public class Company : IEntity
    {

        #region Fields

        private int _iD;
        private int _type;
        private bool _isDistributor;
        private string _name;
        private string _number;
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private string _postcode;
        private int _country;
        private string _phone1;
        private string _phone2;
        private string _fax;
        private string _nickName;
        private int? _coordinator;
        private int? _owner;
        private int _creator;
        private DateTime _createdDate;
        private int _modifier;
        private DateTime _modifiedDate;
        private int? _secondaryCoordinator;
        private bool? _isActive;
        private bool? _isDelete;
        private bool? _isBackOrder;
        private bool _isEnableBackOrderReporting;
        private int? _distributorType;
        private bool _includeAsMYOBInvoice;
        private string _jobName;

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

        public string TableName => "Company";

        public int ID { get { return _iD; } }
        public int Type { get { return _type; } set { _type = value; NotifyPropertyChanged("Type"); } }
        public bool IsDistributor { get { return _isDistributor; } set { _isDistributor = value; NotifyPropertyChanged("IsDistributor"); } }
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }
        public string Number { get { return _number; } set { _number = value; NotifyPropertyChanged("Number"); } }
        public string Address1 { get { return _address1; } set { _address1 = value; NotifyPropertyChanged("Address1"); } }
        public string Address2 { get { return _address2; } set { _address2 = value; NotifyPropertyChanged("Address2"); } }
        public string City { get { return _city; } set { _city = value; NotifyPropertyChanged("City"); } }
        public string State { get { return _state; } set { _state = value; NotifyPropertyChanged("State"); } }
        public string Postcode { get { return _postcode; } set { _postcode = value; NotifyPropertyChanged("Postcode"); } }
        public int Country { get { return _country; } set { _country = value; NotifyPropertyChanged("Country"); } }
        public string Phone1 { get { return _phone1; } set { _phone1 = value; NotifyPropertyChanged("Phone1"); } }
        public string Phone2 { get { return _phone2; } set { _phone2 = value; NotifyPropertyChanged("Phone2"); } }
        public string Fax { get { return _fax; } set { _fax = value; NotifyPropertyChanged("Fax"); } }
        public string NickName { get { return _nickName; } set { _nickName = value; NotifyPropertyChanged("NickName"); } }
        public int? Coordinator { get { return _coordinator; } set { _coordinator = value; NotifyPropertyChanged("Coordinator"); } }
        public int? Owner { get { return _owner; } set { _owner = value; NotifyPropertyChanged("Owner"); } }
        public int Creator { get { return _creator; } set { _creator = value; NotifyPropertyChanged("Creator"); } }
        public DateTime CreatedDate { get { return _createdDate; } set { _createdDate = value; NotifyPropertyChanged("CreatedDate"); } }
        public int Modifier { get { return _modifier; } set { _modifier = value; NotifyPropertyChanged("Modifier"); } }
        public DateTime ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; NotifyPropertyChanged("ModifiedDate"); } }
        public int? SecondaryCoordinator { get { return _secondaryCoordinator; } set { _secondaryCoordinator = value; NotifyPropertyChanged("SecondaryCoordinator"); } }
        public bool? IsActive { get { return _isActive; } set { _isActive = value; NotifyPropertyChanged("IsActive"); } }
        public bool? IsDelete { get { return _isDelete; } set { _isDelete = value; NotifyPropertyChanged("IsDelete"); } }
        public bool? IsBackOrder { get { return _isBackOrder; } set { _isBackOrder = value; NotifyPropertyChanged("IsBackOrder"); } }
        public bool IsEnableBackOrderReporting { get { return _isEnableBackOrderReporting; } set { _isEnableBackOrderReporting = value; NotifyPropertyChanged("IsEnableBackOrderReporting"); } }
        public int? DistributorType { get { return _distributorType; } set { _distributorType = value; NotifyPropertyChanged("DistributorType"); } }
        public bool IncludeAsMYOBInvoice { get { return _includeAsMYOBInvoice; } set { _includeAsMYOBInvoice = value; NotifyPropertyChanged("IncludeAsMYOBInvoice"); } }
        public string JobName { get { return _jobName; } set { _jobName = value; NotifyPropertyChanged("JobName"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
            {
                {"ID",ID},
                {"Type",Type},
                {"IsDistributor",IsDistributor},
                {"Name",Name},
                {"Number",Number},
                {"Address1",Address1},
                {"Address2",Address2},
                {"City",City},
                {"State",State},
                {"Postcode",Postcode},
                {"Country",Country},
                {"Phone1",Phone1},
                {"Phone2",Phone2},
                {"Fax",Fax},
                {"NickName",NickName},
                {"Coordinator",Coordinator},
                {"Owner",Owner},
                {"Creator",Creator},
                {"CreatedDate",CreatedDate},
                {"Modifier",Modifier},
                {"ModifiedDate",ModifiedDate},
                {"SecondaryCoordinator",SecondaryCoordinator},
                {"IsActive",IsActive},
                {"IsDelete",IsDelete},
                {"IsBackOrder",IsBackOrder},
                {"IsEnableBackOrderReporting",IsEnableBackOrderReporting},
                {"DistributorType",DistributorType},
                {"IncludeAsMYOBInvoice",IncludeAsMYOBInvoice},
                {"JobName",JobName}
            };
        }

        #endregion

    }
}
