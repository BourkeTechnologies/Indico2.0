using System;
using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Objects
{
    public class User : IEntity
    {

        public int ID { get; set; }
        public int Company { get; set; }

        public Company ObjCompany
        {
            get { return RepositoryStore.Companies.Get(Company); }
            set
            {
                if(value==null)
                    return;
                Company = value.ID;
            }
        }

        public bool IsDistributor { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoPath { get; set; }
        public int Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Guid { get; set; }
        public string OfficeTelephoneNumber { get; set; }
        public string MobileTelephoneNumber { get; set; }
        public string HomeTelephoneNumber { get; set; }
        public DateTime? DateLastLogin { get; set; }
        public bool? HaveAccessForHTTPPost { get; set; }
        public string Designation { get; set; }
        public bool IsDirectSalesPerson { get; set; }
        public bool Changed { get; set; }
    }
}
