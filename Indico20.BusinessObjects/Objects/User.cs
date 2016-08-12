using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Base.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects
{
    public class User : IEntity
    {

        #region Fields

        private int _company;
        private Company _objCompany;
        private bool _isDistributor;
        private int _status;
        private string _username;
        private string _password;
        private string _givenName;
        private string _familyName;
        private string _emailAddress;
        private string _photoPath;
        private int _creator;
        private DateTime _createdDate;
        private int _modifier;
        private DateTime _modifiedDate;
        private bool _isActive;
        private bool _isDeleted;
        private string _guid;
        private string _officeTelephoneNumber;
        private string _mobileTelephoneNumber;
        private string _homeTelephoneNumber;
        private DateTime? _dateLastLogin;
        private bool? _haveAccessForHTTPPost;
        private string _designation;
        private bool _isDirectSalesPerson;

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

        public int Company { get { return _company; } set { _company = value; NotifyPropertyChanged("Company"); } }
        public Company ObjCompany
        {
            get
            {
                return (_objCompany == null || _objCompany.ID != Company) ? _objCompany = _Context.Get<Company>(Company) :
                _objCompany;
            }
            set
            {
                Company = value.ID;
                _objCompany = value;
            }
        }
        public bool IsDistributor { get { return _isDistributor; } set { _isDistributor = value; NotifyPropertyChanged("IsDistributor"); } }
        public int Status { get { return _status; } set { _status = value; NotifyPropertyChanged("Status"); } }
        public string Username { get { return _username; } set { _username = value; NotifyPropertyChanged("Username"); } }
        public string Password { get { return _password; } set { _password = value; NotifyPropertyChanged("Password"); } }
        public string GivenName { get { return _givenName; } set { _givenName = value; NotifyPropertyChanged("GivenName"); } }
        public string FamilyName { get { return _familyName; } set { _familyName = value; NotifyPropertyChanged("FamilyName"); } }
        public string EmailAddress { get { return _emailAddress; } set { _emailAddress = value; NotifyPropertyChanged("EmailAddress"); } }
        public string PhotoPath { get { return _photoPath; } set { _photoPath = value; NotifyPropertyChanged("PhotoPath"); } }
        public int Creator { get { return _creator; } set { _creator = value; NotifyPropertyChanged("Creator"); } }
        public DateTime CreatedDate { get { return _createdDate; } set { _createdDate = value; NotifyPropertyChanged("CreatedDate"); } }
        public int Modifier { get { return _modifier; } set { _modifier = value; NotifyPropertyChanged("Modifier"); } }
        public DateTime ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; NotifyPropertyChanged("ModifiedDate"); } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; NotifyPropertyChanged("IsActive"); } }
        public bool IsDeleted { get { return _isDeleted; } set { _isDeleted = value; NotifyPropertyChanged("IsDeleted"); } }
        public string Guid { get { return _guid; } set { _guid = value; NotifyPropertyChanged("Guid"); } }
        public string OfficeTelephoneNumber { get { return _officeTelephoneNumber; } set { _officeTelephoneNumber = value; NotifyPropertyChanged("OfficeTelephoneNumber"); } }
        public string MobileTelephoneNumber { get { return _mobileTelephoneNumber; } set { _mobileTelephoneNumber = value; NotifyPropertyChanged("MobileTelephoneNumber"); } }
        public string HomeTelephoneNumber { get { return _homeTelephoneNumber; } set { _homeTelephoneNumber = value; NotifyPropertyChanged("HomeTelephoneNumber"); } }
        public DateTime? DateLastLogin { get { return _dateLastLogin; } set { _dateLastLogin = value; NotifyPropertyChanged("DateLastLogin"); } }
        public bool? HaveAccessForHTTPPost { get { return _haveAccessForHTTPPost; } set { _haveAccessForHTTPPost = value; NotifyPropertyChanged("HaveAccessForHTTPPost"); } }
        public string Designation { get { return _designation; } set { _designation = value; NotifyPropertyChanged("Designation"); } }
        public bool IsDirectSalesPerson { get { return _isDirectSalesPerson; } set { _isDirectSalesPerson = value; NotifyPropertyChanged("IsDirectSalesPerson"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
            {
                {"Company",Company},
                {"IsDistributor",IsDistributor},
                {"Status",Status},
                {"Username",Username},
                {"Password",Password},
                {"GivenName",GivenName},
                {"FamilyName",FamilyName},
                {"EmailAddress",EmailAddress},
                {"PhotoPath",PhotoPath},
                {"Creator",Creator},
                {"CreatedDate",CreatedDate},
                {"Modifier",Modifier},
                {"ModifiedDate",ModifiedDate},
                {"IsActive",IsActive},
                {"IsDeleted",IsDeleted},
                {"Guid",Guid},
                {"OfficeTelephoneNumber",OfficeTelephoneNumber},
                {"MobileTelephoneNumber",MobileTelephoneNumber},
                {"HomeTelephoneNumber",HomeTelephoneNumber},
                {"DateLastLogin",DateLastLogin},
                {"HaveAccessForHTTPPost",HaveAccessForHTTPPost},
                {"Designation",Designation},
                {"IsDirectSalesPerson",IsDirectSalesPerson},
            };
        }

        #endregion

    }

}
