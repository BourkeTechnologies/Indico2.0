using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Objects.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Indico20.BusinessObjects.Objects.Implementation
{
    public class OrderDetail : IEntity
    {

        #region Fields

        private int _orderType;
        private int? _visualLayout;
        private int _pattern;
        private int _fabricCode;
        private string _visualLayoutNotes;
        private string _nameAndNumbersFilePath;
        private int _order;
        private int? _status;
        private DateTime _shipmentDate;
        private DateTime _sheduledDate;
        private bool _isRepeat;
        private DateTime _requestedDate;
        private decimal? _editedPrice;
        private string _editedPriceRemarks;
        private int? _reservation;
        private bool? _photoApprovalReq;
        private bool? _isRequiredNamesNumbers;
        private bool _isBrandingKit;
        private bool _isLockerPatch;
        private int? _artWork;
        private int? _label;
        private int? _paymentMethod;
        private int? _shipmentMode;
        private bool? _isWeeklyShipment;
        private bool? _isCourierDelivery;
        private int? _despatchTo;
        private string _promoCode;
        private string _factoryInstructions;
        private decimal _surcharge;
        private decimal? _distributorSurcharge;

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
        public int OrderType { get { return _orderType; } set { _orderType = value; NotifyPropertyChanged("OrderType"); } }
        public int? VisualLayout { get { return _visualLayout; } set { _visualLayout = value; NotifyPropertyChanged("VisualLayout"); } }
        public int Pattern { get { return _pattern; } set { _pattern = value; NotifyPropertyChanged("Pattern"); } }
        public int FabricCode { get { return _fabricCode; } set { _fabricCode = value; NotifyPropertyChanged("FabricCode"); } }
        public string VisualLayoutNotes { get { return _visualLayoutNotes; } set { _visualLayoutNotes = value; NotifyPropertyChanged("VisualLayoutNotes"); } }
        public string NameAndNumbersFilePath { get { return _nameAndNumbersFilePath; } set { _nameAndNumbersFilePath = value; NotifyPropertyChanged("NameAndNumbersFilePath"); } }
        public int Order { get { return _order; } set { _order = value; NotifyPropertyChanged("Order"); } }
        public int? Status { get { return _status; } set { _status = value; NotifyPropertyChanged("Status"); } }
        public DateTime ShipmentDate { get { return _shipmentDate; } set { _shipmentDate = value; NotifyPropertyChanged("ShipmentDate"); } }
        public DateTime SheduledDate { get { return _sheduledDate; } set { _sheduledDate = value; NotifyPropertyChanged("SheduledDate"); } }
        public bool IsRepeat { get { return _isRepeat; } set { _isRepeat = value; NotifyPropertyChanged("IsRepeat"); } }
        public DateTime RequestedDate { get { return _requestedDate; } set { _requestedDate = value; NotifyPropertyChanged("RequestedDate"); } }
        public decimal? EditedPrice { get { return _editedPrice; } set { _editedPrice = value; NotifyPropertyChanged("EditedPrice"); } }
        public string EditedPriceRemarks { get { return _editedPriceRemarks; } set { _editedPriceRemarks = value; NotifyPropertyChanged("EditedPriceRemarks"); } }
        public int? Reservation { get { return _reservation; } set { _reservation = value; NotifyPropertyChanged("Reservation"); } }
        public bool? PhotoApprovalReq { get { return _photoApprovalReq; } set { _photoApprovalReq = value; NotifyPropertyChanged("PhotoApprovalReq"); } }
        public bool? IsRequiredNamesNumbers { get { return _isRequiredNamesNumbers; } set { _isRequiredNamesNumbers = value; NotifyPropertyChanged("IsRequiredNamesNumbers"); } }
        public bool IsBrandingKit { get { return _isBrandingKit; } set { _isBrandingKit = value; NotifyPropertyChanged("IsBrandingKit"); } }
        public bool IsLockerPatch { get { return _isLockerPatch; } set { _isLockerPatch = value; NotifyPropertyChanged("IsLockerPatch"); } }
        public int? ArtWork { get { return _artWork; } set { _artWork = value; NotifyPropertyChanged("ArtWork"); } }
        public int? Label { get { return _label; } set { _label = value; NotifyPropertyChanged("Label"); } }
        public int? PaymentMethod { get { return _paymentMethod; } set { _paymentMethod = value; NotifyPropertyChanged("PaymentMethod"); } }
        public int? ShipmentMode { get { return _shipmentMode; } set { _shipmentMode = value; NotifyPropertyChanged("ShipmentMode"); } }
        public bool? IsWeeklyShipment { get { return _isWeeklyShipment; } set { _isWeeklyShipment = value; NotifyPropertyChanged("IsWeeklyShipment"); } }
        public bool? IsCourierDelivery { get { return _isCourierDelivery; } set { _isCourierDelivery = value; NotifyPropertyChanged("IsCourierDelivery"); } }
        public int? DespatchTo { get { return _despatchTo; } set { _despatchTo = value; NotifyPropertyChanged("DespatchTo"); } }
        public string PromoCode { get { return _promoCode; } set { _promoCode = value; NotifyPropertyChanged("PromoCode"); } }
        public string FactoryInstructions { get { return _factoryInstructions; } set { _factoryInstructions = value; NotifyPropertyChanged("FactoryInstructions"); } }
        public decimal Surcharge { get { return _surcharge; } set { _surcharge = value; NotifyPropertyChanged("Surcharge"); } }
        public decimal? DistributorSurcharge { get { return _distributorSurcharge; } set { _distributorSurcharge = value; NotifyPropertyChanged("DistributorSurcharge"); } }

        #endregion


        #region Methods

        public Dictionary<string, object> GetColumnValueMapping()
        {
            return new Dictionary<string, object>()
            {
                {"OrderType",OrderType},
                {"VisualLayout",VisualLayout},
                {"Pattern",Pattern},
                {"FabricCode",FabricCode},
                {"VisualLayoutNotes",VisualLayoutNotes},
                {"NameAndNumbersFilePath",NameAndNumbersFilePath},
                {"Order",Order},
                {"Status",Status},
                {"ShipmentDate",ShipmentDate},
                {"SheduledDate",SheduledDate},
                {"IsRepeat",IsRepeat},
                {"RequestedDate",RequestedDate},
                {"EditedPrice",EditedPrice},
                {"EditedPriceRemarks",EditedPriceRemarks},
                {"Reservation",Reservation},
                {"PhotoApprovalReq",PhotoApprovalReq},
                {"IsRequiredNamesNumbers",IsRequiredNamesNumbers},
                {"IsBrandingKit",IsBrandingKit},
                {"IsLockerPatch",IsLockerPatch},
                {"ArtWork",ArtWork},
                {"Label",Label},
                {"PaymentMethod",PaymentMethod},
                {"ShipmentMode",ShipmentMode},
                {"IsWeeklyShipment",IsWeeklyShipment},
                {"IsCourierDelivery",IsCourierDelivery},
                {"DespatchTo",DespatchTo},
                {"PromoCode",PromoCode},
                {"FactoryInstructions",FactoryInstructions},
                {"Surcharge",Surcharge},
                {"DistributorSurcharge",DistributorSurcharge}
            };
        }

        #endregion

    }

}
