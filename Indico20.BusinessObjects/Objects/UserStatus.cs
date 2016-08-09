using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Objects
{
    public class UserStatus : IEntity
    {
        private UnitOfWork _unitOfWork;

        public UserStatus() { }

        public UserStatus(UnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public int ID { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }


        public void Add(UnitOfWork unit = null)
        {
            if (_unitOfWork == null && unit != null)
                _unitOfWork = unit;
            if (_unitOfWork != null)
                _unitOfWork.UserStatus.Add(this);

        }

        public void Delete(UnitOfWork unit = null)
        {
            if (_unitOfWork == null && unit != null)
                _unitOfWork = unit;
            if (_unitOfWork != null)
                _unitOfWork.UserStatus.Remove(ID);
        }

        public void Update(UnitOfWork unit = null)
        {
            if (_unitOfWork == null && unit != null)
                _unitOfWork = unit;
            if (_unitOfWork != null)
                _unitOfWork.UserStatus.Update(this);
        }
    }
}
