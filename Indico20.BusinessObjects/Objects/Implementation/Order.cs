using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects.Implementation
{
    public class Order : IEntity
    {

        #region Fields

        private DateTime _date;
        private int _client;
        private int _distributor;
        private DateTime _orderSubmittedDate;
        private DateTime _estimatedCompletionDate;
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private DateTime? _shipmentDate;
        private int _status;
        private int _creator;
        private int _modifier;
        private int? _paymentMethod;
        private string _orderUsage;
        private string _purchaseOrderNo;
        private bool? _converted;
        private string _oldPONo;
        private int? _invoice;
        private bool _isTemporary;
        private int? _shipmentMode;
        private int? _shipTo;
        private int? _despatchTo;
        private bool? _isWeeklyShipment;
        private bool? _isCourierDelivery;
        private bool? _isAdelaideWareHouse;
        private bool? _isMentionAddress;
        private bool? _isFollowingAddress;
        private int? _reservation;
        private bool? _isShipToDistributor;
        private bool? _isShipExistingDistributor;
        private bool? _isShipNewClient;
        private bool? _isDespatchDistributor;
        private bool? _isDespatchExistingDistributor;
        private bool? _isDespatchNewClient;
        private int? _deliveryOption;
        private bool _isDateNegotiable;
        private string _notes;
        private bool _isAcceptedTermsAndConditions;
        private int? _addressType;
        private int? _mYobCardFile;
        private decimal? _deliveryCharges;
        private decimal? _artWorkCharges;
        private decimal? _otherCharges;
        private string _otherChargesDescription;
        private bool? _isOtherDelivery;
        private string _otherDeliveryDescription;
        private int? _billingAddress;
        private int? _despatchToAddress;
        private bool _isGSTExcluded;

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
        public DateTime Date { get { return _date; } set { _date = value; NotifyPropertyChanged("Date"); } }
        public int Client { get { return _client; } set { _client = value; NotifyPropertyChanged("Client"); } }
        public int Distributor { get { return _distributor; } set { _distributor = value; NotifyPropertyChanged("Distributor"); } }
        public DateTime OrderSubmittedDate { get { return _orderSubmittedDate; } set { _orderSubmittedDate = value; NotifyPropertyChanged("OrderSubmittedDate"); } }
        public DateTime EstimatedCompletionDate { get { return _estimatedCompletionDate; } set { _estimatedCompletionDate = value; NotifyPropertyChanged("EstimatedCompletionDate"); } }
        public DateTime CreatedDate { get { return _createdDate; } set { _createdDate = value; NotifyPropertyChanged("CreatedDate"); } }
        public DateTime ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; NotifyPropertyChanged("ModifiedDate"); } }
        public DateTime? ShipmentDate { get { return _shipmentDate; } set { _shipmentDate = value; NotifyPropertyChanged("ShipmentDate"); } }
        public int Status { get { return _status; } set { _status = value; NotifyPropertyChanged("Status"); } }
        public int Creator { get { return _creator; } set { _creator = value; NotifyPropertyChanged("Creator"); } }
        public int Modifier { get { return _modifier; } set { _modifier = value; NotifyPropertyChanged("Modifier"); } }
        public int? PaymentMethod { get { return _paymentMethod; } set { _paymentMethod = value; NotifyPropertyChanged("PaymentMethod"); } }
        public string OrderUsage { get { return _orderUsage; } set { _orderUsage = value; NotifyPropertyChanged("OrderUsage"); } }
        public string PurchaseOrderNo { get { return _purchaseOrderNo; } set { _purchaseOrderNo = value; NotifyPropertyChanged("PurchaseOrderNo"); } }
        public bool? Converted { get { return _converted; } set { _converted = value; NotifyPropertyChanged("Converted"); } }
        public string OldPONo { get { return _oldPONo; } set { _oldPONo = value; NotifyPropertyChanged("OldPONo"); } }
        public int? Invoice { get { return _invoice; } set { _invoice = value; NotifyPropertyChanged("Invoice"); } }
        public bool IsTemporary { get { return _isTemporary; } set { _isTemporary = value; NotifyPropertyChanged("IsTemporary"); } }
        public int? ShipmentMode { get { return _shipmentMode; } set { _shipmentMode = value; NotifyPropertyChanged("ShipmentMode"); } }
        public int? ShipTo { get { return _shipTo; } set { _shipTo = value; NotifyPropertyChanged("ShipTo"); } }
        public int? DespatchTo { get { return _despatchTo; } set { _despatchTo = value; NotifyPropertyChanged("DespatchTo"); } }
        public bool? IsWeeklyShipment { get { return _isWeeklyShipment; } set { _isWeeklyShipment = value; NotifyPropertyChanged("IsWeeklyShipment"); } }
        public bool? IsCourierDelivery { get { return _isCourierDelivery; } set { _isCourierDelivery = value; NotifyPropertyChanged("IsCourierDelivery"); } }
        public bool? IsAdelaideWareHouse { get { return _isAdelaideWareHouse; } set { _isAdelaideWareHouse = value; NotifyPropertyChanged("IsAdelaideWareHouse"); } }
        public bool? IsMentionAddress { get { return _isMentionAddress; } set { _isMentionAddress = value; NotifyPropertyChanged("IsMentionAddress"); } }
        public bool? IsFollowingAddress { get { return _isFollowingAddress; } set { _isFollowingAddress = value; NotifyPropertyChanged("IsFollowingAddress"); } }
        public int? Reservation { get { return _reservation; } set { _reservation = value; NotifyPropertyChanged("Reservation"); } }
        public bool? IsShipToDistributor { get { return _isShipToDistributor; } set { _isShipToDistributor = value; NotifyPropertyChanged("IsShipToDistributor"); } }
        public bool? IsShipExistingDistributor { get { return _isShipExistingDistributor; } set { _isShipExistingDistributor = value; NotifyPropertyChanged("IsShipExistingDistributor"); } }
        public bool? IsShipNewClient { get { return _isShipNewClient; } set { _isShipNewClient = value; NotifyPropertyChanged("IsShipNewClient"); } }
        public bool? IsDespatchDistributor { get { return _isDespatchDistributor; } set { _isDespatchDistributor = value; NotifyPropertyChanged("IsDespatchDistributor"); } }
        public bool? IsDespatchExistingDistributor { get { return _isDespatchExistingDistributor; } set { _isDespatchExistingDistributor = value; NotifyPropertyChanged("IsDespatchExistingDistributor"); } }
        public bool? IsDespatchNewClient { get { return _isDespatchNewClient; } set { _isDespatchNewClient = value; NotifyPropertyChanged("IsDespatchNewClient"); } }
        public int? DeliveryOption { get { return _deliveryOption; } set { _deliveryOption = value; NotifyPropertyChanged("DeliveryOption"); } }
        public bool IsDateNegotiable { get { return _isDateNegotiable; } set { _isDateNegotiable = value; NotifyPropertyChanged("IsDateNegotiable"); } }
        public string Notes { get { return _notes; } set { _notes = value; NotifyPropertyChanged("Notes"); } }
        public bool IsAcceptedTermsAndConditions { get { return _isAcceptedTermsAndConditions; } set { _isAcceptedTermsAndConditions = value; NotifyPropertyChanged("IsAcceptedTermsAndConditions"); } }
        public int? AddressType { get { return _addressType; } set { _addressType = value; NotifyPropertyChanged("AddressType"); } }
        public int? MYOBCardFile { get { return _mYobCardFile; } set { _mYobCardFile = value; NotifyPropertyChanged("MYOBCardFile"); } }
        public decimal? DeliveryCharges { get { return _deliveryCharges; } set { _deliveryCharges = value; NotifyPropertyChanged("DeliveryCharges"); } }
        public decimal? ArtWorkCharges { get { return _artWorkCharges; } set { _artWorkCharges = value; NotifyPropertyChanged("ArtWorkCharges"); } }
        public decimal? OtherCharges { get { return _otherCharges; } set { _otherCharges = value; NotifyPropertyChanged("OtherCharges"); } }
        public string OtherChargesDescription { get { return _otherChargesDescription; } set { _otherChargesDescription = value; NotifyPropertyChanged("OtherChargesDescription"); } }
        public bool? IsOtherDelivery { get { return _isOtherDelivery; } set { _isOtherDelivery = value; NotifyPropertyChanged("IsOtherDelivery"); } }
        public string OtherDeliveryDescription { get { return _otherDeliveryDescription; } set { _otherDeliveryDescription = value; NotifyPropertyChanged("OtherDeliveryDescription"); } }
        public int? BillingAddress { get { return _billingAddress; } set { _billingAddress = value; NotifyPropertyChanged("BillingAddress"); } }
        public int? DespatchToAddress { get { return _despatchToAddress; } set { _despatchToAddress = value; NotifyPropertyChanged("DespatchToAddress"); } }
        public bool IsGSTExcluded { get { return _isGSTExcluded; } set { _isGSTExcluded = value; NotifyPropertyChanged("IsGSTExcluded"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
            {
                {"Date",Date},
                {"Client",Client},
                {"Distributor",Distributor},
                {"OrderSubmittedDate",OrderSubmittedDate},
                {"EstimatedCompletionDate",EstimatedCompletionDate},
                {"CreatedDate",CreatedDate},
                {"ModifiedDate",ModifiedDate},
                {"ShipmentDate",ShipmentDate},
                {"Status",Status},
                {"Creator",Creator},
                {"Modifier",Modifier},
                {"PaymentMethod",PaymentMethod},
                {"OrderUsage",OrderUsage},
                {"PurchaseOrderNo",PurchaseOrderNo},
                {"Converted",Converted},
                {"OldPONo",OldPONo},
                {"Invoice",Invoice},
                {"IsTemporary",IsTemporary},
                {"ShipmentMode",ShipmentMode},
                {"ShipTo",ShipTo},
                {"DespatchTo",DespatchTo},
                {"IsWeeklyShipment",IsWeeklyShipment},
                {"IsCourierDelivery",IsCourierDelivery},
                {"IsAdelaideWareHouse",IsAdelaideWareHouse},
                {"IsMentionAddress",IsMentionAddress},
                {"IsFollowingAddress",IsFollowingAddress},
                {"Reservation",Reservation},
                {"IsShipToDistributor",IsShipToDistributor},
                {"IsShipExistingDistributor",IsShipExistingDistributor},
                {"IsShipNewClient",IsShipNewClient},
                {"IsDespatchDistributor",IsDespatchDistributor},
                {"IsDespatchExistingDistributor",IsDespatchExistingDistributor},
                {"IsDespatchNewClient",IsDespatchNewClient},
                {"DeliveryOption",DeliveryOption},
                {"IsDateNegotiable",IsDateNegotiable},
                {"Notes",Notes},
                {"IsAcceptedTermsAndConditions",IsAcceptedTermsAndConditions},
                {"AddressType",AddressType},
                {"MYOBCardFile",MYOBCardFile},
                {"DeliveryCharges",DeliveryCharges},
                {"ArtWorkCharges",ArtWorkCharges},
                {"OtherCharges",OtherCharges},
                {"OtherChargesDescription",OtherChargesDescription},
                {"IsOtherDelivery",IsOtherDelivery},
                {"OtherDeliveryDescription",OtherDeliveryDescription},
                {"BillingAddress",BillingAddress},
                {"DespatchToAddress",DespatchToAddress},
                {"IsGSTExcluded",IsGSTExcluded}
          };
        }
        public IEnumerable<OrderDetail> OrderDetailsWhereThisIsOrder()
        {
            return _Context.Where<OrderDetail>(new Dictionary<string, object> { { "Order", ID } });
        }

        #endregion
    }
}
