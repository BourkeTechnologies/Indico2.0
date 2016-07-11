using System;
using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Objects
{
    public class Company : IEntity
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public bool IsDistributor { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public int Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string NickName { get; set; }
        public int? Coordinator { get; set; }
        public int? Owner { get; set; }
        public int Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Modifier { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? SecondaryCoordinator { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsBackOrder { get; set; }
        public bool IsEnableBackOrderReporting { get; set; }
        public int? DistributorType { get; set; }
        public bool IncludeAsMYOBInvoice { get; set; }
        public string JobName { get; set; }
    }
}
